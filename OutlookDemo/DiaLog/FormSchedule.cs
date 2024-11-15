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
using System.Xml.Linq;
using static System.Runtime.CompilerServices.RuntimeHelpers;

namespace OutlookDemo.DiaLog
{
    public partial class FormSchedule : Form
    {
        private connectDB ketNoi;
        private SqlConnection connection;
        public delegate void LoadData();
        public LoadData LoadDataGrid;
        public FormSchedule()
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

        private void FormSchedule_Load(object sender, EventArgs e)
        {
            bxGV.DataSource = getData("select CONCAT(last_name,' ', first_name),member_id from member where role = 1").Tables[0];
            bxGV.DisplayMember = getData("select CONCAT(last_name,' ', first_name),member_id from member where role = 1").Tables[0].Columns[0].ToString();
            //idMember = (string)((System.Data.DataRowView)bxGV.SelectedItem).Row.ItemArray[1];

            bxHP.DataSource = getData("select class_section_name,class_section_id from class_section;").Tables[0];
            bxHP.DisplayMember = getData("select class_section_name,class_section_id from class_section;").Tables[0].Columns[0].ToString();

            bxPH.DataSource = getData("select class_room_number,class_room_id from class_room;;").Tables[0];
            bxPH.DisplayMember = getData("select class_room_number,class_room_id from class_room;;").Tables[0].Columns[0].ToString();
            if (ClassSectionCode == "")
            {
                txtHeader.Text = "Thêm lịch giảng dạy";
                btnDelete.Visible = false;
                btnSave.Text = "Lưu";
                clearData();
            }
            else
            {
                txtHeader.Text = "Sửa lịch giảng dạy";
                btnDelete.Visible = true;
                btnSave.Text = "Sửa";
                BydingData();
            }
        }
        private void clearData()
        {
            txt_name.Text = "";

        }

        public string vbxHP = "" ;
        public string vbxGV ="" ;
        public string vbxPH = "";
        public string vtxt_QD ;
        public int vnumber ;
        public int vtxt_KN ;
        public int vtxt_TE;
        public int vtxt_T;
        public int vtxt_TS;
        public DateTime vtxt_DS = DateTime.Now;
        public DateTime vtxt_DE = DateTime.Now;
        private void BydingData()
        {
            txt_name.Text = ClassSectionCode;
            bxHP.Text = vbxHP;
            bxGV.Text = vbxGV;
            txt_number.Value = vnumber;
            txt_KN.Value = vtxt_KN;
            txt_QD.Text = vtxt_QD;
            bxPH.Text = vbxPH;
            txt_T.Value = vtxt_T;
            txt_TS.Value = vtxt_TS;
            txt_DS.Value = vtxt_DS;
           txt_DE.Value = vtxt_DE;
           txt_TE.Value = vtxt_TE;

        }

        private DataSet getData(string sql)
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

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txt_name.Text.Trim() == "")
            {
                MessageBox.Show("Vui lòng nhập đủ thông tin.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            saveData(0);
        }

        public string class_credit_id;
        public string class_credit_room_id;
        public string ClassSectionCode = "";

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
                            query = "Insert_schedule @class_section_id ,@class_credit_name ,@member_id , @number_student, @redemption_time ,@red_theory ,@class_room_id,@weekdays ,@shift_start ,@start_day ,@end_day ,@shift_end;";

                        }
                        else
                        {
                            query = "EXECUTE Update_schedule @class_credit_id,@class_credit_room_id,@class_section_id,@class_credit_name,@member_id ,@number_student ,@redemption_time ,@red_theory ,@class_room_id ,@weekdays,@shift_start ,@start_day,@end_day,@shift_end";
                        }
                    }
                    else
                    {
                        query = "EXECUTE Delete_schedule @class_credit_id ,@class_credit_room_id";
                    }


                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        if (ClassSectionCode != "")
                        {
                            command.Parameters.AddWithValue("@class_credit_id", class_credit_id);
                            command.Parameters.AddWithValue("@class_credit_room_id", class_credit_room_id);

                        }
                        if (state == 0)
                        {

                            // Truyền giá trị từ các controls vào câu lệnh SQL
                            command.Parameters.AddWithValue("@class_section_id", (string)((System.Data.DataRowView)bxHP.SelectedItem).Row.ItemArray[1]);
                            command.Parameters.AddWithValue("@class_credit_name", txt_name.Text);
                            command.Parameters.AddWithValue("@member_id", (string)((System.Data.DataRowView)bxGV.SelectedItem).Row.ItemArray[1]);
                            command.Parameters.AddWithValue("@number_student", txt_number.Value);
                            command.Parameters.AddWithValue("@redemption_time", txt_KN.Value);
                            command.Parameters.AddWithValue("@red_theory", txt_QD.Value);
                            command.Parameters.AddWithValue("@class_room_id", (string)((System.Data.DataRowView)bxPH.SelectedItem).Row.ItemArray[1]);
                            command.Parameters.AddWithValue("@weekdays", txt_T.Value);
                            command.Parameters.AddWithValue("@shift_start", txt_TS.Value);
                            command.Parameters.AddWithValue("@start_day", txt_DS.Value);
                            command.Parameters.AddWithValue("@end_day", txt_DE.Value);
                            command.Parameters.AddWithValue("@shift_end", txt_TE.Value);


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
                MessageBox.Show("Mã đã tổn tại trong hệ thống", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                ketNoi.DongKetNoi(connection);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show($"Bạn có muốn xóa không?", "Xóa", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                saveData(1);
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void txtHeader_Click(object sender, EventArgs e)
        {

        }
    }

}
