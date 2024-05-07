using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    public class GameState
    {
        private Block currentBlock;
        public Block CurrentBlock
        {
            get => currentBlock;
            private set
            {
                currentBlock = value;
                currentBlock.Reset();
            }
        }
        public GameGrid GameGrid { get; }
        public BlockQueue BlockQueue { get; }
        public bool GameOver { get; set; }
        private int _score;
        
        public GameState()
        {
            GameGrid = new GameGrid(22, 10);
            BlockQueue = new BlockQueue();
            CurrentBlock = BlockQueue.GetAndUpdate();
        }
        public int Score
        {
            get { return _score; }
            set { _score = value; }
        }
        private bool BlockFits()
        {
            foreach (Position p in CurrentBlock.TilePosition()) 
            { 
                if (!GameGrid.IsEmpty(p.Row, p.Column))
                {
                    return false;
                }
            }
            return true;        
        }
        public void RotateBlockCW()
        {
            CurrentBlock.RotateCW();
            if (!BlockFits())
            {
                CurrentBlock.RotateCCW();
            }
        }
        public void RotateBlockCCW()
        {
            CurrentBlock.RotateCCW();
            if (!BlockFits())
            {
                CurrentBlock.RotateCW();
            }
        }
        public void MoveBlockLeft()
        {
            currentBlock.Move(0, -1);
            if (!BlockFits())
            {
                CurrentBlock.Move(0, 1);
            }
        }
        public void MoveBlockRight()
        {
            currentBlock.Move(0, 1);
            if (!BlockFits())
            {
                CurrentBlock.Move(0, -1);
            }
        }
        private bool IsGameOver()
        {
            return !(GameGrid.IsRowEmpty(0) && GameGrid.IsRowEmpty(1));
        }
        private void PlaceBlock()
        {
            foreach( Position p in CurrentBlock.TilePosition())
            {
                int row = p.Row;
                int col = p.Column;

                // Check if the row and column indices are within the grid boundaries
                if (row >= 0 && row < GameGrid.Rows && col >= 0 && col < GameGrid.Columns)
                {
                    GameGrid[p.Row, p.Column] = currentBlock.Id;
                }
                
            }
   
            int lineClears = GameGrid.ClearFullRows();

            switch (lineClears)
            {
                case 1:
                    Score += 100; // Single Line Clear: 100 Points
                    break;
                case 2:
                    Score += 300; // Double Line Clear: 300 Points
                    break;
                case 3:
                    Score += 500; // Triple Line Clear: 500 Points
                    break;
                case 4:
                    Score += 800; // Tetris Line Clear: 800 Points
                    break;
            }
            if (IsGameOver() )
            {
                GameOver = true;
            }
            else
            {
                CurrentBlock = BlockQueue.GetAndUpdate();
            }    
        }
        public void MoveBlockDown()
        {
            currentBlock.Move(1, 0);
            if (!BlockFits())
            {
                currentBlock.Move(-1, 0);
                PlaceBlock();
            }
        }
        public void RestartGame()
        {
            CurrentBlock= BlockQueue.GetAndUpdate();
            GameOver = false;
            Score = 0;
            GameGrid.ClearGrid();

        }
    }
}
