using System;
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

        protected override Movie AddCore ( Movie movie )
        {
            using(var conn = OpenConnection())
            {
                var cmd = new SqlCommand("AddMovie", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                //Add Parameters

                //Approach 1 - preferred for SQL
                cmd.Parameters.AddWithValue("@name", movie.Title);
                cmd.Parameters.AddWithValue("@releaseYear", movie.ReleaseYear);
                cmd.Parameters.AddWithValue("@runLength", movie.Duration);
                cmd.Parameters.AddWithValue("@isClassic", movie.IsClassic);

                //Approach 2 - convert primative to SQL type
                var parmRating = cmd.Parameters.Add("@rating", SqlDbType.NVarChar);      
                parmRating.Value = movie.Rating;

                //Approach 3 - need complete control of parameter or access after call
                var parmDescription = new SqlParameter("@description", movie.Description);
                cmd.Parameters.Add(parmDescription);

                //Approach 4 - needs to be generic
                var parmGenre = cmd.CreateParameter();
                parmGenre.ParameterName = "@genre";
                parmGenre.DbType = DbType.String;
                parmGenre.Value = movie.Genre;
                cmd.Parameters.Add(parmGenre);

                var result = cmd.ExecuteScalar();   //execute, but give me back the first thing

                movie.Id = Convert.ToInt32(result); //first thing is ID, convert and apply ID

                return movie;   //return movie
            };
        }

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
            //Streamed read
            using (var conn = OpenConnection())
            {
                var cmd = new SqlCommand("FindByName", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@name", name);

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())    //what actually reads the next row of data
                    {
                        return LoadMovie(reader);
                    };
                };
            };
            return null;    //return at least 1 row, or return nothing
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
        protected override Movie GetCore ( int id )
        {
            //Streamed read
            using(var conn = OpenConnection())
            {
                var cmd = new SqlCommand("GetMovie", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@id", id);

                using (var reader = cmd.ExecuteReader())
                {
                    while(reader.Read())    //what actually reads the next row of data
                    {
                        return LoadMovie(reader);
                    };
                };
            };
            return null;    //return at least 1 row, or return nothing
        }

        private static Movie LoadMovie ( SqlDataReader reader ) => new Movie() {
            Id = Convert.ToInt32(reader[0]),                       //Array-based index and convert
            Title = reader["Name"]?.ToString(),                    //Array-based column name and convert
            Description = reader.IsDBNull(2) ? "" : reader.GetFieldValue<string>(2),         //Field-based index
            Duration = reader.GetFieldValue<int>("RunLength"),     //Field-based column names
            Rating = reader.GetString(3),                          //Old, type-based ordinal overloads
            ReleaseYear = reader.GetInt32("ReleaseYear"),
            Genre = reader.GetFieldValue<string>("Genre"),
            IsClassic = reader.GetFieldValue<bool>("IsClassic"),
        }; 

        protected override void UpdateCore ( int id, Movie movie )
        {
            using (var conn = OpenConnection())
            {
                var cmd = new SqlCommand("UpdateMovie", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                //Add Parameters

                //Approach 1 - preferred for SQL
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@name", movie.Title);
                cmd.Parameters.AddWithValue("@releaseYear", movie.ReleaseYear);
                cmd.Parameters.AddWithValue("@runLength", movie.Duration);
                cmd.Parameters.AddWithValue("@isClassic", movie.IsClassic);

                //Approach 2 - convert primative to SQL type
                var parmRating = cmd.Parameters.Add("@rating", SqlDbType.NVarChar);
                parmRating.Value = movie.Rating;

                //Approach 3 - need complete control of parameter or access after call
                var parmDescription = new SqlParameter("@description", movie.Description);
                cmd.Parameters.Add(parmDescription);

                //Approach 4 - needs to be generic
                var parmGenre = cmd.CreateParameter();
                parmGenre.ParameterName = "@genre";
                parmGenre.DbType = DbType.String;
                parmGenre.Value = movie.Genre;
                cmd.Parameters.Add(parmGenre);

                cmd.ExecuteNonQuery();
            };
        }
    }
}
