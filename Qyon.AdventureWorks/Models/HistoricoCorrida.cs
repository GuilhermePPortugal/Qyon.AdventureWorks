using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Qyon.AdventureWorks.Models
{
    //CRIANDO A TABELA E SEUS CAMPOS 
    [Table("HistoricoCorrida")]
    public class HistoricoCorrida
    {
        [Column("Id_Historico")]
        [Display(Name = "Código")]
        [Key()]
        public int Id { get; set; }
        [ForeignKey("Competidores")]
        [Display(Name = "Nome Competidor")]
        [Required]
        public int Id_Competidores { get; set; }
        public virtual Competidores Competidores { get; set;}
        [ForeignKey("PistaCorrida")]
        [Display(Name = "Pista de Corrida")]
        [Required]
        public int Id_PistaCorrida { get; set; }
        public virtual PistaCorrida PistaCorrida { get; set; }

        [Column("DataCorrida")]
        [Display(Name = "Data da Corrida")]
        [Required(ErrorMessage = "O campo \"Data da Corrida\" é obrigatório' ")]
        public DateTime DataCorrida { get; set; }

        [Column("TempoGasto")]
        [Display(Name = "Tempo Gasto")]
        [Required(ErrorMessage = "O campo \"Tempo Gasto\" é obrigatório' ")]
        public Decimal TempoGasto { get; set; }






    }
}
