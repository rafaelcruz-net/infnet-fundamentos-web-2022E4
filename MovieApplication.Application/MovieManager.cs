using MovieApplication.Application.Entidade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApplication.Application
{
    public class MovieManager
    {
        public List<Movie> ObterTodos()
        {
            return new List<Movie>
            {
                new Movie()
                {
                    Id = 1,
                    Title = "Star Wars",
                    Genre = "SciFi",
                    Price = 19.99M,
                    ReleaseDate = DateTime.Now
                },
                new Movie()
                {
                    Id = 2,
                    Title = "O poderoso chefão",
                    Genre = "Drama",
                    Price = 29.99M,
                    ReleaseDate = DateTime.Now
                },

            };
        }

        public Movie ObterPorId(int id)
        {
            throw new NotImplementedException();
        }

        public void Salvar(Movie movie)
        {
            throw new NotImplementedException();
        }

        public void Atualizar(Movie movie)
        {
            throw new NotImplementedException();
        }

        public void Excluir(int id)
        {
            throw new NotImplementedException();
        }

    }
}
