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

namespace OutlookDemo
{
    public partial class FormLogin : Form
    {
        private connectDB ketNoi;
        private SqlConnection connection;     
        public FormLogin()
        {
            ketNoi = new connectDB();
            InitializeComponent();
            LoadSavedCredentials();
        }

        private void closebtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void LoadSavedCredentials()
        {
            // Load thông tin tài khoản nếu có
            if (!string.IsNullOrEmpty(Properties.Settings.Default.TaiKhoan) && !string.IsNullOrEmpty(Properties.Settings.Default.MatKhau) )
            {
                txtTaiKhoan.Text = Properties.Settings.Default.TaiKhoan;
                txtMatKhau.Text = Properties.Settings.Default.MatKhau;
                checkBox1.Checked = true;
            }
        }
        private void SaveCredentials()
        {
            // Lưu tài khoản và mật khẩu
            Properties.Settings.Default.TaiKhoan = txtTaiKhoan.Text;
            Properties.Settings.Default.MatKhau = txtMatKhau.Text;
            Properties.Settings.Default.Save();
        }
        private void ClearSavedCredentials()
        {
            // Xóa thông tin tài khoản và mật khẩu
            Properties.Settings.Default.TaiKhoan = string.Empty;
            Properties.Settings.Default.MatKhau = string.Empty;
            Properties.Settings.Default.Save();
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            string taiKhoan = txtTaiKhoan.Text;
            string matKhau = txtMatKhau.Text;

            // Kiểm tra tài khoản và mật khẩu từ cơ sở dữ liệu
            if (KiemTraDangNhap(taiKhoan, matKhau))
            {
                // Nếu đăng nhập thành công, chuyển qua form TrangChu
                Form1 trangChuForm = new Form1();
                trangChuForm.Show();
                this.Hide(); // Ẩn form đăng nhập
            }
            else
            {
                MessageBox.Show("Tài khoản hoặc mật khẩu không đúng. Vui lòng thử lại.", "Lỗi đăng nhập", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            // Lưu tài khoản và mật khẩu nếu checkbox được chọn
            if (checkBox1.Checked)
            {
                SaveCredentials();
            }
            else
            {
                ClearSavedCredentials();
            }
        }

        private bool KiemTraDangNhap(string taiKhoan, string matKhau)
        {
            try
            {
                using (connection = ketNoi.MoKetNoi())
                {
                    //string query = "SELECT * FROM member WHERE member_name = @TaiKhoan AND pass_word = @MatKhau and role = 0";
                    string query = "SELECT * FROM member WHERE member_name = @TaiKhoan AND pass_word = @MatKhau";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@TaiKhoan", taiKhoan);
                        command.Parameters.AddWithValue("@MatKhau", matKhau);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            return reader.HasRows;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đăng nhập thất bại");
                return false;
            }
            finally
            {
                ketNoi.DongKetNoi(connection);
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            // Lưu tài khoản và mật khẩu nếu checkbox được chọn
            if (checkBox1.Checked)
            {
                SaveCredentials();
            }
            else
            {
                ClearSavedCredentials();
            }
        }

        private void txtMatKhau_IconRightClick(object sender, EventArgs e)
        {
            txtMatKhau.UseSystemPasswordChar = !txtMatKhau.UseSystemPasswordChar;
        }
    }
}
