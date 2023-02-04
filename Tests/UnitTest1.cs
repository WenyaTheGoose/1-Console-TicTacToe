namespace TicTacToe
{
    public class Tests
    {
        // VS wants me to use Assert.That method, when i want to use classic model
        // why?
#pragma warning disable NUnit2005 // Consider using Assert.That(actual, Is.EqualTo(expected)) instead of Assert.AreEqual(expected, actual)

        [Test]
        public void NoWinnerTest()
        {
            Assert.AreEqual(Player.Noone, Gamefield.GetWinner(
                new char[,] {{' ','O','X'},
                             {'O','X','O'},
                             {' ','O','X'}}));
        }

        [Test]
        public void DrawTest()
        {
            Assert.AreEqual(Player.Draw, Gamefield.GetWinner(
                new char[,] {{'O','O','X'},
                             {'X','X','O'},
                             {'O','X','X'}}));
        }

        [Test]
        public void ORowWinner()
        {
            Assert.AreEqual(Player.O, Gamefield.GetWinner(
                new char[,] {{'O','X','X'},
                             {'O','O','O'},
                             {'X','O','X'}}));
        }

        [Test]
        public void XColumnWinner()
        {
            Assert.AreEqual(Player.X, Gamefield.GetWinner(
                new char[,] {{'X','X','O'},
                             {'X','O','O'},
                             {'X','O','X'}}));
        }

        [Test]
        public void XColumnWinner2()
        {
            Assert.AreEqual(Player.X, Gamefield.GetWinner(
                new char[,] {{'O','X','X'},
                             {'X','O','X'},
                             {'O','O','X'}}));
        }
    }
}