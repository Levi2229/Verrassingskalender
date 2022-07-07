using Microsoft.AspNetCore.Mvc;
using Verrassingskalender_Api.Models;
using Verrassingskalender_Api.Services;

namespace Verrassingskalender_Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GridController : ControllerBase
    {
        public IGridService GridService { get; }
        public GridController(IGridService gridService)
        {
            GridService = gridService;
        }

        [HttpGet]
        public GridViewModel Get()
        {
            return GridService.GetGridViewModel();
        }
    }
}