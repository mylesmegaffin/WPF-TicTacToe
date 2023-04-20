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
        public MainWindow()
        {
            InitializeComponent();
        }


        public static void CheckWinner(string player)
        {

            // Check Across the top
            if (board[0, 0].Equals(player) && board[0, 1].Equals(player) && board[0, 2].Equals(player))
            {
                MessageBox.Show($"{player} is the Winner");
            }
            // Check Down the left side
            else if (board[0, 0].Equals(player) && board[1, 0].Equals(player) && board[2, 0].Equals(player))
            {
                MessageBox.Show($"{player} is the Winner");
            }
            // Check Top left to Bottom Right
            else if (board[0, 0].Equals(player) && board[1, 1].Equals(player) && board[2, 2].Equals(player))
            {
                MessageBox.Show($"{player} is the Winner");
            }
            // Check Bottom left to Top Right
            else if (board[2, 0].Equals(player) && board[1, 1].Equals(player) && board[0, 2].Equals(player))
            {
                MessageBox.Show($"{player} is the Winner");
            }
            // Check Across the Bottom
            else if (board[2, 0].Equals(player) && board[2, 1].Equals(player) && board[2, 2].Equals(player))
            {
                MessageBox.Show($"{player} is the Winner");
            }
            // Check Down the Right side
            else if (board[0, 2].Equals(player) && board[1, 2].Equals(player) && board[2, 2].Equals(player))
            {
                MessageBox.Show($"{player} is the Winner");
            }
            // Check Across the Middle
            else if (board[1, 0].Equals(player) && board[1, 1].Equals(player) && board[1, 2].Equals(player))
            {
                MessageBox.Show($"{player} is the Winner");
            }
            // Check down the Middle
            else if (board[0, 1].Equals(player) && board[1, 1].Equals(player) && board[2, 1].Equals(player))
            {
                MessageBox.Show($"{player} is the Winner");
            }

        }

        private void Placement(object sender, RoutedEventArgs e)
        {
            CheckWinner(turn);
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

        private void Grid_MouseMove(object sender, MouseEventArgs e)
        {
            CheckWinner("X");
            CheckWinner("O");
        }
    }
}
