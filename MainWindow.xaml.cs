using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Media;


namespace Xiangqi01
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Grid grid = new Grid();
        GameBoard gameboard = new GameBoard();
        //SoundPlayer player = new SoundPlayer();
       
       /* public void PlaySound()
        {
            player.SoundLocation = "..\\..\\..\\Resource\\StartMusic.mp3";
            player.Load();
            player.Play();
        }*/
        public MainWindow()
        {
            InitializeComponent();
            
            
        }


      
        void CreateGrid()
        {
            Button mute = new Button();
            mute.Visibility = Visibility.Visible;
            mute.Width = 200;
            mute.Height = 200;
            mute.HorizontalAlignment = HorizontalAlignment.Center;
            mute.VerticalAlignment = VerticalAlignment.Top;
            
            ImageBrush background = new ImageBrush();
            background.ImageSource = new BitmapImage(new Uri("..\\..\\..\\Resource\\bg3.jpg", UriKind.RelativeOrAbsolute));
            Background = background;
            
            for (int col = 0; col < 9; col++)
            {
                ColumnDefinition columndefinition = new ColumnDefinition();
                columndefinition.Width = new GridLength(1, GridUnitType.Star);
                grid.ColumnDefinitions.Add(columndefinition);
            }
            for (int row = 0; row < 10; row++)
            {
                RowDefinition rowdefinition = new RowDefinition();
                rowdefinition.Height = new GridLength(1, GridUnitType.Star);
                grid.RowDefinitions.Add(rowdefinition);
            }
            Draw();
        }

        private void ImageMouseDown(object sender, MouseButtonEventArgs e)
        {
            Image image = (Image)sender;
            int row = Grid.GetRow(image);
            int column = Grid.GetColumn(image);
            

            if (GameBoard.ChoseChess == 0) //选棋子
            {
                gameboard.JudgeSide(row, column);
                if (GameBoard.Selected)
                {
                    ShowPosition();
                }
            }
            else //移动棋子
            {
                gameboard.MovePiece(row, column);
                if (GameBoard.Moveable)
                {
                    Draw();
                    gameboard.GameOver();
                }
            }
        }
        void Draw()
        {
            grid.Children.Clear();
            for (int row = 0; row < 10; row++)
            {
                for (int col = 0; col < 9; col++)
                {
                    Image image = new Image();
                    image.MouseDown += new MouseButtonEventHandler(ImageMouseDown);

                    //画棋子
                    image.Source = new BitmapImage(new Uri(GameBoard.board[row, col].ToString(), UriKind.Relative));

                    Grid.SetRow(image, row);
                    Grid.SetColumn(image, col);
                    grid.Children.Add(image);
                }
            }
        }


        void ShowPosition() //选棋后的刷新
        {
            grid.Children.Clear();
            for (int row = 0; row < 10; row++)
            {
                for (int col = 0; col < 9; col++)
                {
                    Image image = new Image();
                    image.MouseDown += new MouseButtonEventHandler(ImageMouseDown);

                    if (GameBoard.board[GameBoard.posy, GameBoard.posx].Move(GameBoard.posx, GameBoard.posy, col, row, GameBoard.board))  //显示可走的地方
                        image.Source = new BitmapImage(new Uri(GameBoard.board[row, col].SelcetChess(), UriKind.Relative));
                    else if (row == GameBoard.posy && col == GameBoard.posx)  //变成选中形态的棋子
                        image.Source = new BitmapImage(new Uri(GameBoard.board[row, col].SelcetChess(), UriKind.Relative));
                    else  //画棋子
                        image.Source = new BitmapImage(new Uri(GameBoard.board[row, col].ToString(), UriKind.Relative));

                    Grid.SetRow(image, row);
                    Grid.SetColumn(image, col);
                    grid.Children.Add(image);
                }
            }
        }

        private void Button_Start(object sender, RoutedEventArgs e)
        {
            gameboard.InitializeBoard();
            CreateGrid();
            this.Content = grid;
        }

        private void Button_Exit(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Button_Play(object sender, RoutedEventArgs e)
        {
            
        }

        


    }
}
