using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace gameoflife
{
    public partial class GoLModel
    {
        int h;int w;
        int[,] state; int[,] num_life;
        Random rand;
        public GoLModel(int h,int w) { 
            rand= new Random();
            this.h=h;this.w=w;
            num_life = new int[h, w];
            state = new int[h, w];

            for (int i = 0; i < h; i++)
            {
                for (int j = 0; j < w; j++)
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

        }

        public void Update_Life()
        {
            //Console.WriteLine("this is unko." + state[49,48].ToString());
            for (int i = 0; i < h; i++)
            {
                for (int j = 0; j < w; j++)
                {
                    for (int dy = -1; dy <= 1; dy++)
                    {
                        for (int dx = -1; dx <= 1; dx++)
                        {
                            int y = i + dy;
                            int x = j + dx;
                            if (x < 0) { x = x + w; }
                            else if (x > w - 1) { x = x - w; }
                            if (y < 0) { y = y + h; }
                            else if (y > h - 1) { y = y - h; }
                            if (dx != 0 || dy != 0)
                            {
                                if (state[y, x] == 1)
                                {
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

            for (int i = 0; i < h; i++)
            {
                for (int j = 0; j < w; j++)
                {
                    num_life[i, j] = 0;
                }
            }
        }

        public int[,] get_state()
        {
            return this.state;
        }
    }
}
