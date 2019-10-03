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
        Graphics g;
        Point click;
        Point strt, end, minpol, maxpol;
        Point[] line = new Point[2];
        Point[] pol = new Point[0];

        public Form1()
        {
            InitializeComponent();
            pictureBox1.Image = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            g = Graphics.FromImage(pictureBox1.Image);
            g.Clear(Color.White);

        }

        private void PictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                if (radioEdge.Checked)
                {
                    strt = e.Location;
                }
                else if (radioSquare.Checked && pol.Length == 0)
                {
                    strt = e.Location;
                    Array.Resize(ref pol, 1);
                    pol[pol.Length - 1] = strt;
                }
        }

        private void PictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                if (radioEdge.Checked)
                {
                    end = e.Location;
                    pictureBox1.Invalidate();
                }
                else if (radioSquare.Checked)
                {
                    end = e.Location;
                    pictureBox1.Invalidate();
                }
        }

        private void Intersection_Click(object sender, EventArgs e)
        {
            PointF intersection = new PointF();
            PointF[] intersections = new PointF[0];
            if (line.Length > 4)
            {
                for (int i = 1; i <= line.Length; i += 2)
                {
                    for (int j = i + 2; j <= line.Length; j += 2)
                    {
                        intersection = findIntersection(line[i - 1], line[i], line[j - 1], line[j]);
                        g.DrawEllipse(Pens.Red, intersection.X-3, intersection.Y-3, 6, 6);
                        pictureBox1.Invalidate();
                    }
                }
            }

        }

        private void ButtonReset_Click(object sender, EventArgs e)
        {
            g.Clear(Color.White);
            pictureBox1.Invalidate();
            Array.Clear(line, 0, line.Length);
            Array.Clear(pol, 0, pol.Length);
            Array.Resize(ref line, 2);
            Array.Resize(ref pol, 0);
            click.X = 0; click.Y = 0;
            strt = end = Point.Empty;
        }

        private void PictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                if (radioEdge.Checked)
                {
                    line[line.Length - 2] = strt;
                    line[line.Length - 1] = end;
                    Array.Resize(ref line, line.Length + 2);

                }
                else if (radioSquare.Checked)
                {
                    Array.Resize(ref pol, pol.Length + 1);
                    pol[pol.Length - 1] = end;
                    if (end.X < minpol.X)
                        minpol.X = end.X;
                    if (end.Y < minpol.Y)
                        minpol.Y = end.Y;
                    if (end.X > maxpol.X)
                        maxpol.X = end.X;
                    if (end.Y > maxpol.Y)
                        maxpol.Y = end.Y;
                    strt = end;
                }
                else if (radioDot.Checked)
                {
                    click = e.Location;
                }
            pictureBox1.Invalidate();
        }

        private void PictureBox1_Paint(object sender, PaintEventArgs e)
        {
            for (int i = 0; i < line.Length; i += 2)
            {
                e.Graphics.DrawLine(Pens.Black, line[i], line[i + 1]);
            }
            if (pol.Length > 1)
                e.Graphics.DrawPolygon(Pens.Black, pol);
            e.Graphics.DrawLine(Pens.Black, strt, end);
            if (radioDot.Checked)
                e.Graphics.DrawEllipse(Pens.Black,click.X,click.Y,4,4);
            label_info();
        }

        PointF findIntersection(PointF p0, PointF p1, PointF p2, PointF p3)
        {
            PointF i = new PointF(-1, -1);
            PointF s1 = new PointF();
            PointF s2 = new PointF();
            s1.X = p1.X - p0.X; s1.Y = p1.Y - p0.Y;
            s2.X = p3.X - p2.X; s2.Y = p3.Y - p2.Y;
            float s, t;
            s = (-s1.Y * (p0.X - p2.X) + s1.X * (p0.Y - p2.Y)) / (-s2.X * s1.Y + s1.X * s2.Y);
            t = (s2.X * (p0.Y - p2.Y) - s2.Y * (p0.X - p2.X)) / (-s2.X * s1.Y + s1.X * s2.Y);

            if (s >= 0 && s <= 1 && t >= 0 && t <= 1)
            {
                i.X = p0.X + (t * s1.X);
                i.Y = p0.Y + (t * s1.Y);

            }
            return i;
        }

        bool isInside(Point[] polygon, PointF p)
        {
            int n = polygon.Length;
            if (n < 3) return false;
            PointF extreme = new PointF(pictureBox1.Width, p.Y);
            int count = 0, i = 0;
            do
            {
                int next = (i + 1) % n;
                PointF intersection = findIntersection(polygon[i], polygon[next], p, extreme);
                if (intersection.X != -1)
                {
                    if (orientation(polygon[i], p, polygon[next]) == 0)
                        return onSegment(polygon[i], p, polygon[next]);
                    count++;
                }
                i = next;
            } while (i != 0);
            return count % 2 == 1;
        }

        int orientation(PointF p, PointF q, PointF r)
        {
            float val = (q.Y - p.Y) * (r.X - q.X) -
                      (q.X - p.X) * (r.Y - q.Y);

            if (val == 0) return 0;
            return (val > 0) ? 1 : 2;
        }

        bool onSegment(PointF q, PointF p, PointF r)
        {
            if (q.X <= Math.Max(p.X, r.X) && q.X >= Math.Min(p.X, r.X) &&
                    q.Y <= Math.Max(p.Y, r.Y) && q.Y >= Math.Min(p.Y, r.Y))
                return true;
            return false;
        }

        private void label_info()
        {
            if (pol.Length > 2)
            {
                if (isInside(pol, click))
                {
                    label1.Text = "Принадлежит многоугольнику";
                }
                else
                {
                    label1.Text = "Не принадлежит многоугольнику";
                }
            }
            else
            {
                label1.Text = "";
            }
        }
    }
}
