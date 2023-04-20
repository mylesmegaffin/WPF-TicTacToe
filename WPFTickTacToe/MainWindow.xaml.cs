using Prism.Services.Dialogs;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Reflection.Metadata;
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

namespace WPFTickTacToe
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        static string[,] board = { { "", "", "" }, { "", "", "", }, { "", "", "",} };
        public string turn = "X";
        public static bool winner = false;
        public static int PointsPerWin = 1;

        public MainWindow()
        {
            InitializeComponent();
        }

        public static bool CheckWinner(string player)
        {

            // Check Across the top
            if (board[0, 0].Equals(player) && board[0, 1].Equals(player) && board[0, 2].Equals(player))
            {
                return true;
            }
            // Check Down the left side
            else if (board[0, 0].Equals(player) && board[1, 0].Equals(player) && board[2, 0].Equals(player))
            {
                return true;
            }
            // Check Top left to Bottom Right
            else if (board[0, 0].Equals(player) && board[1, 1].Equals(player) && board[2, 2].Equals(player))
            {
                return true;
            }
            // Check Bottom left to Top Right
            else if (board[2, 0].Equals(player) && board[1, 1].Equals(player) && board[0, 2].Equals(player))
            {
                return true;
            }
            // Check Across the Bottom
            else if (board[2, 0].Equals(player) && board[2, 1].Equals(player) && board[2, 2].Equals(player))
            {
                return true;
            }
            // Check Down the Right side
            else if (board[0, 2].Equals(player) && board[1, 2].Equals(player) && board[2, 2].Equals(player))
            {
                return true;
            }
            // Check Across the Middle
            else if (board[1, 0].Equals(player) && board[1, 1].Equals(player) && board[1, 2].Equals(player))
            {
                return true;
            }
            // Check down the Middle
            else if (board[0, 1].Equals(player) && board[1, 1].Equals(player) && board[2, 1].Equals(player))
            {
                return true;
            }
            else
            {
                return false;
            }

            

        }

        private void Placement(object sender, RoutedEventArgs e)
        {
            string content = (sender as Button).Name.ToString();
            Trace.WriteLine(content);
            switch (content)
            {
                case "btn1":
                    if (board[0, 0] == "")
                    {
                        board[0, 0] = CurrentPlayer();
                        btn1.Content = board[0, 0];
                    }
                    break;
                case "btn2":
                    if (board[1, 0] == "")
                    {
                        board[1, 0] = CurrentPlayer();
                        btn2.Content = board[1, 0];
                    }
                    break;
                case "btn3":
                    if (board[2, 0] == "")
                    {
                        board[2, 0] = CurrentPlayer();
                        btn3.Content = board[2, 0];
                    }
                    break;
                case "btn4":
                    if (board[0, 1] == "")
                    {
                        board[0, 1] = CurrentPlayer();
                        btn4.Content = board[0, 1];
                    }
                    break;
                case "btn5":
                    if (board[1, 1] == "")
                    {
                        board[1, 1] = CurrentPlayer();
                        btn5.Content = board[1, 1];
                    }
                    break;
                case "btn6":
                    if (board[2, 1] == "")
                    {
                        board[2, 1] = CurrentPlayer();
                        btn6.Content = board[2, 1];
                    }
                    break;
                case "btn7":
                    if (board[0, 2] == "")
                    {
                        board[0, 2] = CurrentPlayer();
                        btn7.Content = board[0, 2];
                    }
                    break;
                case "btn8":
                    if (board[1, 2] == "")
                    {
                        board[1, 2] = CurrentPlayer();
                        btn8.Content = board[1, 2];
                    }
                    break;
                case "btn9":
                    if (board[2, 2] == "")
                    {
                        board[2, 2] = CurrentPlayer();
                        btn9.Content = board[2, 2];
                    }
                    break;
            }

            //Adding Score
            if (CheckWinner("X"))
            {
                winner = true;
                Int32.TryParse(XScore.Text, out int result);
                result += PointsPerWin;
                XScore.Text = result.ToString();
            }
            else if (CheckWinner("O"))
            {
                winner = true;
                Int32.TryParse(OScore.Text, out int result);
                result += PointsPerWin;
                OScore.Text = result.ToString();
            }

        }

        public string CurrentPlayer()
        {
            switch(turn)
            {
                case "X":
                    turn = "O";
                    return "X";
                case "O":
                    turn = "X";
                    return "O";
                default:
                    return "";
            }
        }

        private void NewGame(object sender, RoutedEventArgs e)
        {
            btn1.Content = null;
            btn2.Content = null;
            btn3.Content = null;
            btn4.Content = null;
            btn5.Content = null;
            btn6.Content = null;
            btn7.Content = null;
            btn8.Content = null;
            btn9.Content = null;

            if (CheckWinner("X"))
            {
              
            }
            CheckWinner("O");

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    board[i, j] = "";

                }
            }
            winner = false;

        }

        private void Grid_MouseMove(object sender, MouseEventArgs e)
        {
            if (winner)
            {
                btn1.IsEnabled = false;
                btn2.IsEnabled = false;
                btn3.IsEnabled = false;
                btn4.IsEnabled = false;
                btn5.IsEnabled = false;
                btn6.IsEnabled = false;
                btn7.IsEnabled = false;
                btn8.IsEnabled = false;
                btn9.IsEnabled = false;
            }
            else
            {
                btn1.IsEnabled = true;
                btn2.IsEnabled = true;
                btn3.IsEnabled = true;
                btn4.IsEnabled = true;
                btn5.IsEnabled = true;
                btn6.IsEnabled = true;
                btn7.IsEnabled = true;
                btn8.IsEnabled = true;
                btn9.IsEnabled = true;
            }
        }
    }
}
