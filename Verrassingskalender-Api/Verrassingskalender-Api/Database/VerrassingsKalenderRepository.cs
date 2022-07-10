using Microsoft.EntityFrameworkCore;
using System.Net;
using System.Web.Http;
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
                var message = $"Grid with id {id} not found";
                ThrowHttpNotFoundError(message);
            }
            return grid;
        }

        public async Task<Cell> GetCell(int cellId, string playerName)
        {
            var cell = await _context.Cell.SingleOrDefaultAsync(c => c.Id == cellId);
            if (cell == null)
            {
                // Opmerking: Normaal gesproken zou je dit ook loggen, zodat je op productie kan zien wat er fout gegaan in.
                ThrowHttpNotFoundError($"Cell with id {cellId} not found.");
            }
            return cell;
        }

        //Opmerking: dit zou normaal gesproken in een exception handling middleware o.i.d. gedaan worden.
        private void ThrowHttpNotFoundError(string message) 
        {
            var response = new HttpResponseMessage(HttpStatusCode.NotFound)
            {
                Content = new StringContent(message),
                ReasonPhrase = message
            };
            // Opmerking: Normaal gesproken zou je dit ook loggen, zodat je op productie kan zien wat er fout gegaan in.
            throw new HttpResponseException(response);
        }
    }
}
