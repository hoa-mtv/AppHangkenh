using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using Project.Model;

namespace Project
{
    public partial class Form1 : Form
    {
        HangKenhAppEntities db = new HangKenhAppEntities();
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //kiểm tra xem user naem + mk đugns chưa
            try
            {
                var a = db.tests.ToList();
            }
            catch (Exception ex)
            {

                throw;
            }
           
             xuat fr = new xuat();
            fr.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
