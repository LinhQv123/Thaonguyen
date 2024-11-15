using Guna.UI2.WinForms;
using OutlookDemo.DiaLog;
using OutlookDemo.UserControls;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;



namespace OutlookDemo
{
    public partial class Form1 : Form
    {
        private connectDB ketNoi;
        private UserControlGiangVien userControlGiangVien = new UserControlGiangVien();
        private SqlConnection connection;
        private DataGridView dataGridViewChiTietLop;
        private int isCheckUser = 2;
        private string idMember;
        public Form1()
        {
            InitializeComponent();
            ketNoi = new connectDB();
            // Khởi tạo dataGridViewChiTietLop
            dataGridViewChiTietLop = new DataGridView();

            // Thêm dataGridViewChiTietLop vào Controls của Form
            Controls.Add(dataGridViewChiTietLop);
            isCheckUser = 2;
            idMember = "";
        }

        private void moveImageBox(object sender)
        {
            Guna2Button b = (Guna2Button)sender;
            imgSlide.Location = new Point(b.Location.X + 223, b.Location.Y - 30);
            imgSlide.SendToBack();
        }
        private void guna2Button1_CheckedChanged(object sender, EventArgs e)
        {
            moveImageBox(sender);
        }

        private void guna2Button6_Click(object sender, EventArgs e)
        {
            FormLogin loginForm = new FormLogin();
            loginForm.Show();
            this.Hide(); // Ẩn form đăng nhập
        }


        private void guna2Button8_Click(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Normal)
            {
                this.WindowState = FormWindowState.Maximized;
            }
            else
            {
                this.WindowState = FormWindowState.Normal;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnMini_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            txtHeader.Text = "Giảng viên";
            isCheckUser = 0;
            reloadData();
            headerRename();
        }

        /// <summary>
        /// khởi tạo giá trị ban đầu
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Load(object sender, EventArgs e)
        {
            main.Controls.Clear();
            main.Controls.Add(userControlGiangVien);
            string sql = "select DISTINCT type_branch from class_section order by type_branch DESC";
            userControlGiangVien.bxGV.DataSource = getDataGV(sql).Tables[0];
            userControlGiangVien.bxGV.DisplayMember = getDataGV(sql).Tables[0].Columns[0].ToString();
            userControlGiangVien.bxGV.Visible = true;
            idMember = (string)((System.Data.DataRowView)userControlGiangVien.bxGV.SelectedItem).Row.ItemArray[0];
            userControlGiangVien.gridGV.DataSource = loadDataGrid($"select ROW_NUMBER() OVER (ORDER BY semester),class_section_code,class_section_name,number_credits,theory,practice,theory+practice,(CASE elective WHEN 0 THEN '' WHEN 1 THEN N'Tự chọn' ELSE '' END),type, semester from class_section where type_branch = N'{idMember}' order by semester;").Tables[0];
            userControlGiangVien.Dock = DockStyle.Fill;
            userControlGiangVien.btnAdd.Click += opentDialog;
            userControlGiangVien.gridGV.CellDoubleClick += ClickSelectGridView;
            userControlGiangVien.bxGV.SelectedIndexChanged += BxGV_SelectedIndexChanged;
            headerRename();
            isCheckUser = 2;
            userControlGiangVien.checkEx = isCheckUser;

        }

        private void BxGV_SelectedIndexChanged(object sender, EventArgs e)
        {   if(isCheckUser == 5 || isCheckUser == 4)
            {
                idMember = (string)((System.Data.DataRowView)userControlGiangVien.bxGV.SelectedItem).Row.ItemArray[1];

            }
            else if(isCheckUser == 2)
            {
                idMember = (string)((System.Data.DataRowView)userControlGiangVien.bxGV.SelectedItem).Row.ItemArray[0];

            }
            reloadData();
        }

