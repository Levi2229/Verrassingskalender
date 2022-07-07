namespace Verrassingskalender_Api.Models
{
    public class GridViewModel
    {
        public ICollection<CellViewModel> Cells { get; set; }

        public GridViewModel()
        {
            Cells = new List<CellViewModel>();
        }
    }
}
