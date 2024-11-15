using Microsoft.Office.Interop.Excel;
using OfficeOpenXml;
using OutlookDemo.DiaLog;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace OutlookDemo.UserControls
{
    public partial class UserControlGiangVien : UserControl
    {
        public UserControlGiangVien()
        {
            InitializeComponent();
        }

        public void showHideItem(bool ischeck)
        {
            bxGV.Visible = ischeck;
            laberGv.Visible = ischeck;
            txtMoney.Visible = ischeck;
            labelMoney.Visible = ischeck;
            txt_price.Visible = ischeck;
            price.Visible = ischeck;
            txtSumtime.Visible = ischeck;
            LabelSumTime.Visible = ischeck;
            btnAdd.Visible = !ischeck;

        }

        private void bxGV_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtMoney_Click(object sender, EventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {

        }
        public int checkEx = 2;
        private void guna2Button1_Click(object sender, EventArgs e)
        {
            List<string> listHeader = new List<string>();
            listHeader.Clear();
            switch (checkEx)
            {
                case 0:
                    // Giang vien
                    listHeader.Add("Thứ tự");
                    listHeader.Add("Mã Giảng Viên");
                    listHeader.Add("Tên Giảng Viên");
                    listHeader.Add("Giới Tính");
                    listHeader.Add("Ngày Sinh");
                    listHeader.Add("Quê Quán");
                    listHeader.Add("Học Vị");
                    listHeader.Add("Chức Danh");
                    //return;
                    break;
                case 1:
                    // lop co van
                    listHeader.Add("Thứ tự");
                    listHeader.Add("Tên Lớp");
                    listHeader.Add("Khoa");
                    listHeader.Add("Si Số");
                    listHeader.Add("Cố vấn học tập");
                    //return;
                    break;
                case 2:
                    // chuong trinh dao tao
                    listHeader.Add("Thứ tự");
                    listHeader.Add("Mã Lớp Học Phần");
                    listHeader.Add("Tên Lớp Học Phần");
                    listHeader.Add("Số Tín Chỉ");
                    listHeader.Add("Tiết lý thuyết");
                    listHeader.Add("Tiết Thực hành");
                    listHeader.Add("Tổng số tiết");
                    listHeader.Add("Đăng ký");
                    listHeader.Add("Kiến thức");
                    listHeader.Add("Kỳ học");
                    //return;
                    break;
                case 3:
                    // phong hoc
                    listHeader.Add("Thứ tự");
                    listHeader.Add("Tên Phòng học");
                    listHeader.Add("Tòa");
                    //return;
                    break;
                case 4:
                    // lich giang day
                    listHeader.Add("Thứ tự");
                    listHeader.Add("Mã học phần");
                    listHeader.Add("Tên học phần");
                    listHeader.Add("Tín chỉ");
                    listHeader.Add("Tên lớp tín chỉ");
                    listHeader.Add("Từ ngày");
                    listHeader.Add("Đến ngày");
                    listHeader.Add("Giảng viên");
                    listHeader.Add("Thời gian");
                    listHeader.Add("phòng học");
                    //return;
                    break;
                case 5:
                    // luong
                    listHeader.Add("Thứ tự");
                    listHeader.Add("NỘI DUNG CÔNG VIỆC");
                    listHeader.Add("TÊN LỚP");
                    listHeader.Add("HỆ ĐÀO TẠO");
                    listHeader.Add("GIỜ KẾ HOẠCH LÝ THUYẾT");
                    listHeader.Add("GIỜ KẾ HOẠCH THỰC HÀNH");
                    listHeader.Add("GIỜ QUY ĐỔI");
                    listHeader.Add("KIÊM NHIỆM");
                    listHeader.Add("TỔNG SỐ GIỜ");
                    break;
            }
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    
                    GenerateExcelFileAsync(listHeader, saveFileDialog1.FileName);
                    MessageBox.Show("Xuất dữ liệu ra Excel thành công!");

                }
                catch
                {
                    MessageBox.Show("Xuất dữ liệu ra Excel thất bại!");
                }


            }
        }

        public void GenerateExcelFileAsync(List<string> headers, string excelName)
        {


            using (ExcelPackage package = new ExcelPackage(excelName + ".xlsx"))
            {
                var sheet = package.Workbook.Worksheets.Add("sheet1");
                for (int i = 1; i <= headers.Count; i++)
                {
                    sheet.Column(i).AutoFit();
                    sheet.Cells[3, i].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Medium);
                    sheet.Cells[3, i].Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                    sheet.Cells[3, i].Style.Fill.BackgroundColor.SetColor(color: System.Drawing.Color.FromArgb(30988504));
                    sheet.Cells[3, i].Value = headers[i - 1];
                }

                if(checkEx == 5)
                {
                    sheet.Cells[2, 9].Value = "Thành tiền: Tổng số giờ: "+ txtSumtime.Text + " x(nhân) đơn giá: " + txt_price.Text + " = " + txtMoney.Text + "VNĐ";
                }                
                int row = 4;
                int index = 1;

                for (int i = 0; i < ((System.Data.DataTable)gridGV.DataSource).Rows.Count; i++)
                {
                    sheet.Cells[row, 1].Value = index;
                    for (int j = 2; j < headers.Count + 1; j++)
                    {
                        if (checkEx == 1)
                        {
                            if(j > 3)
                            {
                                sheet.Cells[row, j].Value = ((System.Data.DataTable)gridGV.DataSource).Rows[i][j].ToString();
                                continue;
                            }
                        }
                        sheet.Cells[row, j].Value = ((System.Data.DataTable)gridGV.DataSource).Rows[i][j - 1].ToString();
                        
                    }
                    index++;
                    row++;
                }

                row = 4;
                // Style
                foreach (var j in ((System.Data.DataTable)gridGV.DataSource).Rows)
                {                   

                    for (var i = 1; i <= headers.Count; i++)
                    {
                        sheet.Column(i).AutoFit();
                        sheet.Cells[row, i].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Medium);

                    }
                    row++;
                }
                package.Save();
            }


        }
    }
}
