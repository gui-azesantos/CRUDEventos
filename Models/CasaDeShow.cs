using System.ComponentModel.DataAnnotations;

namespace CrudBandas.Models
{
    public class CasaDeShow
    {
        [Key]
        public int Id { get; set; }
        
        public string Nome { get; set; }
        public string Endereco { get; set; }

    }
}