using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Verrassingskalender_Api.Database;
using Verrassingskalender_Api.Models;
using Verrassingskalender_Api.Models.Enums;
using Verrassingskalender_Api.Services;
using Xunit;

namespace Verrassingskalender_Tests
{
    public class GridTests
    {
        [Fact]
        public async void GivenTheAdminUserWantsToGenerateAGrid_WhenGenerateGridIsCalled_ThenGridFactoryReturnsANewGrid()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<VerrassingsKalenderContext>()
            .UseInMemoryDatabase(databaseName: "VerrassingsKalenderDatabase")
            .Options;

            GridFactory gridFactory;
            Grid result;
            using (var context = new VerrassingsKalenderContext(options))
            {
                gridFactory = new GridFactory(context);

                // Act
                result = await gridFactory.GenerateGrid();

            }

            // Assert
            result.Should().NotBeNull();
            result.Cells.Count().Should().Be(10000);
            result.Cells.Where(c => c.CellContent == CellContent.GrandPrize).Count().Should().Be(1);
            result.Cells.Where(c => c.CellContent == CellContent.ConsolationPrize).Count().Should().Be(100);
            result.Cells.Where(c => c.CellContent == CellContent.NoPrize).Count().Should().Be(9899);
            using (var context = new VerrassingsKalenderContext(options))
            {
                context.Grid.Should().NotBeNull();
            }
        }
    }
}