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
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GridViewModel))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Get()
        {
            return Ok(await GridService.GetGridViewModel());
        }

        [HttpPost("scratchGridCell")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CellContent))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> PostScratchGridCell(ScratchGridCellRequest scratchGridCellRequest)
        {
            return Ok(await GridService.ScratchGridCell(scratchGridCellRequest));
        }

        // Opmerking: Deze methode zou normaal gesproken beschermt zijn met een [Authorize] attribuut, met mogelijk rollen systeem voor Admin rol.
        [HttpPost("generateGrid")]
        public async Task<IActionResult> GenerateGrid()
        {
            // Opmerking: Deze methode eigenlijk bloated, hij doet nu genereren en opslaan zonder dat dat duidelijk is uit de naam.
            _ = await GridFactory.GenerateGrid();
            return Ok();
        }
    }
}