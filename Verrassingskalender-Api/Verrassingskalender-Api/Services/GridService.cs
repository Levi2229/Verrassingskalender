using Verrassingskalender_Api.Database;
using Verrassingskalender_Api.Models;
using Verrassingskalender_Api.Models.Enums;

namespace Verrassingskalender_Api.Services
{
    public class GridService : IGridService
    {
        private readonly IVerrassingsKalenderRepository _repository;
        private readonly VerrassingsKalenderContext _context;
        public GridService(IVerrassingsKalenderRepository repository, VerrassingsKalenderContext context)
        {
            _repository = repository;
            _context = context;
        }


        public async Task<GridViewModel> GetGridViewModel()
        {
            Grid grid = await _repository.GetGrid(0);

            var gridViewModel = new GridViewModel();
            gridViewModel.Cells = grid.Cells.Select(c =>
            {
                var cellViewModel = new CellViewModel();
                cellViewModel.Id = c.Id;
                //Clarity: If the player is null, we don't want to provide the front-end with the CellContent type, to prevent cheating.
                cellViewModel.CellContent = c.Player != null ? c.CellContent : null;
                return cellViewModel;
            }).ToList();
            return gridViewModel;
        }

        public async Task<CellContent> ScratchGridCell(ScratchGridCellRequest scratchGridCellRequest)
        {
            var cell = await TryGetEmptyCell(scratchGridCellRequest);

            cell!.Player = new Player(scratchGridCellRequest.PlayerName);
            _context.SaveChanges();

            return cell.CellContent;
        }

        private async Task<Cell?> TryGetEmptyCell(ScratchGridCellRequest scratchGridCellRequest)
        {
            Grid grid = await _repository.GetGrid(0);

            if (grid.Cells.Any(c => c.Player?.Name == scratchGridCellRequest.PlayerName))
            {
                // Improvement: normally this would be a different exception type, i.e. DomainExcption. Handled differentlyto indicate a user error, not a 500.
                throw new Exception($"U hebt al een vakje gekrast met speler naam: {scratchGridCellRequest.PlayerName}");
            }

            var cell = await _repository.GetCell(scratchGridCellRequest.CellId, scratchGridCellRequest.PlayerName);

            if (cell.Player != null)
            {
                throw new Exception($"Dit vakje is al opengekrast door speler {cell.Player.Name}");
            }

            return cell;
        }
    }
}
