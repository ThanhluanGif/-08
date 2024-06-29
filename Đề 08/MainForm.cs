using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Đề_08
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();

            //Thiết lập giá trị mặc định cho các điều kiện
            SetDefaultValues();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            //Thiết lập giá trị mặc định cho các điều khiển khi Form load
            SetDefaultValues();
        }

        public void RefreshForm()
        {
            SetDefaultValues();
        }
        private void SetDefaultValues()
        {
            //Mặc định chọn hình thức Ăn tại quán
            rbtAnquan.Checked = true;

            //Tỉ lệ giảm thiết lập giá trị ban đầu là 0%
            txtbTilegiam.Text = 0+"%";

            //Tỉ lệ tiền giảm lập giá trị ban đầu là 0đ
            txtbTiengiam.Text = 0+"đ";

            //Tổng tiền thiết lập giá trị ban đầu là 0đ
            txtbTongtien.Text = 0+"đ";

            //Tổng tiền cần thanh toán thất lập giá trị ban đầu là 0đ
            txtTong.Text = 0+"đ";

            //Tổng tiền thiết lập giá trị ban đầu là 0đ
            txtbTongtien.Text = 0+"đ";

            //Thiết lập không chọn dữ liệu khi refresh
            checkBox1.Checked = false;
            checkBox2.Checked = false;
            checkBox3.Checked = false;
            checkBox4.Checked = false;
            checkBox5.Checked = false;
        }

        private void tbtThoat_Click(object sender, EventArgs e)
        {
            // Hiển thị hộp thoại xác nhận
            DialogResult result = MessageBox.Show("Bạn có muốn thoát không?", "Xác nhận",
                                                  MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            // Xử lý hành động dựa trên lựa chọn của người dùng
            if (result == DialogResult.Yes)
            {
                // Thoát khỏi chương trình
                Application.Exit();
            }
            // Nếu người dùng chọn No, không cần xử lý gì thêm vì sự kiện chỉ là để thoát
        }

        private void tbtLammoi_Click(object sender, EventArgs e)
        {
            RefreshForm();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            /*  if (checkBox1.Checked)
              {

                  txtbTongtien.Text = 250000+"đ";
              }
              else
              {
                  return ;
              }*/
            CalculateTotal();
        }

        private void txtbTongtien_TextChanged(object sender, EventArgs e)
        {
            CalculateTotal();
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            /*  if (checkBox2.Checked)
              {
                  txtbTongtien.Text = 220000 + "đ";
              }
              else
              {
                  return;
              }    */
            CalculateTotal();
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            /*  if (checkBox3.Checked)
              {
                  txtbTongtien.Text = 150000 + "đ";
              }
              else
              {
                  return;
              }    */
            CalculateTotal();
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            /* if (checkBox4.Checked)
             {
                 txtbTongtien.Text = 350000 + "đ";
             }
             else
             {
                 return;
             }*/
            CalculateTotal();
        }

        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {
            /* if (checkBox5.Checked)
             {
                 txtbTongtien.Text = 50000 + "đ";
             }
             else
             {
                 return;
             }*/
           CalculateTotal();
        }
        private int CalculateTotal()
        {
            int total  = 0;

            if (checkBox1.Checked)
            {
                total += 250000;
            }
            if (checkBox2.Checked)
            {
                total += 220000;
            }
            if (checkBox3.Checked)
            {
                total += 150000;
            }
            if (checkBox4.Checked)
            {
                total += 350000;
            }
            if (checkBox5.Checked)
            {
                total += 50000;
            }
            txtbTongtien.Text = total + "đ";
            return total;
        }

        private int CalculateDiscount(int total)
        {
            int count = CountCheckedCheckboxes();
            int discountPercentage = 0;

            if (count < 3)
            {
                discountPercentage = 5;
                if (!rbtAnquan.Checked)
                {
                    discountPercentage += 5; // Additional 5% for take-out with less than 3 items
                }
            }
            else
            {
                discountPercentage = 10;
                if (rbtAnquan.Checked)
                {
                    discountPercentage += 5; // Additional 5% for dine-in with 3 or more items
                }
                else
                {
                    discountPercentage += 10; // Additional 10% for take-out with 3 or more items
                }
            }

            txtbTilegiam.Text = discountPercentage + "%";

            return total * discountPercentage / 100;
        }

        private int CountCheckedCheckboxes()
        {
            int count = 0;
            if (checkBox1.Checked)
            {
                count++;
            }
            if (checkBox2.Checked)
            {
                count++;
            }
            if (checkBox3.Checked)
            {
                count++;
            }
            if (checkBox4.Checked)
            {
                count++;
            }
            if (checkBox5.Checked)
            {
                count++;
            }
            return count;
    }

        private void txtbTilegiam_TextChanged(object sender, EventArgs e)
        {
            CountCheckedCheckboxes();
        }

        private void tbtThuchien_Click(object sender, EventArgs e)
        {
            int total = CalculateTotal(); // Tính lại tổng tiền khi nhấn nút Thực hiện
            int discount = CalculateDiscount(total); // Tính tiền giảm giá
            txtTong.Text = (total - discount) + "đ"; // Hiển thị tổng tiền cần thanh toán
            txtbTiengiam.Text = discount + "đ";
        }

        private void txtbTiengiam_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
