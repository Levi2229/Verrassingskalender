using Microsoft.EntityFrameworkCore;
using Verrassingskalender_Api.Models;

namespace Verrassingskalender_Api.Database
{
    public interface IVerrassingsKalenderRepository
    {
        public Task<Grid> GetGrid(int id);
        public Task<Cell> GetCell(int cellId, string playerName);
    }
}
