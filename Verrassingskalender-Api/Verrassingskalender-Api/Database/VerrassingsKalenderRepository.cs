using Microsoft.EntityFrameworkCore;
using Verrassingskalender_Api.Models;

namespace Verrassingskalender_Api.Database
{
    public class VerrassingsKalenderRepository : IVerrassingsKalenderRepository
    {
        private readonly VerrassingsKalenderContext _context;

        public VerrassingsKalenderRepository(VerrassingsKalenderContext context)
        {
            _context = context;
        }

        public async Task<Grid> GetGrid(int id)
        {
            var Grid = await _context.Grid
                .Include(g => g.Cells)
                    .ThenInclude(c => c.Player)
                .SingleOrDefaultAsync(g => g.Id == id);

            if (Grid == null)
            {
                throw new Exception($"Grid with id {id} not found ");
            }
            return Grid;
        }

        public async Task<Cell> GetCell(int cellId, string playerName)
        {
            var cell = await _context.Cell.SingleOrDefaultAsync(c => c.Id == cellId);

            cell!.Player = new Player(playerName);
            return cell;
            //await _context.SaveChangesAsync();
        }
    }
}
