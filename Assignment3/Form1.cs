using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Assignment3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.Cursor = new Cursor("../../images/cursor.cur");
        }

        private void Image_MouseClick(object sender, MouseEventArgs e)
        {
            State.xCordinate = e.X;
            State.yCordinate = e.Y;

            if (State.chosenColor.IsEmpty || ImageBox.Image == null)
            {
                MessageBox.Show("Select a color or image!");
                return;
            }

            State.initialColor = State.canvas.GetPixel(State.xCordinate, State.yCordinate);
            Graphics gr = ImageBox.CreateGraphics();
            Brush br = new SolidBrush(State.chosenColor);

            int dotSize = 5;
            gr.FillEllipse(br, State.xCordinate - dotSize / 2, State.yCordinate - dotSize / 2, dotSize, dotSize);
        }
        private void btnSelectImage_Click(object sender, EventArgs e)
        {
            ImageSelection form = new ImageSelection();
            form.ShowDialog();

            ImageBox.Image = State.canvas;
        }
        private void btnChooseColor_Click(object sender, EventArgs e)
        {
            using (ColorDialog colorDialog = new ColorDialog())
            {
                colorDialog.AllowFullOpen = true;
                colorDialog.AnyColor = true;
                colorDialog.SolidColorOnly = false;

                if (colorDialog.ShowDialog() == DialogResult.OK)
                {
                    State.chosenColor = colorDialog.Color;
                }
            }
        }
        private void btnFill_Click(object sender, EventArgs e)
        {
            if (State.xCordinate == -1 || State.yCordinate == -1)
            {
                MessageBox.Show("Select a starting position");
                return;
            }
            Stopwatch timer = new Stopwatch();

            timer.Start();
            //BucketIterative(State.canvas);
            //BucketRecursive(State.canvas, State.xCordinate, State.yCordinate);
            BucketPseudoRecursive(State.canvas);
            timer.Stop();

            lblDuration.Text = $"Duration: {timer.ElapsedMilliseconds} miliseconds";
        }
        private void BucketIterative(Bitmap map)
        {
            Point startingPos = new Point(State.xCordinate, State.yCordinate);
            Queue<Point> q = new Queue<Point>();
            q.Enqueue(startingPos);

            while (q.Count > 0)
            {
                Point nextPos = q.Dequeue();

                if (map.GetPixel(nextPos.X, nextPos.Y) == State.initialColor)
                {
                    if(nextPos.X + 1 < map.Width)
                        q.Enqueue(new Point(nextPos.X + 1, nextPos.Y));
                    if(nextPos.X - 1 > 0)
                        q.Enqueue(new Point(nextPos.X - 1, nextPos.Y));
                    if(nextPos.Y  + 1 < map.Height)
                        q.Enqueue(new Point(nextPos.X, nextPos.Y + 1));
                    if(nextPos.Y - 1 > 0)
                        q.Enqueue(new Point(nextPos.X, nextPos.Y - 1));
                    map.SetPixel(nextPos.X, nextPos.Y, State.chosenColor);
                }
            }
            ImageBox.Image = State.canvas;
            ImageBox.Invalidate();
        }
        // It works in recursive style, but it is not recursive
        // It still is slower then the iterative function with a queue
        private void BucketPseudoRecursive(Bitmap map)
        {
            Stack<Point> stack = new Stack<Point>();
            stack.Push(new Point(State.xCordinate, State.yCordinate));

            while (stack.Count > 0)
            {
                Point curr = stack.Pop();

                if (map.GetPixel(curr.X, curr.Y) == State.chosenColor)
                    continue;

                map.SetPixel(curr.X, curr.Y, State.chosenColor);

                if (curr.X + 1 < map.Width && map.GetPixel(curr.X + 1, curr.Y) == State.initialColor)
                    stack.Push(new Point(curr.X + 1, curr.Y));
                if (curr.X - 1 >= 0 && map.GetPixel(curr.X - 1, curr.Y) == State.initialColor)
                    stack.Push(new Point(curr.X - 1, curr.Y));
                if (curr.Y + 1 < map.Height && map.GetPixel(curr.X, curr.Y + 1) == State.initialColor)
                    stack.Push(new Point(curr.X, curr.Y + 1));
                if (curr.Y - 1 >= 0 && map.GetPixel(curr.X, curr.Y - 1) == State.initialColor) 
                    stack.Push(new Point(curr.X, curr.Y - 1));

                //ImageBox.Refresh();
            }
            ImageBox.Image = State.canvas;
            ImageBox.Invalidate();
        }
        // Really slow,
        // Gives a stackoverflow exception if the fill area is on the bigger side.
        private void BucketRecursive(Bitmap map, int x, int y)
        {
            if ((x <= 0) || (y <= 0) || (x >= map.Width) || (y >= map.Height))
                return;
            if (map.GetPixel(x, y) != State.initialColor)
                return;

            map.SetPixel(x, y, State.chosenColor);

            BucketRecursive(map, x + 1, y);
            BucketRecursive(map, x - 1, y);
            BucketRecursive(map, x, y + 1);
            BucketRecursive(map, x, y - 1);
        }
    }
    public class State
    {
        public static int xCordinate = -1;
        public static int yCordinate = -1;
        public static Bitmap originalImage;
        public static Bitmap canvas;
        public static Color chosenColor;
        public static Color initialColor;
    }
}
