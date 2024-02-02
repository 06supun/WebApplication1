using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class Product
    {
        public int PID { get; set; }
        public int Code { get; set; }
        public string ProductName { get; set; }
        public int CID { get; set; }
        public decimal Price { get; set; }
        public string Username { get; set; }
        public string ImageURL { get; set; }

        public void SaveProduct(Product objProduct
    )
        {
            try
            {
                SqlConnection con = new SqlConnection("Data Source = TOGSL-CC-28\\SQLEXPRESS; Database=ECOM1; Integrated Security=SSPI");
                con.Open();

                SqlCommand cmd = new SqlCommand("EXEC SPSaveProduct '" + objProduct.Code + "','" + objProduct.ProductName + "','" + objProduct.CID + "','" + objProduct.Price + "','" + objProduct.ImageURL + "'");
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

        public List<Product> LoadAllProduct()
        {
            try
            {
                List<Product> Prolist = new List<Product>();

                SqlConnection con = new SqlConnection("Data Source = TOGSL-CC-28\\SQLEXPRESS; Database=ECOM1; Integrated Security=SSPI");
                con.Open();
                SqlCommand cmd = new SqlCommand("EXEC SPLoadAllProduct");
                cmd.Connection = con;

                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataSet DS = new DataSet();
                adp.Fill(DS);

                foreach (DataRow dr in DS.Tables[0].Rows)
                {
                    Product objPro = new Product();
                    objPro.PID = Convert.ToInt32(dr["PID"]);
                    objPro.Code = Convert.ToInt32(dr["Code"]);
                    objPro.ProductName = Convert.ToString(dr["ProductName"]);
                    objPro.CID = Convert.ToInt32(dr["CID"]);
                    objPro.Price = Convert.ToDecimal(dr["Price"]);
                    objPro.ImageURL = Convert.ToString(dr["ImageURL"]);

                    Prolist.Add(objPro);

                }

                con.Close();
                return Prolist;



            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}
