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
    public partial class FormClassSection : Form
    {
        private connectDB ketNoi;
        private SqlConnection connection;
        public string ClassSectionCode;
        public delegate void LoadData();
        public LoadData LoadDataGrid;
        public string class_section_id;
        public FormClassSection()
        {
            InitializeComponent();
            ketNoi = new connectDB();
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void FormClassSection_Load(object sender, EventArgs e)
        {
            if (ClassSectionCode == "")
            {
                txtHeader.Text = "Thêm Học Phần";
                btnDelete.Visible = false;
                btnSave.Text = "Lưu";
                clearData();
            }
            else
            {
                txtHeader.Text = "Sửa Học Phần";
                btnDelete.Visible = true;
                btnSave.Text = "Sửa";
                getDataBycode();
            }

        }

        private void clearData()
        {
            txtCode.Text = "";
            txtName.Text = "";
            txtNumber_credits.Text = "";
            txt_pactice.Text = "";
            txt_theoty.Text = "";
            txttype.Text = "Cơ sở";
            txtsemester.Text = "";
            txtTC.Checked = false;
        }
        private void getDataBycode()
        {
            try
            {
                using (SqlConnection connection = ketNoi.MoKetNoi())
                {

                    var query = $"select * from class_section where class_section_code = '{ClassSectionCode}'";


                    using (SqlCommand command = new SqlCommand(query, connection))
                    {

                        // Thực hiện câu lệnh INSERT
                        var reader = command.ExecuteReader();

                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                txtCode.Text = reader["class_section_code"].ToString();
                                txtName.Text = reader["class_section_name"].ToString();
                                txtNumber_credits.Text = reader["number_credits"].ToString();
                                txt_pactice.Text = reader["practice"].ToString();
                                txt_theoty.Text = reader["theory"].ToString();
                                txttype.Text = reader["type"].ToString();
                                txtsemester.Text = reader["semester"].ToString();
                                class_section_id = reader["class_section_id"].ToString();
                                txt_nganh.Text = reader["type_branch"].ToString();

                                if ((Int32)(reader["elective"]) == 0)
                                {
                                    txtTC.Checked = false;
                                }
                                else if ((Int32)(reader["elective"]) == 1)
                                {
                                    txtTC.Checked = true;
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

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtCode.Text.Trim() == "" || txtName.Text.Trim() == "")
            {
                MessageBox.Show("Vui lòng nhập đủ thông tin", "Lưu thất bại",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            saveData(0);
        }
        void saveData(int state)
        {
            try
            {
                using (SqlConnection connection = ketNoi.MoKetNoi())
                {
                    string query = "";
                    if (state == 0)
                    {
                        if (ClassSectionCode == "")
                        {
                            query = "INSERT INTO [dbo].[class_section] ([class_section_id],[class_section_name],[number_credits],[class_section_code],[theory],[practice],[elective],[semester],[type],[type_branch]) VALUES(NEWID(),@class_section_name,@number_credits,@class_section_code,@theory,@practice,@elective,@semester,@type,@type_branch)";

                        }
                        else
                        {
                            query = "UPDATE [dbo].[class_section] SET [class_section_name] = @class_section_name,[number_credits] = @number_credits,[class_section_code] = @class_section_code ,[theory] = @theory,[practice] = @practice,[elective] = @elective,[semester] = @semester,[type] = @type,[type_branch] = @type_branch WHERE [class_section_id] = @class_section_id;";
                        }
                    }
                    else
                    {
                        query = "DELETE FROM [dbo].[class_section] WHERE [class_section_id] = @class_section_id";
                    }


                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        if (ClassSectionCode != "")
                        {
                            command.Parameters.AddWithValue("@class_section_id", class_section_id);

                        }
                        if (state == 0)
                        {
                            int isTC = 0;
                            if (txtTC.Checked)
                            {
                                isTC = 1;
                            }
                            // Truyền giá trị từ các controls vào câu lệnh SQL
                            command.Parameters.AddWithValue("@class_section_name", txtName.Text);
                            command.Parameters.AddWithValue("@number_credits", txtNumber_credits.Value);
                            command.Parameters.AddWithValue("@class_section_code", txtCode.Text);
                            command.Parameters.AddWithValue("@theory", txt_theoty.Value);
                            command.Parameters.AddWithValue("@elective", isTC);
                            command.Parameters.AddWithValue("@practice", txt_pactice.Value);
                            command.Parameters.AddWithValue("@semester", txtsemester.Value);
                            command.Parameters.AddWithValue("@type", txttype.Text);
                            command.Parameters.AddWithValue("@type_branch", txt_nganh.Text);


                        }

                        // Thực hiện câu lệnh INSERT
                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            if (state == 0)
                            {
                                MessageBox.Show("Lưu thành công.", "Lưu thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                MessageBox.Show("Xóa thành công", "Xóa thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            //LoadDataTabPage1(); // Cập nhật lại datagridview1 sau khi thêm
                            LoadDataGrid();
                            this.Hide();
                        }
                        else
                        {
                            MessageBox.Show("Thất bại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }            
            catch (Exception ex)
            {
                MessageBox.Show("Mã học phần đã tổn tại trong hệ thống", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                ketNoi.DongKetNoi(connection);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show($"Bạn có muốn xóa học phần '{txtName.Text}' không?", "Xóa", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                saveData(1);
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
