using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System;
using FronEndClassicDev.Models;

namespace FronEndClassicDev.Models
{
    /// <summary>
    /// Summary description for OrderDetailDAL
    /// </summary>
    public class OrderDetailDAL
    {
        public static List<OrderDetail> GetOrderDetailsByProductID(int productID)
        {
            // returns a list of OrderDetail instances for a particular product based on the
            // data in the Northwind Products table
            string sql = "SELECT OrderID, UnitPrice, Quantity FROM [Order Details] WHERE ProductID = @ProductID";

            using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["NWConnectionString"].ConnectionString))
            {
                SqlCommand myCommand = new SqlCommand(sql, myConnection);
                myCommand.Parameters.Add(new SqlParameter("@ProductID", productID));

                myConnection.Open();

                SqlDataReader reader = myCommand.ExecuteReader(CommandBehavior.CloseConnection);

                List<OrderDetail> results = new List<OrderDetail>();

                while (reader.Read())
                {
                    OrderDetail detail = new OrderDetail();

                    detail.OrderID = Convert.ToInt32(reader["OrderID"]);
                    detail.ProductID = productID;
                    detail.Quantity = Convert.ToInt32(reader["Quantity"]);
                    detail.UnitPrice = Convert.ToDecimal(reader["UnitPrice"]);

                    results.Add(detail);
                }

                reader.Close();
                myConnection.Close();

                return results;
            }
        }


        public static void DeleteOrderDetail(int original_OrderID, int original_ProductID)
        {
            // deletes a specified Order Details record from the Northwind Products table
            string sql = "DELETE FROM [Order Details] WHERE OrderID = @OrderID AND ProductID = @ProductID";

            using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["NWConnectionString"].ConnectionString))
            {
                SqlCommand myCommand = new SqlCommand(sql, myConnection);
                myCommand.Parameters.Add(new SqlParameter("@OrderID", original_OrderID));
                myCommand.Parameters.Add(new SqlParameter("@ProductID", original_ProductID));

                myConnection.Open();
                myCommand.ExecuteNonQuery();
                myConnection.Close();
            }
        }

        public static List<OrderDetail> GetOrders()
        {
            return GetOrders(int.MaxValue, 0, string.Empty);
        }

        public static List<OrderDetail> GetOrders(int maximumRows, int startRowIndex)
        {
            return GetOrders(maximumRows, startRowIndex, string.Empty);
        }
        public static List<OrderDetail> GetOrders(string SortExpression)
        {
            return GetOrders(int.MaxValue, 0, SortExpression);
        }

        public static List<OrderDetail> GetOrders(int maximumRows, int startRowIndex, string SortExpression)
        {            
            string sql = "SELECT OrderID, UnitPrice, Quantity FROM [Order Details]";

            if (SortExpression != string.Empty)
                sql += " ORDER BY " + SortExpression;

            using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["NWConnectionString"].ConnectionString))
            {
                // Place the data in a DataTable
                SqlCommand myCommand = new SqlCommand(sql, myConnection);
                SqlDataAdapter myAdapter = new SqlDataAdapter(myCommand);

                myConnection.Open();
                DataTable dt = new DataTable();

                myAdapter.Fill(dt);

                List<OrderDetail> results = new List<OrderDetail>();

                int currentIndex = startRowIndex;
                int itemsRead = 0;
                int totalRecords = dt.Rows.Count;

                while (itemsRead < maximumRows && currentIndex < totalRecords)
                {
                    OrderDetail order = new OrderDetail();
                    order.OrderID = Convert.ToInt32(dt.Rows[currentIndex]["OrderID"]);
                    order.ProductID = Convert.ToInt32(dt.Rows[currentIndex]["ProductID"]);
                    order.Quantity = Convert.ToInt32(dt.Rows[currentIndex]["Quantity"]);

                    if (dt.Rows[currentIndex]["UnitPrice"].Equals(DBNull.Value))
                        order.UnitPrice = 0;
                    else
                        order.UnitPrice = Convert.ToDecimal(dt.Rows[currentIndex]["UnitPrice"]);

                    if (dt.Rows[currentIndex]["Quantity"].Equals(DBNull.Value))
                        order.Quantity = 0;
                    else
                        order.Quantity = Convert.ToInt32(dt.Rows[currentIndex]["Quantity"]);

                    results.Add(order);

                    itemsRead++;
                    currentIndex++;
                }

                myConnection.Close();

                return results;
            }
        }

        
    }
}