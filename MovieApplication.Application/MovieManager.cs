using MovieApplication.Entidade;
using MovieApplication.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApplication.Application
{
    public class MovieManager
    {
        MovieDatabase database = new MovieDatabase(); 

        public List<Movie> ObterTodos()
        {
            return database.ObterTodos();
        }

        public Movie ObterPorId(int id)
        {
            return database.ObterPorId(id);
        }

        public void Salvar(Movie movie)
        {
            database.Salvar(movie);
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
            return database.ObterPorGenero(genero);
        }

    }
}
