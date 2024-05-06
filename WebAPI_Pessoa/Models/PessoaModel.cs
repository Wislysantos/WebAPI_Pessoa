using System.ComponentModel.DataAnnotations;

namespace WebAPI_Pessoa.Models
{
    public class PessoaModel
    {
        [Key]
        public int Codigo { get; set; }
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }
        public bool Inativo { get; set; }
        public sbyte Nacionalidade { get; set; } //(1- BR , 2 - OUTROS)
        public string RG { get; set; }
        public string Passaporte { get; set; }


    }
}
