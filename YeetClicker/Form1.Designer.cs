namespace YeetClicker
{
    partial class Window
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Window));
            scoretimer = new System.Windows.Forms.Timer(components);
            pbBanana = new PictureBox();
            labelmoney = new Label();
            shopPanel = new FlowLayoutPanel();
            QuitButton = new Button();
            timer1s = new System.Windows.Forms.Timer(components);
            ((System.ComponentModel.ISupportInitialize)pbBanana).BeginInit();
            SuspendLayout();
            // 
            // scoretimer
            // 
            scoretimer.Enabled = true;
            scoretimer.Tick += Game_Tick;
            // 
            // pbBanana
            // 
            pbBanana.Image = Properties.Resources.banana_happy;
            pbBanana.Location = new Point(365, 153);
            pbBanana.Name = "pbBanana";
            pbBanana.Size = new Size(100, 100);
            pbBanana.SizeMode = PictureBoxSizeMode.StretchImage;
            pbBanana.TabIndex = 0;
            pbBanana.TabStop = false;
            // 
            // labelmoney
            // 
            labelmoney.AutoSize = true;
            labelmoney.Font = new Font("Stencil", 24F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelmoney.ForeColor = Color.DarkGoldenrod;
            labelmoney.Location = new Point(0, 0);
            labelmoney.Name = "labelmoney";
            labelmoney.Size = new Size(129, 38);
            labelmoney.TabIndex = 1;
            labelmoney.Text = "label1";
            // 
            // shopPanel
            // 
            shopPanel.BackColor = Color.CadetBlue;
            shopPanel.BorderStyle = BorderStyle.FixedSingle;
            shopPanel.FlowDirection = FlowDirection.TopDown;
            shopPanel.Location = new Point(10, 10);
            shopPanel.Name = "shopPanel";
            shopPanel.Size = new Size(200, 1000);
            shopPanel.TabIndex = 2;
            // 
            // QuitButton
            // 
            QuitButton.Location = new Point(1077, 10);
            QuitButton.Name = "QuitButton";
            QuitButton.Size = new Size(50, 50);
            QuitButton.TabIndex = 3;
            QuitButton.Text = "I/O";
            QuitButton.UseVisualStyleBackColor = true;
            QuitButton.Click += IObutton;
            // 
            // timer1s
            // 
            timer1s.Interval = 1000;
            timer1s.Tick += timer1s_Tick;
            // 
            // Window
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(71, 88, 65);
            ClientSize = new Size(1139, 584);
            Controls.Add(QuitButton);
            Controls.Add(shopPanel);
            Controls.Add(labelmoney);
            Controls.Add(pbBanana);
            FormBorderStyle = FormBorderStyle.None;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Window";
            Text = "YeetClicker";
            WindowState = FormWindowState.Maximized;
            FormClosed += Window_FormClosed;
            Load += Window_Load;
            SizeChanged += Window_SizeChanged;
            ((System.ComponentModel.ISupportInitialize)pbBanana).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Timer scoretimer;
        private PictureBox pbBanana;
        private Label labelmoney;
        private FlowLayoutPanel shopPanel;
        private Button QuitButton;
        private System.Windows.Forms.Timer timer1s;
    }
}
