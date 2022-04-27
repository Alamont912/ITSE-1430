﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace MovieLib.Sql
{
    public class SqlMovieDatabase : MovieDatabase
    {
        public SqlMovieDatabase(string connectionString)
        {
            _connectionString = connectionString;
        }

        private readonly string _connectionString;

        protected override Movie AddCore ( Movie movie ) => throw new NotImplementedException();
        protected override void DeleteCore ( int id )
        {
            using(var conn = OpenConnection())
            {
                //Command - approach 2
                var cmd = conn.CreateCommand();
                cmd.CommandText = "DeleteMovie";
                cmd.CommandType = CommandType.StoredProcedure;

                //Always use parameters to prevent attacks
                //approach 1
                cmd.Parameters.AddWithValue("@id", id);

                //Execute - no results (deletion/updates)
                cmd.ExecuteNonQuery();
            }
        }
        protected override Movie FindByName ( string name )
        {
            return null;
        }
        protected override IEnumerable<Movie> GetAllCore ()
        {
            DataSet ds = new DataSet();

            //IDisposable
            using (var conn = OpenConnection())
            {
                //Create Command - approach 1
                var command = new SqlCommand("GetMovies", conn);

                //Buffered IO
                var da = new SqlDataAdapter(command);

                da.Fill(ds);
            };
            //Get the first table, have to use OfType<T> to get IEnumerable<T>
            var table = ds.Tables.OfType<DataTable>().FirstOrDefault();
            if (table != null)
                return table.Rows.OfType<DataRow>().Select(LoadMovie);
            return Enumerable.Empty<Movie>();
        }

        private Movie LoadMovie ( DataRow row )
        {
            return new Movie() {
                Id = Convert.ToInt32(row[0]),           //Array-based index and convert
                Title = row["Name"].ToString(),         //Array-based column name and convert
                Description = row.Field<string>(2),     //Field-based index
                Duration = row.Field<int>("RunLength"), //Field-based column names
                Rating = row.Field<string>("Rating"),
                ReleaseYear = row.Field<int>("ReleaseYear"),
                Genre = row.Field<string>("Genre"),
                IsClassic = row.Field<bool>("IsClassic"),
            };
        }

        private SqlConnection OpenConnection ()
        {
            //IDisposable
            var conn = new SqlConnection(_connectionString);
            conn.Open();

            return conn;
        }

        //TODO: GetCore
        protected override Movie GetCore ( int id ) => GetAllCore().FirstOrDefault(x => x.Id == id);
        protected override void UpdateCore ( int id, Movie movie ) => throw new NotImplementedException();
    }
}
