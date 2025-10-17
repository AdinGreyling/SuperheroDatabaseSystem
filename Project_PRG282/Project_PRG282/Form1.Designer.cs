namespace Project_PRG282
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lblHeroID = new Label();
            lblName = new Label();
            lblAge = new Label();
            lblSuperpower = new Label();
            lblExamScore = new Label();
            btnAdd = new Button();
            btnUpdate = new Button();
            btnDelete = new Button();
            btnViewAll = new Button();
            btnGenerate = new Button();
            dgvSuperheroes = new DataGridView();
            txtAge = new TextBox();
            txtExamScore = new TextBox();
            txtHeroID = new TextBox();
            txtSuperpower = new TextBox();
            txtName = new TextBox();
            txtReport = new TextBox();
            lblCOntrols = new Label();
            lblDataGrid = new Label();
            lblReport = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvSuperheroes).BeginInit();
            SuspendLayout();
            // 
            // lblHeroID
            // 
            lblHeroID.AutoSize = true;
            lblHeroID.Location = new Point(12, 208);
            lblHeroID.Name = "lblHeroID";
            lblHeroID.Size = new Size(47, 15);
            lblHeroID.TabIndex = 0;
            lblHeroID.Text = "Hero ID";
            // 
            // lblName
            // 
            lblName.AutoSize = true;
            lblName.Location = new Point(12, 236);
            lblName.Name = "lblName";
            lblName.Size = new Size(39, 15);
            lblName.TabIndex = 1;
            lblName.Text = "Name";
            // 
            // lblAge
            // 
            lblAge.AutoSize = true;
            lblAge.Location = new Point(12, 262);
            lblAge.Name = "lblAge";
            lblAge.Size = new Size(28, 15);
            lblAge.TabIndex = 2;
            lblAge.Text = "Age";
            // 
            // lblSuperpower
            // 
            lblSuperpower.AutoSize = true;
            lblSuperpower.Location = new Point(12, 294);
            lblSuperpower.Name = "lblSuperpower";
            lblSuperpower.Size = new Size(70, 15);
            lblSuperpower.TabIndex = 3;
            lblSuperpower.Text = "Superpower";
            // 
            // lblExamScore
            // 
            lblExamScore.AutoSize = true;
            lblExamScore.Location = new Point(12, 324);
            lblExamScore.Name = "lblExamScore";
            lblExamScore.Size = new Size(67, 15);
            lblExamScore.TabIndex = 4;
            lblExamScore.Text = "Exam Score";
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(95, 413);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(115, 25);
            btnAdd.TabIndex = 5;
            btnAdd.Text = "Add Superhero";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // btnUpdate
            // 
            btnUpdate.Location = new Point(216, 413);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(115, 25);
            btnUpdate.TabIndex = 6;
            btnUpdate.Text = "Update Superhero";
            btnUpdate.UseVisualStyleBackColor = true;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(337, 413);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(115, 25);
            btnDelete.TabIndex = 7;
            btnDelete.Text = "Delete Selected";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnViewAll
            // 
            btnViewAll.Location = new Point(458, 414);
            btnViewAll.Name = "btnViewAll";
            btnViewAll.Size = new Size(115, 25);
            btnViewAll.TabIndex = 8;
            btnViewAll.Text = "View All";
            btnViewAll.UseVisualStyleBackColor = true;
            btnViewAll.Click += btnViewAll_Click;
            // 
            // btnGenerate
            // 
            btnGenerate.Location = new Point(579, 416);
            btnGenerate.Name = "btnGenerate";
            btnGenerate.Size = new Size(115, 23);
            btnGenerate.TabIndex = 9;
            btnGenerate.Text = "Generate Report";
            btnGenerate.UseVisualStyleBackColor = true;
            btnGenerate.Click += btnGenerate_Click;
            // 
            // dgvSuperheroes
            // 
            dgvSuperheroes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvSuperheroes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvSuperheroes.Location = new Point(12, 28);
            dgvSuperheroes.Name = "dgvSuperheroes";
            dgvSuperheroes.Size = new Size(488, 168);
            dgvSuperheroes.TabIndex = 10;
            dgvSuperheroes.CellClick += dgvSuperheroes_CellClick;
            // 
            // txtAge
            // 
            txtAge.Location = new Point(95, 262);
            txtAge.Name = "txtAge";
            txtAge.Size = new Size(100, 23);
            txtAge.TabIndex = 11;
            // 
            // txtExamScore
            // 
            txtExamScore.Location = new Point(95, 320);
            txtExamScore.Name = "txtExamScore";
            txtExamScore.Size = new Size(100, 23);
            txtExamScore.TabIndex = 12;
            // 
            // txtHeroID
            // 
            txtHeroID.Location = new Point(95, 205);
            txtHeroID.Name = "txtHeroID";
            txtHeroID.Size = new Size(100, 23);
            txtHeroID.TabIndex = 13;
            // 
            // txtSuperpower
            // 
            txtSuperpower.Location = new Point(95, 290);
            txtSuperpower.Name = "txtSuperpower";
            txtSuperpower.Size = new Size(100, 23);
            txtSuperpower.TabIndex = 14;
            // 
            // txtName
            // 
            txtName.Location = new Point(95, 234);
            txtName.Name = "txtName";
            txtName.Size = new Size(100, 23);
            txtName.TabIndex = 15;
            // 
            // txtReport
            // 
            txtReport.Location = new Point(522, 28);
            txtReport.Multiline = true;
            txtReport.Name = "txtReport";
            txtReport.ReadOnly = true;
            txtReport.Size = new Size(256, 257);
            txtReport.TabIndex = 16;
            // 
            // lblCOntrols
            // 
            lblCOntrols.AutoSize = true;
            lblCOntrols.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblCOntrols.Location = new Point(365, 368);
            lblCOntrols.Name = "lblCOntrols";
            lblCOntrols.Size = new Size(53, 15);
            lblCOntrols.TabIndex = 17;
            lblCOntrols.Text = "Controls";
            // 
            // lblDataGrid
            // 
            lblDataGrid.AutoSize = true;
            lblDataGrid.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblDataGrid.Location = new Point(229, 10);
            lblDataGrid.Name = "lblDataGrid";
            lblDataGrid.Size = new Size(60, 15);
            lblDataGrid.TabIndex = 18;
            lblDataGrid.Text = "Data Grid";
            // 
            // lblReport
            // 
            lblReport.AutoSize = true;
            lblReport.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblReport.Location = new Point(598, 10);
            lblReport.Name = "lblReport";
            lblReport.Size = new Size(102, 15);
            lblReport.TabIndex = 19;
            lblReport.Text = "Summary Report";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(lblReport);
            Controls.Add(lblDataGrid);
            Controls.Add(lblCOntrols);
            Controls.Add(txtReport);
            Controls.Add(txtName);
            Controls.Add(txtSuperpower);
            Controls.Add(txtHeroID);
            Controls.Add(txtExamScore);
            Controls.Add(txtAge);
            Controls.Add(dgvSuperheroes);
            Controls.Add(btnGenerate);
            Controls.Add(btnViewAll);
            Controls.Add(btnDelete);
            Controls.Add(btnUpdate);
            Controls.Add(btnAdd);
            Controls.Add(lblExamScore);
            Controls.Add(lblSuperpower);
            Controls.Add(lblAge);
            Controls.Add(lblName);
            Controls.Add(lblHeroID);
            Name = "Form1";
            Text = "Superhero Form";
            ((System.ComponentModel.ISupportInitialize)dgvSuperheroes).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblHeroID;
        private Label lblName;
        private Label lblAge;
        private Label lblSuperpower;
        private Label lblExamScore;
        private Button btnAdd;
        private Button btnUpdate;
        private Button btnDelete;
        private Button btnViewAll;
        private Button btnGenerate;
        private DataGridView dgvSuperheroes;
        private TextBox txtAge;
        private TextBox txtExamScore;
        private TextBox txtHeroID;
        private TextBox txtSuperpower;
        private TextBox txtName;
        private TextBox txtReport;
        private Label lblCOntrols;
        private Label lblDataGrid;
        private Label lblReport;
    }
}
