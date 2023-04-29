namespace DTA_2022_23_Battleship
{
    partial class BattleshipGame
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            battleshipBoardPlayer1 = new BattleshipBoard();
            battleshipBoardPlayer2 = new BattleshipBoard();
            label1 = new Label();
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            groupBox1 = new GroupBox();
            radioButton4 = new RadioButton();
            radioButton3 = new RadioButton();
            radioButton2 = new RadioButton();
            radioButton1 = new RadioButton();
            groupBox2 = new GroupBox();
            radioButton5 = new RadioButton();
            radioButton6 = new RadioButton();
            radioButton7 = new RadioButton();
            radioButton8 = new RadioButton();
            button4 = new Button();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // battleshipBoardPlayer1
            // 
            battleshipBoardPlayer1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            battleshipBoardPlayer1.BackColor = SystemColors.ControlLight;
            battleshipBoardPlayer1.Location = new Point(68, 111);
            battleshipBoardPlayer1.Margin = new Padding(4, 7, 4, 7);
            battleshipBoardPlayer1.Name = "battleshipBoardPlayer1";
            battleshipBoardPlayer1.ShowShips = false;
            battleshipBoardPlayer1.Size = new Size(359, 442);
            battleshipBoardPlayer1.TabIndex = 4;
            // 
            // battleshipBoardPlayer2
            // 
            battleshipBoardPlayer2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            battleshipBoardPlayer2.BackColor = SystemColors.ControlLight;
            battleshipBoardPlayer2.Location = new Point(719, 111);
            battleshipBoardPlayer2.Margin = new Padding(4, 7, 4, 7);
            battleshipBoardPlayer2.Name = "battleshipBoardPlayer2";
            battleshipBoardPlayer2.ShowShips = false;
            battleshipBoardPlayer2.Size = new Size(359, 452);
            battleshipBoardPlayer2.TabIndex = 5;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Times New Roman", 18F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(408, 47);
            label1.Margin = new Padding(2, 0, 2, 0);
            label1.Name = "label1";
            label1.Size = new Size(146, 34);
            label1.TabIndex = 6;
            label1.Text = "BattleShip ";
            // 
            // button1
            // 
            button1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            button1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            button1.Location = new Point(396, 598);
            button1.Margin = new Padding(2);
            button1.Name = "button1";
            button1.Size = new Size(337, 44);
            button1.TabIndex = 7;
            button1.Text = "EXIT";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(167, 33);
            button2.Margin = new Padding(4);
            button2.Name = "button2";
            button2.Size = new Size(86, 31);
            button2.TabIndex = 8;
            button2.Text = "button2";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.Location = new Point(638, 49);
            button3.Margin = new Padding(4);
            button3.Name = "button3";
            button3.Size = new Size(86, 31);
            button3.TabIndex = 9;
            button3.Text = "button3";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(84, 71);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(50, 20);
            label2.TabIndex = 10;
            label2.Text = "label2";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(568, 81);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(50, 20);
            label3.TabIndex = 11;
            label3.Text = "label3";
            label3.Click += label3_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(308, 76);
            label4.Margin = new Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new Size(17, 20);
            label4.TabIndex = 12;
            label4.Text = "0";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(825, 79);
            label5.Margin = new Padding(4, 0, 4, 0);
            label5.Name = "label5";
            label5.Size = new Size(17, 20);
            label5.TabIndex = 13;
            label5.Text = "0";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(radioButton4);
            groupBox1.Controls.Add(radioButton3);
            groupBox1.Controls.Add(radioButton2);
            groupBox1.Controls.Add(radioButton1);
            groupBox1.Location = new Point(9, 591);
            groupBox1.Margin = new Padding(4);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(4);
            groupBox1.Size = new Size(367, 68);
            groupBox1.TabIndex = 14;
            groupBox1.TabStop = false;
            // 
            // radioButton4
            // 
            radioButton4.AutoSize = true;
            radioButton4.Location = new Point(278, 28);
            radioButton4.Margin = new Padding(4);
            radioButton4.Name = "radioButton4";
            radioButton4.Size = new Size(74, 24);
            radioButton4.TabIndex = 3;
            radioButton4.Text = "Genius";
            radioButton4.UseVisualStyleBackColor = true;
            // 
            // radioButton3
            // 
            radioButton3.AutoSize = true;
            radioButton3.Location = new Point(188, 28);
            radioButton3.Margin = new Padding(4);
            radioButton3.Name = "radioButton3";
            radioButton3.Size = new Size(69, 24);
            radioButton3.TabIndex = 2;
            radioButton3.Text = "Smart";
            radioButton3.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            radioButton2.AutoSize = true;
            radioButton2.Location = new Point(104, 28);
            radioButton2.Margin = new Padding(4);
            radioButton2.Name = "radioButton2";
            radioButton2.Size = new Size(73, 24);
            radioButton2.TabIndex = 1;
            radioButton2.Text = "Stupid";
            radioButton2.UseVisualStyleBackColor = true;
            radioButton2.CheckedChanged += radioButton2_CheckedChanged;
            // 
            // radioButton1
            // 
            radioButton1.AutoSize = true;
            radioButton1.Checked = true;
            radioButton1.Location = new Point(23, 28);
            radioButton1.Margin = new Padding(4);
            radioButton1.Name = "radioButton1";
            radioButton1.Size = new Size(79, 24);
            radioButton1.TabIndex = 0;
            radioButton1.TabStop = true;
            radioButton1.Text = "Manual";
            radioButton1.UseVisualStyleBackColor = true;
            radioButton1.CheckedChanged += radioButton1_CheckedChanged;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(radioButton5);
            groupBox2.Controls.Add(radioButton6);
            groupBox2.Controls.Add(radioButton7);
            groupBox2.Controls.Add(radioButton8);
            groupBox2.Location = new Point(739, 574);
            groupBox2.Margin = new Padding(4);
            groupBox2.Name = "groupBox2";
            groupBox2.Padding = new Padding(4);
            groupBox2.Size = new Size(367, 68);
            groupBox2.TabIndex = 15;
            groupBox2.TabStop = false;
            // 
            // radioButton5
            // 
            radioButton5.AutoSize = true;
            radioButton5.Location = new Point(280, 30);
            radioButton5.Margin = new Padding(4);
            radioButton5.Name = "radioButton5";
            radioButton5.Size = new Size(74, 24);
            radioButton5.TabIndex = 3;
            radioButton5.Text = "Genius";
            radioButton5.UseVisualStyleBackColor = true;
            // 
            // radioButton6
            // 
            radioButton6.AutoSize = true;
            radioButton6.Location = new Point(190, 29);
            radioButton6.Margin = new Padding(4);
            radioButton6.Name = "radioButton6";
            radioButton6.Size = new Size(69, 24);
            radioButton6.TabIndex = 2;
            radioButton6.Text = "Smart";
            radioButton6.UseVisualStyleBackColor = true;
            // 
            // radioButton7
            // 
            radioButton7.AutoSize = true;
            radioButton7.Location = new Point(106, 30);
            radioButton7.Margin = new Padding(4);
            radioButton7.Name = "radioButton7";
            radioButton7.Size = new Size(73, 24);
            radioButton7.TabIndex = 1;
            radioButton7.Text = "Stupid";
            radioButton7.UseVisualStyleBackColor = true;
            // 
            // radioButton8
            // 
            radioButton8.AutoSize = true;
            radioButton8.Checked = true;
            radioButton8.Location = new Point(25, 30);
            radioButton8.Margin = new Padding(4);
            radioButton8.Name = "radioButton8";
            radioButton8.Size = new Size(79, 24);
            radioButton8.TabIndex = 0;
            radioButton8.TabStop = true;
            radioButton8.Text = "Manual";
            radioButton8.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            button4.Location = new Point(435, 522);
            button4.Margin = new Padding(4);
            button4.Name = "button4";
            button4.Size = new Size(276, 31);
            button4.TabIndex = 16;
            button4.Text = "Перейти к форме администратора";
            button4.UseVisualStyleBackColor = true;
            button4.Visible = false;
            button4.Click += ToAdmonistratorForm;
            // 
            // BattleshipGame
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1108, 659);
            Controls.Add(button4);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(battleshipBoardPlayer1);
            Controls.Add(battleshipBoardPlayer2);
            Controls.Add(button1);
            Controls.Add(label1);
            ForeColor = SystemColors.ActiveCaptionText;
            Margin = new Padding(4);
            Name = "BattleshipGame";
            Text = "BattleShip";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private BattleshipBoard battleshipBoardPlayer1;
        private BattleshipBoard battleshipBoardPlayer2;
        private Label label1;
        private Button button1;
        private Button button2;
        private Button button3;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private GroupBox groupBox1;
        private RadioButton radioButton3;
        private RadioButton radioButton2;
        private RadioButton radioButton1;
        private RadioButton radioButton4;
        private GroupBox groupBox2;
        private RadioButton radioButton5;
        private RadioButton radioButton6;
        private RadioButton radioButton7;
        private RadioButton radioButton8;
        private Button button4;
    }
}