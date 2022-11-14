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
        private static List<Movie> Movies { get; set; }

        public MovieManager()
        {
            if (Movies == null)
            {

                Movies = new List<Movie>
                {
                    new Movie()
                    {
                        Id = 1,
                        Title = "Star Wars",
                        Genre = "SciFi",
                        Price = 19.99M,
                        ReleaseDate = DateTime.Now,
                        Description = "Star Wars é uma franquia do tipo space opera estadunidense criada pelo cineasta George Lucas, que conta com uma série de nove filmes de fantasia científica e dois spin-offs.[1] O primeiro filme foi lançado apenas com o título Star Wars,[2] em 25 de maio de 1977, e tornou-se um fenômeno mundial inesperado de cultura popular,[3] sendo responsável pelo início da era dos blockbusters, que são superproduções cinematográficas que fazem sucesso nas bilheterias e viram franquias com brinquedos, jogos, livros, etc"
                    },
                    new Movie()
                    {
                        Id = 2,
                        Title = "O poderoso chefão",
                        Genre = "Drama",
                        Price = 29.99M,
                        ReleaseDate = DateTime.Now,
                        Description = "The Godfather é um filme norte-americano de 1972, dirigido por Francis Ford Coppola, baseado no livro homônimo escrito por Mario Puzo. É estrelado por Marlon Brando, Al Pacino, James Caan, Richard Castellano, Robert Duvall, Sterling Hayden, John Marley, Richard Conte e Diane Keaton"
                    },

                };
            }
        }



        public List<Movie> ObterTodos()
        {
            return Movies;
        }

        public Movie ObterPorId(int id)
        {
            Movie result = null;

            foreach (var item in Movies)
            {
                if (item.Id == id)
                    result = item;
            }

            return result;
        }

        public void Salvar(Movie movie)
        {
            var nextId = Movies.Last().Id + 1;
            movie.Id = nextId;
            Movies.Add(movie);
        }

        public void Atualizar(Movie movie)
        {
            throw new NotImplementedException();
        }

        public void Excluir(int id)
        {
            throw new NotImplementedException();
        }

        public List<Movie> Search(string genero)
        {
            List<Movie> result = new List<Movie>();

            foreach (var item in Movies)
            {
                if (string.Compare(item.Genre, genero, true) == 0)
                    result.Add(item);
            }

            return result;
        }

    }
}
