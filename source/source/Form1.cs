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

            int number = int.Parse(txtNumber.Text);
            int size = panelChessBoard.Size.Width;

            float width = (float)size / number;

            Graphics graphic = panelChessBoard.CreateGraphics();
            SolidBrush whiteBrush = new SolidBrush(Color.White);
            SolidBrush brownBrush = new SolidBrush(Color.SandyBrown);

            for(int i = 0; i < number; i++)
            {
                for (int j = 0; j < number; j++)
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

        private void drawHorse()
        {
            if (txtNumber.Text == "") return;

            int number = int.Parse(txtNumber.Text);
            int size = panelChessBoard.Size.Width;

            float width = (float)size / number;

            Graphics graphic = panelChessBoard.CreateGraphics();
            Image blHorse = Image.FromFile("img_horse_black.png");
            Image whHorse = Image.FromFile("img_horse_gray.png");
            for (int i = 0; i < number; i++)
            {
                for (int j = 0; j < number; j++)
                    if (i % 2 != 0)
                    {
                        graphic.DrawImage(j % 2 == 0 ? blHorse : whHorse, new RectangleF(j * width, i * width, width, width));
                    }
                    else
                    {
                        graphic.DrawImage(j % 2 != 0 ? blHorse : whHorse, new RectangleF(j * width, i * width, width, width));
                    }
            }
        }

        private void btnDrawHorse_Click(object sender, EventArgs e)
        {
            drawHorse();
        }
    }
}
