using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Qyon.AdventureWorks.Models
{
    //CRIANDO A TABELA E SEUS CAMPOS 
    [Table("PistaCorrida")]
    public class PistaCorrida
    {
        [Column("Id_PistaCorrida")]
        [Display(Name = "Código")]
        [Key()]
        public int Id_PistaCorrida { get; set; }

        [Column("Descricao")]
        [Display(Name = "Descrição")]
        [StringLength(50)]
        [Required(ErrorMessage = "O campo \"Descrição\" é obrigatório' ")]
        public string Descricao { get; set; }



    }
}
