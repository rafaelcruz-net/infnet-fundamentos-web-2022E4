using MovieApplication.Entidade;
using System;
using System.Collections.Generic;
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
                var sql = $"SELECT * FROM FILMES WHERE Id = {id};";

                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText = sql;
                command.CommandType = System.Data.CommandType.Text;

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
                var sql = $"SELECT * FROM FILMES WHERE UPPER(genre) = '{genre.ToUpper()}'";

                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText = sql;
                command.CommandType = System.Data.CommandType.Text;

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
                             VALUES('{movie.Title}', '{movie.Description}', '{movie.Price}', '{movie.Genre}', '{movie.ReleaseDate}');   
                            ";

                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText = sql;
                command.CommandType = System.Data.CommandType.Text;

                command.ExecuteNonQuery();
                connection.Close();
            }
        }



    }
}
