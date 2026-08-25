using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace NeuralNetworkProject
{
    public partial class DrawingBox : UserControl
    {

        DrawingCell[,] Cells;
        int HighShade; // The shade value added to the cell that is directly hovered
        int MediumShade;
        int LowShade;

        public DrawingBox()
        {
            InitializeComponent();

            this.Size = new Size(600, 600);
            this.BackColor = Color.White;

            this.Cells = new DrawingCell[28,28];

            for (int row = 0; row < 28; row++)
            {
                for (int column = 0; column < 28; column++)
                {
                    DrawingCell cell = new DrawingCell(row, column);
                    cell.Location = new Point(row * 21, column * 21);
                    cell.Size = new Size(25, 25);

                    cell.Colored += ColorAdjacent;
                    this.Controls.Add(cell);
                    this.Cells[row, column] = cell;
                }
            }

            this.HighShade = 120;
            this.MediumShade = HighShade / 3;
            this.LowShade = HighShade / 4;
        }

        // ColorAdjacent colors the surrounding tiles in this pattern:
        //  O X X X O
        //  X X X X X
        //  X X X X X
        //  X X X X X
        //  O X X X O

        private void ColorAdjacent(DrawingCell sender)
        {
            int row = sender.Row;
            int column = sender.Column;

            // Shade center cell
            GetCell(row, column)?.ColorCell(HighShade);

            // Shade outer cells
            GetCell(row - 2, column - 1)?.ColorCell(LowShade);
            GetCell(row - 2, column)?.ColorCell(LowShade);
            GetCell(row - 2, column + 1)?.ColorCell(LowShade);

            GetCell(row + 1, column - 2)?.ColorCell(LowShade);
            GetCell(row, column - 2)?.ColorCell(LowShade);
            GetCell(row - 1, column - 2)?.ColorCell(LowShade);

            GetCell(row + 2, column - 1)?.ColorCell(LowShade);
            GetCell(row + 2, column)?.ColorCell(LowShade);
            GetCell(row + 2, column + 1)?.ColorCell(LowShade);

            GetCell(row + 1, column + 2)?.ColorCell(LowShade);
            GetCell(row, column + 2)?.ColorCell(LowShade);
            GetCell(row - 1, column + 2)?.ColorCell(LowShade);

            // Shade middle cells
            GetCell(row - 1, column - 1)?.ColorCell(MediumShade);
            GetCell(row, column)?.ColorCell(MediumShade);
            GetCell(row - 1, column + 1)?.ColorCell(MediumShade);

            GetCell(row, column - 1)?.ColorCell(MediumShade);
            GetCell(row, column + 1)?.ColorCell(MediumShade);

            GetCell(row + 1, column - 1)?.ColorCell(MediumShade);
            GetCell(row + 1, column)?.ColorCell(MediumShade);
            GetCell(row + 1, column + 1)?.ColorCell(MediumShade);
        }

        private DrawingCell GetCell(int row, int column)
        {
            if (row < 0 || row >= 28 || column < 0 || column >= 28)
            {
                return null;
            }

            return Cells[row, column];
        }

        // NOTE: shades should be formatted as black = 1, white = 0.
        public void Display(double[] shades)
        {
            if (shades.Length != 784)
            {
                Debug.WriteLine($"Attempted to display {shades.Length} cells on a 28*28 grid");
                return;
            }

            for (int row = 0; row < 28; row++)
            {
                for (int column = 0; column < 28; column++)
                {
                    Cells[row, column].BlackValue = (int)(255 - (255 * shades[(row*28) + column]));
                }
            }
        }
        public void Reset()
        {
            for (int row = 0; row < 28; row++)
            {
                for (int column = 0; column < 28; column++)
                {
                    Cells[row, column].Reset();
                }
            }
        }

        public TrainingSample GetSample()
        {
            TrainingSample sample = new TrainingSample();
            sample.Inputs = new double[784];

            for (int row = 0; row < 28; row++)
            {
                for (int column = 0; column < 28; column++)
                {
                    sample.Inputs[row * 28 + column] = Cells[row, column].GetActivation();
                }
            }
            Reset();
            return sample;
        }

    }
}
