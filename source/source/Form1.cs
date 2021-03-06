﻿using System;
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
            if (txtNumber.Text == "")
            {
                MessageBox.Show("Kích thước bàn cờ không được để trống", "Lỗi nhập", MessageBoxButtons.OK);
                txtNumber.Text = "0";
                return;

            }

            groupBox1.Enabled = true;
            btnRun.Enabled = true;

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

            txtNumber.Enabled = false;
            btnDrawChessBoard.Enabled = false;
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

            nextPoint = findNextPoint(currentPoint);
            if (isStop)
            {
                labelFinish.Visible = true;
                return;
            }
            drawHorse(currentPoint);
            drawHorse(nextPoint);
            currentPoint = nextPoint;
        }

        private void txtNumber_TextChanged(object sender, EventArgs e)
        {
            if (txtNumber.Text.Trim() == "") { return; }

            try
            {
                double.Parse(txtNumber.Text.Trim());
            }
            catch
            {
                MessageBox.Show("Vui lòng nhập số", "Lỗi nhập", MessageBoxButtons.OK);
                txtNumber.Text = "0";
            }
        }

        private void txtX_TextChanged(object sender, EventArgs e)
        {
            if (txtX.Text.Trim() == "") { return; }

            try
            {
                double.Parse(txtX.Text.Trim());
            }
            catch
            {
                MessageBox.Show("Vui lòng nhập số", "Lỗi nhập", MessageBoxButtons.OK);
                txtX.Text = "0";
            }

            if(double.Parse(txtX.Text.Trim()) >= double.Parse(txtNumber.Text.Trim()))
            {
                MessageBox.Show("Tọa độ phải nhỏ hơn kích thước bàn cờ", "Lỗi nhập", MessageBoxButtons.OK);
                txtX.Text = "0";
            }
        }

        private void txtY_TextChanged(object sender, EventArgs e)
        {
            if (txtY.Text.Trim() == "") { return; }

            try
            {
                double.Parse(txtY.Text.Trim());
            }
            catch
            {
                MessageBox.Show("Vui lòng nhập số", "Lỗi nhập", MessageBoxButtons.OK);
                txtY.Text = "0";
            }

            if (double.Parse(txtY.Text.Trim()) >= double.Parse(txtNumber.Text.Trim()))
            {
                MessageBox.Show("Tọa độ phải nhỏ hơn kích thước bàn cờ", "Lỗi nhập", MessageBoxButtons.OK);
                txtY.Text = "0";
            }
        }

        private void btnRun_Click(object sender, EventArgs e)
        {
            if(txtX.Text.Trim() == "")
            {
                MessageBox.Show("Chưa nhập X", "Lỗi nhập", MessageBoxButtons.OK);
                txtX.Text = "0";
                return;
            }

            if (txtY.Text.Trim() == "")
            {
                MessageBox.Show("Chưa nhập Y", "Lỗi nhập", MessageBoxButtons.OK);
                txtY.Text = "0";
                return;
            }

            groupBox1.Enabled = false;

            int x = int.Parse(txtX.Text);
            int y = int.Parse(txtY.Text);

            currentPoint = new Point(x, y);
            drawHorse(currentPoint);
            timer.Start();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
