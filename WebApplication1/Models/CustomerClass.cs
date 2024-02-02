using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Web;

namespace WebApplication1.Models
{
    public class CustomerClass
    {
        public int Csid { get; set; }
        public string FirstName { get; set; }
        public string Address { get; set; }
        public string Contact { get; set; }
        public string Username { get; set; }
        public string password { get; set; }



        public void SaveCustomer(CustomerClass objCustomer
    )
        {
            try
            {
                SqlConnection con = new SqlConnection("Data Source = TOGSL-CC-28\\SQLEXPRESS; Database=ECOM1; Integrated Security=SSPI");
                con.Open();

                SqlCommand cmd = new SqlCommand("EXEC SPSaveCustomer '" + objCustomer.Csid + "','" + objCustomer.FirstName + "','" + objCustomer.Address + "','" + objCustomer.Contact + "','" + objCustomer.Username + "','" + objCustomer.password + "'");
                cmd.Connection = con;

                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataSet DS = new DataSet();
                adp.Fill(DS);


            }
            catch (Exception ex)
            {
                throw ex;
            }
        }





    }
}