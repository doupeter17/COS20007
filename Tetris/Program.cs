using System;
using System.Diagnostics;
using System.Reflection.Emit;
using SplashKitSDK;
using Tetris;
namespace SnakeBite
{
    public class Program
    {
        public static void Main()
        {
            const int WindowWidth = 800;
            const int WindowHeight = 800;
            SplashKit.OpenWindow("Tetris Game", WindowWidth, WindowHeight);
            GameState gameState = new GameState();
            GameUI gameUI = new GameUI(gameState);
            double initialMoveDownInterval = 0.5;
            double MoveDownInterval = initialMoveDownInterval;
            double timeSinceLastMoveDown = 0;


            Stopwatch gameTimer = new Stopwatch();
            Stopwatch deplayStep = new Stopwatch();
            while (!SplashKit.WindowCloseRequested("Tetris Game"))
            {
                SplashKit.ProcessEvents();
                SplashKit.ClearScreen(SplashKit.RGBColor(116, 116, 116));    
                

                
                gameTimer.Start();
                deplayStep.Start();
                if (gameTimer.Elapsed.TotalSeconds  - timeSinceLastMoveDown >= MoveDownInterval)
                {
                    gameState.MoveBlockDown(); // Move the Tetromino down
                    timeSinceLastMoveDown = gameTimer.Elapsed.TotalSeconds; // Update the time of the last move
                }

                if (SplashKit.KeyDown(KeyCode.LeftKey) && deplayStep.ElapsedMilliseconds >= 200)
                {
                    gameState.MoveBlockLeft();
                    deplayStep.Restart();
                }
                if (SplashKit.KeyDown(KeyCode.RightKey) && deplayStep.ElapsedMilliseconds >= 200)
                {
                    gameState.MoveBlockRight();
                    deplayStep.Restart();
                }
                if (SplashKit.KeyDown(KeyCode.DownKey) && deplayStep.ElapsedMilliseconds >= 200)
                {
                    gameState.MoveBlockDown();
                    deplayStep.Restart();
                }
                if (SplashKit.KeyDown(KeyCode.ZKey) && deplayStep.ElapsedMilliseconds >= 200)
                {
                    gameState.RotateBlockCW();
                    deplayStep.Restart();
                }
                if (SplashKit.KeyDown(KeyCode.XKey) && deplayStep.ElapsedMilliseconds >= 200)
                {
                    gameState.RotateBlockCCW();
                    deplayStep.Restart();
                }
                if (SplashKit.KeyDown(KeyCode.RKey) && deplayStep.ElapsedMilliseconds >= 1000)
                {
                    gameState.RestartGame();
                    deplayStep.Start();
                }


                gameUI.DrawUI();
                SplashKit.RefreshScreen(120);
            }
        }
    }
}
