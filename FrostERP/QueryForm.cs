using System;
using System.Data;
using MySql.Data.MySqlClient;
using System.Windows.Forms;
using static System.ComponentModel.Design.ObjectSelectorEditor;
using System.Runtime.Serialization;

namespace FrostERP.Inventory
{
    public partial class QueryForm : Form
    {
        // Aurora MySQL Connection String
        private string connectionString = @"Server=db-frosterp.cluster-c1k0aogigapf.us-east-2.rds.amazonaws.com;Port=3306;Database=frosterp_db;Uid=admin;Pwd=iEtude123!;";

        public QueryForm()
        {
            InitializeComponent();
            SetupCustomControls();
        }

        private void SetupCustomControls()
        {
            this.Text = "ERP - MySQL Query & Lookup Module (Aurora)";

            // Populate ComboBox with query types
            cmbQueryType.Items.AddRange(new string[]
            {
                "Product Information",
                "Stock Level",
                "Product by Category",
                "Low Stock Items"
            });
            cmbQueryType.SelectedIndex = 0;

            // Button Event
            btnExecute.Click += btnExecute_Click;
        }

        private void btnExecute_Click(object sender, EventArgs e)
        {
            ExecuteQuery(cmbQueryType.Text, txtSearchValue.Text);
        }

        private void ExecuteQuery(string queryType, string searchValue)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
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
                                     WHERE SKU LIKE @search OR ProductName LIKE @search";
                            break;

                        case "Stock Level":
                            sql = @"SELECT p.ProductID, p.ProductName, i.QuantityInStock, i.WarehouseLocation, 
                                           (i.QuantityInStock - p.ReorderLevel) as StockStatus
                                    FROM Products p 
                                    INNER JOIN Inventory i ON p.ProductID = i.ProductID 
                                    WHERE p.ProductID = @Search OR p.ProductName LIKE @SearchLike";
                            break;

                        case "Product by Category":
                            sql = @"SELECT p.ProductID, p.ProductName, p.UnitPrice, i.QuantityInStock 
                                    FROM Products p 
                                    INNER JOIN Categories c ON p.CategoryID = c.CategoryID
                                    INNER JOIN Inventory i ON p.ProductID = i.ProductID
                                    WHERE c.CategoryName = @Search";
                            break;

                        case "Low Stock Items":
                            sql = @"SELECT p.ProductID, p.ProductName, i.QuantityInStock, p.ReorderLevel,
                                           (p.ReorderLevel - i.QuantityInStock) as Shortage
                                    FROM Products p 
                                    INNER JOIN Inventory i ON p.ProductID = i.ProductID 
                                    WHERE i.QuantityInStock < p.ReorderLevel 
                                    ORDER BY Shortage DESC";
                            break;
                    }

                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@search", "%" + searchValue + "%");

                    MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                    DataTable table = new DataTable();
                    adapter.Fill(table);

                    dgvResults.DataSource = table;
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