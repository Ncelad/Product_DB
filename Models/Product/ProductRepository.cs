using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using System.Data.SqlClient;

namespace Product_DB.Models.Product
{
    public static class ProductRepository
    {
        private static string conn_str = "Data Source = SQL5061.site4now.net; Initial Catalog = db_a7966a_ion; User Id = db_a7966a_ion_admin; Password=Gorb_bc24";

        public static List<Product> Get_Data()
        {
            List<Product> products;
            using(SqlConnection connection = new SqlConnection(conn_str))
            {
                connection.Open();
                try
                {
                    products = connection.Query<Product>("exec GetData").ToList();
                }
                catch (Exception ex)
                {
                    products = new List<Product>(); 
                    throw ex;
                }
            }
            return products;
        }

        public static void Add_Data(Product product)
        {
            using (SqlConnection connection = new SqlConnection(conn_str))
            {
                connection.Open();
                try
                {
                    connection.Query("exec AddData",product);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
    }
}
