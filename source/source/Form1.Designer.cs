namespace source
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.panelChessBoard = new System.Windows.Forms.Panel();
            this.btnDrawChessBoard = new System.Windows.Forms.Button();
            this.txtNumber = new System.Windows.Forms.TextBox();
            this.btnDrawHorse = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // panelChessBoard
            // 
            this.panelChessBoard.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelChessBoard.Location = new System.Drawing.Point(32, 34);
            this.panelChessBoard.Name = "panelChessBoard";
            this.panelChessBoard.Size = new System.Drawing.Size(500, 500);
            this.panelChessBoard.TabIndex = 0;
            // 
            // btnDrawChessBoard
            // 
            this.btnDrawChessBoard.Location = new System.Drawing.Point(625, 98);
            this.btnDrawChessBoard.Name = "btnDrawChessBoard";
            this.btnDrawChessBoard.Size = new System.Drawing.Size(159, 44);
            this.btnDrawChessBoard.TabIndex = 1;
            this.btnDrawChessBoard.Text = "Draw Chessboard";
            this.btnDrawChessBoard.UseVisualStyleBackColor = true;
            this.btnDrawChessBoard.Click += new System.EventHandler(this.btnDrawChessBoard_Click);
            // 
            // txtNumber
            // 
            this.txtNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNumber.Location = new System.Drawing.Point(625, 34);
            this.txtNumber.Name = "txtNumber";
            this.txtNumber.Size = new System.Drawing.Size(159, 30);
            this.txtNumber.TabIndex = 2;
            // 
            // btnDrawHorse
            // 
            this.btnDrawHorse.Location = new System.Drawing.Point(625, 180);
            this.btnDrawHorse.Name = "btnDrawHorse";
            this.btnDrawHorse.Size = new System.Drawing.Size(159, 44);
            this.btnDrawHorse.TabIndex = 1;
            this.btnDrawHorse.Text = "Draw Horse";
            this.btnDrawHorse.UseVisualStyleBackColor = true;
            this.btnDrawHorse.Click += new System.EventHandler(this.btnDrawHorse_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(964, 582);
            this.Controls.Add(this.txtNumber);
            this.Controls.Add(this.btnDrawHorse);
            this.Controls.Add(this.btnDrawChessBoard);
            this.Controls.Add(this.panelChessBoard);
            this.Name = "Form1";
            this.Text = "Knight\'s Tour";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Panel panelChessBoard;
        private System.Windows.Forms.Button btnDrawChessBoard;
        private System.Windows.Forms.TextBox txtNumber;
        private System.Windows.Forms.Button btnDrawHorse;
    }
}

