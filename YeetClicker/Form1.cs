using Gma.System.MouseKeyHook;
using System.Diagnostics;
namespace YeetClicker
{
    public partial class Window : Form
    {
        private static IKeyboardMouseEvents mouseEvents;
        private static IKeyboardEvents keyboardEvents;
        Button[] shop;
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


            foreach (Button b in shop)
            {
                if (b != null)
                {
                    shopPanel.Controls.Add(b);
                    b.Show();

                }
            }
        }
        private static double Score = 0;
        private static double ScorePerSecond = 0.001;
        private static double ScorePerClick = 0.001;
        private static int shopbuttonamount = 5;

        private static void AddScore(double amount)
        {
            Score += amount;
        }

        private void Game_Tick(object sender, EventArgs e)
        {
            AddScore(ScorePerSecond *0.001);
            labelmoney.Text = Score.ToString("C");
        }



        private void Window_Load(object sender, EventArgs e)
        {
            QuitButton.Location = new Point(shopPanel.Location.X + shopPanel.Width + shopPanel.Location.Y, shopPanel.Location.Y);
            mouseEvents = Hook.GlobalEvents();
            keyboardEvents = Hook.GlobalEvents();
            // Subscribe to mouse events
            mouseEvents.MouseDown += OnMouseDown;
            mouseEvents.MouseUp += OnMouseUp;
            mouseEvents.MouseMove += OnMouseMove;
            keyboardEvents.KeyUp += OnKeyUp;

            labelmoney.Location = new Point(Screen.FromControl(this).Bounds.Width / 2, 20);





            LoadVariables();
        }
        private static void OnKeyUp(object sender, KeyEventArgs e)
        {
            AddScore(ScorePerClick / 2);
        }
        private static void OnMouseDown(object sender, MouseEventArgs e)
        {
            AddScore(ScorePerClick);
        }
        private static void OnMouseUp(object sender, MouseEventArgs e)
        {
            Debug.WriteLine($"Mouse Up: {e.Button}, X={e.X}, Y={e.Y}");
        }
        private static void OnMouseMove(object sender, MouseEventArgs e)
        {
            Debug.WriteLine($"Mouse Move: X={e.X}, Y={e.Y}");
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
    }
}