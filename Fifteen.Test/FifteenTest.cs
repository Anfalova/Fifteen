using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Fifteen.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Too few arguments.")]
        public void Game_FewArguments_ExceptionThrown()
        {
             new Fifteen.Game(1, 2);
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Playing field isn't squared.")]
        public void Game_IsNotSquare_ExceptionThrown()
        {
             new Fifteen.Game(1, 2, 3, 4, 0);
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Numeric values is not correct.")]
        public void Game_ValuesIsNotDifferent_ExceptionThrown()
        {
            new Fifteen.Game(1, 2, 3, 4, 5, 6, 9, 9, 0);
        }
        [TestMethod]
        public void Indexator_Should_Return_Correct_Value()
        {
            Game game = new Game(1, 2, 3, 0);
            int result = game[0, 0];
            Assert.AreEqual(1, result);
        }
        [TestMethod]
        public void GetLocation_Should_Return_Correct_Value()
        {
            Game game = new Game(1, 2, 3, 0);
            Location result = game.GetLocation(1);
            Assert.AreEqual(0, result.X);
            Assert.AreEqual(0, result.Y);
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Element not adjacent to zero.")]
        public void Shift_ElementCanNotBeMoved_ThrowException()
        {
            Game game = new Game(1, 2, 3, 0);
            game.Shift(1);
        }
        [TestMethod]
        public void Shift_MoveOfElement_IsCorrect()
        {
            Game game = new Game(1, 2, 3, 0);
            game.Shift(2);
            Location resultCoordinatesOfZero = game.GetLocation(0);
            int shiftedTile = game[1, 1];
            Assert.AreEqual(2, shiftedTile);
            Assert.AreEqual(0, resultCoordinatesOfZero.X);
            Assert.AreEqual(1, resultCoordinatesOfZero.Y);
        }

        [TestMethod]
        public void ImmutableGame_Should_BeImmutable()
        {
            FifteenImmutable.ImmutableGame game = new FifteenImmutable.ImmutableGame(1, 2, 3, 0);
            game.Shift(2);
            FifteenImmutable.Location resultCoordinatesOfZero = game.GetLocation(0);
            int shiftedTile = game[0, 1];
            Assert.AreEqual(2, shiftedTile);
            Assert.AreEqual(1, resultCoordinatesOfZero.X);
            Assert.AreEqual(1, resultCoordinatesOfZero.Y);
        }

        [TestMethod]
        public void ImmutableGame_Shift_CreateNewImmutableGameCorrectly()
        {
            FifteenImmutable.ImmutableGame game = new FifteenImmutable.ImmutableGame(1, 2, 3, 0);
            game = game.Shift(2);
            FifteenImmutable.Location resultCoordinatesOfZero = game.GetLocation(0);
            int shiftedTile = game[1, 1];
            Assert.AreEqual(2, shiftedTile);
            Assert.AreEqual(0, resultCoordinatesOfZero.X);
            Assert.AreEqual(1, resultCoordinatesOfZero.Y);
        }
    }
}
