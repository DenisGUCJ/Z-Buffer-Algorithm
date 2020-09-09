using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using static Project5.Predefines;
using System.Numerics;
using System.Linq;

namespace Project5
{
    public partial class Form1 : Form
    {
        private static int MidHeight { get; set; }

        private static int MidWidth { get; set; }

        public static double alpha_x = 0;

        public static double alpha_y = 0;

        public static double alpha_z = 0;

        private static double gamma = Math.PI / 1.7;

        public static double T_z = 5;

        public static double T_y = 0;

        public static double T_x = 0;

        public static float rate_of_change = 0.04f;

        private static double[][] M1 = new double[][] {
                    new double[] { 1,0,0,0},
                    new double[] { 0,1,0,0},
                    new double[] { 0,0,1,0},
                    new double[] { 0,0,0,1}
        };

        private static double[][] M2 = new double[][] {
                    new double[] { 2,0,0,0},
                    new double[] { 0,2,0,0},
                    new double[] { 0,0,1,-1},
                    new double[] { 0,0,0,1}
        };

        //__________________CAMERA_MATRIX_____________________

        public static Vector3 cPos = new Vector3(0, 0, 15);

        public static Vector3 cTarget = new Vector3(0, 0, 0);

        public static Vector3 cUp = new Vector3(0, 1, 0);

        private static Vector3 originalcPos = cPos;

        private static double camera_rotation_angle = gamma;

        //_____________________________________________________

        //__________________Axis_______________________________

        private static Figure xAxis { get; set; }

        private static Figure yAxis { get; set; }

        private static Figure zAxis { get; set; }

        private static List<Vector4> xPoints = new List<Vector4>() { new Vector4(-3, 0, 0, 1), new Vector4(3, 0, 0, 1) };

        private static List<Vector4> yPoints = new List<Vector4>() { new Vector4(0, -3, 0, 1), new Vector4(0, 3, 0, 1) };

        private static List<Vector4> zPoints = new List<Vector4>() { new Vector4(0, 0, -3, 1), new Vector4(0, 0, 3, 1) };


        //__________________Z buffer___________________________

        public static Z_buffer z_buffer { get; set; }

        //_____________________________________________________


        private static List<Vector4> points1 = new List<Vector4>() { // Point of Cube on the Left
                new Vector4(-1, -1, -1, 1),
                new Vector4(1, -1, -1, 1),
                new Vector4(1, 1, -1, 1),
                new Vector4(-1, 1 ,-1 ,1),
                new Vector4(-1, -1, -3, 1),
                new Vector4(1, -1, -3, 1),
                new Vector4(1, 1, -3, 1),
                new Vector4(-1, 1 ,-3 ,1),
        };


        private static List<Vector4> points2 = new List<Vector4>() { // Point of Cube on the Right
                new Vector4(-1, -1, 3, 1),
                new Vector4(1, -1, 3, 1),
                new Vector4(1, 1, 3, 1),
                new Vector4(-1, 1 ,3 ,1),
                new Vector4(-1, -1, 1, 1),
                new Vector4(1, -1, 1, 1),
                new Vector4(1, 1, 1, 1),
                new Vector4(-1, 1 ,1 ,1),
        };

        private static List<Color> FaceColors1 = new List<Color>() { 
            Color.Red,
            Color.Blue,
            Color.Green,
            Color.Yellow,
            Color.Violet,
            Color.Orange
        };

        private static List<Color> FaceColors2 = new List<Color>() {
            Color.Pink,
            Color.Brown,
            Color.Gold,
            Color.LightGreen,
            Color.Fuchsia,
            Color.LightSkyBlue
        };

        private Figure cube1;

        private Figure cube2;

        public Form1()
        {
            InitializeComponent();
            Reset();

            MidHeight = Canvas.Image.Height / 2;
            MidWidth = Canvas.Image.Width / 2;

            z_buffer = new Z_buffer(Canvas.Image.Width, Canvas.Image.Height);

            z_buffer.Initialize();

            xAxis = new Figure(xPoints, Color.DarkBlue, Color.Black);

            yAxis = new Figure(yPoints, Color.DarkRed, Color.Black);

            zAxis = new Figure(zPoints, Color.DarkGreen, Color.Black);

            cube1 = new Figure(points1, Color.Black, Color.Red);

            cube2 = new Figure(points2, Color.Black, Color.Blue);


        }

        private double[][] P(double angle)
        {
            var cot = 1 / Math.Tan(angle / 2);

            double[][] P = new double[][]
            {
                new double[] {-MidWidth * cot, 0, MidWidth, 0},
                new double[] {0, MidWidth * cot, MidHeight, 0},
                new double[] {0, 0, 0, 1},
                new double[] {0, 0, 1, 0}
            };

            return P;
        }

