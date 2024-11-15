namespace OutlookDemo.DiaLog
{
    partial class FormSchedule
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
            this.components = new System.ComponentModel.Container();
            this.header = new System.Windows.Forms.Panel();
            this.btnClose = new Guna.UI2.WinForms.Guna2Button();
            this.txtHeader = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnSave = new Guna.UI2.WinForms.Guna2Button();
            this.btnDelete = new Guna.UI2.WinForms.Guna2Button();
            this.btnCancel = new Guna.UI2.WinForms.Guna2Button();
            this.guna2DragControl1 = new Guna.UI2.WinForms.Guna2DragControl(this.components);
            this.bxHP = new Guna.UI2.WinForms.Guna2ComboBox();
            this.bxGV = new Guna.UI2.WinForms.Guna2ComboBox();
            this.bxPH = new Guna.UI2.WinForms.Guna2ComboBox();
            this.txt_DS = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.txt_DE = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.txt_TS = new Guna.UI2.WinForms.Guna2NumericUpDown();
            this.txt_TE = new Guna.UI2.WinForms.Guna2NumericUpDown();
            this.txt_T = new Guna.UI2.WinForms.Guna2NumericUpDown();
            this.txt_number = new Guna.UI2.WinForms.Guna2NumericUpDown();
            this.txt_KN = new Guna.UI2.WinForms.Guna2NumericUpDown();
            this.txt_QD = new Guna.UI2.WinForms.Guna2NumericUpDown();
            this.txt_name = new Guna.UI2.WinForms.Guna2TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.header.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txt_TS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_TE)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_T)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_number)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_KN)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_QD)).BeginInit();
            this.SuspendLayout();
            // 
            // header
            // 
            this.header.BackColor = System.Drawing.Color.White;
            this.header.Controls.Add(this.btnClose);
            this.header.Controls.Add(this.txtHeader);
            this.header.Dock = System.Windows.Forms.DockStyle.Top;
            this.header.Location = new System.Drawing.Point(0, 0);
            this.header.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.header.Name = "header";
            this.header.Size = new System.Drawing.Size(1096, 44);
            this.header.TabIndex = 4;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.BackColor = System.Drawing.Color.Transparent;
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClose.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnClose.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnClose.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnClose.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnClose.FillColor = System.Drawing.Color.Transparent;
            this.btnClose.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnClose.ForeColor = System.Drawing.Color.Black;
            this.btnClose.Location = new System.Drawing.Point(1041, 9);
            this.btnClose.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(43, 25);
            this.btnClose.TabIndex = 3;
            this.btnClose.Text = "X";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // txtHeader
            // 
            this.txtHeader.AutoSize = true;
            this.txtHeader.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtHeader.ForeColor = System.Drawing.Color.Black;
            this.txtHeader.Location = new System.Drawing.Point(19, 9);
            this.txtHeader.Name = "txtHeader";
            this.txtHeader.Size = new System.Drawing.Size(164, 23);
            this.txtHeader.TabIndex = 2;
            this.txtHeader.Text = "Thêm Lớp Tín Chỉ";
            this.txtHeader.Click += new System.EventHandler(this.txtHeader_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.btnSave);
            this.panel1.Controls.Add(this.btnDelete);
            this.panel1.Controls.Add(this.btnCancel);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 641);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1096, 74);
            this.panel1.TabIndex = 57;
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.BorderRadius = 4;
            this.btnSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSave.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnSave.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnSave.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnSave.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(972, 17);
            this.btnSave.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(113, 43);
            this.btnSave.TabIndex = 6;
            this.btnSave.Text = "Lưu";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDelete.BorderColor = System.Drawing.Color.Transparent;
            this.btnDelete.BorderRadius = 4;
            this.btnDelete.BorderThickness = 1;
            this.btnDelete.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDelete.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnDelete.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnDelete.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnDelete.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnDelete.FillColor = System.Drawing.Color.Red;
            this.btnDelete.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnDelete.ForeColor = System.Drawing.Color.White;
            this.btnDelete.Location = new System.Drawing.Point(832, 17);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(113, 43);
            this.btnDelete.TabIndex = 55;
            this.btnDelete.Text = "Xóa";
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCancel.BorderRadius = 4;
            this.btnCancel.BorderThickness = 1;
            this.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancel.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnCancel.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnCancel.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnCancel.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnCancel.FillColor = System.Drawing.Color.Transparent;
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.ForeColor = System.Drawing.Color.Black;
            this.btnCancel.Location = new System.Drawing.Point(15, 17);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(113, 43);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "Hủy";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // guna2DragControl1
            // 
            this.guna2DragControl1.DockIndicatorTransparencyValue = 0.6D;
            this.guna2DragControl1.TargetControl = this.header;
            this.guna2DragControl1.UseTransparentDrag = true;
            // 
            // bxHP
            // 
            this.bxHP.BackColor = System.Drawing.Color.Transparent;
            this.bxHP.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.bxHP.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.bxHP.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.bxHP.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.bxHP.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.bxHP.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.bxHP.ItemHeight = 30;
            this.bxHP.Location = new System.Drawing.Point(24, 101);
            this.bxHP.Margin = new System.Windows.Forms.Padding(4);
            this.bxHP.Name = "bxHP";
            this.bxHP.Size = new System.Drawing.Size(292, 36);
            this.bxHP.TabIndex = 59;
            // 
            // bxGV
            // 
            this.bxGV.BackColor = System.Drawing.Color.Transparent;
            this.bxGV.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.bxGV.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.bxGV.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.bxGV.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.bxGV.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.bxGV.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.bxGV.ItemHeight = 30;
            this.bxGV.Location = new System.Drawing.Point(763, 101);
            this.bxGV.Margin = new System.Windows.Forms.Padding(4);
            this.bxGV.Name = "bxGV";
            this.bxGV.Size = new System.Drawing.Size(291, 36);
            this.bxGV.TabIndex = 63;
            // 
            // bxPH
            // 
            this.bxPH.BackColor = System.Drawing.Color.Transparent;
            this.bxPH.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.bxPH.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.bxPH.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.bxPH.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.bxPH.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.bxPH.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.bxPH.ItemHeight = 30;
            this.bxPH.Location = new System.Drawing.Point(24, 326);
            this.bxPH.Margin = new System.Windows.Forms.Padding(4);
            this.bxPH.Name = "bxPH";
            this.bxPH.Size = new System.Drawing.Size(291, 36);
            this.bxPH.TabIndex = 71;
            // 
            // txt_DS
            // 
            this.txt_DS.Checked = true;
            this.txt_DS.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txt_DS.Format = System.Windows.Forms.DateTimePickerFormat.Long;
            this.txt_DS.Location = new System.Drawing.Point(763, 326);
            this.txt_DS.Margin = new System.Windows.Forms.Padding(4);
            this.txt_DS.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.txt_DS.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.txt_DS.Name = "txt_DS";
            this.txt_DS.Size = new System.Drawing.Size(292, 44);
            this.txt_DS.TabIndex = 82;
            this.txt_DS.Value = new System.DateTime(2023, 12, 18, 0, 0, 0, 0);
            // 
            // txt_DE
            // 
            this.txt_DE.Checked = true;
            this.txt_DE.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txt_DE.Format = System.Windows.Forms.DateTimePickerFormat.Long;
            this.txt_DE.Location = new System.Drawing.Point(24, 437);
            this.txt_DE.Margin = new System.Windows.Forms.Padding(4);
            this.txt_DE.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.txt_DE.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.txt_DE.Name = "txt_DE";
            this.txt_DE.Size = new System.Drawing.Size(292, 44);
            this.txt_DE.TabIndex = 83;
            this.txt_DE.Value = new System.DateTime(2023, 12, 18, 0, 0, 0, 0);
            // 
            // txt_TS
            // 
            this.txt_TS.BackColor = System.Drawing.Color.Transparent;
            this.txt_TS.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_TS.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txt_TS.Location = new System.Drawing.Point(401, 437);
            this.txt_TS.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txt_TS.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.txt_TS.Name = "txt_TS";
            this.txt_TS.Size = new System.Drawing.Size(292, 44);
            this.txt_TS.TabIndex = 84;
            // 
            // txt_TE
            // 
            this.txt_TE.BackColor = System.Drawing.Color.Transparent;
            this.txt_TE.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_TE.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txt_TE.Location = new System.Drawing.Point(763, 437);
            this.txt_TE.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txt_TE.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.txt_TE.Name = "txt_TE";
            this.txt_TE.Size = new System.Drawing.Size(292, 44);
            this.txt_TE.TabIndex = 85;
            // 
            // txt_T
            // 
            this.txt_T.BackColor = System.Drawing.Color.Transparent;
            this.txt_T.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_T.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txt_T.Location = new System.Drawing.Point(401, 326);
            this.txt_T.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txt_T.Maximum = new decimal(new int[] {
            7,
            0,
            0,
            0});
            this.txt_T.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.txt_T.Name = "txt_T";
            this.txt_T.Size = new System.Drawing.Size(292, 44);
            this.txt_T.TabIndex = 86;
            this.txt_T.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // txt_number
            // 
            this.txt_number.BackColor = System.Drawing.Color.Transparent;
            this.txt_number.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_number.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txt_number.Location = new System.Drawing.Point(24, 209);
            this.txt_number.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txt_number.Name = "txt_number";
            this.txt_number.Size = new System.Drawing.Size(292, 44);
            this.txt_number.TabIndex = 87;
            // 
            // txt_KN
            // 
            this.txt_KN.BackColor = System.Drawing.Color.Transparent;
            this.txt_KN.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_KN.DecimalPlaces = 2;
            this.txt_KN.Enabled = false;
            this.txt_KN.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txt_KN.Location = new System.Drawing.Point(401, 209);
            this.txt_KN.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txt_KN.Name = "txt_KN";
            this.txt_KN.Size = new System.Drawing.Size(292, 44);
            this.txt_KN.TabIndex = 88;
            this.txt_KN.Visible = false;
            // 
            // txt_QD
            // 
            this.txt_QD.BackColor = System.Drawing.Color.Transparent;
            this.txt_QD.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_QD.DecimalPlaces = 2;
            this.txt_QD.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txt_QD.Location = new System.Drawing.Point(763, 209);
            this.txt_QD.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txt_QD.Name = "txt_QD";
            this.txt_QD.Size = new System.Drawing.Size(292, 44);
            this.txt_QD.TabIndex = 89;
            // 
            // txt_name
            // 
            this.txt_name.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_name.DefaultText = "";
            this.txt_name.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txt_name.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txt_name.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txt_name.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txt_name.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txt_name.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txt_name.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txt_name.Location = new System.Drawing.Point(401, 101);
            this.txt_name.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txt_name.Name = "txt_name";
            this.txt_name.PasswordChar = '\0';
            this.txt_name.PlaceholderText = "";
            this.txt_name.SelectedText = "";
            this.txt_name.Size = new System.Drawing.Size(292, 44);
            this.txt_name.TabIndex = 90;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(19, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 23);
            this.label1.TabIndex = 4;
            this.label1.Text = "Học Phần";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(403, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(149, 23);
            this.label2.TabIndex = 91;
            this.label2.Text = "Tên Lớp Tín Chỉ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(759, 60);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(108, 23);
            this.label3.TabIndex = 92;
            this.label3.Text = "Giảng Viên ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(29, 170);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(54, 23);
            this.label4.TabIndex = 93;
            this.label4.Text = "Sỹ số";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(403, 168);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(122, 23);
            this.label5.TabIndex = 94;
            this.label5.Text = "Giờ kế hoạch";
            this.label5.Visible = false;
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(759, 170);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(107, 23);
            this.label6.TabIndex = 95;
            this.label6.Text = "Giờ quy đổi";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(20, 285);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(96, 23);
            this.label7.TabIndex = 96;
            this.label7.Text = "Phòng học";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Black;
            this.label8.Location = new System.Drawing.Point(397, 287);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(180, 23);
            this.label8.TabIndex = 97;
            this.label8.Text = "Ngày học trong tuần";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.Black;
            this.label9.Location = new System.Drawing.Point(759, 287);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(121, 23);
            this.label9.TabIndex = 98;
            this.label9.Text = "Ngày bắt đầu";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.Black;
            this.label10.Location = new System.Drawing.Point(19, 398);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(129, 23);
            this.label10.TabIndex = 99;
            this.label10.Text = "Ngày kết thúc";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.Black;
            this.label11.Location = new System.Drawing.Point(397, 398);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(112, 23);
            this.label11.TabIndex = 100;
            this.label11.Text = "Tiết bắt đầu";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.Black;
            this.label12.Location = new System.Drawing.Point(760, 398);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(120, 23);
            this.label12.TabIndex = 101;
            this.label12.Text = "Tiết kết thúc";
            // 
            // FormSchedule
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1096, 715);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txt_name);
            this.Controls.Add(this.txt_QD);
            this.Controls.Add(this.txt_KN);
            this.Controls.Add(this.txt_number);
            this.Controls.Add(this.txt_T);
            this.Controls.Add(this.txt_TE);
            this.Controls.Add(this.txt_TS);
            this.Controls.Add(this.txt_DE);
            this.Controls.Add(this.txt_DS);
            this.Controls.Add(this.bxPH);
            this.Controls.Add(this.bxGV);
            this.Controls.Add(this.bxHP);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.header);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FormSchedule";
            this.Text = "FormSchedule";
            this.Load += new System.EventHandler(this.FormSchedule_Load);
            this.header.ResumeLayout(false);
            this.header.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txt_TS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_TE)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_T)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_number)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_KN)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_QD)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel header;
        private Guna.UI2.WinForms.Guna2Button btnClose;
        private System.Windows.Forms.Label txtHeader;
        private System.Windows.Forms.Panel panel1;
        private Guna.UI2.WinForms.Guna2Button btnSave;
        private Guna.UI2.WinForms.Guna2Button btnDelete;
        private Guna.UI2.WinForms.Guna2Button btnCancel;
        private Guna.UI2.WinForms.Guna2DragControl guna2DragControl1;
        private Guna.UI2.WinForms.Guna2ComboBox bxHP;
        private Guna.UI2.WinForms.Guna2ComboBox bxGV;
        private Guna.UI2.WinForms.Guna2ComboBox bxPH;
        private Guna.UI2.WinForms.Guna2DateTimePicker txt_DS;
        private Guna.UI2.WinForms.Guna2DateTimePicker txt_DE;
        private Guna.UI2.WinForms.Guna2NumericUpDown txt_TS;
        private Guna.UI2.WinForms.Guna2NumericUpDown txt_TE;
        private Guna.UI2.WinForms.Guna2NumericUpDown txt_T;
        private Guna.UI2.WinForms.Guna2NumericUpDown txt_number;
        private Guna.UI2.WinForms.Guna2NumericUpDown txt_KN;
        private Guna.UI2.WinForms.Guna2NumericUpDown txt_QD;
        private Guna.UI2.WinForms.Guna2TextBox txt_name;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
    }
}