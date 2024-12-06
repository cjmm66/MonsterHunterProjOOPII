
namespace WindowsFormsApp
{
    partial class Game
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
            this.monsterPic = new System.Windows.Forms.PictureBox();
            this.picPlayer = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.picGoal = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.monsterPic)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picPlayer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picGoal)).BeginInit();
            this.SuspendLayout();
            // 
            // monsterPic
            // 
            this.monsterPic.Image = global::WindowsFormsApp.Properties.Resources.angryAppa;
            this.monsterPic.Location = new System.Drawing.Point(140, 398);
            this.monsterPic.Name = "monsterPic";
            this.monsterPic.Size = new System.Drawing.Size(40, 40);
            this.monsterPic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.monsterPic.TabIndex = 2;
            this.monsterPic.TabStop = false;
            // 
            // picPlayer
            // 
            this.picPlayer.Image = global::WindowsFormsApp.Properties.Resources.Avatar_aang;
            this.picPlayer.Location = new System.Drawing.Point(80, 398);
            this.picPlayer.Name = "picPlayer";
            this.picPlayer.Size = new System.Drawing.Size(40, 40);
            this.picPlayer.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picPlayer.TabIndex = 1;
            this.picPlayer.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::WindowsFormsApp.Properties.Resources.wall;
            this.pictureBox1.Location = new System.Drawing.Point(18, 398);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(40, 40);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // picGoal
            // 
            this.picGoal.Image = global::WindowsFormsApp.Properties.Resources.goal;
            this.picGoal.Location = new System.Drawing.Point(201, 398);
            this.picGoal.Name = "picGoal";
            this.picGoal.Size = new System.Drawing.Size(40, 40);
            this.picGoal.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picGoal.TabIndex = 3;
            this.picGoal.TabStop = false;
            // 
            // Game
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.picGoal);
            this.Controls.Add(this.monsterPic);
            this.Controls.Add(this.picPlayer);
            this.Controls.Add(this.pictureBox1);
            this.KeyPreview = true;
            this.Name = "Game";
            this.Text = "Game";
            this.Load += new System.EventHandler(this.Game_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Game_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.monsterPic)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picPlayer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picGoal)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox picPlayer;
        private System.Windows.Forms.PictureBox monsterPic;
        private System.Windows.Forms.PictureBox picGoal;
    }
}