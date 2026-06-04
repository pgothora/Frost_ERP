namespace FrostERP.Inventory
{
    partial class QueryForm
    {
        private System.ComponentModel.IContainer components = null;

        private GroupBox grpSearch;
        private Label lblQueryType;
        private ComboBox cmbQueryType;
        private Label lblSearchValue;
        private TextBox txtSearchValue;
        private Label lblWarehouse;
        private ComboBox cmbWarehouse;
        private Button btnExecute;
        private Button btnClear;
        private DataGridView dgvResults;
        private Label lblStatus;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.grpSearch = new System.Windows.Forms.GroupBox();
            this.lblQueryType = new System.Windows.Forms.Label();
            this.cmbQueryType = new System.Windows.Forms.ComboBox();
            this.lblSearchValue = new System.Windows.Forms.Label();
            this.txtSearchValue = new System.Windows.Forms.TextBox();
            this.lblWarehouse = new System.Windows.Forms.Label();
            this.cmbWarehouse = new System.Windows.Forms.ComboBox();
            this.btnExecute = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.dgvResults = new System.Windows.Forms.DataGridView();
            this.lblStatus = new System.Windows.Forms.Label();

            this.grpSearch.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvResults)).BeginInit();
            this.SuspendLayout();

            // === SEARCH GROUP BOX ===
            this.grpSearch.Controls.Add(this.lblQueryType);
            this.grpSearch.Controls.Add(this.cmbQueryType);
            this.grpSearch.Controls.Add(this.lblSearchValue);
            this.grpSearch.Controls.Add(this.txtSearchValue);
            this.grpSearch.Controls.Add(this.lblWarehouse);
            this.grpSearch.Controls.Add(this.cmbWarehouse);
            this.grpSearch.Controls.Add(this.btnExecute);
            this.grpSearch.Controls.Add(this.btnClear);
            this.grpSearch.Location = new System.Drawing.Point(15, 12);
            this.grpSearch.Size = new System.Drawing.Size(950, 135);
            this.grpSearch.Text = "Search Criteria";
            this.grpSearch.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.grpSearch.ForeColor = System.Drawing.Color.DarkSlateGray;

            // Labels & Controls inside GroupBox
            this.lblQueryType.AutoSize = true;
            this.lblQueryType.Location = new System.Drawing.Point(20, 28);
            this.lblQueryType.Text = "Query Type:";

            this.cmbQueryType.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmbQueryType.Location = new System.Drawing.Point(130, 25);
            this.cmbQueryType.Size = new System.Drawing.Size(280, 25);
            this.cmbQueryType.Font = new System.Drawing.Font("Segoe UI", 9.5F);

            this.lblSearchValue.AutoSize = true;
            this.lblSearchValue.Location = new System.Drawing.Point(20, 62);
            this.lblSearchValue.Text = "Search (SKU / Name):";

            this.txtSearchValue.Location = new System.Drawing.Point(130, 59);
            this.txtSearchValue.Size = new System.Drawing.Size(280, 25);
            this.txtSearchValue.Font = new System.Drawing.Font("Segoe UI", 9.5F);

            this.lblWarehouse.AutoSize = true;
            this.lblWarehouse.Location = new System.Drawing.Point(20, 96);
            this.lblWarehouse.Text = "Warehouse:";

            this.cmbWarehouse.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmbWarehouse.Location = new System.Drawing.Point(130, 93);
            this.cmbWarehouse.Size = new System.Drawing.Size(280, 25);
            this.cmbWarehouse.Font = new System.Drawing.Font("Segoe UI", 9.5F);

            // Buttons
            this.btnExecute.Location = new System.Drawing.Point(430, 25);
            this.btnExecute.Size = new System.Drawing.Size(140, 40);
            this.btnExecute.Text = "🔍 Execute Query";
            this.btnExecute.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnExecute.BackColor = System.Drawing.Color.FromArgb(0, 122, 204);
            this.btnExecute.ForeColor = System.Drawing.Color.White;
            this.btnExecute.FlatStyle = FlatStyle.Flat;

            this.btnClear.Location = new System.Drawing.Point(430, 80);
            this.btnClear.Size = new System.Drawing.Size(140, 35);
            this.btnClear.Text = "🗑 Clear";
            this.btnClear.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.btnClear.BackColor = System.Drawing.Color.LightGray;

            // DataGridView
            this.dgvResults.Location = new System.Drawing.Point(15, 160);
            this.dgvResults.Size = new System.Drawing.Size(950, 420);
            this.dgvResults.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvResults.ReadOnly = true;
            this.dgvResults.AllowUserToAddRows = false;
            this.dgvResults.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(245, 245, 245);
            this.dgvResults.Font = new System.Drawing.Font("Segoe UI", 9.25F);
            this.dgvResults.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.dgvResults.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(0, 122, 204);
            this.dgvResults.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.White;
            this.dgvResults.EnableHeadersVisualStyles = false;

            // Status
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(20, 595);
            this.lblStatus.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblStatus.ForeColor = System.Drawing.Color.Green;
            this.lblStatus.Text = "Ready";

            // Form
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.ClientSize = new System.Drawing.Size(980, 630);
            this.Controls.Add(this.grpSearch);
            this.Controls.Add(this.dgvResults);
            this.Controls.Add(this.lblStatus);
            this.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = System.Drawing.Color.WhiteSmoke;

            this.grpSearch.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvResults)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}