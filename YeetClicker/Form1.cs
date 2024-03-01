using Gma.System.MouseKeyHook;
using System.Diagnostics;
namespace YeetClicker
{
    public partial class Window : Form
    {
        private static IKeyboardMouseEvents mouseEvents;
        private static IKeyboardEvents keyboardEvents;
        private Color[] colors = {Color.FromArgb(230,232,230),
            Color.FromArgb(206, 208, 206),
            Color.FromArgb(159, 184, 173),
            Color.FromArgb(71, 88, 65),
            Color.FromArgb(80, 81, 80),
            Color.FromArgb(96, 97, 96)};


        Button[] shop;
        private static double Score = 0;
        private static double ScorePerSecond = 0.001;
        private static double ScorePerClick = 0.001;
        private static int shopbuttonamount = 5;
        private CoffeeBar coffeemachine;
        public Window()
        {
            InitializeComponent();
            shop = new Button[shopbuttonamount];
            shop[0] = new Button
            {
                Text = "Kaffee kaufen",
                Size = new Size(100, 50),
                BackColor = Color.Beige,
            };
            shop[0].Click += BuyCoffee;
            foreach (Button b in shop)
            {
                if (b != null)
                {
                    b.BackColor = colors[3];
                    shopPanel.Controls.Add(b);
                    b.Show();
                }
            }



        }
        private void Window_Load(object sender, EventArgs e)
        {
            shopPanel.BackColor = colors[4];
            coffeemachine = new(this, new Point(shopPanel.Location.X + shopPanel.Width + 5, Height - 30),
                new Size(Width - shopPanel.Width - 20, 20));
            Debug.WriteLine(coffeemachine.Size);
            QuitButton.Location = new Point(shopPanel.Location.X + shopPanel.Width + shopPanel.Location.Y, shopPanel.Location.Y);
            mouseEvents = Hook.GlobalEvents();
            keyboardEvents = Hook.GlobalEvents();
            // Subscribe to mouse events
            mouseEvents.MouseDown += OnMouseDown;
            keyboardEvents.KeyUp += OnKeyUp;

            LoadVariables();
        }
        private void BuyCoffee(object? sender, EventArgs e)
        {
            if (Score >= 0.5)
            {
                Score -= 0.5;
                coffeemachine.Fill(60);
                timer1s.Enabled = true;
            }
        }
        private static void AddScore(double amount)
        {
            Score += amount;
        }

        private void Game_Tick(object sender, EventArgs e)
        {
            AddScore(ScorePerSecond * 0.001);
            labelmoney.Text = Score.ToString("C");
            labelmoney.Location = new Point(Screen.FromControl(this).Bounds.Width / 2 - labelmoney.Width / 2, 20);
        }



        private static void OnKeyUp(object sender, KeyEventArgs e)
        {
            AddScore(ScorePerClick / 2);
        }
        private static void OnMouseDown(object sender, MouseEventArgs e)
        {
            AddScore(ScorePerClick);
        }
        private void Window_FormClosed(object sender, FormClosedEventArgs e)
        {
            SaveVariables();
        }
        private void Window_SizeChanged(object sender, EventArgs e)
        {
            shopPanel.Size = new Size(109, Height - 20);
        }
        private static void SaveVariables()
        {
            Settings1.Default.Score = Score;
            Settings1.Default.ScorePerSecond = ScorePerSecond;
            Settings1.Default.Save();
        }
        private static void LoadVariables()
        {
            Score = Settings1.Default.Score;
            ScorePerSecond = Settings1.Default.ScorePerSecond;
        }

        private void IObutton(object sender, EventArgs e)
        {
            SaveVariables();
            Environment.Exit(0);
        }

        private void timer1s_Tick(object sender, EventArgs e)
        {
            if(coffeemachine.FillLevel != 0)
            {
                coffeemachine.FillLevel --;
                coffeemachine.Update();

            }
            else timer1s.Enabled = false;
        }
    }
}