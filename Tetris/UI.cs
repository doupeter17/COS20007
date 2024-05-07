using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using SplashKitSDK;
using static System.Formats.Asn1.AsnWriter;

namespace Tetris
{
    public class GameUI
    {
        private const int CellSize = 30; // set size of each block is 40 pixel
        private const int BoardX = 50;
        private const int BoardY = 50;  // Set the initial point of X and Y of board in the screen
        private int level = 1;

        public int Level
        {
            get
            {
                return level;
            }
            set
            {
                level  = value;
            }
        }


        private GameState _gameState;

        public GameUI(GameState gamestate)
        {
            _gameState = gamestate;
        }
        public void DrawGameBoard()
        {
            int boardWidth = _gameState.GameGrid.Columns * CellSize;
            int boardHeight = _gameState.GameGrid.Rows * CellSize;

            // Calculating the width and height for game board 

            for (int i = 0; i < 8; i++)
            {
                int x = BoardX - i;
                int y = BoardY - i;
                int width = boardWidth + 2 * i;
                int height = boardHeight + 2 * i;
                SplashKit.DrawRectangle(Color.White, x, y, width, height);
            }
            for (int row = 0; row < _gameState.GameGrid.Rows; row++)
            {
                for (int col = 0; col < _gameState.GameGrid.Columns; col++)
                {
                    int cellValue = _gameState.GameGrid[row, col];
                    Color cellColor = GetCellColor(cellValue);

                    // Calculate the coordinates of the current cell
                    int cellX = BoardX + col * CellSize;
                    int cellY = BoardY + row * CellSize;

                    // Calculate the coordinates of the right border of the cell
                    int rightBorderX = cellX + CellSize - 4;
                    int rightBorderY = cellY;

                    // Calculate the coordinates of the bottom border of the cell
                    int bottomBorderX = cellX;
                    int bottomBorderY = cellY + CellSize - 4;

                    // Fill the rest of the cell with the actual cell color
                    SplashKit.FillRectangle(cellColor, cellX, cellY, CellSize - 1, CellSize - 1);

                    // Draw the right border of the cell
                    SplashKit.FillRectangle(Color.Black, rightBorderX, rightBorderY, 4, CellSize);

                    // Draw the bottom border of the cell
                    SplashKit.FillRectangle(Color.Black, bottomBorderX, bottomBorderY, CellSize, 4);

                    // Draw the white reflection
                    if (cellValue != 0)
                    {
                        
                    }
                }
            }

        }
        private Color GetCellColor(int cellValue)
        {
           
            switch (cellValue)
            {
                case 1: return SplashKit.RGBColor(141, 211, 199);
                case 3: return SplashKit.RGBColor(255, 255, 179);
                case 5: return SplashKit.RGBColor(190, 186, 218);
                case 7: return SplashKit.RGBColor(251, 128, 114);
                case 2: return SplashKit.RGBColor(128, 177, 211);
                case 4: return SplashKit.RGBColor(253, 180, 98);
                case 6: return SplashKit.RGBColor(179, 222, 105);
                default: return Color.Black; // Empty cell color
            }
                
            
        }

