using System;
using System.Runtime.Remoting.Channels;
using TicTacToe.Services;

namespace TicTacToe.UnitTests
{
    internal class GameBoard
    {
        private static bool currentPlayer = true;
        private static int coord1;
        private static int coord2;
        private static char[,] currentGameBoard = new char[3, 3]
        {
            {' ', ' ', ' '},
            {' ', ' ', ' '},
            {' ', ' ', ' '}
        };
        

        internal static char[,] GetGameBoard()
        {
            return currentGameBoard;
        }

        

        internal static bool GetPlayer()
        {
            return currentPlayer;
        }

        internal static void SetCurrentPlayer()
        {
            if (currentPlayer)
                currentPlayer = false;
            else
                currentPlayer = true;
        }

        internal static bool CanConvertPlayerInput(string input)
        {
            int temp1 = Int32.Parse(input.Substring(0, 1));
            int temp2 = Int32.Parse(input.Substring(2, 1));

            if (temp1 >= 0 && temp1 <= 2 && temp2 >= 0 && temp2 <= 2)
            {
                coord1 = temp1;
                coord2 = temp2;
                
                return true;
            }
            
            return false;
        }

        internal static char GetGameBoardField()
        {
            return currentGameBoard[coord1,coord2]; 
        }

        public static char[,] GetSelectedField()
        {
            return new char[coord1,coord2];
        }

        internal static int CountPlayerIcons()
        {
            int iconCount = 0;
            char playerIcon = GetPlayerIcon();
            foreach (char c in currentGameBoard)
            {
                if (c.Equals(playerIcon))
                    iconCount++;
            }
            return iconCount;
        }

        public static char GetPlayerIcon()
        {
            char PlayerIcon = 'X';
            if (!currentPlayer)
                PlayerIcon = 'O';

            return PlayerIcon;
        }

        internal static void PopulateField()
        {
            

            currentGameBoard[coord1, coord2] = GetPlayerIcon();
        }
    }
}