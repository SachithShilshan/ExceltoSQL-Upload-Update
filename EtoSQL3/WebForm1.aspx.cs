using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Web;
using System.Web.Services.Description;
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

        protected void Upload_Click(object sender, EventArgs e) 
        {
            string module;
            String material;
            String fG_Referance;
            String customer_Style;

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
                module = dr[0].ToString();
                material = dr[1].ToString();
                fG_Referance = dr[2].ToString();
                customer_Style = dr[3].ToString();
                
                // Response.Write("<br/>"+dr[0].ToString());
                /* Module = dr[0].ToString();
                 Material = Convert.ToInt32(dr[1].ToString());
                 FG_Referance = dr[2].ToString();
                 Customer_Style = dr[3].ToString();*/
                /*Color_Description = dr[4].ToString();
                Subcon_Type= dr[5].ToString();
                Description = dr[6].ToString();
                Fabric_Design = dr[7].ToString();
                Order_Reason = dr[8].ToString();
                Special_Services = dr[9].ToString();
                CPO = dr[10].ToString();
                Region_Country = dr[11].ToString();
                Name = dr[12].ToString();
                Start_date = dr[13].ToString();
                Finish_date = dr[14].ToString();*/
                savedata(module, material, fG_Referance, customer_Style);
                //savedata(Module, Material, FG_Referance, Customer_Style);
                // savedata(Module, Material, FG_Referance, Customer_Style, Color_Description, Subcon_Type, Description, Fabric_Design, Order_Reason, Special_Services, CPO, Region_Country, Name, Start_date, Finish_date);
            }
            Label3.Text = "Data Has Been Saved Successfully";
        }

        protected void Update_Click(object sender, EventArgs e)
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

        protected void Delete_Upload_Click(object sender, EventArgs e)
        {
            string module;
            String material;
            String fG_Referance;
            String customer_Style;
            string path = Path.GetFileName(FileUpload2.FileName);
            path = path.Replace(" ", "");
            FileUpload2.SaveAs(Server.MapPath("~/ExcelFile/") + path);
            String ExcelPath = Server.MapPath("~/ExcelFile/") + path;
            OleDbConnection mycon = new OleDbConnection("Provider = Microsoft.ACE.OLEDB.12.0; Data Source = " + ExcelPath + "; Extended Properties=Excel 8.0; Persist Security Info = False");
            mycon.Open();
            OleDbCommand cmd = new OleDbCommand("select * from [Sheet1$]", mycon);
            OleDbDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                // if (dr[0].ToString() == "")
                // {
                // Response.Write("<br/>"+dr[0].ToString());
                module = dr[0].ToString();
                material = dr[1].ToString();
                fG_Referance = dr[2].ToString();
                customer_Style = dr[3].ToString();
                //UpdateDatabase(rollno, sname, fname, mname);
                deletedata(module, material, fG_Referance, customer_Style);
                //savedata(rollno, sname, fname, mname);
                break;   
              /*  }
                else
                {
                    break;
                }*/
            }
            dr.Close();
            Label5.Text = "Data Has Been Deleted Successfully";

            //mycon.Close();
            //File.Delete(ExcelPath);

            ///insert////
            OleDbDataReader dr1 = cmd.ExecuteReader();
            while (dr1.Read())
            {
                // Response.Write("<br/>"+dr[0].ToString());
                module = dr1[0].ToString();
                material = dr1[1].ToString();
                fG_Referance = dr1[2].ToString();
                customer_Style = dr1[3].ToString();

                savedata(module, material, fG_Referance, customer_Style); //req....
            }
            Label3.Text = "Data Has Been Saved Successfully";
            mycon.Close();
            File.Delete(ExcelPath);
        }

        /////////////////////////////////////////////////////////////////

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

        private void savedata(String module1, String material1, String FG_Referance1, String Customer_Style1)
        {
            String query = "insert into studentdetail values('" + module1 + "','" + material1 + "','" + FG_Referance1 + "','" + Customer_Style1 + "')";
            String mycon = "Data Source=DESKTOP-2KR4GNF\\SQLEXPRESS;Initial Catalog=test2;Integrated Security=True";
            SqlConnection con = new SqlConnection(mycon);
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = query;
            cmd.Connection = con;
            cmd.ExecuteNonQuery();

        }

        private void deletedata(String module1, String material1, String FG_Referance1, String Customer_Style1)
        {
            String query = "delete from studentdetail where module = "+ "'" + module1+ "'"; 
            String mycon = "Data Source=DESKTOP-2KR4GNF\\SQLEXPRESS;Initial Catalog=test2;Integrated Security=True";
            SqlConnection con = new SqlConnection(mycon);
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = query;
            cmd.Connection = con;
            cmd.ExecuteNonQuery();

        }

    }
}