using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Graf4
{
    public partial class Form1 : Form
    {
        private Image CorrectImage;
        Graphics g;
        Pen blackPen = new Pen(Color.Black, 2);
        private Color CorrectColor = Color.Black;
        private Point prevLocation;
        bool isDown = true;
        float size = 1;
        bool PrevExist = false;
        Point PrevPoint;
        public Form1()
        {
            InitializeComponent();
            CorrectImage = DrawingImageByColor(new Bitmap(pictureBox1.Width, pictureBox1.Height), Color.White);
            pictureBox1.Image = CorrectImage;
            g = Graphics.FromImage(CorrectImage);

        }

        private Bitmap DrawingImageByColor(Image Image, Color color)
        {
            Bitmap res = new Bitmap(Image);
            for (int x = 0; x < res.Width; x++)
            {
                for (int y = 0; y < res.Height; y++)
                {
                    res.SetPixel(x, y, color);
                }
            }
            return res;
        }

        private void PictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            if (radioDot.Checked)
            {
                PrevExist = false;
                Pen pen = new Pen(CorrectColor);
                SolidBrush solid = new SolidBrush(CorrectColor);
                g.FillEllipse(solid, e.X, e.Y, 5, 5);
                g.DrawEllipse(pen, e.X, e.Y, 5, 5);
                pictureBox1.Refresh();

                solid.Dispose();
                pen.Dispose();
            }
            else if(radioEdge.Checked && !isDown)
            {
                if (g != null)
                {
                    g.Dispose();
                }
                PrevExist = false;
                g = Graphics.FromImage(CorrectImage);
                g.DrawLine(new Pen(CorrectColor, 4), prevLocation, prevLocation = new Point(e.X, e.Y));
                pictureBox1.Image = CorrectImage;
            }
            else if(radioSquare.Checked && !isDown)
            {
                if (g != null)
                {
                    g.Dispose();
                }
                //DrawRectangle(sender,e);
                //prevLocation = new Point(e.X, e.Y);
                g = Graphics.FromImage(CorrectImage);
                //g.DrawRectangle(new Pen(CorrectColor, 4), prevLocation.X, prevLocation.Y, 60,60);
                //pictureBox1.Image = CorrectImage;
                if (PrevExist)
                {
                    PrevExist = false;
                    g.DrawRectangle(new Pen(CorrectColor, 4), PrevPoint.X, PrevPoint.Y, PrevPoint.Y - e.Y, PrevPoint.Y - e.Y);
                    pictureBox1.Image = CorrectImage;
                }
                else
                {
                    PrevExist = true;
                    PrevPoint = new Point(e.X, e.Y);
                }
            }
        }

        private int[] PicMove(int x, int y, int dx, int dy)
        {
            int[,] matr = new int[3,3]{ { 1, 0, 0 },{ 0, 1, 0 },{ dx*(-1), dy*(-1), 1 } };
            int[] coord = new int[]{ x, y, 1 };
            int[] res = new int[3] {0,0,0};
            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                    res[i] += matr[j,i] * coord[j];
            return res;
        }




        private void Button1_Click(object sender, EventArgs e)
        {
            Bitmap img = new Bitmap(pictureBox1.Image);
            for (int y = 0; y < img.Height-1; y++)
                for (int x = 0; x < img.Width-1; x++)
                {
                    if (img.GetPixel(x, y).Equals(Color.FromArgb(0,0,0))){
                        int[] res = PicMove(x, y, Convert.ToInt32(textBox1.Text), Convert.ToInt32(textBox2.Text));
                        img.SetPixel(x, y, Color.White);
                        img.SetPixel(res[0], res[1], Color.Black);
                    }
                }
            pictureBox1.Image = img;
        }

        //------------------------------------------------------------------------------------------
        private void PictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                isDown = false;
            prevLocation = e.Location;
        }

        private void PictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                isDown = true;
        }

        private void ButtonReset_Click(object sender, EventArgs e)
        {
            if (CorrectImage != null)
            {
                CorrectImage.Dispose();
            }
            CorrectImage = DrawingImageByColor(new Bitmap(pictureBox1.Width, pictureBox1.Height), Color.White);
            if (g != null)
            {
                g.Dispose();
            }
            g = Graphics.FromImage(CorrectImage);
            pictureBox1.Image = CorrectImage;
        }
    }
}
