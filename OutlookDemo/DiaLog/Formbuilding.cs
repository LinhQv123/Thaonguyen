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
    public partial class Formbuilding : Form
    {
        private connectDB ketNoi;
        private SqlConnection connection;
        public string roomCode;
        public delegate void LoadData();
        public LoadData LoadDataGrid;
        public string room_id;
        public Formbuilding()
        {
            ketNoi = new connectDB();
            InitializeComponent();
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
            if (txtNameRoom.Text.Trim() == "" || txtNameBuilding.Text.Trim() == "")
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
                        if (roomCode == "")
                        {
                            query = "INSERT INTO [dbo].[class_room]([class_room_id],[class_room_number],[building])VALUES(NEWID(),@class_room_number,@building)";

                        }
                        else
                        {
                            query = "UPDATE [dbo].[class_room] SET [class_room_number] = @class_room_number ,[building] = @building WHERE [class_room_id] = @class_room_id;";
                        }
                    }
                    else
                    {
                        query = "DELETE FROM [dbo].[class_room] WHERE [class_room_id] = @class_room_id;";
                    }


                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        if (roomCode != "")
                        {
                            command.Parameters.AddWithValue("@class_room_id", room_id);

                        }
                        if (state == 0)
                        {

                            // Truyền giá trị từ các controls vào câu lệnh SQL
                            command.Parameters.AddWithValue("@class_room_number", txtNameRoom.Text);
                            command.Parameters.AddWithValue("@building", txtNameBuilding.Text);


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
                MessageBox.Show("Mã phòng học đã tổn tại trong hệ thống", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                ketNoi.DongKetNoi(connection);
            }
        }

        private void Formbuilding_Load(object sender, EventArgs e)
        {

            if (roomCode == "")
            {
                txtHeader.Text = "Thêm Phòng Học";
                btnDelete.Visible = false;
                btnSave.Text = "Lưu";
                clearData();
            }
            else
            {
                txtHeader.Text = "Sửa Phòng Học";
                btnDelete.Visible = true;
                btnSave.Text = "Sửa";
                btnSave.Text = "Sửa";
                getDataBycode();
            }
        }

        private void clearData()
        {
            txtNameRoom.Text = "";
            txtNameBuilding.Text = "";         

        }
        private void getDataBycode()
        {
            try
            {
                using (SqlConnection connection = ketNoi.MoKetNoi())
                {

                    var query = $"select * from class_room where class_room_number = '{roomCode}'";


                    using (SqlCommand command = new SqlCommand(query, connection))
                    {

                        var reader = command.ExecuteReader();

                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {

                                txtNameRoom.Text = reader["class_room_number"].ToString();
                                txtNameBuilding.Text = reader["building"].ToString();                                
                                room_id = reader["class_room_id"].ToString();
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
            DialogResult dialogResult = MessageBox.Show($"Bạn có muốn xóa phòng học '{txtNameRoom.Text}' không?", "Xóa phòng học", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                saveData(1);
            }
        }
    }
}
