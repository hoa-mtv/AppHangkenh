using Project.Model;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Project
{
    public partial class xuat : Form
    {
        HangKenhAppEntities db = new HangKenhAppEntities();
        public xuat()
        {
            InitializeComponent();
        }

        private void nhậpHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            nhap fr = new nhap();
            fr.Show();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            tem fr = new tem();
            fr.Show();
        }

        
        private void xuat_Load(object sender, EventArgs e)
        {
            string maphieu = common.getPhieuxuat();
            txtPhieuxuat.Text = maphieu;
        }
        private void guna2Button1_Click(object sender, EventArgs e)
        {
            //check info add
            /*
             kiểm tra xem phiếu đã có chưa. nếu có rồi thì ko cho sửa mấy info kia

             */
            string maphieu = txtPhieuxuat.Text.Trim();
            bool checkphieu = common.checkPhieuxuat(maphieu: maphieu);
            if(checkphieu==true)
            {
                notactive();
                //chir add bang chi tiet
            }
            else
            {
                //add cả 2 bảng
                var infoxuat = new XuatInfo();
                infoxuat.MaPhieu = txtPhieuxuat.Text.Trim();
                infoxuat.UserNhan = txtNguoinhan.Text.Trim();
                infoxuat.DateCreate =DateTime.Parse(txtdate.Text);
                db.XuatInfoes.Add(infoxuat);
                //add chi tieets xuat
                var detailxuat = new XuatDetail();
                detailxuat.XuatId = infoxuat.Id;
                detailxuat.PhieuYc = txtPhieuyc.Text.Trim();
                detailxuat.Trongluong =double.Parse(txtTrongluong.Text.Trim());
                detailxuat.Soluong = 1;
                detailxuat.MaHang = txtMahang.Text.Trim();
                db.XuatDetails.Add(detailxuat);
                try
                {
                    db.SaveChanges();

                }
                catch (Exception exx)
                {

                  
                }

            }
        }
        public void loaddata()
        {
            string sql = " select i.*,d.phieuyc,d.trongluong,d.soluong,d.mahang from xuatinfoes i ";
            sql += " inner join xuatdetails d on i.id = d.xuatid ";
            sql += " where 1=1 ";
            DataTable dt = System.Help.DataTable_Sql(sql);
            dataGridView1.DataSource = dt;
        }
        
        public void notactive()
        {
            txtPhieuxuat.ReadOnly = true;
            txtPhieuyc.ReadOnly = true;
            txtNguoinhan.ReadOnly = true;
        }
        public void active()
        {
            txtPhieuxuat.ReadOnly = false;
            txtPhieuyc.ReadOnly = false;
            txtNguoinhan.ReadOnly = false;
        }
    }
}
