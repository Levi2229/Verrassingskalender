using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Verrassingskalender_Api.Models
{
    public class Grid
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public ICollection<Cell> Cells { get; set; }

        public Grid()
        {
            Cells = new List<Cell>();
        }
    }
}
