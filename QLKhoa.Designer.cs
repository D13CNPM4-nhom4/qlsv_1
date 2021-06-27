namespace QLSV
{
    partial class QLKhoa
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnlammoi = new System.Windows.Forms.Button();
            this.txtsotien = new System.Windows.Forms.TextBox();
            this.txttenkhoa = new System.Windows.Forms.TextBox();
            this.txtmakhoa = new System.Windows.Forms.TextBox();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.btnthem = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnlammoicn = new System.Windows.Forms.Button();
            this.txttencn = new System.Windows.Forms.TextBox();
            this.txtmacn = new System.Windows.Forms.TextBox();
            this.cbbmakhoa = new System.Windows.Forms.ComboBox();
            this.btnxoacn = new System.Windows.Forms.Button();
            this.btnsuacn = new System.Windows.Forms.Button();
            this.btnthemcn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.dgvkhoa = new System.Windows.Forms.DataGridView();
            this.Makhoa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Tenkhoa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Sotien1TC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvcn = new System.Windows.Forms.DataGridView();
            this.Machuyennganh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Tenchuyennganh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Khoa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvkhoa)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvcn)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnlammoi);
            this.groupBox1.Controls.Add(this.txtsotien);
            this.groupBox1.Controls.Add(this.txttenkhoa);
            this.groupBox1.Controls.Add(this.txtmakhoa);
            this.groupBox1.Controls.Add(this.button3);
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.btnthem);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Location = new System.Drawing.Point(24, 43);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(487, 209);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Quản lý khoa";
            // 
            // btnlammoi
            // 
            this.btnlammoi.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btnlammoi.Location = new System.Drawing.Point(340, 33);
            this.btnlammoi.Name = "btnlammoi";
            this.btnlammoi.Size = new System.Drawing.Size(122, 31);
            this.btnlammoi.TabIndex = 19;
            this.btnlammoi.Text = "Làm mới";
            this.btnlammoi.UseVisualStyleBackColor = false;
            this.btnlammoi.Click += new System.EventHandler(this.btnlammoi_Click);
            // 
            // txtsotien
            // 
            this.txtsotien.Location = new System.Drawing.Point(123, 128);
            this.txtsotien.Name = "txtsotien";
            this.txtsotien.Size = new System.Drawing.Size(185, 20);
            this.txtsotien.TabIndex = 18;
            // 
            // txttenkhoa
            // 
            this.txttenkhoa.Location = new System.Drawing.Point(123, 77);
            this.txttenkhoa.Name = "txttenkhoa";
            this.txttenkhoa.Size = new System.Drawing.Size(185, 20);
            this.txttenkhoa.TabIndex = 17;
            // 
            // txtmakhoa
            // 
            this.txtmakhoa.Location = new System.Drawing.Point(123, 33);
            this.txtmakhoa.Name = "txtmakhoa";
            this.txtmakhoa.Size = new System.Drawing.Size(185, 20);
            this.txtmakhoa.TabIndex = 16;
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.button3.Location = new System.Drawing.Point(340, 145);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(122, 31);
            this.button3.TabIndex = 15;
            this.button3.Text = "Xoá khoa";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.button2.Location = new System.Drawing.Point(340, 108);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(122, 31);
            this.button2.TabIndex = 14;
            this.button2.Text = "Sửa khoa";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnthem
            // 
            this.btnthem.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btnthem.Location = new System.Drawing.Point(340, 71);
            this.btnthem.Name = "btnthem";
            this.btnthem.Size = new System.Drawing.Size(122, 31);
            this.btnthem.TabIndex = 13;
            this.btnthem.Text = "Thêm khoa";
            this.btnthem.UseVisualStyleBackColor = false;
            this.btnthem.Click += new System.EventHandler(this.btnthem_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(24, 131);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(87, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Số tiền/1 tín chỉ:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(57, 80);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "Tên khoa:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(61, 36);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(52, 13);
            this.label6.TabIndex = 6;
            this.label6.Text = "Mã khoa:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnlammoicn);
            this.groupBox2.Controls.Add(this.txttencn);
            this.groupBox2.Controls.Add(this.txtmacn);
            this.groupBox2.Controls.Add(this.cbbmakhoa);
            this.groupBox2.Controls.Add(this.btnxoacn);
            this.groupBox2.Controls.Add(this.btnsuacn);
            this.groupBox2.Controls.Add(this.btnthemcn);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Location = new System.Drawing.Point(24, 258);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(487, 223);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Quản lý chuyên ngành";
            // 
            // btnlammoicn
            // 
            this.btnlammoicn.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btnlammoicn.Location = new System.Drawing.Point(340, 38);
            this.btnlammoicn.Name = "btnlammoicn";
            this.btnlammoicn.Size = new System.Drawing.Size(122, 31);
            this.btnlammoicn.TabIndex = 20;
            this.btnlammoicn.Text = "Làm mới";
            this.btnlammoicn.UseVisualStyleBackColor = false;
            this.btnlammoicn.Click += new System.EventHandler(this.btnlammoicn_Click);
            // 
            // txttencn
            // 
            this.txttencn.Location = new System.Drawing.Point(123, 147);
            this.txttencn.Name = "txttencn";
            this.txttencn.Size = new System.Drawing.Size(185, 20);
            this.txttencn.TabIndex = 20;
            // 
            // txtmacn
            // 
            this.txtmacn.Location = new System.Drawing.Point(123, 92);
            this.txtmacn.Name = "txtmacn";
            this.txtmacn.Size = new System.Drawing.Size(185, 20);
            this.txtmacn.TabIndex = 19;
            // 
            // cbbmakhoa
            // 
            this.cbbmakhoa.FormattingEnabled = true;
            this.cbbmakhoa.Location = new System.Drawing.Point(123, 44);
            this.cbbmakhoa.Name = "cbbmakhoa";
            this.cbbmakhoa.Size = new System.Drawing.Size(185, 21);
            this.cbbmakhoa.TabIndex = 19;
            // 
            // btnxoacn
            // 
            this.btnxoacn.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btnxoacn.Location = new System.Drawing.Point(340, 150);
            this.btnxoacn.Name = "btnxoacn";
            this.btnxoacn.Size = new System.Drawing.Size(122, 31);
            this.btnxoacn.TabIndex = 18;
            this.btnxoacn.Text = "Xoá chuyên ngành";
            this.btnxoacn.UseVisualStyleBackColor = false;
            this.btnxoacn.Click += new System.EventHandler(this.btnxoacn_Click);
            // 
            // btnsuacn
            // 
            this.btnsuacn.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btnsuacn.Location = new System.Drawing.Point(340, 113);
            this.btnsuacn.Name = "btnsuacn";
            this.btnsuacn.Size = new System.Drawing.Size(122, 31);
            this.btnsuacn.TabIndex = 17;
            this.btnsuacn.Text = "Sửa chuyên ngành";
            this.btnsuacn.UseVisualStyleBackColor = false;
            this.btnsuacn.Click += new System.EventHandler(this.btnsuacn_Click);
            // 
            // btnthemcn
            // 
            this.btnthemcn.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btnthemcn.Location = new System.Drawing.Point(340, 76);
            this.btnthemcn.Name = "btnthemcn";
            this.btnthemcn.Size = new System.Drawing.Size(122, 31);
            this.btnthemcn.TabIndex = 16;
            this.btnthemcn.Text = "Thêm chuyên ngành";
            this.btnthemcn.UseVisualStyleBackColor = false;
            this.btnthemcn.Click += new System.EventHandler(this.btnthemcn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 150);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 13);
            this.label1.TabIndex = 13;
            this.label1.Text = "Tên chuyên ngành:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 95);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Mã chuyên ngành:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(60, 44);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Mã khoa:";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.button1.Location = new System.Drawing.Point(836, 8);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(87, 33);
            this.button1.TabIndex = 8;
            this.button1.Text = "Quay lại";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // dgvkhoa
            // 
            this.dgvkhoa.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgvkhoa.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvkhoa.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Makhoa,
            this.Tenkhoa,
            this.Sotien1TC});
            this.dgvkhoa.Location = new System.Drawing.Point(519, 47);
            this.dgvkhoa.Name = "dgvkhoa";
            this.dgvkhoa.Size = new System.Drawing.Size(431, 205);
            this.dgvkhoa.TabIndex = 9;
            this.dgvkhoa.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvkhoa_CellClick);
            this.dgvkhoa.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvkhoa_CellContentClick);
            // 
            // Makhoa
            // 
            this.Makhoa.DataPropertyName = "Makhoa";
            this.Makhoa.HeaderText = "Mã khoa";
            this.Makhoa.Name = "Makhoa";
            this.Makhoa.Width = 130;
            // 
            // Tenkhoa
            // 
            this.Tenkhoa.DataPropertyName = "Tenkhoa";
            this.Tenkhoa.HeaderText = "Tên khoa";
            this.Tenkhoa.Name = "Tenkhoa";
            this.Tenkhoa.Width = 130;
            // 
            // Sotien1TC
            // 
            this.Sotien1TC.DataPropertyName = "Sotien1TC";
            this.Sotien1TC.HeaderText = "Số tiền/ 1 tín chỉ";
            this.Sotien1TC.Name = "Sotien1TC";
            this.Sotien1TC.Width = 130;
            // 
            // dgvcn
            // 
            this.dgvcn.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgvcn.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvcn.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Machuyennganh,
            this.Tenchuyennganh,
            this.Khoa});
            this.dgvcn.Location = new System.Drawing.Point(519, 258);
            this.dgvcn.Name = "dgvcn";
            this.dgvcn.Size = new System.Drawing.Size(431, 223);
            this.dgvcn.TabIndex = 13;
            this.dgvcn.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvcn_CellClick);
            // 
            // Machuyennganh
            // 
            this.Machuyennganh.DataPropertyName = "Machuyennganh";
            this.Machuyennganh.HeaderText = "Mã chuyên ngành";
            this.Machuyennganh.Name = "Machuyennganh";
            this.Machuyennganh.Width = 130;
            // 
            // Tenchuyennganh
            // 
            this.Tenchuyennganh.DataPropertyName = "Tenchuyennganh";
            this.Tenchuyennganh.HeaderText = "Tên chuyên ngành";
            this.Tenchuyennganh.Name = "Tenchuyennganh";
            this.Tenchuyennganh.Width = 130;
            // 
            // Khoa
            // 
            this.Khoa.DataPropertyName = "Makhoa";
            this.Khoa.HeaderText = "Khoa";
            this.Khoa.Name = "Khoa";
            this.Khoa.Width = 130;
            // 
            // QLKhoa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(962, 488);
            this.Controls.Add(this.dgvcn);
            this.Controls.Add(this.dgvkhoa);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "QLKhoa";
            this.Text = "QLKhoa";
            this.Load += new System.EventHandler(this.QLKhoa_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvkhoa)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvcn)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button btnthem;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnxoacn;
        private System.Windows.Forms.Button btnsuacn;
        private System.Windows.Forms.Button btnthemcn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtsotien;
        private System.Windows.Forms.TextBox txttenkhoa;
        private System.Windows.Forms.TextBox txtmakhoa;
        private System.Windows.Forms.TextBox txttencn;
        private System.Windows.Forms.TextBox txtmacn;
        private System.Windows.Forms.ComboBox cbbmakhoa;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView dgvkhoa;
        private System.Windows.Forms.DataGridView dgvcn;
        private System.Windows.Forms.Button btnlammoi;
        private System.Windows.Forms.Button btnlammoicn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Makhoa;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tenkhoa;
        private System.Windows.Forms.DataGridViewTextBoxColumn Sotien1TC;
        private System.Windows.Forms.DataGridViewTextBoxColumn Machuyennganh;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tenchuyennganh;
        private System.Windows.Forms.DataGridViewTextBoxColumn Khoa;
    }
}