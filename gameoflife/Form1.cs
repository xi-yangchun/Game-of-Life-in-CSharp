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
        int h;int w;
        GoLModel GOL;
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

            
            h = 200;w = 200;
            GOL = new GoLModel(h, w);
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

        private void timer1_Tick(object sender, EventArgs e)
        {
            GOL.Update_Life();
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
            int[,] arr = GOL.get_state();
            for (int i = 0; i < h; i++)
            {
                for(int j=0;j < w; j++)
                {
                    if(arr[i, j] == 1)
                    {
                        g.FillRectangle(brush1, pix[i, j]);
                    }
                }
            }
            brush1.Dispose();
        }
    }
}
