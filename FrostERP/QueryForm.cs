using System;
using System.Data;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace FrostERP.Inventory
{
    public partial class QueryForm : Form
    {
        private string connectionString = @"Server=db-frosterp.cluster-c1k0aogigapf.us-east-2.rds.amazonaws.com;Port=3306;Database=frosterp_db;Uid=admin;Pwd=iEtude123!;";

        public QueryForm()
        {
            InitializeComponent();
            SetupCustomControls();
        }

        private void SetupCustomControls()
        {
            this.Text = "FrostERP → Inventory Query & Lookup";

            // Populate Query Types
            cmbQueryType.Items.AddRange(new string[]
            {
                "Product Information",
                "Stock Level",
                "Product by Category",
                "Low Stock Items"
            });
            cmbQueryType.SelectedIndex = 0;

            // Load Warehouses
            LoadWarehouses();

            btnExecute.Click += btnExecute_Click;
            btnClear.Click += btnClear_Click;

            cmbWarehouse.SelectedIndex = 0;
        }

        private void LoadWarehouses()
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    string sql = @"SELECT DISTINCT WarehouseLocation 
                                   FROM Inventory 
                                   WHERE WarehouseLocation IS NOT NULL 
                                   ORDER BY WarehouseLocation";

                    using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        cmbWarehouse.Items.Clear();
                        cmbWarehouse.Items.Add("All Warehouses");

                        while (reader.Read())
                        {
                            string wh = reader["WarehouseLocation"].ToString().Trim();
                            if (!string.IsNullOrEmpty(wh))
                                cmbWarehouse.Items.Add(wh);
                        }
                    }
                }
            }
            catch
            {
                cmbWarehouse.Items.Add("All Warehouses");
            }
            cmbWarehouse.SelectedIndex = 0;
        }

        private void btnExecute_Click(object sender, EventArgs e)
        {
            ExecuteQuery(cmbQueryType.Text, txtSearchValue.Text, cmbWarehouse.Text);
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtSearchValue.Clear();
            cmbQueryType.SelectedIndex = 0;
            cmbWarehouse.SelectedIndex = 0;
            dgvResults.DataSource = null;
            lblStatus.Text = "Ready";
            lblStatus.ForeColor = System.Drawing.Color.Green;
        }

        private void ExecuteQuery(string queryType, string searchValue, string warehouseFilter)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();

                    string sql = "";

                    switch (queryType)
                    {
                        case "Product Information":
                            sql = @"SELECT
                                        ProductID,
                                        SKU,
                                        ProductName,
                                        Color,
                                        Width,
                                        Length,
                                        Height,
                                        Weight,
                                        Grade,
                                        SellingPrice,
                                        IsDangerousGoods
                                     FROM Products
                                     WHERE (SKU LIKE @search OR ProductName LIKE @search)";
                            break;

                        case "Stock Level":
                            sql = @"SELECT 
                                        p.ProductID,
                                        p.SKU,
                                        p.ProductName,
                                        i.QuantityInStock,
                                        i.WarehouseLocation,
                                        (i.QuantityInStock - COALESCE(p.ReorderLevel, 0)) as StockStatus
                                    FROM Products p 
                                    INNER JOIN Inventory i ON p.ProductID = i.ProductID 
                                    WHERE (p.SKU LIKE @search OR p.ProductName LIKE @search)";
                            break;

                        case "Product by Category":
                            sql = @"SELECT 
                                        p.ProductID,
                                        p.SKU,
                                        p.ProductName,
                                        c.CategoryName,
                                        p.SellingPrice,
                                        i.QuantityInStock,
                                        i.WarehouseLocation
                                    FROM Products p 
                                    INNER JOIN Categories c ON p.CategoryID = c.CategoryID
                                    INNER JOIN Inventory i ON p.ProductID = i.ProductID
                                    WHERE (p.SKU LIKE @search OR p.ProductName LIKE @search)
                                      AND c.CategoryName LIKE @search";
                            break;

                        case "Low Stock Items":
                            sql = @"SELECT 
                                        p.ProductID,
                                        p.SKU,
                                        p.ProductName,
                                        i.QuantityInStock,
                                        p.ReorderLevel,
                                        (p.ReorderLevel - i.QuantityInStock) as Shortage,
                                        i.WarehouseLocation
                                    FROM Products p 
                                    INNER JOIN Inventory i ON p.ProductID = i.ProductID 
                                    WHERE i.QuantityInStock < COALESCE(p.ReorderLevel, 0)
                                      AND (p.SKU LIKE @search OR p.ProductName LIKE @search)";
                            break;
                    }

                    // Apply Warehouse Filter (if not "All Warehouses")
                    if (!string.IsNullOrWhiteSpace(warehouseFilter) && warehouseFilter != "All Warehouses")
                    {
                        sql += " AND i.WarehouseLocation = @warehouse";
                    }

                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@search", "%" + (string.IsNullOrWhiteSpace(searchValue) ? "" : searchValue) + "%");

                    if (!string.IsNullOrWhiteSpace(warehouseFilter) && warehouseFilter != "All Warehouses")
                    {
                        cmd.Parameters.AddWithValue("@warehouse", warehouseFilter);
                    }

                    MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                    DataTable table = new DataTable();
                    adapter.Fill(table);

                    dgvResults.DataSource = table;

                    lblStatus.Text = $"Query completed successfully. {table.Rows.Count} records found.";
                    lblStatus.ForeColor = System.Drawing.Color.Green;
                }
            }
            catch (Exception ex)
            {
                lblStatus.Text = "Error: " + ex.Message;
                lblStatus.ForeColor = System.Drawing.Color.Red;
                MessageBox.Show("Database error: " + ex.Message, "ERP MySQL Query Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}