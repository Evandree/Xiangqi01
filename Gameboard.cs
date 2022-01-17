using System;
using System.Windows;

namespace Xiangqi01
{
    public class GameBoard
    {

        public static ChessPiece[,] board = new ChessPiece[10, 9]; //initialize an actual chessboard to store chesspiece and all the moving method

        public static int posx;
        public static int posy;
        public static int posx2;
        public static int posy2;
        int turn = 0;
        int Gameover = 0;
        public static int ErrorNumber = 0;
        public static int ChoseChess = 0;
        public static bool Selected = false;
        public static bool Moveable = false;



        public void InitializeBoard()
        {
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    board[i, j] = new blank(Side.blank);    //初始化null
                }
            }

            board[0, 0] = new Chariot(Side.black);
            board[0, 1] = new Horse(Side.black);
            board[0, 2] = new Elephant(Side.black);
            board[0, 3] = new Advisor(Side.black);
            board[0, 4] = new General(Side.black);
            board[0, 5] = new Advisor(Side.black);
            board[0, 6] = new Elephant(Side.black);
            board[0, 7] = new Horse(Side.black);
            board[0, 8] = new Chariot(Side.black);
            board[2, 1] = new Cannon(Side.black);
            board[2, 7] = new Cannon(Side.black);
            board[3, 0] = new Soldier(Side.black);
            board[3, 2] = new Soldier(Side.black);
            board[3, 4] = new Soldier(Side.black);
            board[3, 6] = new Soldier(Side.black);
            board[3, 8] = new Soldier(Side.black);


            board[9, 0] = new Chariot(Side.red);
            board[9, 1] = new Horse(Side.red);
            board[9, 2] = new Elephant(Side.red);
            board[9, 3] = new Advisor(Side.red);
            board[9, 4] = new General(Side.red);
            board[9, 5] = new Advisor(Side.red);
            board[9, 6] = new Elephant(Side.red);
            board[9, 7] = new Horse(Side.red);
            board[9, 8] = new Chariot(Side.red);
            board[7, 1] = new Cannon(Side.red);
            board[7, 7] = new Cannon(Side.red);
            board[6, 0] = new Soldier(Side.red);
            board[6, 2] = new Soldier(Side.red);
            board[6, 4] = new Soldier(Side.red);
            board[6, 6] = new Soldier(Side.red);
            board[6, 8] = new Soldier(Side.red);

        }



        public void JudgeSide(int row, int column)//Determine whether the player select his or her opponent's chesspiece or select an empty place
        {

            if (turn % 2 == 0)
            {
                    if (board[row, column].Side == Side.red)
                    {
                        MessageBox.Show("Please select a black piece!");
                        Selected = false;
                    }
                    else if (board[row, column].Side == Side.blank)
                    {
                        Selected = false;
                    }
                    else
                    {
                        posy = row;
                        posx = column;
                        ChoseChess = 1;
                        Selected = true;
                        turn++;
                }
                
            }
            else
            {
                if (board[row, column].Side == Side.black)
                {
                    MessageBox.Show("Please select a red piece!");
                    Selected = false;
                }
                else if (board[row, column].Side == Side.blank)
                {
                    Selected = false;
                }
                else
                {
                    posy = row;
                    posx = column;
                    ChoseChess = 1;
                    Selected = true;
                    turn++;
                }
            }
            
        }



        public void MovePiece(int row, int column)
        {

            posy2 = row;
            posx2 = column;

            if (board[posy, posx].Move(posx, posy, posx2, posy2, board))  //合法移动
            {
                if (board[posy2, posx2].Type == PieceTypes.General)  //判断被吃的是不是帅
                    Gameover = 1;

                board[posy2, posx2] = board[posy, posx];
                board[posy, posx] = new blank(Side.blank);
                ChoseChess = 0;
                Moveable = true;
            }
            else if (board[posy, posx] == board[posy2, posx2])  //取消移动（再点击一次）
            {
                ChoseChess = 0;
                Moveable = true;
                turn--;
            }
            else if (board[posy, posx].Side == board[posy2, posx2].Side)
            {

            }
            else  //不合法移动
            {
                Moveable = false;
            }

        }

        public void GameOver()
        {
            if (Gameover == 1)
                MessageBox.Show("Game over!");
        }


    }

}