        private double[][] Camera_Matrix(Vector3 pos, Vector3 target, Vector3 up) 
        {
            var cZ = (pos - target) / (pos - target).Length();
            var cX = Vector3.Cross(up, cZ) / Vector3.Cross(up,cZ).Length();
            var cY = Vector3.Cross(cZ, cX) / Vector3.Cross(cZ, cX).Length();

            double[][] result = {
                new double[]{ cX.X, cX.Y, cX.Z, Vector3.Dot(cX, pos)},
                new double[]{ cY.X, cY.Y, cY.Z, Vector3.Dot(cY, pos)},
                new double[]{ cZ.X, cZ.Y, cZ.Z, Vector3.Dot(cZ, pos)},
                new double[]{ 0, 0, 0, 1},
            };

            return result;
        }

        private double[][] T(double tx, double ty, double tz)
        {
            double[][] T = new double[][] {
                new double[] { 1,0,0,tx},
                new double[] { 0,1,0,ty},
                new double[] { 0,0,1,tz},
                new double[] { 0,0,0,1}
            };

            return T;
        }
    

        private double[][] Rx(double angle)
        {
            double[][] Rx = new double[][] {
                new double[] {1, 0, 0, 0},
                new double[] {0, Math.Cos(angle), -Math.Sin(angle), 1},
                new double[] {0, Math.Sin(angle), Math.Cos(angle), 0},
                new double[] {0, 0, 0, 1}
            };

            return Rx;
        }

        private double[][] Ry(double angle)
        {
            double[][] Ry = new double[][] {
                new double[] {Math.Cos(angle), 0, Math.Sin(angle), 0},
                new double[] {0, 1, 0, 0},
                new double[] {-Math.Sin(angle), 0, Math.Cos(angle), 0},
                new double[] {0, 0, 0, 1}
            };

            return Ry;
        }

        private double[][] Rz(double angle)
        {
            double[][] Rz = new double[][] {
                new double[] {Math.Cos(angle), -Math.Sin(angle), 0, 0},
                new double[] {Math.Sin(angle), Math.Cos(angle), 0, 0},
                new double[] {0, 0, 1, 0},
                new double[] {0, 0, 0, 1}
            };

            return Rz;
        }

        private List<Vector4> Affine_transformation(List<Vector4> points, double [][] m)
        {
            List<Vector4> result = new List<Vector4>();

            for (int i = 0; i < points.Count; i++)
            {
                var tmp = MatrixMultiplication(m,new double[][] { 
                    new double[] { points[i].X },
                    new double[] { points[i].Y }, 
                    new double[] { points[i].Z }, 
                    new double[] { points[i].W } 
                });

                Vector4 point = new Vector4((float)tmp[0][0], (float)tmp[1][0], (float)tmp[2][0], (float)tmp[3][0]);
                result.Add(point);
            }


            
            return result;
        }

        private List<Vector4> Projection_interpolaion(List<Vector4> points, double[][] P, double[][] M, bool flag = true)
        {
            double[][] tmp = new double[4][];
            if (flag)
                tmp = MatrixMultiplication(MatrixMultiplication(MatrixMultiplication(T(T_x, T_y, T_z),Rx(alpha_x)),Ry(alpha_y)),M/*Rz(alpha_z)*/);
            else
                tmp = MatrixMultiplication(MatrixMultiplication(MatrixMultiplication(T(T_x, T_y, T_z), Rx(0)), Ry(0)), Rz(0));

            tmp = MatrixMultiplication(Camera_Matrix(cPos,cTarget,cUp), tmp);
            var temp = MatrixMultiplication(P, tmp);

            List<Vector4> result = Affine_transformation(points, temp);

            for (int i = 0; i < result.Count; i++)
            {
                result[i] /= result[i].W;
               
            }

            return result;
        }

        private void Reset()
        {
            Bitmap bmp = new Bitmap(Canvas.Width, Canvas.Height);
            using (Graphics graph = Graphics.FromImage(bmp))
            {
                Rectangle ImageSize = new Rectangle(0, 0, Canvas.Width, Canvas.Height);
                graph.FillRectangle(Brushes.White, ImageSize);
            }
            Canvas.Image = bmp;

        }

