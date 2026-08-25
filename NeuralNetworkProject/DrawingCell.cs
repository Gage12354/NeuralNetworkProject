using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


internal class DrawingCell : Panel
{
    int blackValue = 255;

    public event Action<DrawingCell> Colored; // Triggers when the cell is directly shaded

    public int BlackValue
    {
        get { return blackValue; }

        set
        {
            blackValue = Math.Max(0, Math.Min(255, value));
            this.BackColor = Color.FromArgb(blackValue, blackValue, blackValue);
        }
    }

    public int Row { get; set;}
    public int Column { get; set; }

    public DrawingCell(int row, int column)
    {
        Row = row;
        Column = column;

        this.TabStop = false;
        this.BackColor = Color.White;

        this.MouseEnter += Hover;
        this.MouseDown += Hover;
        
    }

    private void Hover(object sender, EventArgs e)
    {
        if ((System.Windows.Forms.Control.MouseButtons) == 0) { return; }
        Capture = false;

        Colored?.Invoke(this);
    }

    public void ColorCell(int value)
    {
        BlackValue -= value;
    }


    public void LightlyColor()
    {
        BlackValue -= 50;
    }

    public void Reset()
    {
        BlackValue = 255;
        this.BackColor = System.Drawing.Color.White;
    }

    public double GetActivation()
    {
        return (double)(255.0 - BlackValue) / 255.0;
    }

}

