using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Runtime.InteropServices.ComTypes;
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
            String module, material, fG_Referance, customer_Style, Color_Description, subcon_Type, description, fabric_Design, order_Reason, 
                special_Services, cpo, region_Country, name, season, external_Material_Group, customer, customer_Dept, sales_Order, item, 
                prod_order, so_qty, order_qty, smv, effi, emp,pcs_day, days, cut_date, startdate, finishdate,expected_prod_end_date,
                deliv_date,del_status,cut_qty,in_qty, out_qty, fab_In_H_date, acc_In_H_date, qco, product_category_Name, gender, 
                relative_Similarity, remarks, l_Curve, planning_Fab, planning_acc, approval_DD, section;


            String path = Path.GetFileName(FileUpload.FileName);
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
                Color_Description = dr[4].ToString();
                subcon_Type = dr[5].ToString();
                description = dr[6].ToString();
                fabric_Design = dr[7].ToString();
                order_Reason = dr[8].ToString();
                special_Services = dr[9].ToString();
                cpo = dr[10].ToString();
                region_Country = dr[11].ToString();
                name = dr[12].ToString();
                season = dr[13].ToString();
                external_Material_Group = dr[14].ToString();
                customer = dr[15].ToString();
                customer_Dept = dr[16].ToString();
                sales_Order = dr[17].ToString();
                item = dr[18].ToString();
                prod_order = dr[19].ToString();
                so_qty = dr[20].ToString();
                order_qty = dr[21].ToString();
                smv = dr[22].ToString();
                effi = dr[23].ToString();
                emp = dr[24].ToString();
                pcs_day = dr[25].ToString();
                days = dr[26].ToString();
                cut_date = dr[27].ToString();
                startdate = dr[28].ToString();
                finishdate = dr[29].ToString();
                expected_prod_end_date = dr[30].ToString();
                deliv_date = dr[31].ToString();
                del_status = dr[32].ToString();
                cut_qty = dr[33].ToString();
                in_qty = dr[34].ToString();
                out_qty = dr[35].ToString();
                fab_In_H_date = dr[36].ToString();
                acc_In_H_date = dr[37].ToString();
                qco = dr[38].ToString();
                product_category_Name = dr[39].ToString();
                gender = dr[40].ToString();
                relative_Similarity = dr[41].ToString();
                remarks = dr[42].ToString();
                l_Curve = dr[43].ToString();
                planning_Fab = dr[44].ToString();
                planning_acc = dr[45].ToString();
                approval_DD = dr[46].ToString();
                section = dr[47].ToString();

                savedata(module, material, fG_Referance, customer_Style, Color_Description, subcon_Type, description, fabric_Design, order_Reason,
                special_Services, cpo, region_Country, name, season, external_Material_Group, customer, customer_Dept, sales_Order, item,
                prod_order, so_qty, order_qty, smv, effi, emp, pcs_day, days, cut_date, startdate, finishdate, expected_prod_end_date,
                deliv_date, del_status, cut_qty, in_qty, out_qty, fab_In_H_date, acc_In_H_date, qco, product_category_Name, gender,
                relative_Similarity, remarks, l_Curve, planning_Fab, planning_acc, approval_DD, section);
               
            }
            Label3.Text = "Data Has Been Saved Successfully";
            mycon.Close();
            File.Delete(ExcelPath);

        }

        protected void Update_Click(object sender, EventArgs e)
        {
            int rollno;
            String sname;
            String fname;
            String mname;
            String path = Path.GetFileName(FileUpload1.FileName);
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
            String module, material, fG_Referance, customer_Style, Color_Description, subcon_Type, description, fabric_Design, order_Reason,
                special_Services, cpo, region_Country, name, season, external_Material_Group, customer, customer_Dept, sales_Order, item,
                prod_order, so_qty, order_qty, smv, effi, emp, pcs_day, days, cut_date, startdate, finishdate, expected_prod_end_date,
                deliv_date, del_status, cut_qty, in_qty, out_qty, fab_In_H_date, acc_In_H_date, qco, product_category_Name, gender,
                relative_Similarity, remarks, l_Curve, planning_Fab, planning_acc, approval_DD, section;

            String path = Path.GetFileName(FileUpload2.FileName);
            path = path.Replace(" ", "");
            FileUpload2.SaveAs(Server.MapPath("~/ExcelFile/") + path);
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
                Color_Description = dr[4].ToString();
                subcon_Type = dr[5].ToString();
                description = dr[6].ToString();
                fabric_Design = dr[7].ToString();
                order_Reason = dr[8].ToString();
                special_Services = dr[9].ToString();
                cpo = dr[10].ToString();
                region_Country = dr[11].ToString();
                name = dr[12].ToString();
                season = dr[13].ToString();
                external_Material_Group = dr[14].ToString();
                customer = dr[15].ToString();
                customer_Dept = dr[16].ToString();
                sales_Order = dr[17].ToString();
                item = dr[18].ToString();
                prod_order = dr[19].ToString();
                so_qty = dr[20].ToString();
                order_qty = dr[21].ToString();
                smv = dr[22].ToString();
                effi = dr[23].ToString();
                emp = dr[24].ToString();
                pcs_day = dr[25].ToString();
                days = dr[26].ToString();
                cut_date = dr[27].ToString();
                startdate = dr[28].ToString();
                finishdate = dr[29].ToString();
                expected_prod_end_date = dr[30].ToString();
                deliv_date = dr[31].ToString();
                del_status = dr[32].ToString();
                cut_qty = dr[33].ToString();
                in_qty = dr[34].ToString();
                out_qty = dr[35].ToString();
                fab_In_H_date = dr[36].ToString();
                acc_In_H_date = dr[37].ToString();
                qco = dr[38].ToString();
                product_category_Name = dr[39].ToString();
                gender = dr[40].ToString();
                relative_Similarity = dr[41].ToString();
                remarks = dr[42].ToString();
                l_Curve = dr[43].ToString();
                planning_Fab = dr[44].ToString();
                planning_acc = dr[45].ToString();
                approval_DD = dr[46].ToString();
                section = dr[47].ToString();
                //UpdateDatabase(rollno, sname, fname, mname);
                deletedata(module, material, fG_Referance, customer_Style, Color_Description, subcon_Type, description, fabric_Design, order_Reason,
                special_Services, cpo, region_Country, name, season, external_Material_Group, customer, customer_Dept, sales_Order, item,
                prod_order, so_qty, order_qty, smv, effi, emp, pcs_day, days, cut_date, startdate, finishdate, expected_prod_end_date,
                deliv_date, del_status, cut_qty, in_qty, out_qty, fab_In_H_date, acc_In_H_date, qco, product_category_Name, gender,
                relative_Similarity, remarks, l_Curve, planning_Fab, planning_acc, approval_DD, section);
                break;   
              
            }
            dr.Close();
            Label5.Text = "Data Has Been Deleted Successfully";

            ///insert////////////////////////////////////////////////////////////
            OleDbDataReader dr1 = cmd.ExecuteReader();
            while (dr1.Read())
            {
                module = dr1[0].ToString();
                material = dr1[1].ToString();
                fG_Referance = dr1[2].ToString();
                customer_Style = dr1[3].ToString();
                Color_Description = dr1[4].ToString();
                subcon_Type = dr1[5].ToString();
                description = dr1[6].ToString();
                fabric_Design = dr1[7].ToString();
                order_Reason = dr1[8].ToString();
                special_Services = dr1[9].ToString();
                cpo = dr1[10].ToString();
                region_Country = dr1[11].ToString();
                name = dr1[12].ToString();
                season = dr1[13].ToString();
                external_Material_Group = dr1[14].ToString();
                customer = dr1[15].ToString();
                customer_Dept = dr1[16].ToString();
                sales_Order = dr1[17].ToString();
                item = dr1[18].ToString();
                prod_order = dr1[19].ToString();
                so_qty = dr1[20].ToString();
                order_qty = dr1[21].ToString();
                smv = dr1[22].ToString();
                effi = dr1[23].ToString();
                emp = dr1[24].ToString();
                pcs_day = dr1[25].ToString();
                days = dr1[26].ToString();
                cut_date = dr1[27].ToString();
                startdate = dr1[28].ToString();
                finishdate = dr1[29].ToString();
                expected_prod_end_date = dr1[30].ToString();
                deliv_date = dr1[31].ToString();
                del_status = dr1[32].ToString();
                cut_qty = dr1[33].ToString();
                in_qty = dr1[34].ToString();
                out_qty = dr1[35].ToString();
                fab_In_H_date = dr1[36].ToString();
                acc_In_H_date = dr1[37].ToString();
                qco = dr1[38].ToString();
                product_category_Name = dr1[39].ToString();
                gender = dr1[40].ToString();
                relative_Similarity = dr1[41].ToString();
                remarks = dr1[42].ToString();
                l_Curve = dr1[43].ToString();
                planning_Fab = dr1[44].ToString();
                planning_acc = dr1[45].ToString();
                approval_DD = dr1[46].ToString();
                section = dr1[47].ToString();

                savedata(module, material, fG_Referance, customer_Style, Color_Description, subcon_Type, description, fabric_Design, order_Reason,
                special_Services, cpo, region_Country, name, season, external_Material_Group, customer, customer_Dept, sales_Order, item,
                prod_order, so_qty, order_qty, smv, effi, emp, pcs_day, days, cut_date, startdate, finishdate, expected_prod_end_date,
                deliv_date, del_status, cut_qty, in_qty, out_qty, fab_In_H_date, acc_In_H_date, qco, product_category_Name, gender,
                relative_Similarity, remarks, l_Curve, planning_Fab, planning_acc, approval_DD, section); //req....
            }
            Label3.Text = "Data Has Been Saved Successfully";
            mycon.Close();
            File.Delete(ExcelPath);
        }

        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////

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

        private void savedata(String module1, String material1, String fG_Referance1, String customer_Style1, String Color_Description1, 
            String subcon_Type1, String description1, String fabric_Design1, String order_Reason1, String special_Services1, String cpo1, 
            String region_Country1, String name1, String season1, String external_Material_Group1, String customer1, String customer_Dept1, 
            String sales_Order1, String item1, String prod_order1, String so_qty1, String order_qty1, String smv1, String effi1, String emp1,
            String pcs_day1, String days1, String cut_date1, String startdate1, String finishdate1, String expected_prod_end_date1,
            String deliv_date1, String del_status1, String cut_qty1, String in_qty1, String out_qty1, String fab_In_H_date1,
            String acc_In_H_date1, String qco1, String product_category_Name1, String gender1, String relative_Similarity1, String remarks1,
            String l_Curve1, String planning_Fab1, String planning_acc1, String approval_DD1, String section1)
        {
            String query = "insert into plan2 values('" + module1 + "','" + material1 + "','" + fG_Referance1 + "','" + customer_Style1
                + "','" + Color_Description1 + "','" + subcon_Type1 + "','" + description1 + "','" + fabric_Design1 + "','" + order_Reason1 
                + "','" + special_Services1 + "','" + cpo1 + "','" + region_Country1 + "','" + name1 + "','" + season1 + "','" + external_Material_Group1 
                + "','" + customer1 + "','" + customer_Dept1 + "','" + sales_Order1 + "','" + item1 + "','" + prod_order1 + "','" + so_qty1 + "','" 
                + order_qty1 + "','" + smv1 + "','" + effi1 + "','" + emp1 + "','" + pcs_day1 + "','" + days1 + "','" + cut_date1 + "','" + startdate1 
                + "','" + finishdate1 + "','" + expected_prod_end_date1 + "','" + deliv_date1 + "','" + del_status1 + "','" + cut_qty1 + "','" + in_qty1 
                + "','" + out_qty1 + "','" + fab_In_H_date1 + "','" + acc_In_H_date1 + "','" + qco1 + "','" + product_category_Name1 + "','" + gender1 
                + "','" + relative_Similarity1 + "','" + remarks1 + "','" + l_Curve1 + "','" + planning_Fab1 + "','" + planning_acc1 + "','" + approval_DD1
                + "','" + section1+ "')";
            String mycon = "Data Source=DESKTOP-2KR4GNF\\SQLEXPRESS;Initial Catalog=test2;Integrated Security=True";
            SqlConnection con = new SqlConnection(mycon);
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = query;
            cmd.Connection = con;
            cmd.ExecuteNonQuery();

        }

        private void deletedata(String module1, String material1, String fG_Referance1, String customer_Style1, String Color_Description1,
            String subcon_Type1, String description1, String fabric_Design1, String order_Reason1, String special_Services1, String cpo1,
            String region_Country1, String name1, String season1, String external_Material_Group1, String customer1, String customer_Dept1,
            String sales_Order1, String item1, String prod_order1, String so_qty1, String order_qty1, String smv1, String effi1, String emp1,
            String pcs_day1, String days1, String cut_date1, String startdate1, String finishdate1, String expected_prod_end_date1,
            String deliv_date1, String del_status1, String cut_qty1, String in_qty1, String out_qty1, String fab_In_H_date1,
            String acc_In_H_date1, String qco1, String product_category_Name1, String gender1, String relative_Similarity1, String remarks1,
            String l_Curve1, String planning_Fab1, String planning_acc1, String approval_DD1, String section1)
        {
            String query = "delete from plan2 where module = " + "'" + module1+ "'"; 
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