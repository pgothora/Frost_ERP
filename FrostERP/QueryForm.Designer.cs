namespace FrostERP.Inventory
{
    partial class QueryForm
    {
        private System.ComponentModel.IContainer components = null;

        private GroupBox grpSearch;
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            grpSearch = new GroupBox();
            lblSearchValue = new Label();
            txtSearchValue = new TextBox();
            lblWarehouse = new Label();
            cmbWarehouse = new ComboBox();
            btnExecute = new Button();
            btnClear = new Button();
            dgvResults = new DataGridView();
            lblStatus = new Label();
            grpSearch.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvResults).BeginInit();
            SuspendLayout();
            // 
            // grpSearch
            // 
            grpSearch.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            grpSearch.Controls.Add(lblSearchValue);
            grpSearch.Controls.Add(txtSearchValue);
            grpSearch.Controls.Add(lblWarehouse);
            grpSearch.Controls.Add(cmbWarehouse);
            grpSearch.Controls.Add(btnExecute);
            grpSearch.Controls.Add(btnClear);
            grpSearch.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            grpSearch.ForeColor = Color.DarkSlateGray;
            grpSearch.Location = new Point(15, 12);
            grpSearch.Name = "grpSearch";
            grpSearch.Size = new Size(950, 135);
            grpSearch.TabIndex = 0;
            grpSearch.TabStop = false;
            grpSearch.Text = "Search Criteria";
            // 
            // lblSearchValue
            // 
            lblSearchValue.AutoSize = true;
            lblSearchValue.Location = new Point(20, 35);
            lblSearchValue.Name = "lblSearchValue";
            lblSearchValue.Size = new Size(173, 21);
            lblSearchValue.TabIndex = 2;
            lblSearchValue.Text = "Search (SKU / Name):";
            // 
            // txtSearchValue
            // 
            txtSearchValue.Font = new Font("Segoe UI", 9.5F);
            txtSearchValue.Location = new Point(199, 30);
            txtSearchValue.Name = "txtSearchValue";
            txtSearchValue.Size = new Size(211, 29);
            txtSearchValue.TabIndex = 3;
            // 
            // lblWarehouse
            // 
            lblWarehouse.AutoSize = true;
            lblWarehouse.Location = new Point(20, 87);
            lblWarehouse.Name = "lblWarehouse";
            lblWarehouse.Size = new Size(99, 21);
            lblWarehouse.TabIndex = 4;
            lblWarehouse.Text = "Warehouse:";
            // 
            // cmbWarehouse
            // 
            cmbWarehouse.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbWarehouse.Font = new Font("Segoe UI", 9.5F);
            cmbWarehouse.Location = new Point(130, 84);
            cmbWarehouse.Name = "cmbWarehouse";
            cmbWarehouse.Size = new Size(280, 29);
            cmbWarehouse.TabIndex = 5;
            // 
            // btnExecute
            // 
            btnExecute.BackColor = Color.FromArgb(0, 122, 204);
            btnExecute.FlatStyle = FlatStyle.Flat;
            btnExecute.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnExecute.ForeColor = Color.White;
            btnExecute.Location = new Point(430, 25);
            btnExecute.Name = "btnExecute";
            btnExecute.Size = new Size(140, 40);
            btnExecute.TabIndex = 6;
            btnExecute.Text = "🔍 Execute Query";
            btnExecute.UseVisualStyleBackColor = false;
            // 
            // btnClear
            // 
            btnClear.BackColor = Color.LightGray;
            btnClear.Font = new Font("Segoe UI", 9.5F);
            btnClear.Location = new Point(430, 80);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(140, 35);
            btnClear.TabIndex = 7;
            btnClear.Text = "🗑 Clear";
            btnClear.UseVisualStyleBackColor = false;
            // 
            // dgvResults
            // 
            dgvResults.AllowUserToAddRows = false;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(245, 245, 245);
            dgvResults.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dgvResults.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvResults.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(0, 122, 204);
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = Color.White;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dgvResults.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dgvResults.ColumnHeadersHeight = 29;
            dgvResults.EnableHeadersVisualStyles = false;
            dgvResults.Font = new Font("Segoe UI", 9.25F);
            dgvResults.Location = new Point(15, 160);
            dgvResults.Name = "dgvResults";
            dgvResults.ReadOnly = true;
            dgvResults.RowHeadersWidth = 51;
            dgvResults.Size = new Size(950, 420);
            dgvResults.TabIndex = 1;
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblStatus.ForeColor = Color.Green;
            lblStatus.Location = new Point(20, 595);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(57, 21);
            lblStatus.TabIndex = 2;
            lblStatus.Text = "Ready";
            // 
            // QueryForm
            // 
            BackColor = Color.WhiteSmoke;
            ClientSize = new Size(980, 630);
            Controls.Add(grpSearch);
            Controls.Add(dgvResults);
            Controls.Add(lblStatus);
            Font = new Font("Segoe UI", 9.5F);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "QueryForm";
            StartPosition = FormStartPosition.CenterScreen;
            grpSearch.ResumeLayout(false);
            grpSearch.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvResults).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
    }
}