        public void DrawBlockFallDown(Block block)
        {
            foreach (Position position in block.TilePosition())
            {
                int row = position.Row;
                int col = position.Column;
                int cellValue = block.Id;
                Color cellColor = GetCellColor(block.Id);


                int cellX = BoardX + col * CellSize;
                int cellY = BoardY + row * CellSize;
                int rightBorderX = cellX + CellSize - 4;
                int rightBorderY = cellY;

                // Calculate the coordinates of the bottom border of the cell
                int bottomBorderX = cellX;
                int bottomBorderY = cellY + CellSize - 4;

                SplashKit.FillRectangle(cellColor, cellX, cellY, CellSize - 1, CellSize - 1);
                SplashKit.FillRectangle(Color.Black, rightBorderX, rightBorderY, 4, CellSize);

                // Draw the bottom border of the cell
                SplashKit.FillRectangle(Color.Black, bottomBorderX, bottomBorderY, CellSize, 4);

            }
        }
        public void DrawNextBlockPreview(Block nextBlock)
        {

            // Calculate the position where you want to draw the next Tetromino preview
            int nextBlockX = 620;
            int nextBlockY = 110;
            int offSetX = nextBlock.TilePosition().ElementAt(0).Column * CellSize;
            int offSetY = nextBlock.TilePosition().ElementAt(0).Row * CellSize;

            SplashKit.FillRectangle(Color.White, 495, 45, 280, 190);
            SplashKit.FillRectangle(Color.Black, 500, 50, 270, 180 );
            SplashKit.DrawText("NEXT BLOCK ", Color.Cyan, "Arial", 35, 495 + 10, 45 + 10);
            SplashKit.DrawText("NEXT BLOCK", Color.White, "Arial", 35, 495 + 12, 45 + 12);

            foreach (Position position in nextBlock.TilePosition())
            {
                int row = position.Row;
                int col = position.Column;
                
                int cellValue = nextBlock.Id;
                Color cellColor = GetCellColor(cellValue);

                int drawX = nextBlockX + col * CellSize - offSetX;
                int drawY = nextBlockY + row * CellSize  - offSetY;
                // Draw the cell with a black border
                SplashKit.FillRectangle(cellColor, drawX, drawY, CellSize, CellSize);
                SplashKit.FillRectangle(Color.Black, drawX + CellSize - 4, drawY, 4, CellSize);
                SplashKit.FillRectangle(Color.Black, drawX, drawY + CellSize - 4, CellSize, 4);
 
            }
        }
        public void DrawScore(int score, bool gameover)
        {
            int scoreX = 500;
            int scoreY = 300;
            SplashKit.FillRectangle(Color.White, scoreX - 4, scoreY - 4, 278, 188);
            SplashKit.FillRectangle(Color.Black, scoreX , scoreY , 270, 180);
            
            

            SplashKit.DrawText("Score: " + score, Color.Cyan, "Arial", 35, scoreX + 10 , scoreY + 10);
            SplashKit.DrawText("Score: " + score, Color.White, "Arial", 35, scoreX +12, scoreY +12);
            if (gameover)
            {
                SplashKit.DrawText("GAME OVER!!!", Color.Cyan, "Arial", 60, scoreX + 70, scoreY + 70);
                SplashKit.DrawText("GAME OVER!!!", Color.White, "Arial", 60, scoreX + 72, scoreY + 72);
            }

        }
        public void DrawInstruction()
        {
            int scoreX = 500;
            int scoreY = 550;
            SplashKit.FillRectangle(Color.White, scoreX - 4, scoreY - 4, 278, 148);
            SplashKit.FillRectangle(Color.Black, scoreX, scoreY, 270, 140);



            SplashKit.DrawText("INSTRUCTION: ", Color.Cyan, "Arial", 35, scoreX + 10, scoreY + 10);
            SplashKit.DrawText("INSTRUCTION: ", Color.White, "Arial", 35, scoreX + 12, scoreY + 12);

            SplashKit.DrawText("rotate: Z, X", Color.Cyan, "Arial", 35, scoreX + 10, scoreY + 30);
            SplashKit.DrawText("rotate: Z, X", Color.White, "Arial", 35, scoreX + 12, scoreY + 32);

            

            SplashKit.DrawText("movement: LEFT DOWN RIGHT", Color.Cyan, "Arial", 35, scoreX + 10, scoreY + 50);
            SplashKit.DrawText("movement: LEFT DOWN RIGHT", Color.White, "Arial", 35, scoreX + 12, scoreY + 52);

            SplashKit.DrawText("restart: R ", Color.Cyan, "Arial", 35, scoreX + 10, scoreY + 70);
            SplashKit.DrawText("restart: R ", Color.White, "Arial", 35, scoreX + 12, scoreY + 72);
        }

        public void DrawUI()
        {
            DrawGameBoard();
            DrawInstruction();
            DrawBlockFallDown(_gameState.CurrentBlock);
            DrawNextBlockPreview(_gameState.BlockQueue.NextBlock);
            DrawScore(_gameState.Score, _gameState.GameOver);
            

        }
    }
}
