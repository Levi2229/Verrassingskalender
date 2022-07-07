using Verrassingskalender_Api.Models.Enums;

namespace Verrassingskalender_Api.Models
{
    public class Cell
    {
        public int Id { get; set; }
        public GridContent GridContent { get; set; }
        public Player? Player { get; set; }

        public Cell(int id, GridContent gridContent)
        {
            Id = id;
            GridContent = gridContent;
        }
    }
}
