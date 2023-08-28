using System;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace gameoflife
{
    class Program
    {
        /// <summary>
        /// アプリケーションのメイン エントリ ポイントです。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
/*
class Form1 : Form
{
    public Form1()
    {
        this.BackColor = SystemColors.Window;
    }

    protected override void OnPaint(PaintEventArgs e)
    {
        // Graphics オブジェクトを取得
        Graphics g = e.Graphics;

        // 青色，太さ 2 のペンを定義
        SolidBrush brush = new SolidBrush(Color.Yellow);
        Rectangle rect = new Rectangle(20, 20, 200, 200);
        // (20, 20) から (200, 200) まで直線を描画
        g.FillRectangle(brush, rect);

        // ペンを破棄
        brush.Dispose();
    }
}
*/