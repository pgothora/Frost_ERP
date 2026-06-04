namespace FrostERP.Inventory
{
    partial class QueryForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        private Label lblSearchType;
        private ComboBox cmbQueryType;
        private Label lblSearchValue;
        private TextBox txtSearchValue;
        private Button btnExecute;
        private DataGridView dgvResults;
        private Label lblStatus;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.lblSearchType = new System.Windows.Forms.Label();
            this.cmbQueryType = new System.Windows.Forms.ComboBox();
            this.lblSearchValue = new System.Windows.Forms.Label();
            this.txtSearchValue = new System.Windows.Forms.TextBox();
            this.btnExecute = new System.Windows.Forms.Button();
            this.dgvResults = new System.Windows.Forms.DataGridView();
            this.lblStatus = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvResults)).BeginInit();
            this.SuspendLayout();

            // lblSearchType
            this.lblSearchType.AutoSize = true;
            this.lblSearchType.Location = new System.Drawing.Point(20, 20);
            this.lblSearchType.Size = new System.Drawing.Size(78, 13);
            this.lblSearchType.Text = "Query Type:";

            // cmbQueryType
            this.cmbQueryType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbQueryType.Location = new System.Drawing.Point(120, 18);
            this.cmbQueryType.Size = new System.Drawing.Size(250, 21);

            // lblSearchValue
            this.lblSearchValue.AutoSize = true;
            this.lblSearchValue.Location = new System.Drawing.Point(20, 60);
            this.lblSearchValue.Size = new System.Drawing.Size(85, 13);
            this.lblSearchValue.Text = "Search Value:";

            // txtSearchValue
            this.txtSearchValue.Location = new System.Drawing.Point(120, 58);
            this.txtSearchValue.Size = new System.Drawing.Size(250, 20);
            this.txtSearchValue.PlaceholderText = "Product ID / Name / Category";

            // btnExecute
            this.btnExecute.Location = new System.Drawing.Point(390, 55);
            this.btnExecute.Size = new System.Drawing.Size(150, 30);
            this.btnExecute.Text = "Execute Query";
            this.btnExecute.BackColor = System.Drawing.Color.SteelBlue;
            this.btnExecute.ForeColor = System.Drawing.Color.White;
            this.btnExecute.UseVisualStyleBackColor = false;

            // dgvResults
            this.dgvResults.Location = new System.Drawing.Point(20, 110);
            this.dgvResults.Size = new System.Drawing.Size(940, 480);
            this.dgvResults.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvResults.ReadOnly = true;
            this.dgvResults.AllowUserToAddRows = false;
            this.dgvResults.AllowUserToDeleteRows = false;

            // lblStatus
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(20, 610);
            this.lblStatus.Size = new System.Drawing.Size(46, 13);
            this.lblStatus.Text = "Ready";
            this.lblStatus.ForeColor = System.Drawing.Color.Green;

            // QueryForm
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(980, 650);
            this.Controls.Add(this.lblSearchType);
            this.Controls.Add(this.cmbQueryType);
            this.Controls.Add(this.lblSearchValue);
            this.Controls.Add(this.txtSearchValue);
            this.Controls.Add(this.btnExecute);
            this.Controls.Add(this.dgvResults);
            this.Controls.Add(this.lblStatus);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ERP - MySQL Query Module";
            ((System.ComponentModel.ISupportInitialize)(this.dgvResults)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion
    }
}