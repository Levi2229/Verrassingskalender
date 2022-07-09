using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Verrassingskalender_Api.Models.Enums;

namespace Verrassingskalender_Api.Models
{
    public class Cell
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public CellContent CellContent { get; set; }
        public Player? Player { get; set; }

        public Cell(int id, CellContent cellContent)
        {
            Id = id;
            CellContent = cellContent;
        }
    }
}
