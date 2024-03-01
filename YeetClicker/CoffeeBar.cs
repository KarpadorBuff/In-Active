using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YeetClicker
{
    internal class CoffeeBar
    {
        private Panel bgPanel;
        private Panel fgPanel;
        public Size Size;
        private int Margin = 2;
        public Point Location;
        public Color BackColor = Color.DarkGray;
        public Color ForeColor = Color.SaddleBrown;

        public int Maximum = 60;
        private int fillLevel;
        public int FillLevel
        {
            get { return fillLevel; }
            set
            {
                if (value < Maximum) fillLevel = value;
                else fillLevel = Maximum;
                    
                
            }
        }
        public Window Window;
        public CoffeeBar(Window window, Point location, Size size)
        {
            Size = size;
            Window = window;
            bgPanel = new Panel()
            {
                Location = location,
                Size = Size,
                BackColor = BackColor,

            };
            fgPanel = new Panel()
            {
                Location = new Point(Margin, Margin),
                Size = new Size(Size.Width - Margin * 2, Size.Height - Margin*2),
                BackColor = ForeColor,
            };
            Window.Controls.Add(bgPanel);
            bgPanel.Controls.Add(fgPanel);
            bgPanel.Show();
            fgPanel.Show();

        }
        public void Fill(int amount)
        {
            fillLevel += amount;
        }
        public void Update()
        {
            fgPanel.Size = new Size((int)((FillLevel* 100)/60 *(1789 * 0.01)), 16);
        }

    }
}
