using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace Nile.Stores.Sql
{
    public class SqlProductDatabase : ProductDatabase
    {    
        public SqlProductDatabase(string connectionString)
        {
            _connectionString = connectionString;
        }
        private readonly string _connectionString;

        protected override Product GetCore ( int id )
        {
            using (var conn = OpenConnection())
            {
                var cmd = new SqlCommand("GetProduct", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@id", id);

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        return LoadProduct(reader);
                    };
                };
            };
            return null;
        }

        protected override IEnumerable<Product> GetAllCore ()
        {
            DataSet ds = new DataSet ();

            using (var conn = OpenConnection())
            {
                var command = new SqlCommand("GetAllProducts", conn);

                var da = new SqlDataAdapter (command);

                da.Fill(ds);
            };

            var table = ds.Tables.OfType<DataTable>().FirstOrDefault();
            if (table != null)
                return table.Rows.OfType<DataRow>().Select(LoadProduct);
            return Enumerable.Empty<Product>();
        }

        private Product LoadProduct(DataRow row)
        {
            return new Product() {
                Id = row.Field<int>("id"),
                Name = row.Field<string>("name"),
                Price = row.Field<decimal>("price"),
                Description = row.Field<string>("description"),
                IsDiscontinued = row.Field<bool>("isDiscontinued")
            };
        }

        private static Product LoadProduct(SqlDataReader reader)
        {
            return new Product() {
                Id = reader.GetFieldValue<int>("id"),
                Name = reader.GetFieldValue<string>("name"),
                Price = reader.GetFieldValue<decimal>("price"),
                Description = reader.GetFieldValue<string>("description"),
                IsDiscontinued = reader.GetFieldValue<bool>("isDiscontinued")
            };
        }

        protected override void RemoveCore ( int id )
        {
            using (var conn = OpenConnection())
            {
                var cmd = new SqlCommand("RemoveProduct", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@id", id);

                cmd.ExecuteNonQuery();
            }
        }

        protected override Product UpdateCore ( Product existing, Product newItem )
        {
            using(var conn = OpenConnection())
            {
                var cmd = new SqlCommand("UpdateProduct", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@id", existing.Id);
                cmd.Parameters.AddWithValue("@name", newItem.Name);
                cmd.Parameters.AddWithValue("@price", newItem.Price);
                cmd.Parameters.AddWithValue("@description", newItem.Description);
                cmd.Parameters.AddWithValue("@isDiscontinued", newItem.IsDiscontinued);

                cmd.ExecuteNonQuery();

                return newItem;
            };
        }

        protected override Product AddCore ( Product product )
        {
            using (var conn = OpenConnection())
            {
                var cmd = new SqlCommand("AddProduct", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@name", product.Name);
                cmd.Parameters.AddWithValue("@price", product.Price);
                cmd.Parameters.AddWithValue("@description", product.Description);
                cmd.Parameters.AddWithValue("@isDiscontinued", product.IsDiscontinued);

                var result = cmd.ExecuteScalar();

                product.Id = Convert.ToInt32(result);

                return product;
            }
        }

        private SqlConnection OpenConnection()
        {
            var conn = new SqlConnection(_connectionString);
            conn.Open();

            return conn;
        }
    }
}
