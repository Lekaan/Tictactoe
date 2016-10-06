using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.SqlServer.Server;
using NUnit.Framework;
using TicTacToe.Services;

namespace TicTacToe.UnitTests
{
    [TestFixture]
    class GameBoardTest
    {
        private char[,] _gameBoard;

        [SetUp]
        public void SetupUnitTests()
        {
            _gameBoard = new char[3, 3]
                  {
                      {' ', ' ', ' '},
                      {' ', ' ', ' '},
                      {' ', ' ', ' '}
                  };
        }
        [Test]
        public void CanGetGameBoard()
        {
            Assert.AreEqual(_gameBoard, GameBoard.GetGameBoard());
        }

        [Test]
        public void CanCheckPlayerInput()
        {
            Assert.IsTrue(GameBoard.CanConvertPlayerInput("0.2"));
            Assert.IsFalse(GameBoard.CanConvertPlayerInput("4.5"));

        }

        [Test]
        public void CanGetPlayer()
        {
            Assert.IsTrue(GameBoard.GetPlayer());
            GameBoard.SetCurrentPlayer();
            Assert.IsFalse(GameBoard.GetPlayer());
            GameBoard.SetCurrentPlayer();

        }
        [Test]
        public void CanSetGameBoard()
        {
            Assert.AreEqual(' ', GameBoard.GetGameBoardField());
            Assert.AreEqual(0, GameBoard.CountPlayerIcons());
            Assert.LessOrEqual(GameBoard.CountPlayerIcons(), 3);

            GameBoard.PopulateField();
            Assert.AreEqual('X', GameBoard.GetGameBoardField());

            Assert.AreEqual(1, GameBoard.CountPlayerIcons());

            GameWinnerService gm = new GameWinnerService();
            Assert.AreEqual(' ', gm.Validate(GameBoard.GetGameBoard()));
        }

        //public void CanPrintBoard()
        //{

        //    string board =
        //        "       #       #                        #       #       \n" +
        //        "       #       #                  (0,0) # (0,1) # (0,2) \n" +
        //        "       #       #                        #       #       \n" +
        //        "#######################          #######################\n" +
        //        "       #       #                        #       #       \n" +
        //        "       #       #                  (1,0) # (1,1) # (1,2) \n" +
        //        "       #       #                        #       #       \n" +
        //        "#######################          #######################\n" +
        //        "       #       #                        #       #       \n" +
        //        "       #       #                  (2,0) # (2,1) # (2,2) \n" +
        //        "       #       #                        #       #       \n";

        //    GameBoard.


        //    Assert.AreEqual(board, GameBoard.GetBoard());
        //}
    }
}
