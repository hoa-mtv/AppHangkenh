using Project.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace Project
{
    public class common
    {
       
      
        public static string getPhieuxuat()
        {
            string Maphieu = "XK" + DateTime.Now.Year + "" + DateTime.Now.Month;
            string sql = " select maphieu from xuatinfoes  ";
            DataTable dt = Help.DataTable_Sql(sql);
            if(dt != null && dt.Rows.Count <= 0)
            {
                Maphieu += "001";
            }
            else
            {
                Maphieu += dt.Rows[0]["Maphieu"].ToString().Substring(dt.Rows[0]["Maphieu"].ToString().Length-3); 
            }
            return Maphieu;
        }
        public static bool checkPhieuxuat(string maphieu=null)
        {
            HangKenhAppEntities db = new HangKenhAppEntities();
            var check = db.XuatInfoes.Where(a => a.MaPhieu == maphieu).FirstOrDefault();
            if(check != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
