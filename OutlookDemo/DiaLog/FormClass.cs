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
    public partial class FormClass : Form
    {
        private connectDB ketNoi;
        private SqlConnection connection;
        public string ClassCode;
        public delegate void LoadData();
        public LoadData LoadDataGrid;
        public string class_id;
        public FormClass()
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

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtCode.Text.Trim() == "" || txtclassName.Text.Trim() == "")
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
                        if (ClassCode == "")
                        {
                            query = "INSERT INTO [dbo].[class] ([class_id],[class_name],[class_code],[number_students],[memberId]) VALUES (NEWID(),@class_name,@class_code,@number_students,@memberId)";

                        }
                        else
                        {
                            query = "UPDATE [dbo].[class] SET [class_name] = @class_name,[class_code] = @class_code ,[number_students] = @number_students,[memberId] = @memberId WHERE [class_id] = @class_id ;";
                        }
                    }
                    else
                    {
                        query = "DELETE FROM [dbo].[class] WHERE [class_id] = @class_id";
                    }


                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        if (ClassCode != "")
                        {
                            command.Parameters.AddWithValue("@class_id", class_id);

                        }
                        if (state == 0)
                        {
                           
                            // Truyền giá trị từ các controls vào câu lệnh SQL
                            command.Parameters.AddWithValue("@class_name", txtclassName.Text);
                            command.Parameters.AddWithValue("@class_code", txtCode.Text);
                            command.Parameters.AddWithValue("@number_students", txtSS.Value);
                            command.Parameters.AddWithValue("@memberId", ((System.Data.DataRowView)txtCV.SelectedItem).Row.ItemArray[1]);                     


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
                                MessageBox.Show("Xóa thành công.", "Xóa thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                MessageBox.Show("Mã Giảng viên đã tổn tại trong hệ thống", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                ketNoi.DongKetNoi(connection);
            }
        }
        private void FormClass_Load(object sender, EventArgs e)
        {
            string sql = "select CONCAT(last_name,' ', first_name),member_id from member where role = 1";
            txtCV.DataSource = getDataGV(sql).Tables[0];
            txtCV.DisplayMember = getDataGV(sql).Tables[0].Columns[0].ToString();
            if (ClassCode == "")
            {
                txtHeader.Text = "Thêm Lớp Học";
                btnDelete.Visible = false;
                btnSave.Text = "Lưu";
                clearData();
            }
            else
            {
                txtHeader.Text = "Sửa Lớp Học";
                btnDelete.Visible = true;
                btnSave.Text = "Sửa";
                getDataBycode();
            }
            
        }

        private void clearData()
        {
            txtCode.Text = "";
            txtclassName.Text = "";
            txtCV.Text = "";
            txtSS.Value = 0;

        }
        private void getDataBycode()
        {
            try
            {
                using (SqlConnection connection = ketNoi.MoKetNoi())
                {

                    var query = $"select *,CONCAT(last_name,' ', first_name) as gvName from class inner join member on member_id = memberId where class_code = '{ClassCode}'";


                    using (SqlCommand command = new SqlCommand(query, connection))
                    {

                        var reader = command.ExecuteReader();

                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {

                                txtCode.Text = reader["class_code"].ToString();
                                txtclassName.Text = reader["class_name"].ToString();                                 
                                txtSS.Value = Int32.Parse(reader["number_students"].ToString());                                
                                txtCV.Text = reader["gvName"].ToString();
                                class_id = reader["class_id"].ToString();
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

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show($"Bạn có muốn xóa lớp '{txtclassName.Text}' không?", "Xóa lớp học", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                saveData(1);
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
