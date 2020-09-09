using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static Project5.Form1;

namespace Project5
{

    public static class Predefines
    {
        public static byte[] Pixels { get; set; }
        public static int BytesPerPixel { get; set; }
        public static int BitmapStride { get; set; }

        public static void AssignPixel(int x, int y, Color color)
        {
            var currentLine = y * BitmapStride;
            var width = (x) * BytesPerPixel;

            if (width > 0 && width < BitmapStride)
            {
                if ((currentLine + width) > 0 && (currentLine + width) < Pixels.Length)
                {
                    Pixels[(currentLine + width)] = color.B;
                }
                if ((currentLine + width + 1) > 0 && (currentLine + width + 1) < Pixels.Length)
                {
                    Pixels[(currentLine + width + 1) % Pixels.Length] = color.G;
                }
                if ((currentLine + width + 2) > 0 && (currentLine + width + 2) < Pixels.Length)
                {
                    Pixels[(currentLine + width + 2) % Pixels.Length] = color.R;
                }
            }

        }

        public static void SymetricMidpointLineTop(int x1, int y1, int x2, int y2, Color color)
        {


            int dx = x2 - x1;
            int dy = y2 - y1;
            int xi = 1;

            if (dx < 0)
            {
                xi = -1;
                dx = -dx;
            }

            int d = 2 * dx - dy;
            int dE = 2 * dx;
            int dNE = 2 * (dx - dy);
            int xf = x1, yf = y1;
            int xb = x2, yb = y2;

            AssignPixel(xf, yf, color);
            AssignPixel(xb, yb, color);

            while (yf < yb)
            {
                ++yf; --yb;
                if (d < 0)
                    d += dE;
                else
                {
                    d += dNE;
                    xf += xi;
                    xb -= xi;
                }
                AssignPixel(xf, yf, color);
                AssignPixel(xb, yb, color);
            }
        }

        public static void SymetricMidpointLineBot(int x1, int y1, int x2, int y2, Color color)
        {

            int dx = x2 - x1;
            int dy = y2 - y1;
            int yi = 1;

            if (dy < 0)
            {
                yi = -1;
                dy = -dy;
            }

            int d = 2 * dy - dx;
            int dE = 2 * dy;
            int dNE = 2 * (dy - dx);
            int xf = x1, yf = y1;
            int xb = x2, yb = y2;

            AssignPixel(xf, yf, color);
            AssignPixel(xb, yb, color);


            Color L = color;
            Color B = Color.FromArgb(255, 255, 255);

            while (xf < xb)
            {
                ++xf; --xb;
                if (d < 0)
                    d += dE;
                else
                {
                    d += dNE;
                    yf += yi;
                    yb -= yi;
                }


                AssignPixel(xf, yf, color);
                AssignPixel(xb, yb, color);

            }

        }

        public static void LineDrawer(Figure line)
        {

            if (Math.Abs(line.Vertices[1].Y - line.Vertices[0].Y) < Math.Abs(line.Vertices[1].X - line.Vertices[0].X))
            {
                if (line.Vertices[0].X > line.Vertices[1].X)
                {

                    SymetricMidpointLineBot((int)line.Vertices[1].X, (int)line.Vertices[1].Y, (int)line.Vertices[0].X, (int)line.Vertices[0].Y, line.Color);


                }
                else
                {

                    SymetricMidpointLineBot((int)line.Vertices[0].X, (int)line.Vertices[0].Y, (int)line.Vertices[1].X, (int)line.Vertices[1].Y, line.Color);


                }
            }
            else
            {
                if (line.Vertices[0].Y > line.Vertices[1].Y)
                {

                    SymetricMidpointLineTop((int)line.Vertices[1].X, (int)line.Vertices[1].Y, (int)line.Vertices[0].X, (int)line.Vertices[0].Y, line.Color);

                }
                else
                {

                    SymetricMidpointLineTop((int)line.Vertices[0].X, (int)line.Vertices[0].Y, (int)line.Vertices[1].X, (int)line.Vertices[1].Y, line.Color);

                }
            }
        }

        public static void PolygonDrawer(Figure polygon)
        {
            for (int i = 0; i < polygon.Vertices.Count; i++)
            {
                var vertex1 = polygon.Vertices[i];

                Figure line;
                if (i != polygon.Vertices.Count - 1)
                {
                    var vertex2 = polygon.Vertices[i + 1];
                    line = new Figure(new List<Vector4> { vertex1, vertex2 }, polygon.Color, polygon.BackColor);

                }
                else
                {
                    line = new Figure(new List<Vector4> { vertex1, polygon.Vertices[0] }, polygon.Color, polygon.BackColor);

                }

                LineDrawer(line);
            }
        }

