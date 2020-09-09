using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Project5
{
    public class Figure
    {
        public List<Vector4> Vertices { get; set; }
        public Color Color { get; set; }
        public Color BackColor { get; set; }
        public List<Point> Points { get; set; }
        public Figure(List<Vector4> _Vertices, Color _Color, Color _BackColor)
        {
            Vertices = _Vertices.ToList();
            Color = _Color;
            Points = new List<Point>();
            BackColor = _BackColor;
        }
    }
}
