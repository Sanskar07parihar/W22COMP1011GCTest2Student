using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace InventoryManagement.API
{
    public class SQLConnectionClient
    {
        private string ConnectionString = "Data Source={0};Initial Catalog={1};User ID={2};Password={3}";

        //public static SQLConnectionClient Instance;

        public SQLConnectionClient()
        {
            ConnectionString = string.Format(ConnectionString, ".", "InventoryManagement", "sa", "sa");
        }

        //public static void Createinstance()
        //{
        //    Instance = new SQLConnectionClient();
        //}


        /// <summary>
        /// Call this method to Read:: R
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public DataTable ReadData(string query)
        {
            DataTable dt = new DataTable();

            using (SqlConnection _con = new SqlConnection(ConnectionString))
            {
                using (SqlCommand _cmd = new SqlCommand(query, _con))
                {
                    SqlDataAdapter _dap = new SqlDataAdapter(_cmd);

                    _con.Open();
                    _dap.Fill(dt);
                    _con.Close();
                }
            }

            return dt;
        }

        /// <summary>
        /// Call this method with SQL query to Create/Update/Delete:: CUD. Retruns -1 for unsuccessful attempt. 0 for no change in database.
        /// Greater than 0 for no of records affected.
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public int ExecuteSQLQuery(string query)
        {
            int commandStatus = -1;

            try
            {
                using (SqlConnection _con = new SqlConnection(ConnectionString))
                {
                    using (SqlCommand _cmd = new SqlCommand(query, _con))
                    {
                        _con.Open();
                        commandStatus = _cmd.ExecuteNonQuery();
                        _con.Close();
                    }
                }
            }
            catch (Exception ex)
            {

            }

            return commandStatus;
        }

    }
}
