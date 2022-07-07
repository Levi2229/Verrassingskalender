namespace Verrassingskalender_Api.Models
{
    public class Grid
    {
        public int Id { get; set; }
        public ICollection<Cell> Cells { get; set; }

        public Grid()
        {
            Cells = new List<Cell>();
        }
    }
}
