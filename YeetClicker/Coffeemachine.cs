using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YeetClicker
{
    internal class Coffeemachine
    {
        Panel bgPanel;
        Panel fgPanel;
        Size Size = new Size(10,200);
        int Margin = 2;
        Point Location;
        Color BackColor = Color.DarkGray;
        Color ForeColor = Color.SaddleBrown;
        int Maximum = 100;
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
        public Coffeemachine() 
        { 
            bgPanel = new Panel()
            {
                Location = Location,
                Size = Size,

            };
            fgPanel = new Panel()
            {
                Location = new Point(2, 2),
                Size = new Size(Size.Width - Margin * 2, Size.Height - Margin*2),
            };
        }
    }
}
