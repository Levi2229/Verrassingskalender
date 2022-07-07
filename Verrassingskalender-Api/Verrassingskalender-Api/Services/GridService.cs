using Verrassingskalender_Api.Models;
using Verrassingskalender_Api.Models.Enums;

namespace Verrassingskalender_Api.Services
{
    public class GridService : IGridService
    {
        private readonly IGridFactory _gridFactory;
        public GridService(IGridFactory gridFactory)
        {
            _gridFactory = gridFactory;
        }


        public GridViewModel GetGridViewModel()
        {
            //TODO get from DB instead of generating each time.
            var grid = _gridFactory.GenerateGrid();

            var gridViewModel = new GridViewModel();
            gridViewModel.Cells = grid.Cells.Select(c =>
            {
                var cellViewModel = new CellViewModel();
                cellViewModel.Id = c.Id;
                // If the player is null, we don't want to provide the front-end with the CellContent type, to prevent cheating.
                cellViewModel.GridContent = c.Player != null ? c.CellContent : null;
                return cellViewModel;
            }).ToList();
            return gridViewModel;
        }

        public CellContent ScratchGridCell(int id, string playerName)
        {
            // TODO get cell from database.
            // TODO validate if cell is empty.
            // TODO validate if playername is not in database yet.
            // TODO if cell is empty, set playername to cell.
            // TODO return correct CellContent
            return CellContent.GrandPrize;
        }
    }
}