        private void Canvas_Paint(object sender, PaintEventArgs e)
        {
            Reset();
            z_buffer.Initialize();

            Bitmap processedBitmap = new Bitmap((Bitmap)Canvas.Image);
            BitmapData bitmapData = processedBitmap.LockBits(new Rectangle(0, 0, processedBitmap.Width, processedBitmap.Height), ImageLockMode.ReadWrite, processedBitmap.PixelFormat);

            int bytesPerPixel = Bitmap.GetPixelFormatSize(processedBitmap.PixelFormat) / 8;
            int byteCount = bitmapData.Stride * processedBitmap.Height;
            byte[] pixels = new byte[byteCount];
            IntPtr ptrFirstPixel = bitmapData.Scan0;
            Marshal.Copy(ptrFirstPixel, pixels, 0, pixels.Length);

            Pixels = pixels;
            BytesPerPixel = bytesPerPixel;
            BitmapStride = bitmapData.Stride;

            var c1 = Projection_interpolaion(points1, P(gamma), M1);
            var c2 = Projection_interpolaion(points2, P(gamma), M2);


            cube1.Vertices = c1;
            cube2.Vertices = c2;

            //==========================================================

            Cube_Drawer(cube1, FaceColors1);
            Cube_Drawer(cube2, FaceColors2);

            updateLabels();

            //==========================================================

            Marshal.Copy(pixels, 0, ptrFirstPixel, pixels.Length);
            processedBitmap.UnlockBits(bitmapData);

            Canvas.Image = processedBitmap;
        }

        private void Cube_Drawer(Figure figure, List<Color> colors)
        {
            var faces = Get_Faces(figure, colors);

            foreach (var face in faces)
            {
                Figure triangle1 = new Figure(new List<Vector4>() { face.Item1[0], face.Item1[1], face.Item1[2] }, figure.Color, face.Item2);
                Figure triangle2 = new Figure(new List<Vector4>() { face.Item1[0], face.Item1[2], face.Item1[3] }, figure.Color, face.Item2);

                

                fillPolygon(triangle1);
                fillPolygon(triangle2);

                if (showMeshToolStripMenuItem.Checked)
                {
                    PolygonDrawer(triangle1);
                    PolygonDrawer(triangle2);
                }
            }


        }

