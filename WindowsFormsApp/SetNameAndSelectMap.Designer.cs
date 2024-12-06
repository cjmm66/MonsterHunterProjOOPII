
namespace WindowsFormsApp
{
    partial class SetNameAndSelectMap
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.StartGame = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.textBoxNameSet = new System.Windows.Forms.TextBox();
            this.listBoxMaps = new System.Windows.Forms.ListBox();
            this.ErrorText = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(225, 101);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Player Name:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(225, 161);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Map:";
            // 
            // StartGame
            // 
            this.StartGame.Location = new System.Drawing.Point(229, 343);
            this.StartGame.Margin = new System.Windows.Forms.Padding(4);
            this.StartGame.Name = "StartGame";
            this.StartGame.Size = new System.Drawing.Size(196, 59);
            this.StartGame.TabIndex = 2;
            this.StartGame.Text = "StartGame";
            this.StartGame.UseVisualStyleBackColor = true;
            this.StartGame.Click += new System.EventHandler(this.StartGame_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(475, 343);
            this.button2.Margin = new System.Windows.Forms.Padding(4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(196, 59);
            this.button2.TabIndex = 3;
            this.button2.Text = "Quit Program";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // textBoxNameSet
            // 
            this.textBoxNameSet.Location = new System.Drawing.Point(431, 101);
            this.textBoxNameSet.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxNameSet.Name = "textBoxNameSet";
            this.textBoxNameSet.Size = new System.Drawing.Size(239, 22);
            this.textBoxNameSet.TabIndex = 4;
            this.textBoxNameSet.TextChanged += new System.EventHandler(this.textBoxNameSet_TextChanged);
            this.textBoxNameSet.Leave += new System.EventHandler(this.textBoxNameSet_Leave);
            // 
            // listBoxMaps
            // 
            this.listBoxMaps.FormattingEnabled = true;
            this.listBoxMaps.ItemHeight = 16;
            this.listBoxMaps.Location = new System.Drawing.Point(431, 161);
            this.listBoxMaps.Margin = new System.Windows.Forms.Padding(4);
            this.listBoxMaps.Name = "listBoxMaps";
            this.listBoxMaps.Size = new System.Drawing.Size(251, 20);
            this.listBoxMaps.TabIndex = 5;
            this.listBoxMaps.Leave += new System.EventHandler(this.listBoxMaps_Leave);
            // 
            // ErrorText
            // 
            this.ErrorText.AutoSize = true;
            this.ErrorText.Location = new System.Drawing.Point(225, 199);
            this.ErrorText.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.ErrorText.Name = "ErrorText";
            this.ErrorText.Size = new System.Drawing.Size(16, 17);
            this.ErrorText.TabIndex = 6;
            this.ErrorText.Text = "a";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(269, 38);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(293, 17);
            this.label3.TabIndex = 7;
            this.label3.Text = "WELCOME TO MONSTER HUNTER WORLD";
            // 
            // SetNameAndSelectMap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 554);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.ErrorText);
            this.Controls.Add(this.listBoxMaps);
            this.Controls.Add(this.textBoxNameSet);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.StartGame);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "SetNameAndSelectMap";
            this.Text = "SetNameAndSelectMap";
            this.Load += new System.EventHandler(this.SetNameAndSelectMap_Load_1);
            this.Click += new System.EventHandler(this.SetNameAndSelectMap_Click);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button StartGame;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox textBoxNameSet;
        private System.Windows.Forms.ListBox listBoxMaps;
        private System.Windows.Forms.Label ErrorText;
        private System.Windows.Forms.Label label3;
    }
}