        public static double[][] MatrixMultiplication(double [][] m1, double [][] m2)
        {
            
            int size11 = m1.GetLength(0);
            int size21 = m2.GetLength(0);
            int size12 = m1[0].GetLength(0);
            int size22 = m2[0].GetLength(0);

            double[][] result = new double[size11][];

            for (int i = 0; i < size11; i++)
            {
                result[i] = new double[size22];

                for (int j = 0; j < size22; j++)
                {
                    double sum = 0;

                    for (int k = 0; k < size12; k++)
                    {
                        sum += m1[i][k] * m2[k][j];
                    }

                    result[i][j] = sum;

                }
            }

                
            return result;
        }


        //_________________Scan line_____________________________

        static private float areaFunction(Vector4 a1, Vector4 a2, Vector4 a3)
        {
            float ret = ((int)a3.X - (int)a1.X) * ((int)a2.Y - (int)a1.Y) - ((int)a3.Y - (int)a1.Y) * ((int)a2.X - (int)a1.X);
            return ret;
        }

        static public void fillPolygon(Figure polygon)
        {
            
            float area = areaFunction(polygon.Vertices[0], polygon.Vertices[1], polygon.Vertices[2]);

            List<AETPoint> AET = new List<AETPoint>();

            int k = 0;
            var P = polygon.Vertices.ToList();

            for (int j = 0; j < P.Count; j++)
            {
                P[j] = new Vector4((int)P[j].X, (int)P[j].Y, P[j].Z, P[j].W);
            }

            int N = P.Count;
            List<int> indices = GetIndices(P);
            int i = indices[k];
            var y = P[indices[0]].Y;
            var ymin = y;
            var ymax = P[indices[N - 1]].Y;

            var n = 0;


            if (CheckY(P))
            {
                List<Thread> threads = new List<Thread>();

                while (y <= ymax)
                {

                    while (P[i].Y == y)
                    {
                        if (P[(i - 1 + N) % N].Y > P[i].Y)
                            AET.Add(new AETPoint(P[i], P[(i - 1 + N) % N]));
                        if (P[(i + 1) % N].Y > P[i].Y)
                            AET.Add(new AETPoint(P[i], P[(i + 1) % N]));
                        k++;
                        i = indices[k % N];
                    }

                    AET = AET.OrderBy((a) => a.X).ToList();

                  
                    FillAETRow(AET, y, polygon, area);
                    y++;

                    for (int j = AET.Count - 1; j >= 0; j--)
                    {
                        if (AET[j].Ymax == y)
                            AET.RemoveAt(j);
                        else
                        {
                            AET[j].IncrementX();
                        }

                    }
                }

                foreach (var t in threads)
                {
                    t.Join();
                }
            }
        }

        static private bool CheckY(List<Vector4> points)
        {
            for (int i = 0; i < points.Count - 1; i++)
            {
                for (int j = i + 1; j < points.Count; j++)
                {
                    if (points[i].Y != points[j].Y)
                        return true;
                }
            }
            return false;
        }

        static private List<int> GetIndices(List<Vector4> verticies)
        {
            List<int> indices = new List<int>();

            var sorted = verticies.OrderBy((a) => a.Y).ThenBy((a) => a.X).ToList();

            foreach (var value in sorted)
            {
                indices.Add(verticies.IndexOf(value));
            }

            return indices;

        }

        static private void FillAETRow(List<AETPoint> AET, float y, Figure polygon, float area)
        {
            for (int i = 0; i < AET.Count; i += 2)
            {

                for (var x = AET[i].X; x <= AET[i + 1].X; x++)
                {

                    var a0 = areaFunction(polygon.Vertices[1], polygon.Vertices[2], new Vector4((int)x, (int)y, 0, 1));
                    var a1 = areaFunction(polygon.Vertices[2], polygon.Vertices[0], new Vector4((int)x, (int)y, 0, 1));
                    var a2 = areaFunction(polygon.Vertices[0], polygon.Vertices[1], new Vector4((int)x, (int)y, 0, 1));

                    a0 /= area;
                    a1 /= area;
                    a2 /= area;

                    var non_lenear_z = polygon.Vertices[0].Z * a0 + polygon.Vertices[1].Z * a1 + polygon.Vertices[2].Z * a2;

                    float z = 1.0f / non_lenear_z;

                    if (z_buffer.CheckZ((int)x, (int)y, z))
                    {
                        AssignPixel((int)x, (int)y, polygon.BackColor);
                    }
                }

            }
        }
    }
}
