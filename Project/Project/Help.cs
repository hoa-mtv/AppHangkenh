using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
namespace System
{
    public class Help
    {
        //public static string stringConn = "Data Source=192.168.1.202;initial catalog=MinhDoanPro;Uid=Outnerr;Pwd=5RutE5gUhM3omJ";//max pool size=1
        public static string stringConn = "Data Source=DESKTOP-1NTRD12\\SQLEXPRESS;initial catalog=HangKenhApp;Uid=sa;Pwd=12345678";//max pool size=1


        public static SqlConnection open()
        {
            return new SqlConnection(stringConn);
        }
        public static DataTable DataTable_Sql(string sql)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(stringConn))
                {
                    using (SqlDataAdapter dap = new SqlDataAdapter(sql, conn))
                    {
                        using (DataSet ds = new DataSet())
                        {
                            dap.Fill(ds);
                            conn.Close();
                            conn.Dispose();
                            return ds.Tables[0];
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
          public static List<DataTable> DataTable_Sql2(string sql=null,int rowpage=0,int? page=1,string order= null)
        {
           string strQuery = " SELECT  COUNT_BIG(*) AS TotalRows FROM #TEMP ";
            strQuery += " SELECT * FROM #TEMP  ";
            strQuery += " ORDER BY "+order+"  ";
            strQuery += " OFFSET " + rowpage + " * (" + page + " - 1) ROWS FETCH NEXT " + rowpage + "  ROWS ONLY ";
            strQuery += " OPTION(RECOMPILE) ";

            strQuery += " DROP TABLE IF EXISTS #TEMP";
            sql += strQuery;
            List<DataTable> Listdt = new List<DataTable>();
            try
            {
                using (SqlConnection conn = new SqlConnection(stringConn))
                {
                    using (SqlDataAdapter dap = new SqlDataAdapter(sql, conn))
                    {
                        using (DataSet ds = new DataSet())
                        {
                            dap.Fill(ds);
                            conn.Close();
                            conn.Dispose();
                            Listdt.Add(ds.Tables[0]);
                            Listdt.Add(ds.Tables[1]);
                            return Listdt;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static int[] infopaging(List<DataTable> dts = null,int? page=1,int rowpage=0,int offset=0)
        {
            int TotalRow = int.Parse(dts[0].Rows[0]["TotalRows"].ToString());
            int limit = rowpage;
            int start;
            if (page > 0)
            {
                page = page;
            }
            else
            {
                page = 1;
            }
            start = (int)(page - 1) * limit;
            string abc = page.ToString();
            int pagecurrent = 0;
            try
            {
                 pagecurrent = int.Parse(abc);
            }
            catch (Exception)
            {

                
            }
           

            int totalProduct = TotalRow;

           
            double a = TotalRow / rowpage;

            int TotalPage = (int)Math.Ceiling(double.Parse(TotalRow.ToString()) / rowpage);
            int[] data = { TotalPage, pagecurrent, offset,TotalRow }; //totalpage,currentpage,offset, totalrow
            return data;
        }
        public static DataTable Querry(string strSQL, SqlParameter[] prs, CommandType cmtype)
        {
            DataTable dt = new DataTable();
            SqlDataReader reader = null;
            SqlConnection sqlCon = new SqlConnection(stringConn);
            SqlCommand sqlCmd = null;

            try
            {
                sqlCon.Open();
                dt = new DataTable();
                sqlCmd = sqlCon.CreateCommand();

                sqlCmd.CommandType = cmtype;
                sqlCmd.CommandText = strSQL;
                if (prs != null)
                {
                    sqlCmd.Parameters.AddRange(prs);
                }
                reader = sqlCmd.ExecuteReader();
                dt.Load(reader);
            }
            catch (Exception e)
            {
                e.GetBaseException();
                throw e;
            }
            finally
            {
                if (reader != null)
                {
                    reader.Close();
                }
                sqlCon.Close();
            }
            return dt;
        }
        public static DataTable exe_table(string sql, SqlParameter[] prs, CommandType cmtype)
        {
            SqlDataReader reader = null;
            DataTable dt = new DataTable();
            SqlConnection sqlcon = new SqlConnection(stringConn);
            try
            {
                    sqlcon.Open();
                    SqlCommand cmd = new SqlCommand();
                    cmd = sqlcon.CreateCommand();
                    cmd.CommandType = cmtype;
                    cmd.CommandText = sql;
                    if (prs != null)
                    {
                        cmd.Parameters.AddRange(prs);
                    }
                    reader = cmd.ExecuteReader();
                    dt.Load(reader);
                    sqlcon.Dispose();
                    sqlcon.Close();
                    return dt;
               
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
       
      

        
        
       
        public static int none_query(string sql, SqlParameter[] prs, CommandType cmtype)
        {
            SqlConnection conn = new SqlConnection(stringConn);
            SqlCommand cmd = new SqlCommand(sql, conn);
            int row = 0;
            conn.Open();

            cmd.CommandType = cmtype;
            cmd.CommandText = sql;
            if (prs != null)
            {
                cmd.Parameters.AddRange(prs);
            }
            row = cmd.ExecuteNonQuery();
            conn.Dispose();
            conn.Close();
            return row;
        }
        public static int exe_NoneSql(string sql)
        {
            SqlConnection conn = new SqlConnection(stringConn);
            SqlCommand cmd = new SqlCommand(sql, conn);
            int row = 0;
            conn.Open();

            cmd.CommandType = CommandType.Text;
            cmd.CommandText = sql;
            row = cmd.ExecuteNonQuery();
            conn.Dispose();
            conn.Close();
            return row;
        }
        /**
         * thangngueyn
         * Check exists record
         */
        public static bool CheckExist(string sql)
        {
            DataTable dtb = new DataTable();
            dtb = DataTable_Sql(sql);
            if (dtb.Rows.Count > 0) return true;
            return false;
        }

        public static string image(string code)
        {

            return "http://localhost/image?code=" + code;
        }

         public static DataTable GetPagedTable (DataTable dt, int PageIndex=0 , int PageSize=0)
            {
             
                if (PageIndex == 0)
                return dt;
                DataTable newdt = dt.Copy ();
                newdt.Clear ();
                 int rowbegin = (PageIndex - 1 ) * PageSize;
                int rowend = PageIndex * PageSize;
                if (rowbegin >= dt.Rows.Count)
                return newdt;
                if (rowend> dt.Rows.Count)
                rowend = dt.Rows.Count;
                for (int i = rowbegin; i <= rowend - 1 ; i++)
                {
                    DataRow newdr = newdt.NewRow ();
                    DataRow dr = dt.Rows [i];
                    foreach (DataColumn column in dt.Columns)
                    {
                    newdr [column.ColumnName] = dr [column.ColumnName];
                    }
                    newdt.Rows.Add (newdr);
                }
                return newdt;
            }
        public static int get_number(string type = null,string area=null,string role=null)
        {
            string table = "";
            if (type == "input")
            {
                table = "InputForms";
            }
            else if (type == "output")
            {
                table = "OutForms";
            }
            string sql = "  select count(Number) count from " + table + " ";
            sql+=" where complete is not null and (UserApprove is null  or UserApprove ='')   ";
            if(role !="Pgd" && role !="Gd")                                                 
            {
                sql += " and SUBSTRING(number,4,1) = '"+area+"' ";
            }
           
            //sql += " group by Number ";
            DataTable dt = Help.DataTable_Sql(sql);
            int count = 0;
            if (dt != null)
            {
                try
                {
                    count = int.Parse(dt.Rows[0]["count"].ToString());
                }
                catch (Exception)
                {

                  
                }
                
            }
            return count;
        }
        public static int get_quy(string area = null, string role = null)
        {
            string sql = "select count(id) count from QuyTotals where (UserApprove is null or UserApprove='') ";
            if (role != "Pgd" && role != "Gd")
            {
                sql += " and area = '" + area + "' ";
            }
            int count = 0;
            DataTable dt = Help.DataTable_Sql(sql);
            if (dt != null)
            {
                try
                {
                    count = int.Parse(dt.Rows[0]["count"].ToString());
                }
                catch (Exception)
                {


                }

            }
            return count;
        }
    }
    public class help2
    {
        public static string stringConn = "data source=10.120.112.215;initial catalog=API_Server_Test;Uid=production;Pwd=MeikoT@2020";//max pool size=1
        public static SqlConnection open()
        {
            return new SqlConnection(stringConn);
        }
        public static DataTable DataTable_Sql(string sql)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(stringConn))
                {
                    using (SqlDataAdapter dap = new SqlDataAdapter(sql, conn))
                    {
                        using (DataSet ds = new DataSet())
                        {
                            dap.Fill(ds);
                            conn.Close();
                            conn.Dispose();
                            return ds.Tables[0];
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}