using quanLyGV.entity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OutlookDemo.DiaLog
{
    public partial class ActionUserForm : Form
    {
        private connectDB ketNoi;
        private SqlConnection connection;
        public string memberCode;
        public delegate void LoadData();
        public LoadData LoadDataGrid;
        public string idMember;



        public ActionUserForm()
        {
            InitializeComponent();
            ketNoi = new connectDB();

        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            if (txtLastName.Text == "" || txtCode.Text == "" || txtEmail.Text == "" || txtHV.Text == "" || txtSDT.Text == "" || txtUserName.Text == "" || txtPass.Text == "" || txtSDT.Text == "")
            {
                MessageBox.Show("Vui lòng nhập đủ thông tin", "Lưu thất bại",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if(txt_price.Value > 100000)
            {
                MessageBox.Show("Đơn giá không hợp lệ ! ", "Lưu thất bại",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            saveData(0);       
     
        }

        void saveData(int state)
        {
            int gender = 0;
            if (RadioNu.Checked)
            {
                gender = 1;
            }
            else if (RadioKhac.Checked)
            {
                gender = 2;
            }
            try
            {
                using (SqlConnection connection = ketNoi.MoKetNoi())
                {
                    string query = "";
                    if(state == 0)
                    {
                        if (memberCode == "")
                        {
                            query = "INSERT INTO [dbo].[member]([member_id],[member_name],[pass_word],[last_name],[first_name],[role],[gender],[member_code],[dateOfbirth],[hometown],[degree],[email],[phone_number],[unit_price],[concurrently],[Position]) " +
                                                         "VALUES(NEWID(),@member_name,@pass_word,@last_name,@first_name,1,@gender,@member_code,@dateOfbirth,@hometown,@degree,@email,@phone_number,@unit_price,@concurrently,@Position)";

                        }
                        else
                        {
                            query = "UPDATE [dbo].[member] SET [member_name] = @member_name,[pass_word] = @pass_word,[last_name] = @last_name,[first_name] = @first_name,[gender] = @gender,[member_code] = @member_code,[dateOfbirth] = @dateOfbirth,[hometown] = @hometown,[degree] = @degree,[email] = @email,[phone_number] = @phone_number,[unit_price] = @unit_price ,[concurrently] = @concurrently,[Position] = @Position WHERE [member_id] = @member_id";
                        }
                    }
                    else
                    {
                        query = "DELETE FROM [dbo].[member] WHERE member_id = @member_id";
                    }
                   

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        if(memberCode != "")
                        {
                            command.Parameters.AddWithValue("@member_id", idMember);

                        }
                        if(state == 0)
                        {
                            // Truyền giá trị từ các controls vào câu lệnh SQL
                            command.Parameters.AddWithValue("@member_name", txtUserName.Text);
                            command.Parameters.AddWithValue("@pass_word", txtPass.Text);
                            command.Parameters.AddWithValue("@last_name", txtLastName.Text);
                            command.Parameters.AddWithValue("@first_name", txtFisrtName.Text);
                            command.Parameters.AddWithValue("@gender", gender);
                            command.Parameters.AddWithValue("@member_code", txtCode.Text);
                            command.Parameters.AddWithValue("@dateOfbirth", Convert.ToDateTime(txtDOB.Value));
                            command.Parameters.AddWithValue("@hometown", txtQQ.Text);
                            command.Parameters.AddWithValue("@degree", txtHV.Text);
                            command.Parameters.AddWithValue("@email", txtEmail.Text);
                            command.Parameters.AddWithValue("@phone_number", txtSDT.Text);
                            command.Parameters.AddWithValue("@unit_price", txt_price.Value);
                            command.Parameters.AddWithValue("@concurrently", txt_KN.Value);
                            command.Parameters.AddWithValue("@Position", txt_CD.Text);
                        }                        

                        // Thực hiện câu lệnh INSERT
                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Lưu thành công.", "Lưu thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            //LoadDataTabPage1(); // Cập nhật lại datagridview1 sau khi thêm
                            LoadDataGrid();
                                 this.Hide();
                        }
                        else
                        {
                            MessageBox.Show("Xóa thành công.", "Xóa thành công", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Mã Giảng viên đã tổn tại trong hệ thống", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                ketNoi.DongKetNoi(connection);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void ActionUserForm_Load(object sender, EventArgs e)
        {
            idMember = "";
            if (memberCode == "")
            {
                txtHeaderAddmember.Text = "Thêm Giảng viên";
                btnDelete.Visible = false;
                btnSave.Text = "Lưu";
                clearData();
            }
            else
            {
                txtHeaderAddmember.Text = "Sửa Giảng viên";
                btnDelete.Visible = true;
                btnSave.Text = "Sửa";
                getDataBycode(memberCode);
            }

        }
        private void clearData()
        {
            txtCode.Text = "";
            txtFisrtName.Text = "";
            txtLastName.Text = "";
            txtEmail.Text = "";
            txtHV.Text = "";
            txtPass.Text ="";
            txtSDT.Text = "";
            txtQQ.Text ="";
            txtDOB.Value = DateTime.Now;
            txtPass.Text = "";
            RadioNam.Checked = true;
            RadioNu.Checked = false;
            RadioKhac.Checked = false;
            txt_price.Value = 0;
            txt_KN.Value = 0;
            txt_CD.Text = "";

        }

        private void getDataBycode(string code)
        {
            try
            {
                using (SqlConnection connection = ketNoi.MoKetNoi())
                {

                    var query = $"select * from member where member_code = '{code}'";


                    using (SqlCommand command = new SqlCommand(query, connection))
                    {                      

                        // Thực hiện câu lệnh INSERT
                        var reader = command.ExecuteReader();

                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                idMember = reader["member_id"].ToString();
                                txtCode.Text = reader["member_code"].ToString();
                                txtFisrtName.Text = reader["first_name"].ToString(); 
                                txtLastName.Text = reader["last_name"].ToString();
                                txtEmail.Text = reader["email"].ToString();
                                txtHV.Text = reader["degree"].ToString();
                                txtPass.Text = reader["member_code"].ToString();
                                txtSDT.Text = reader["phone_number"].ToString();
                                txtQQ.Text = reader["hometown"].ToString();
                                txtDOB.Value = new DateTime(((DateTime)reader["dateOfbirth"]).Year, ((DateTime)reader["dateOfbirth"]).Month, ((DateTime)reader["dateOfbirth"]).Day, 0, 0, 0);
                                txtPass.Text = reader["pass_word"].ToString();
                                txtUserName.Text = reader["member_name"].ToString();
                                txt_price.Text = reader["unit_price"].ToString();
                                txt_KN.Text = reader["concurrently"].ToString();
                                txt_CD.Text = reader["Position"].ToString(); 
                                if ((Int32)(reader["gender"]) == 0)
                                {
                                    RadioNam.Checked = true;
                                    RadioNu.Checked = false;
                                    RadioKhac.Checked = false;
                                }
                                else if ((Int32)(reader["gender"]) == 1)
                                {
                                    RadioNam.Checked = false;
                                    RadioNu.Checked = true;
                                    RadioKhac.Checked = false;
                                }
                                else
                                {
                                    RadioNam.Checked = false;
                                    RadioNu.Checked = false;
                                    RadioKhac.Checked = true;
                                }

                            }
                        }
                        else
                        {
                            Console.WriteLine("Không có dữ liệu trả về");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lôi xảy ra vui lòng liên hệ dev!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                ketNoi.DongKetNoi(connection);
            }

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (memberCode != "")
            {
                DialogResult dialogResult = MessageBox.Show($"Bạn có muốn xóa giảng viên '{txtCode.Text}' không?","Xóa Giảng viên", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    saveData(1);
                }              
            }
            
        }
    }
}