        private List<(List<Vector4>,Color)> Get_Faces(Figure figure, List<Color> colors)
        {
            return new List<(List<Vector4>,Color)>() {
                (new List<Vector4>(){ figure.Vertices[0], figure.Vertices[1], figure.Vertices[2], figure.Vertices[3] }, colors[0]), // Front
                (new List<Vector4>(){ figure.Vertices[5], figure.Vertices[4], figure.Vertices[7], figure.Vertices[6] }, colors[1]), // Back
                (new List<Vector4>(){ figure.Vertices[0], figure.Vertices[4], figure.Vertices[5], figure.Vertices[1] }, colors[2]), // Top
                (new List<Vector4>(){ figure.Vertices[7], figure.Vertices[6], figure.Vertices[2], figure.Vertices[3] }, colors[3]), // Bot
                (new List<Vector4>(){ figure.Vertices[0], figure.Vertices[4], figure.Vertices[7], figure.Vertices[3] }, colors[4]), // Left
                (new List<Vector4>(){ figure.Vertices[2], figure.Vertices[6], figure.Vertices[5], figure.Vertices[1] }, colors[5])  // Right
                };
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {

           switch (e.KeyCode)
            {
                case Keys.Right:
                    if(rotationToolStripMenuItem.Checked)
                        alpha_y += rate_of_change;
                    if (transpositionToolStripMenuItem.Checked)
                        T_x -= rate_of_change;
                    if (positionToolStripMenuItem.Checked)
                        cPos.X -= rate_of_change;
                    if (cameraToolStripMenuItem.Checked)
                        cTarget.X -= rate_of_change;
                    if (rotateCameraToolStripMenuItem.Checked)
                    {
                        camera_rotation_angle -= rate_of_change;
                        MoveCameraAroundX(camera_rotation_angle);
                    }
                        
                    break;

                case Keys.Left:
                    if (rotationToolStripMenuItem.Checked)
                        alpha_y -= rate_of_change;
                    if (transpositionToolStripMenuItem.Checked)
                        T_x += rate_of_change;
                    if (positionToolStripMenuItem.Checked)
                        cPos.X += rate_of_change;
                    if (cameraToolStripMenuItem.Checked)
                        cTarget.X += rate_of_change;
                    if (rotateCameraToolStripMenuItem.Checked)
                    {
                        camera_rotation_angle += rate_of_change;
                        MoveCameraAroundX(camera_rotation_angle);
                    }
                    break;

                case Keys.Up:
                    if (rotationToolStripMenuItem.Checked)
                        alpha_x -= rate_of_change;
                    if (transpositionToolStripMenuItem.Checked)
                        T_y -= rate_of_change;
                    if (positionToolStripMenuItem.Checked)
                        cPos.Y -= rate_of_change;
                    if (cameraToolStripMenuItem.Checked)
                        cTarget.Y -= rate_of_change;
                    if (rotateCameraToolStripMenuItem.Checked)
                    {
                        camera_rotation_angle -= rate_of_change;
                        MoveCameraAroundY(camera_rotation_angle);
                    }
                    break;

                case Keys.Down:
                    if (rotationToolStripMenuItem.Checked)
                        alpha_x += rate_of_change;
                    if (transpositionToolStripMenuItem.Checked)
                        T_y += rate_of_change;
                    if (positionToolStripMenuItem.Checked)
                        cPos.Y += rate_of_change;
                    if (cameraToolStripMenuItem.Checked)
                        cTarget.Y += rate_of_change;
                    if (rotateCameraToolStripMenuItem.Checked)
                    {
                        camera_rotation_angle += rate_of_change;
                        MoveCameraAroundY(camera_rotation_angle);
                    }
                    break;

                case Keys.OemMinus:
                    if (rotationToolStripMenuItem.Checked)
                        alpha_z += rate_of_change;
                    if (transpositionToolStripMenuItem.Checked)
                        T_z += rate_of_change;
                    if (positionToolStripMenuItem.Checked)
                        cPos.Z += rate_of_change;
                    if (cameraToolStripMenuItem.Checked)
                        cTarget.Z += rate_of_change;
                    break;

                case Keys.Oemplus:
                    if (rotationToolStripMenuItem.Checked)
                        alpha_z -= rate_of_change;
                    if (transpositionToolStripMenuItem.Checked)
                        T_z -= rate_of_change;
                    if (positionToolStripMenuItem.Checked)
                        cPos.Z -= rate_of_change;
                    if (cameraToolStripMenuItem.Checked)
                        cTarget.Z -= rate_of_change;
                    break;


                case Keys.D1:
                    ChangeState(showMeshToolStripMenuItem);
                    break;

                case Keys.D2:
                    ChangeState(transpositionToolStripMenuItem);
                    break;

                case Keys.D3:
                    ChangeState(rotationToolStripMenuItem);
                    break;

                case Keys.D4:
                    ChangeState(rotateCameraToolStripMenuItem);
                    break;
            }
        }

        private void MoveCameraAroundX(double angle)
        {
            var distance = Math.Sqrt(Math.Pow((cPos.X - cTarget.X),2) + Math.Pow((cPos.Z - cTarget.Z),2));

            cPos.X = cTarget.X + (float)(Math.Cos(angle) * distance);
            cPos.Z = cTarget.Z + (float)(Math.Sin(angle) * distance);
        }

        private void MoveCameraAroundY(double angle)
        {
            var distance = Math.Sqrt(Math.Pow((cPos.Y - cTarget.Y), 2) + Math.Pow((cPos.Z - cTarget.Z), 2));

            cPos.Y = cTarget.Y + (float)(Math.Cos(angle) * distance);
            cPos.Z = cTarget.Z + (float)(Math.Sin(angle) * distance);
        }

        private void ChangeState(ToolStripMenuItem item)
        {
            ResetAll();
            item.Checked = true;
        }

        private void ResetAll()
        {
            transpositionToolStripMenuItem.Checked = false;
            rotationToolStripMenuItem.Checked = false;
            showMeshToolStripMenuItem.Checked = false;
            positionToolStripMenuItem.Checked = false;
            cameraToolStripMenuItem.Checked = false;
            rotateCameraToolStripMenuItem.Checked = false;
        }

        private void transpositionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            ChangeState(transpositionToolStripMenuItem);
        }

        private void rotationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChangeState(rotationToolStripMenuItem);
        }

        private void showMeshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChangeState(showMeshToolStripMenuItem);
        }

        private void positionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChangeState(positionToolStripMenuItem);
        }

        private void cameraToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ResetAll();
            ChangeState(cameraToolStripMenuItem);
        }

        private void updateLabels()
        {
            labelCPos.Text = cPos.ToString();
            labelCTarget.Text = cTarget.ToString();
            labelCUp.Text = cUp.ToString();
            labelTx.Text = T_x.ToString();
            labelTy.Text = T_y.ToString();
            labelTz.Text = T_z.ToString();
        }

        private void rotateCameraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChangeState(rotateCameraToolStripMenuItem);
        }
    }
}
