﻿using Microsoft.EntityFrameworkCore;
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
            // Verklaring: Id nu niet in gebruik omdat we nu even uigaan van 1 grid in DB want we kunnen toch niet wisselen.
            var grid = await _context.Grid
                .Include(g => g.Cells)
                    .ThenInclude(c => c.Player)
                .FirstOrDefaultAsync();

            if (grid == null)
            {
                // Improvement: normally this would be logged to gain insight into production and debug capabilities.
                throw new Exception($"Grid with id {id} not found ");
            }
            return grid;
        }

        public async Task<Cell> GetCell(int cellId, string playerName)
        {
            var cell = await _context.Cell.SingleOrDefaultAsync(c => c.Id == cellId);
            if (cell == null)
            {
                // Improvement: normally this would be logged to gain insight into production and debug capabilities.
                throw new Exception($"Cell with id {cellId} not found.");
            }
            return cell;
        }
    }
}
