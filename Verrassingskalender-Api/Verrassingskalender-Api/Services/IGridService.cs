using Verrassingskalender_Api.Models;
using Verrassingskalender_Api.Models.Enums;

namespace Verrassingskalender_Api.Services
{
    public interface IGridService
    {
        public Task<CellContent> ScratchGridCell(ScratchGridCellRequest scratchGridCellRequest);

        public Task<GridViewModel> GetGridViewModel();
    }
}
