using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project5
{
    public class Z_buffer
    {
        private int width;

        private int height;

        private float[,] buffer;

        public Z_buffer(int _width, int _height)
        {
            width = _width;
            height = _height;
            buffer = new float[width,height];
        }
        public bool CheckZ(int x, int y, float value)
        {
            if (x >= 0 && y >= 0 && x < width && y < height)
            {
                if (value < buffer[x, y])
                {
                    buffer[x, y] = value;
                    return true;
                }
            }

            return false;
        }

        public float GetZ(int x, int y)
        {
            return buffer[x,y];
        }

        public void Initialize()
        {
            for (int i = 0; i < buffer.GetLength(0); i++)
            {
                for (int j = 0; j < buffer.GetLength(1); j++)
                {
                    buffer[i, j] = float.MaxValue;
                }
            }
        }
    }
}
