using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApplication.Application.Entidade
{
    public class Movie
    {
        public int Id { get; set; }
        
        [Required(ErrorMessage = "Campo 'Titulo' Obrigatório")]
        [StringLength(120, ErrorMessage = "Campo Titulo não pode ter mais de 120 caracteres")]
        public string? Title { get; set; }

        [Required(ErrorMessage = "Campo 'Data de Lançamento' Obrigatório")]
        public DateTime ReleaseDate { get; set; }

        [Required(ErrorMessage = "Campo 'Genero' Obrigatório")]
        public string? Genre { get; set; }

        [Required(ErrorMessage = "Campo 'Preço' Obrigatório")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "Campo 'Descrição' Obrigatório")]
        [StringLength(1024, ErrorMessage = "Campo Descrição não pode ter mais de 1024 caracteres")]
        public string Description { get; set; }
    }
}
