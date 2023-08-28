using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace gameoflife
{
    public partial class Form1 : Form
    {
        int[,] state;
        int[,] num_life;
        int h;int w;
        Random rand;
        Rectangle[,] pix;
        int pixsize;
        Timer timer1;
        public Form1()
        {
            InitializeComponent();
            //ダブルバッファリングの設定
            SetStyle(
            ControlStyles.DoubleBuffer |
            ControlStyles.UserPaint |
            ControlStyles.AllPaintingInWmPaint, true
            );

            rand = new Random();
            h = 200;w = 200;
            state = new int[h,w];
            num_life = new int[h,w];
            pix = new Rectangle[h,w];
            pixsize = 3;

            int ps = pixsize;
            for (int i = 0; i < h; i++)
            {
                for (int j = 0; j < w; j++)
                {
                    pix[i, j] = new Rectangle(j * ps, i * ps, ps, ps);
                }
            }

            for (int i = 0; i < h; i++)
            {
                for(int j=0; j < w; j++)
                {
                    state[i, j] = rand.Next(2);
                }
            }

            for (int i = 0; i < h; i++)
            {
                for (int j = 0; j < w; j++)
                {
                    num_life[i, j] = 0;
                }
            }

            this.Paint += new PaintEventHandler(Form1_Paint);

            timer1 = new Timer(){
                Interval = 20,
                Enabled = true,
            };
            timer1.Tick += new EventHandler(timer1_Tick);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Update_Life() {
            //Console.WriteLine("this is unko." + state[49,48].ToString());
            for (int i= 0; i < h;i++){
                for(int j= 0; j < w; j++){
                    for(int dy = -1; dy <= 1; dy++){
                        for(int dx= -1; dx <= 1; dx++){
                            int y = i + dy;
                            int x = j+ dx;
                            if (x < 0) { x = x + w ; }
                            else if (x > w - 1) { x = x - w ; }
                            if (y < 0) { y = y + h; }
                            else if (y > h - 1) { y = y - h; }
                            if (dx!=0 || dy!=0) {
                                if (state[y, x] == 1) {
                                    num_life[i, j] += 1;
                                }
                            }
                        }
                    }
                }
            }

            for (int i = 0; i < h; i++)
            {
                for (int j = 0; j < w; j++)
                {
                    if (state[i, j] == 0 && num_life[i, j] == 3)
                    {
                        state[i, j] = 1;
                    }
                    else if (state[i, j] == 1 && num_life[i, j] == 2)
                    {
                        state[i, j] = 1;
                    }
                    else if (state[i, j] == 1 && num_life[i, j] == 3)
                    {
                        state[i, j] = 1;
                    }
                    else { state[i, j] = 0; }
                }
            }

            for (int i = 0; i < h; i++){
                for (int j = 0; j < w; j++){
                    num_life[i,j] = 0;
                }
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.Update_Life();
            this.Invalidate();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            
            Graphics g = e.Graphics;
            /*
            SolidBrush brush = new SolidBrush(Color.Yellow);
            Rectangle rect = new Rectangle(20, 20, 200, 200);
            g.FillRectangle(brush, rect);
            brush.Dispose();
            */
            SolidBrush brush1 = new SolidBrush(Color.Black);
            for (int i = 0; i < h; i++)
            {
                for(int j=0;j < w; j++)
                {
                    if(state[i, j] == 1)
                    {
                        g.FillRectangle(brush1, pix[i, j]);
                    }
                }
            }
            brush1.Dispose();
        }
    }
}
