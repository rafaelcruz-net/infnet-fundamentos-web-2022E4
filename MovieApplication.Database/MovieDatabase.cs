using MovieApplication.Entidade;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace MovieApplication.Database
{
    public class MovieDatabase
    {
        private string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;Integrated Security=True";

        public List<Movie> ObterTodos()
        {
            List<Movie> result = new List<Movie>(); 

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                var sql = "SELECT * FROM FILMES";

                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText = sql;
                command.CommandType = System.Data.CommandType.Text;

                var data = command.ExecuteReader();

                if(data.HasRows)
                {
                    while(data.Read())
                    {
                        Movie movie = new Movie();
                        movie.Id = Convert.ToInt32(data["Id"].ToString());
                        movie.Title = data["Title"].ToString();
                        movie.Description = data["Description"].ToString();
                        movie.Genre = data["Genre"].ToString();
                        movie.Price = Convert.ToDecimal(data["Price"].ToString());
                        movie.ReleaseDate = Convert.ToDateTime(data["ReleaseDate"].ToString());

                        result.Add(movie);
                    }
                }

                connection.Close();

                return result;
            }
        }

        public Movie ObterPorId(int id)
        {
            Movie result = null;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // 1 or 1=1
                var sql = $"SELECT * FROM FILMES WHERE Id = @Param1;";

                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText = sql;
                command.CommandType = System.Data.CommandType.Text;
                
                var param = new SqlParameter("@Param1", SqlDbType.Int);
                param.Value = id;

                command.Parameters.Add(param);

                var data = command.ExecuteReader();

                if (data.HasRows)
                {
                    if (data.Read())
                    {
                        result = new Movie();

                        result.Id = Convert.ToInt32(data["Id"].ToString());
                        result.Title = data["Title"].ToString();
                        result.Description = data["Description"].ToString();
                        result.Genre = data["Genre"].ToString();
                        result.Price = Convert.ToDecimal(data["Price"].ToString());
                        result.ReleaseDate = Convert.ToDateTime(data["ReleaseDate"].ToString());
                    }
                }

                connection.Close();

                return result;
            }
        }

        public List<Movie> ObterPorGenero(string genre)
        {
            List<Movie> result = new List<Movie>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                var sql = $"SELECT * FROM FILMES WHERE UPPER(genre) = @PARAM1";

                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText = sql;
                command.CommandType = System.Data.CommandType.Text;

                var param = new SqlParameter("@PARAM1", SqlDbType.VarChar);
                param.Value = genre.ToUpper();

                command.Parameters.Add(param);

                var data = command.ExecuteReader();

                if (data.HasRows)
                {
                    while (data.Read())
                    {
                        Movie movie = new Movie();
                        movie.Id = Convert.ToInt32(data["Id"].ToString());
                        movie.Title = data["Title"].ToString();
                        movie.Description = data["Description"].ToString();
                        movie.Genre = data["Genre"].ToString();
                        movie.Price = Convert.ToDecimal(data["Price"].ToString());
                        movie.ReleaseDate = Convert.ToDateTime(data["ReleaseDate"].ToString());

                        result.Add(movie);
                    }
                }

                connection.Close();

                return result;
            }
        }

        public void Salvar(Movie movie)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                var sql = @$"INSERT INTO FILMES(Title, Description, Price, Genre, ReleaseDate)
                             VALUES(@P1, @P2, @P3, @P4, @P5);   
                            ";

                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText = sql;
                command.CommandType = System.Data.CommandType.Text;

                var p1 = new SqlParameter("@P1", SqlDbType.VarChar);
                p1.Value = movie.Title;
                command.Parameters.Add(p1);

                var p2 = new SqlParameter("@P2", SqlDbType.VarChar);
                p2.Value = movie.Description;
                command.Parameters.Add(p2);

                var p3 = new SqlParameter("@P3", SqlDbType.Money);
                p3.Value = movie.Price;
                command.Parameters.Add(p3);

                var p4 = new SqlParameter("@P4", SqlDbType.VarChar);
                p4.Value = movie.Genre;
                command.Parameters.Add(p4);

                var p5 = new SqlParameter("@P5", SqlDbType.DateTime);
                p5.Value = movie.ReleaseDate;
                command.Parameters.Add(p5);

                command.ExecuteNonQuery();
                connection.Close();
            }
        }



    }
}
