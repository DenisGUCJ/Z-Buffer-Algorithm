using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Project5
{
    public class AETPoint
    {
        public float M { get; set; }

        public float Ymax { get; set; }
        public float X { get; set; }
        public AETPoint(Vector4 p1, Vector4 p2)
        {

            M = (float)(p2.Y - p1.Y) / (float)(p2.X - p1.X);
            Ymax = p2.Y;
            X = p1.X;
        }

        public void IncrementX()
        {
            X += 1 / M;
        }

    }
}