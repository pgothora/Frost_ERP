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
                    string sql = @"SELECT WarehouseName
                                   FROM Warehouses";

                    using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        cmbWarehouse.Items.Clear();
                        cmbWarehouse.Items.Add("All Warehouses");

                        while (reader.Read())
                        {
                            string wh = reader["WarehouseName"].ToString().Trim();
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
            ExecuteQuery(txtSearchValue.Text, cmbWarehouse.Text);
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtSearchValue.Clear();
            cmbWarehouse.SelectedIndex = 0;
            dgvResults.DataSource = null;
            lblStatus.Text = "Ready";
            lblStatus.ForeColor = System.Drawing.Color.Green;
        }

        private void ExecuteQuery(string searchValue, string warehouseFilter)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();

                    string sql = "";

                    sql = @"SELECT
                            p.SKU,
                            p.ProductName,
                            p.Color,
                            p.Grade,
                            i.Quantity,
                            p.Width,
                            p.Length,
                            p.Height,
                            p.Weight,
                            p.IsDangerousGoods
                            FROM InventoryStock i
                            INNER JOIN Products p ON p.ProductID = i.ProductID
                            WHERE i.WarehouseID = 1
                            AND (p.SKU LIKE @search OR p.ProductName LIKE @search)";

                    // Apply Warehouse Filter (if not "All Warehouses")
                    if (!string.IsNullOrWhiteSpace(warehouseFilter) && warehouseFilter != "All Warehouses")
                    {
                        sql += " AND i.WarehouseLocation = @warehouse";
                    }

                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@search", "%" + (string.IsNullOrWhiteSpace(searchValue) ? "" : searchValue));

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