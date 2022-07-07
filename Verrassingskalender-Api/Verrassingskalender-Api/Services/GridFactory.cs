using Verrassingskalender_Api.Models;
using Verrassingskalender_Api.Models.Enums;

namespace Verrassingskalender_Api.Services
{
    public class GridFactory : IGridFactory
    {
        private static readonly int GridLength = 10000;
        private static readonly int AmountOfConsulationPrizes = 100;

        public Grid GenerateGrid()
        {
            var grid = new Grid();
            var indicesToAddConsulationPrize = GetUniqueRandomNumbersInRange(0, GridLength, AmountOfConsulationPrizes);
            for (int i = 0; i < GridLength; i++)
            {
                if (indicesToAddConsulationPrize.Contains(i))
                {
                    grid.Cells.Add(new Cell(i, GridContent.ConsolationPrize));
                }
            }
            grid = AddGrandPrize(grid);
            return grid;
        }

        private static Grid AddGrandPrize(Grid grid)
        {
            var noPrizeCells = grid.Cells.Where(c => c.GridContent == GridContent.NoPrize).ToArray();
            var random = new Random().Next(noPrizeCells.Count());
            var cellWithRandomId = noPrizeCells.ElementAt(random);
            //var cellAtRandomId = noPrizeCells.SingleOrDefault(npc => npc.Id == cellWithRandomId.Id);

            if (cellWithRandomId == null)
            {
                throw new Exception($"There is no cell for number: {random}");
            }

            cellWithRandomId.GridContent = GridContent.GrandPrize;
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
