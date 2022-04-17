using DemoADOMVC.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Web;

namespace DemoADOMVC.Repository
{
    public class CollegeRepository
    {
        private SqlConnection con;

        private void connection()
        {
            String cnn = ConfigurationManager.ConnectionStrings["con"].ToString();
            con = new SqlConnection(cnn);
        }
        //To Add College details
        public bool AddCollege(Registration obj)
        {
            connection();
            SqlCommand cmd = new SqlCommand("AddNewDetails", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("Name", obj.Name);
            cmd.Parameters.AddWithValue("DOB", obj.DOB);
            cmd.Parameters.AddWithValue("@City", obj.City);
            cmd.Parameters.AddWithValue("@Address", obj.Address);
            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();
            if (i >= 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        //To view College details with generic list  
        public List<Registration> GetAllCollege()
            {
                connection();
                List<Registration> CollegeList = new List<Registration>();
                SqlCommand cmd = new SqlCommand("GetCollege",con);
                cmd.CommandType=System.Data.CommandType.StoredProcedure;
                SqlDataAdapter Da= new SqlDataAdapter(cmd);
                DataTable Dt = new DataTable();
                con.Open();
                Da.Fill(Dt);
                con.Close();
                //Bind Registration generic list using dataRow  
                foreach(DataRow dr in Dt.Rows)
                {
                CollegeList.Add(
                        new Registration
                        {
                            id=Convert.ToInt32(dr["id"]), 
                            Name=Convert.ToString(dr["Name"]),
                            DOB=Convert.ToDateTime(dr["DOB"]),
                            City=Convert.ToString(dr["City"]),
                            Address=Convert.ToString(dr["Address"])
                        });
                    
                }
            return CollegeList;
        }
            public bool UpdateCollege(Registration obj)
            {
                connection();
                SqlCommand cmd = new SqlCommand("UpdateDetails", con);
                cmd.CommandType=System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Name", obj.Name);
                cmd.Parameters.AddWithValue("@DOB",obj.DOB);
                cmd.Parameters.AddWithValue("@City", obj.City);
                cmd.Parameters.AddWithValue("@Address", obj.Address);
                con.Open();
                int i = cmd.ExecuteNonQuery();
                con.Close();
                if (i >= 1)
                {

                    return true;
                }
                else
                {
                    return false;
                }
            }
            //To delete College details 
            public bool DeleteCollege(int id)
            {
                connection();
                SqlCommand cmd = new SqlCommand("DeleteDetailsById", con);
                cmd.CommandType= System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id", id);
                con.Open();
                int i = cmd.ExecuteNonQuery();
                con.Close();
                if (i >= 1)
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