        /// <summary>
        /// hàm mở form nhậ liệu của các màn 
        /// </summary>
        private void opentDialog(object sender, EventArgs e)
        {
            memberCode = "";
            class_credit_room_id = "";
            class_credit_id = "";
            ShowDialog();
        }
        public string memberCode = "";
        /// <summary>
        /// hàm mở form nhậ liệu của các màn 
        /// </summary>
        private void ShowDialog()
        {

            switch (isCheckUser)
            {
                case 0:
                    ActionUserForm addUser = new ActionUserForm();
                    addUser.memberCode = memberCode;
                    addUser.LoadDataGrid = new ActionUserForm.LoadData(reloadData);
                    addUser.ShowDialog();
                    break;
                case 1:
                    FormClass formClass = new FormClass();
                    formClass.ClassCode = memberCode;
                    formClass.LoadDataGrid = new FormClass.LoadData(reloadData);
                    formClass.ShowDialog();
                    break;
                case 2:
                    FormClassSection formClassSection = new FormClassSection();
                    formClassSection.ClassSectionCode = memberCode;
                    formClassSection.LoadDataGrid = new FormClassSection.LoadData(reloadData);
                    formClassSection.Left = 700;
                    formClassSection.Top = 500;
                    formClassSection.ShowDialog();
                    break;
                case 3:
                    Formbuilding room = new Formbuilding();
                    room.roomCode = memberCode;
                    room.LoadDataGrid = new Formbuilding.LoadData(reloadData);
                    room.ShowDialog();
                    break;
                case 4:
                    FormSchedule classGD = new FormSchedule();
                    classGD.ClassSectionCode = memberCode;
                    classGD.class_credit_room_id = class_credit_room_id;
                    classGD.class_credit_id = class_credit_id;
                    classGD.vbxHP = vbxHP;
                    classGD.vbxGV = vbxGV;
                    classGD.vbxPH = vbxPH;
                    classGD.vtxt_TE = vtxt_TE;
                    classGD.vtxt_T = vtxt_T;
                    classGD.vtxt_TS = vtxt_TS;
                    classGD.vtxt_DS = vtxt_DS;
                    classGD.vtxt_DE = vtxt_DE;
                    classGD.vnumber = vnumber;
                    classGD.vtxt_QD = vtxt_QD;
                    classGD.LoadDataGrid = new FormSchedule.LoadData(reloadData);
                    classGD.ShowDialog();
                    break;
                    // default :
                    //    addUser.memberCode = memberCode;
                    //    addUser.LoadDataGrid = new ActionUserForm.LoadData(reloadData);
                    //    addUser.ShowDialog();
            }

        }
        private string class_credit_room_id = "";
        private string class_credit_id = "";
        private string vbxHP;
        private string vbxGV;
        private string vbxPH;
        private string vtxt_QD;
        private int vnumber;
        private int vtxt_KN;
        private int vtxt_TE;
        private int vtxt_T;
        private int vtxt_TS;
        private DateTime vtxt_DS;
        private DateTime vtxt_DE;
        /// <summary>
        /// lấy dữ liệu khi click và dòng trong bảng
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ClickSelectGridView(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = userControlGiangVien.gridGV.Rows[e.RowIndex];

            memberCode = row.Cells[1].Value.ToString();
            if (isCheckUser == 4)
            {
                class_credit_room_id = row.Cells[11].Value.ToString();
                class_credit_id = row.Cells[10].Value.ToString();
                memberCode = row.Cells[4].Value.ToString();
                vbxHP = row.Cells[2].Value.ToString();
                vbxGV = row.Cells[7].Value.ToString();
                vbxPH = row.Cells[9].Value.ToString();
                vtxt_TE = (int)row.Cells[14].Value;
                vtxt_T = (int)row.Cells[12].Value;
                vtxt_TS = (int)row.Cells[13].Value;
                vtxt_DS = (DateTime)row.Cells[5].Value;
                vtxt_DE = (DateTime)row.Cells[6].Value;
                vnumber = (int)row.Cells[15].Value;
                vtxt_QD = row.Cells[16].Value.ToString();
            }

            ShowDialog();
        }
        /// <summary>
        /// hàm lấy lại dữ liệu khi thêm sửa xóa 
        /// </summary>
        private void reloadData()
        {
            userControlGiangVien.checkEx = isCheckUser;
            txtSearch.Text = "";
            string queryUser = "";
            switch (isCheckUser)
            {
                case 0:
                    userControlGiangVien.showHideItem(false);
                    queryUser = "select ROW_NUMBER() OVER (ORDER BY first_name),member_code,CONCAT(last_name,' ',first_name),(CASE gender WHEN 0 THEN 'Nam' WHEN 1 THEN N'Nữ' ELSE 'Khác'END),dateOfbirth,hometown,degree,Position from member  where role = 1 order by first_name";
                    break;
                case 1:
                    userControlGiangVien.showHideItem(false);
                    queryUser = $"select ROW_NUMBER() OVER (ORDER BY class_code),class_code,N'Khoa Công nghệ thông tin',class_name,number_students,CONCAT(last_name,' ',first_name) from class inner join member on member_id = memberId order by class_code;";
                    break;
                case 2:
                    userControlGiangVien.showHideItem(false);
                    queryUser = $"select ROW_NUMBER() OVER (ORDER BY semester),class_section_code,class_section_name,number_credits,theory,practice,theory+practice,(CASE elective WHEN 0 THEN '' WHEN 1 THEN N'Tự chọn' ELSE '' END),type, semester from class_section where type_branch = N'{idMember}'order by semester;";
                    userControlGiangVien.bxGV.Visible = true;
                    break;
                case 3:
                    userControlGiangVien.showHideItem(false);
                    queryUser = $"select ROW_NUMBER() OVER (ORDER BY building),class_room_number,building from class_room order by building";
                    break;
                case 4:
                    userControlGiangVien.showHideItem(false);
                    queryUser = $"select ROW_NUMBER() OVER (ORDER BY class_section_code),class_section_code,class_section_name,number_credits,class_credit_name,start_day,end_day,CONCAT(last_name,' ', first_name) ,CONCAT(N'Thứ ',weekdays,' (T',shift_start,'-',shift_end,')'),class_room_number ,class_credit.class_credit_id ,class_credit_room.class_room_id ,weekdays,shift_start,shift_end,number_student,red_theory from class_credit"
                    + " inner join  class_section on class_credit.class_section_id = class_section.class_section_id"
                   + " inner join member on member.member_id =  class_credit.member_id "
                   + " inner join class_credit_room on class_credit_room.class_credit_id = class_credit.class_credit_id"
                   + $" inner join class_room on class_room.class_room_id =class_credit_room.class_room_id where member.member_id = '{idMember}'";
                    userControlGiangVien.bxGV.Visible = true;
                    break;
                case 5:
                    queryUser = $"EXEC SelectAllLuong @MemberId = '{idMember}'";
                    break;
            }
            try
            {
                userControlGiangVien.gridGV.DataSource = loadDataGrid(queryUser).Tables[0];
            }

            catch { }
            if (isCheckUser == 5)
            {
                try { 
                userControlGiangVien.txtSumtime.Text = Math.Round((double)loadDataGrid(queryUser).Tables[1].Rows[0].ItemArray[0],2).ToString();
                userControlGiangVien.txt_price.Text = loadDataGrid(queryUser).Tables[1].Rows[0].ItemArray[1].ToString();
                userControlGiangVien.txtMoney.Text = Math.Round((double)loadDataGrid(queryUser).Tables[1].Rows[0].ItemArray[2], 2).ToString();
                }
                catch {
                    userControlGiangVien.txtSumtime.Text = "0";
                    userControlGiangVien.txt_price.Text = "0";
                    userControlGiangVien.txtMoney.Text = "0";
                }

            }

        }
        private void guna2Button2_Click(object sender, EventArgs e)
        {
            txtHeader.Text = "Lớp Học";
            isCheckUser = 1;
            reloadData();
            headerRename();
        }
        /// <summary>
        /// Lấy dư liệu từ database gán lên bảng 
        /// </summary>
        /// <param name="sql">câu lệnh truy vấn</param>
        /// <returns></returns>
        DataSet loadDataGrid(string sql)
        {
            DataSet dataSet = new DataSet();
            try
            {
                using (connection = ketNoi.MoKetNoi())
                {
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        SqlDataAdapter adapter = new SqlDataAdapter(command);
                        adapter.Fill(dataSet);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                ketNoi.DongKetNoi(connection);
            }
            return dataSet;
        }

        /// <summary>
        /// Hàm tìm kiếm
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string queryUser = "";
            switch (isCheckUser)
            {
                case 0:
                    queryUser = $"select ROW_NUMBER() OVER (ORDER BY first_name), member_code,N'Khoa Công nghệ thông tin',CONCAT(last_name,' ',first_name),(CASE gender WHEN 0 THEN 'Nam' WHEN 1 THEN N'Nữ' ELSE 'Khác'END) AS gender,dateOfbirth,hometown,degree,Position from member where member_code like  '%{txtSearch.Text}%' or CONCAT(last_name,' ',first_name) like '%{txtSearch.Text}%' and role = 1 order by first_name  ";
                    break;
                case 1:
                    queryUser = $"select ROW_NUMBER() OVER (ORDER BY class_code),class_code,class_name,number_students from class where class_code like '%{txtSearch.Text}%' or class_name like '%{txtSearch.Text}%' order by class_code ";
                    break;
                case 2:

                    queryUser = $"select ROW_NUMBER() OVER (ORDER BY semester),class_section_code,class_section_name,number_credits,theory,practice,theory+practice,(CASE elective WHEN 0 THEN '' WHEN 1 THEN N'Tự chọn' ELSE '' END),type, semester from class_section where class_section_code like '%{txtSearch.Text}%' or class_section_name like '%{txtSearch.Text}%' and type_branch = N'{idMember}' order by semester  ";
                    break;
                case 3:

                    queryUser = $"select ROW_NUMBER() OVER (ORDER BY building), class_room_number,building from class_room where class_room_number like '%{txtSearch.Text}%' or class_room_number like '%{txtSearch.Text}%' order by building ";
                    break;
                case 4:
                    queryUser = $"select ROW_NUMBER() OVER (ORDER BY class_section_code),class_section_code,class_section_name,number_credits,class_credit_name,start_day,end_day,CONCAT(last_name,' ', first_name) ,CONCAT(N'Thứ ',weekdays,' (T',shift_start,'-',shift_end,')'),class_room_number,class_credit.class_credit_id ,class_credit_room.class_room_id ,weekdays,shift_start,shift_end,number_student,red_theory from class_credit"
                        + " inner join  class_section on class_credit.class_section_id = class_section.class_section_id"
                       + " inner join member on member.member_id =  class_credit.member_id "
                       + " inner join class_credit_room on class_credit_room.class_credit_id = class_credit.class_credit_id"
                       + " inner join class_room on class_room.class_room_id =class_credit_room.class_room_id"
                    + $" where (class_section_code like '%{txtSearch.Text}%' or class_section_name like '%{txtSearch.Text}%' or CONCAT(last_name,' ',first_name) like '%{txtSearch.Text}%') and member.member_id = '{idMember}'";
                    break;
            }
            userControlGiangVien.gridGV.DataSource = loadDataGrid(queryUser).Tables[0];

        }
        /// <summary>
        /// Hàm đổi tên cột và set auto size
        /// </summary>
        private void headerRename()
        {
            if (isCheckUser == 0)
            {
                userControlGiangVien.gridGV.Columns[0].Visible=true;
                userControlGiangVien.gridGV.Columns[1].Visible=true;
                userControlGiangVien.gridGV.Columns[2].Visible=true;
                userControlGiangVien.gridGV.Columns[3].Visible=true;
                userControlGiangVien.gridGV.Columns[4].Visible=true;
                userControlGiangVien.gridGV.Columns[5].Visible=true;
                userControlGiangVien.gridGV.Columns[6].Visible = true;
                userControlGiangVien.gridGV.Columns[7].Visible = true;

                userControlGiangVien.gridGV.Columns[0].HeaderText = "STT ";
                userControlGiangVien.gridGV.Columns[1].HeaderText = "Mã Giảng Viên ";
                userControlGiangVien.gridGV.Columns[2].HeaderText = "Tên Giảng Viên";
                userControlGiangVien.gridGV.Columns[3].HeaderText = "Giới Tính";
                userControlGiangVien.gridGV.Columns[4].HeaderText = "Ngày Sinh";
                userControlGiangVien.gridGV.Columns[5].HeaderText = "Quê Quán";
                userControlGiangVien.gridGV.Columns[6].HeaderText = "Học Vị";
                userControlGiangVien.gridGV.Columns[7].HeaderText = "Chức danh";

                userControlGiangVien.gridGV.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                userControlGiangVien.gridGV.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                userControlGiangVien.gridGV.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                userControlGiangVien.gridGV.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                userControlGiangVien.gridGV.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                userControlGiangVien.gridGV.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                userControlGiangVien.gridGV.Columns[7].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
            else if (isCheckUser == 1)
            {
                userControlGiangVien.gridGV.Columns[0].Visible =true;
                userControlGiangVien.gridGV.Columns[1].Visible =true;
                userControlGiangVien.gridGV.Columns[2].Visible =true;
                userControlGiangVien.gridGV.Columns[3].Visible =true;
                userControlGiangVien.gridGV.Columns[4].Visible =true;
                userControlGiangVien.gridGV.Columns[5].Visible = true;

                userControlGiangVien.gridGV.Columns[0].HeaderText = "STT";
                userControlGiangVien.gridGV.Columns[1].HeaderText = "Tên Lớp";
                userControlGiangVien.gridGV.Columns[2].HeaderText = "Khoa";
                userControlGiangVien.gridGV.Columns[3].HeaderText = "Mã Lớp";
                userControlGiangVien.gridGV.Columns[4].HeaderText = "Si Số";
                userControlGiangVien.gridGV.Columns[5].HeaderText = "Cố vấn học tập";
                userControlGiangVien.gridGV.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                userControlGiangVien.gridGV.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                userControlGiangVien.gridGV.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                userControlGiangVien.gridGV.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                userControlGiangVien.gridGV.Columns[3].Visible = false;

            }
            else if (isCheckUser == 2)
            {
                userControlGiangVien.gridGV.Columns[0].Visible =true;
                userControlGiangVien.gridGV.Columns[1].Visible =true;
                userControlGiangVien.gridGV.Columns[2].Visible =true;
                userControlGiangVien.gridGV.Columns[3].Visible =true;
                userControlGiangVien.gridGV.Columns[4].Visible =true;
                userControlGiangVien.gridGV.Columns[5].Visible =true;
                userControlGiangVien.gridGV.Columns[6].Visible =true;
                userControlGiangVien.gridGV.Columns[7].Visible =true;
                userControlGiangVien.gridGV.Columns[8].Visible =true;
                userControlGiangVien.gridGV.Columns[9].Visible = true;

                userControlGiangVien.gridGV.Columns[0].HeaderText = "STT";
                userControlGiangVien.gridGV.Columns[1].HeaderText = "Mã Lớp Học Phần";
                userControlGiangVien.gridGV.Columns[2].HeaderText = "Tên Lớp Học Phần";
                userControlGiangVien.gridGV.Columns[3].HeaderText = "Số Tín Chỉ";
                userControlGiangVien.gridGV.Columns[4].HeaderText = "Tiết lý thuyết";
                userControlGiangVien.gridGV.Columns[5].HeaderText = "Tiết Thực hành";
                userControlGiangVien.gridGV.Columns[6].HeaderText = "Tổng số tiết";
                userControlGiangVien.gridGV.Columns[7].HeaderText = "Đăng ký";
                userControlGiangVien.gridGV.Columns[8].HeaderText = "Kiến thức";
                userControlGiangVien.gridGV.Columns[9].HeaderText = "Kỳ học";
                
            }
            else if (isCheckUser == 3)
            {
                userControlGiangVien.gridGV.Columns[0].Visible =true;
                userControlGiangVien.gridGV.Columns[1].Visible =true;
                userControlGiangVien.gridGV.Columns[2].Visible = true;

                userControlGiangVien.gridGV.Columns[0].HeaderText = "STT";
                userControlGiangVien.gridGV.Columns[1].HeaderText = "Tên Phòng học";
                userControlGiangVien.gridGV.Columns[2].HeaderText = "Tòa";

                userControlGiangVien.gridGV.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                userControlGiangVien.gridGV.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
            else if (isCheckUser == 4)
            {
                userControlGiangVien.gridGV.Columns[0].Visible =true;
                userControlGiangVien.gridGV.Columns[1].Visible =true;
                userControlGiangVien.gridGV.Columns[2].Visible =true;
                userControlGiangVien.gridGV.Columns[3].Visible =true;
                userControlGiangVien.gridGV.Columns[4].Visible =true;
                userControlGiangVien.gridGV.Columns[5].Visible =true;
                userControlGiangVien.gridGV.Columns[6].Visible =true;
                userControlGiangVien.gridGV.Columns[7].Visible =true;
                userControlGiangVien.gridGV.Columns[8].Visible =true;
                userControlGiangVien.gridGV.Columns[9].Visible = true;

                userControlGiangVien.gridGV.Columns[0].HeaderText = "STT";
                userControlGiangVien.gridGV.Columns[1].HeaderText = "Mã học phần";
                userControlGiangVien.gridGV.Columns[2].HeaderText = "Tên học phần";
                userControlGiangVien.gridGV.Columns[3].HeaderText = "Tín chỉ";
                userControlGiangVien.gridGV.Columns[4].HeaderText = "Tên lớp tín chỉ";
                userControlGiangVien.gridGV.Columns[5].HeaderText = "Từ ngày";
                userControlGiangVien.gridGV.Columns[6].HeaderText = "Đến ngày";
                userControlGiangVien.gridGV.Columns[7].HeaderText = "Giảng viên";
                userControlGiangVien.gridGV.Columns[8].HeaderText = "Thời gian";
                userControlGiangVien.gridGV.Columns[9].HeaderText = "phòng học";
                userControlGiangVien.gridGV.Columns[10].Visible = false;
                userControlGiangVien.gridGV.Columns[11].Visible = false;
                userControlGiangVien.gridGV.Columns[12].Visible = false;
                userControlGiangVien.gridGV.Columns[13].Visible = false;
                userControlGiangVien.gridGV.Columns[14].Visible = false;
                userControlGiangVien.gridGV.Columns[15].Visible = false;
                userControlGiangVien.gridGV.Columns[16].Visible = false;
                
                userControlGiangVien.gridGV.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                userControlGiangVien.gridGV.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                userControlGiangVien.gridGV.Columns[7].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
            else if (isCheckUser == 5)
            {

                userControlGiangVien.gridGV.Columns[0].Visible =true;
                userControlGiangVien.gridGV.Columns[1].Visible =true;
                userControlGiangVien.gridGV.Columns[2].Visible =true;
                userControlGiangVien.gridGV.Columns[3].Visible =true;
                userControlGiangVien.gridGV.Columns[4].Visible =true;
                userControlGiangVien.gridGV.Columns[5].Visible =true;
                userControlGiangVien.gridGV.Columns[6].Visible =true;
                userControlGiangVien.gridGV.Columns[7].Visible =true;
                userControlGiangVien.gridGV.Columns[8].Visible = true;

                userControlGiangVien.gridGV.Columns[0].HeaderText = "TT";
                userControlGiangVien.gridGV.Columns[1].HeaderText = "NỘI DUNG CÔNG VIỆC";
                userControlGiangVien.gridGV.Columns[2].HeaderText = "TÊN LỚP";
                userControlGiangVien.gridGV.Columns[3].HeaderText = "HỆ ĐÀO TẠO";               
                userControlGiangVien.gridGV.Columns[4].HeaderText = "GIỜ KẾ HOẠCH LT";
                userControlGiangVien.gridGV.Columns[5].HeaderText = "GIỜ KẾ HOẠCH TH";
                userControlGiangVien.gridGV.Columns[6].HeaderText = "GIỜ QUY ĐỔI";
                userControlGiangVien.gridGV.Columns[7].HeaderText = "KIÊM NHIỆM";
                userControlGiangVien.gridGV.Columns[8].HeaderText = "TỔNG SỐ GIỜ";

                userControlGiangVien.gridGV.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                userControlGiangVien.gridGV.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                userControlGiangVien.gridGV.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                userControlGiangVien.gridGV.Columns[7].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }

        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            isCheckUser = 2;
            string sql = "select DISTINCT type_branch from class_section order by type_branch DESC";
            userControlGiangVien.bxGV.DataSource = getDataGV(sql).Tables[0];
            userControlGiangVien.bxGV.DisplayMember = getDataGV(sql).Tables[0].Columns[0].ToString();
            idMember = (string)((System.Data.DataRowView)userControlGiangVien.bxGV.SelectedItem).Row.ItemArray[0];
            txtHeader.Text = "Chương trình đào tạo";
            reloadData();
            headerRename();
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            txtHeader.Text = "Phòng học";
            isCheckUser = 3;
            reloadData();
            headerRename();
        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            txtHeader.Text = "Lương Giáo viên";
            isCheckUser = 5;
            string sql = "select CONCAT(last_name,' ', first_name),member_id from member where role = 1";
            userControlGiangVien.bxGV.DataSource = getDataGV(sql).Tables[0];
            userControlGiangVien.bxGV.DisplayMember = getDataGV(sql).Tables[0].Columns[0].ToString();
            idMember = (string)((System.Data.DataRowView)userControlGiangVien.bxGV.SelectedItem).Row.ItemArray[1];
            reloadData();
            userControlGiangVien.showHideItem(true);
            headerRename();

        }

        private DataSet getDataGV(string sql)
        {

            DataSet dataSet = new DataSet();
            try
            {
                using (connection = ketNoi.MoKetNoi())
                {
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        SqlDataAdapter adapter = new SqlDataAdapter(command);
                        adapter.Fill(dataSet);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return dataSet;
        }


        private void guna2Button9_Click(object sender, EventArgs e)
        {
            isCheckUser = 4;
            txtHeader.Text = "Lịch giảng dạy";
            string sql = "select CONCAT(last_name,' ', first_name),member_id from member where role = 1";
            userControlGiangVien.bxGV.DataSource = getDataGV(sql).Tables[0];
            userControlGiangVien.bxGV.DisplayMember = getDataGV(sql).Tables[0].Columns[0].ToString();
            reloadData();
            headerRename();
        }
    }
}
