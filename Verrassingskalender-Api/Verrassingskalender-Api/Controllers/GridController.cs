using Microsoft.AspNetCore.Mvc;
using Verrassingskalender_Api.Models;
using Verrassingskalender_Api.Models.Enums;
using Verrassingskalender_Api.Services;

namespace Verrassingskalender_Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GridController : ControllerBase
    {
        public IGridService GridService { get; }
        public IGridFactory GridFactory { get; }

        public GridController(IGridService gridService, IGridFactory gridFactory)
        {
            GridService = gridService;
            GridFactory = gridFactory;
        }

        [HttpGet]
        public async Task<GridViewModel> Get()
        {
            return await GridService.GetGridViewModel();
        }

        [HttpPost("scratchGridCell")]
        public async Task<CellContent> PostScratchGridCell(ScratchGridCellRequest scratchGridCellRequest)
        {
            return await GridService.ScratchGridCell(scratchGridCellRequest);
        }

        //Opdracht notitie: Deze methode zou normaal gesproken beschermt zijn met een [Authorize] attribuut, met mogelijk rollen systeem voor Admin rol.
        [HttpPost("generateGrid")]
        public async Task GenerateGrid()
        {
            await GridFactory.GenerateGrid();
        }
    }
}