using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace source
{
    public partial class Form1 : Form
    {
        private Point currentPoint;
        private Point nextPoint;
        private int sizeOfChessBoard;
        private Boolean isStop = false;

        private Boolean[,] arrHorsePass;

        private int[] availableX = { -1, 1, 2, 2, 1, -1, -2, -2 };
        private int[] availableY = { -2, -2, -1, 1, 2, 2, 1, -1 };

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            panelChessBoard.Size = new Size(400, 400);
        }

        private void btnDrawChessBoard_Click(object sender, EventArgs e)
        {
            if (txtNumber.Text == "") return;

            sizeOfChessBoard = int.Parse(txtNumber.Text);
            arrHorsePass = new Boolean[sizeOfChessBoard, sizeOfChessBoard];
            int size = panelChessBoard.Size.Width;

            float width = (float)size / sizeOfChessBoard;

            Graphics graphic = panelChessBoard.CreateGraphics();
            SolidBrush whiteBrush = new SolidBrush(Color.White);
            SolidBrush brownBrush = new SolidBrush(Color.SandyBrown);

            for (int i = 0; i < sizeOfChessBoard; i++)
            {
                for (int j = 0; j < sizeOfChessBoard; j++)
                    if (i % 2 == 0)
                    {
                        graphic.FillRectangle(j % 2 == 0 ? whiteBrush : brownBrush, new RectangleF(j * width, i * width, width, width));
                    }
                    else
                    {
                        graphic.FillRectangle(j % 2 != 0 ? whiteBrush : brownBrush, new RectangleF(j * width, i * width, width, width));
                    }
            }
        }

        private void btnRun_Click(object sender, EventArgs e)
        {
            int x = int.Parse(txtX.Text);
            int y = int.Parse(txtY.Text);

            currentPoint = new Point(x, y);
            drawHorse(currentPoint);
            timer.Start();
        }

        private void drawHorse(Point point)
        {
            if (txtNumber.Text == "") return;

            int size = panelChessBoard.Size.Width;

            float width = (float)size / sizeOfChessBoard;

            Graphics graphic = panelChessBoard.CreateGraphics();
            Image blHorse = Image.FromFile("img_horse_black.png");
            Image grHorse = Image.FromFile("img_horse_gray.png");
            graphic.DrawImage(isPass(point) ? grHorse : blHorse, new RectangleF(point.X * width, point.Y * width, width, width));

            arrHorsePass[point.X, point.Y] = true;
        }

        private Point findNextPoint(Point point)
        {
            if (countAvailableSteps(point) == 0)
            {
                isStop = true;
                return new Point();
            }

            int minSteps = 9;
            Point result = new Point();

            for (int i = 0; i < 8; i++)
            {
                Point nextPoint = new Point(point.X + availableX[i], point.Y + availableY[i]);
                if (!isInChessBoard(nextPoint) || isPass(nextPoint)) continue;

                int availableSteps = countAvailableSteps(nextPoint);
                if (availableSteps < minSteps)
                {
                    minSteps = availableSteps;
                    result = nextPoint;
                }
            }
            return result;
        }

        private int countAvailableSteps(Point point)
        {
            int count = 0;
            for (int i = 0; i < 8; i++)
            {
                Point availablePoint = new Point(point.X + availableX[i], point.Y + availableY[i]);
                if (isInChessBoard(availablePoint) && !isPass(availablePoint)) count++;
            }
            return count;
        }

        private Boolean isInChessBoard(Point point)
        {
            return !(point.X < 0 || point.Y < 0 || point.X >= sizeOfChessBoard || point.Y >= sizeOfChessBoard);
        }

        private Boolean isPass(Point point)
        {
            return arrHorsePass[point.X, point.Y];
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            if (isStop)
            {
                timer.Stop();
                return;
            }

            drawHorse(currentPoint);
            currentPoint = findNextPoint(currentPoint);
            drawHorse(currentPoint);
        } 
    }
}
