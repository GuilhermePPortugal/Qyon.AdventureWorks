using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Qyon.AdventureWorks.Models
{    
    //CRIANDO A TABELA E SEUS CAMPOS 
    [Table("Competidores")]
    public class Competidores
    {   
        [Column("Id_Competidores")]
        [Display(Name ="Código")]
        [Key()]
        public int Id_Competidores { get; set; }

        [Column("Nome")]
        [Display(Name = "Nome")]
        [StringLength (150)]
        [Required(ErrorMessage = "O campo \"Nome\" é obrigatório' ")]
        public string Nome { get; set; }

        [Column("Sexo")]
        [Display(Name = "Sexo")]
        [Required(ErrorMessage = "O campo \"Sexo\" é obrigatório' ")]
        public Char Sexo { get; set; }

        [Column("TemperaturaMediaCorpo")]
        [Display(Name = "Temperatura Media do Corpo")]
        [Required(ErrorMessage = "O campo \"Temperatura Media do Corpo\" é obrigatório' ")]
        public Decimal TemperaturaMediaCorpo { get; set; }

        [Column("Peso")]
        [Display(Name = "Peso do Competidor")]
        [Required(ErrorMessage = "O campo \"Peso do Competidor\" é obrigatório' ")]
        public Decimal Peso { get; set; }

        [Column("Altura")]
        [Display(Name = "Altura do Competidor")]
        [Required(ErrorMessage = "O campo \"Altura do Competidor\" é obrigatório' ")]
        public Decimal Altura { get; set; }




    }
}
