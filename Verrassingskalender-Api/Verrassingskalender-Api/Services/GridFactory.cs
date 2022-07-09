using Verrassingskalender_Api.Database;
using Verrassingskalender_Api.Models;
using Verrassingskalender_Api.Models.Enums;

namespace Verrassingskalender_Api.Services
{
    public class GridFactory : IGridFactory
    {
        private static readonly int GridLength = 10000;
        private static readonly int AmountOfConsulationPrizes = 100;

        public VerrassingsKalenderContext _verrassingsKalenderContext { get; }

        public GridFactory(VerrassingsKalenderContext verrassingsKalenderContext)
        {
            _verrassingsKalenderContext = verrassingsKalenderContext;
        }

        public async Task<Grid> GenerateGrid()
        {
            var grid = new Grid();
            var indicesToAddConsulationPrize = GetUniqueRandomNumbersInRange(0, GridLength, AmountOfConsulationPrizes);
            for (int i = 0; i < GridLength; i++)
            {
                if (indicesToAddConsulationPrize.Contains(i))
                {
                    grid.Cells.Add(new Cell(CellContent.ConsolationPrize));
                } else
                {
                    grid.Cells.Add(new Cell(CellContent.NoPrize));
                }
            }
            grid = AddGrandPrize(grid);

            _verrassingsKalenderContext.Grid.Add(grid);
            await _verrassingsKalenderContext.SaveChangesAsync();

            return grid;
        }

        private static Grid AddGrandPrize(Grid grid)
        {
            var noPrizeCells = grid.Cells.Where(c => c.CellContent == CellContent.NoPrize).ToArray();
            var random = new Random().Next(noPrizeCells.Count());
            var cellWithRandomId = noPrizeCells.ElementAt(random);
            //var cellAtRandomId = noPrizeCells.SingleOrDefault(npc => npc.Id == cellWithRandomId.Id);

            if (cellWithRandomId == null)
            {
                throw new Exception($"There is no cell for number: {random}");
            }

            cellWithRandomId.CellContent = CellContent.GrandPrize;
            return grid;
        }

        private static List<int> GetUniqueRandomNumbersInRange(int from, int to, int numberOfElement)
        {
            var random = new Random();
            HashSet<int> numbers = new HashSet<int>();
            while (numbers.Count < numberOfElement)
            {
                numbers.Add(random.Next(from, to));
            }
            return numbers.ToList();
        }
    }
}
