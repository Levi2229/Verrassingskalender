using Verrassingskalender_Api.Models.Enums;

namespace Verrassingskalender_Api.Models
{
    public class Cell
    {
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
