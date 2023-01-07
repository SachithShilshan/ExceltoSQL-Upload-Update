using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;


namespace EtoSQL3
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Unnamed3_Click(object sender, EventArgs e)
        {
            int rollno;
            String sname;
            String fname;
            String mname;
            string path = Path.GetFileName(FileUpload1.FileName);
            path = path.Replace(" ", "");
            FileUpload1.SaveAs(Server.MapPath("~/ExcelFile/") + path);
            String ExcelPath = Server.MapPath("~/ExcelFile/") + path;
            OleDbConnection mycon = new OleDbConnection("Provider = Microsoft.ACE.OLEDB.12.0; Data Source = " + ExcelPath + "; Extended Properties=Excel 8.0; Persist Security Info = False");
            mycon.Open();
            OleDbCommand cmd = new OleDbCommand("select * from [Sheet1$]", mycon);
            OleDbDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                if (dr[0].ToString() != "")
                {
                    // Response.Write("<br/>"+dr[0].ToString());
                    rollno = Convert.ToInt32(dr[0].ToString());
                    sname = dr[1].ToString();
                    fname = dr[2].ToString();
                    mname = dr[3].ToString();
                    UpdateDatabase(rollno, sname, fname, mname);
                }
                else
                {
                    break;
                }



            }
            Label4.Text = "Data Has Been Updated Successfully";
            mycon.Close();

            File.Delete(ExcelPath);

        }

        private void UpdateDatabase(int rollno1, String sname1, String fname1, String mname1)
        {
            String query = "update studentdetail set sname='" + sname1 + "', fathername='" + fname1 + "', mothername='" + mname1 + "' where rollno=" + rollno1;
            String mycon = "Data Source=DESKTOP-2KR4GNF\\SQLEXPRESS;Initial Catalog=test3;Integrated Security=True";
            SqlConnection con = new SqlConnection(mycon);
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = query;
            cmd.Connection = con;
            cmd.ExecuteNonQuery();

        }

        protected void Unnamed_Click(object sender, EventArgs e)
        {
            int rollno;
            String sname;
            String fname;
            String mname;
            string path = Path.GetFileName(FileUpload.FileName);
            path = path.Replace(" ", "");
            FileUpload.SaveAs(Server.MapPath("~/ExcelFile/") + path);
            String ExcelPath = Server.MapPath("~/ExcelFile/") + path;
            OleDbConnection mycon = new OleDbConnection("Provider = Microsoft.ACE.OLEDB.12.0; Data Source = " + ExcelPath + "; Extended Properties=Excel 8.0; Persist Security Info = False");
            mycon.Open();
            OleDbCommand cmd = new OleDbCommand("select * from [Sheet1$]", mycon);
            OleDbDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                // Response.Write("<br/>"+dr[0].ToString());
                rollno = Convert.ToInt32(dr[0].ToString());
                sname = dr[1].ToString();
                fname = dr[2].ToString();
                mname = dr[3].ToString();
                savedata(rollno, sname, fname, mname);
            }
            Label3.Text = "Data Has Been Saved Successfully";
        }

        private void savedata(int rollno1, String sname1, String fname1, String mname1)
        {
            String query = "insert into studentdetail values(" + rollno1 + ",'" + sname1 + "','" + fname1 + "','" + mname1 + "')";
            String mycon = "Data Source=DESKTOP-2KR4GNF\\SQLEXPRESS;Initial Catalog=test3;Integrated Security=True";
            SqlConnection con = new SqlConnection(mycon);
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = query;
            cmd.Connection = con;
            cmd.ExecuteNonQuery();

        }
    }
}