using Verrassingskalender_Api.Models;
using Verrassingskalender_Api.Models.Enums;

namespace Verrassingskalender_Api.Services
{
    public interface IGridService
    {
        public CellContent ScratchGridCell(int id, string playerName);

        public GridViewModel GetGridViewModel();
    }
}
