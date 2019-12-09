using System;
using System.Drawing;
using System.Windows.Forms;

namespace CountFourGame
{
    public partial class frmCount4 : Form
    {
        private Rectangle[] brdColumns;
        private int[,] tokenboard;
        private int player;
        private const int ROW = 6;
        private const int COLUMN = 7;
        
        public frmCount4()
        {
            InitializeComponent();
            this.brdColumns = new Rectangle[COLUMN];
            this.tokenboard = new int[ROW, COLUMN];
            this.player = 1;
        }

        private void frmCount4_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.FillRectangle(Brushes.RosyBrown, 24, 24, 340, 300);
            for (int i = 0; i < ROW; i++)
            {
                for (int j = 0; j < COLUMN; j++)
                {
                    if (i == 0)
                    {
                        this.brdColumns[j] = new Rectangle(32 + 48 * j, 24, 32, 300);
                    }
                    e.Graphics.FillEllipse(Brushes.White, 32 + 48 * j, 32 + 48 * i, 32, 32);
                }
            }
        }
        #region token placed feature - 1
        private void frmCount4_MouseClick(object sender, MouseEventArgs e)
        {
            int columnIndex = this.GetColumnNumber(e.Location);
            if (columnIndex != -1)
            {
                int rowIndex = this.CheckEmptyRow(columnIndex);
                if (rowIndex != -1)
                {
                    this.tokenboard[rowIndex, columnIndex] = this.player;
                    if (this.player == 1)
                    {
                        Graphics g = this.CreateGraphics();
                        g.FillEllipse(Brushes.Red, 32 + 48 * columnIndex, 32 + 48 * rowIndex, 32, 32);
                    }
                    else if (this.player == 2)
                    {
                        Graphics g = this.CreateGraphics();
                        g.FillEllipse(Brushes.Blue, 32 + 48 * columnIndex, 32 + 48 * rowIndex, 32, 32);
                    }
                    int winner = this.CheckWinner(this.player);
                    if (winner != -1)
                    {
                        string player = (winner == 1) ? "Red" : "Blue";
                        MessageBox.Show(player + " is winner");
                        DialogResult result = MessageBox.Show("Do you want to reset game?", "Reset Game" ,MessageBoxButtons.YesNo);
                        if (result == DialogResult.No)
                            this.Close();
                        else
                            Application.Restart();
                    }
                    if (this.player == 1)
                        this.player = 2;
                    else
                        this.player = 1;
                }
                else
                    MessageBox.Show("Column is full");
            }
        }
        private int GetColumnNumber(Point mouse)
        {
            for (int i = 0; i < this.brdColumns.Length; i++)
            {
                if ((mouse.X >= this.brdColumns[i].X) && (mouse.Y >= this.brdColumns[i].Y))
                {
                    if ((mouse.X <= this.brdColumns[i].X + this.brdColumns[i].Width) && (mouse.Y <= this.brdColumns[i].Y + this.brdColumns[i].Height))
                    {
                        return i;
                    }
                }
            }
            return -1;
        }
        private int CheckEmptyRow(int col)
        {
            for (int i = 5; i >= 0; i--)
            {
                if (this.tokenboard[i, col] == 0)
                {
                    return i;
                }
            }
            return -1;
        }
        #endregion
 
        #region winning condition check - feature - 2 

        private int CheckWinner(int wincondition)
        {
            //vertically arrange tokens: winner (|)
            for (int r = 0; r < tokenboard.GetLength(0) - 3; r++)
            {
                for (int c = 0; c < tokenboard.GetLength(1); c++)
                {
                    if (this.FoundSameNumbers(wincondition, tokenboard[r, c], tokenboard[r + 1, c], tokenboard[r + 2, c], tokenboard[r + 3, c]))
                        return wincondition;
                }
            }
            //horizontally arrange tokens: winner (-)
            for (int r = 0; r < tokenboard.GetLength(0); r++)
            {
                for (int c = 0; c < tokenboard.GetLength(1) - 3; c++)
                {
                    if (this.FoundSameNumbers(wincondition, tokenboard[r, c], tokenboard[r, c + 1], tokenboard[r, c + 2], tokenboard[r, c + 3]))
                        return wincondition;
                }
            }
            //diagonally arrange tokens: win (top-left \) 
            for (int r = 0; r < tokenboard.GetLength(0) - 3; r++)
            {
                for (int c = 0; c < tokenboard.GetLength(1) - 3; c++)
                {
                    if (this.FoundSameNumbers(wincondition, tokenboard[r, c], tokenboard[r + 1, c + 1], tokenboard[r + 2, c + 2], tokenboard[r + 3, c + 3]))
                        return wincondition;
                }
            }
            //diagonally arrange tokens: win (top-right /) 
            for (int r = 0; r < tokenboard.GetLength(0) - 3; r++)
            {
                for (int c = 3; c < tokenboard.GetLength(1); c++)
                {
                    if (this.FoundSameNumbers(wincondition, tokenboard[r, c], tokenboard[r + 1, c - 1], tokenboard[r + 2, c - 2], tokenboard[r + 3, c - 3]))
                        return wincondition;
                }
            }
            return -1;

        }

        private bool FoundSameNumbers(int chkplayer, params int[] numbers)
        {
            foreach (int num in numbers)
            {
                if (num != chkplayer)
                {
                    return false;
                }
            }
            return true;
        }


        #endregion

        private void btnResetGame_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }
      
    }
}
