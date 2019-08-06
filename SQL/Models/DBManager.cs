using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
namespace SQL.Models
{
    public class DBManager
    {
        private readonly string ConnStr = "Data Source=localhost;Initial Catalog=Northwind;Integrated Security=True";
        public List<Suppliers> GetSuppliers()
        {
            List<Suppliers> Supplier = new List<Suppliers>();
            SqlConnection sqlConnection = new SqlConnection(ConnStr);
            SqlCommand sqlCommand = new SqlCommand("SELECT * FROM Suppliers");
            sqlCommand.Connection = sqlConnection;
            sqlConnection.Open();

            SqlDataReader reader = sqlCommand.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Suppliers suppliers = new Suppliers
                    {
                        CompanyName = reader.GetString(reader.GetOrdinal("CompanyName")),
                        ContactName = reader.GetString(reader.GetOrdinal("ContactName")),
                    };
                    Supplier.Add(suppliers);
                }
            }
            else
            {
                Console.WriteLine("資料庫為空！");
            }
            sqlConnection.Close();
            return Supplier;
        }
    }
}