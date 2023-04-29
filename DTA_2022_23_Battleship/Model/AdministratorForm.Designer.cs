namespace DTA_2022_23_Battleship.Model
{
    partial class AdministratorForm
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
            dataGridViewUsers = new DataGridView();
            button1 = new Button();
            dataGridViewStatistic = new DataGridView();
            label1 = new Label();
            label2 = new Label();
            button2 = new Button();
            button3 = new Button();
            button4 = new Button();
            textBoxName = new TextBox();
            label3 = new Label();
            label4 = new Label();
            textBoxPassword = new TextBox();
            label5 = new Label();
            dateTimePicker1 = new DateTimePicker();
            checkBox1 = new CheckBox();
            groupBox1 = new GroupBox();
            button5 = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridViewUsers).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridViewStatistic).BeginInit();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // dataGridViewUsers
            // 
            dataGridViewUsers.BackgroundColor = SystemColors.Info;
            dataGridViewUsers.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewUsers.Location = new Point(20, 68);
            dataGridViewUsers.Margin = new Padding(5, 4, 5, 4);
            dataGridViewUsers.Name = "dataGridViewUsers";
            dataGridViewUsers.RowHeadersWidth = 51;
            dataGridViewUsers.RowTemplate.Height = 29;
            dataGridViewUsers.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewUsers.Size = new Size(410, 294);
            dataGridViewUsers.TabIndex = 0;
            // 
            // button1
            // 
            button1.Location = new Point(20, 534);
            button1.Margin = new Padding(5, 4, 5, 4);
            button1.Name = "button1";
            button1.Size = new Size(153, 38);
            button1.TabIndex = 1;
            button1.Text = "Удалить";
            button1.UseVisualStyleBackColor = true;
            button1.Click += Delete;
            // 
            // dataGridViewStatistic
            // 
            dataGridViewStatistic.BackgroundColor = SystemColors.Info;
            dataGridViewStatistic.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewStatistic.Location = new Point(34, 61);
            dataGridViewStatistic.Margin = new Padding(5, 4, 5, 4);
            dataGridViewStatistic.Name = "dataGridViewStatistic";
            dataGridViewStatistic.RowHeadersWidth = 51;
            dataGridViewStatistic.RowTemplate.Height = 29;
            dataGridViewStatistic.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewStatistic.Size = new Size(419, 294);
            dataGridViewStatistic.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(20, 24);
            label1.Name = "label1";
            label1.Size = new Size(89, 26);
            label1.TabIndex = 3;
            label1.Text = "Игроки:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(34, 17);
            label2.Name = "label2";
            label2.Size = new Size(127, 26);
            label2.TabIndex = 4;
            label2.Text = "Статистика:";
            // 
            // button2
            // 
            button2.Location = new Point(746, 534);
            button2.Margin = new Padding(5, 4, 5, 4);
            button2.Name = "button2";
            button2.Size = new Size(153, 38);
            button2.TabIndex = 5;
            button2.Text = "Выход";
            button2.UseVisualStyleBackColor = true;
            button2.Click += Exit;
            // 
            // button3
            // 
            button3.Location = new Point(209, 534);
            button3.Margin = new Padding(5, 4, 5, 4);
            button3.Name = "button3";
            button3.Size = new Size(153, 38);
            button3.TabIndex = 6;
            button3.Text = "Добавить ";
            button3.UseVisualStyleBackColor = true;
            button3.Click += AddUser;
            // 
            // button4
            // 
            button4.Location = new Point(395, 534);
            button4.Margin = new Padding(5, 4, 5, 4);
            button4.Name = "button4";
            button4.Size = new Size(195, 38);
            button4.TabIndex = 7;
            button4.Text = "Деактивировать";
            button4.UseVisualStyleBackColor = true;
            button4.Click += Deactive;
            // 
            // textBoxName
            // 
            textBoxName.Location = new Point(20, 479);
            textBoxName.Name = "textBoxName";
            textBoxName.Size = new Size(153, 34);
            textBoxName.TabIndex = 8;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(20, 437);
            label3.Name = "label3";
            label3.Size = new Size(53, 26);
            label3.TabIndex = 9;
            label3.Text = "Имя";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(209, 437);
            label4.Name = "label4";
            label4.Size = new Size(82, 26);
            label4.TabIndex = 11;
            label4.Text = "Пароль";
            // 
            // textBoxPassword
            // 
            textBoxPassword.Location = new Point(209, 479);
            textBoxPassword.Name = "textBoxPassword";
            textBoxPassword.Size = new Size(153, 34);
            textBoxPassword.TabIndex = 10;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(395, 437);
            label5.Name = "label5";
            label5.Size = new Size(159, 26);
            label5.TabIndex = 13;
            label5.Text = "Дата рождения";
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Location = new Point(395, 476);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(195, 34);
            dateTimePicker1.TabIndex = 14;
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Location = new Point(621, 476);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(188, 30);
            checkBox1.TabIndex = 15;
            checkBox1.Text = "Администратор";
            checkBox1.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(button5);
            groupBox1.Controls.Add(dataGridViewStatistic);
            groupBox1.Controls.Add(label2);
            groupBox1.Location = new Point(438, 7);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(461, 427);
            groupBox1.TabIndex = 16;
            groupBox1.TabStop = false;
            // 
            // button5
            // 
            button5.Location = new Point(183, 382);
            button5.Margin = new Padding(5, 4, 5, 4);
            button5.Name = "button5";
            button5.Size = new Size(270, 38);
            button5.TabIndex = 8;
            button5.Text = "Скрыть всю таблицу";
            button5.UseVisualStyleBackColor = true;
            button5.Click += UnVisibleTable;
            // 
            // AdministratorForm
            // 
            AutoScaleDimensions = new SizeF(13F, 26F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(913, 585);
            Controls.Add(groupBox1);
            Controls.Add(checkBox1);
            Controls.Add(dateTimePicker1);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(textBoxPassword);
            Controls.Add(label3);
            Controls.Add(textBoxName);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(label1);
            Controls.Add(button1);
            Controls.Add(dataGridViewUsers);
            Font = new Font("Times New Roman", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            Margin = new Padding(5, 4, 5, 4);
            Name = "AdministratorForm";
            Text = "AdministratorForm";
            ((System.ComponentModel.ISupportInitialize)dataGridViewUsers).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridViewStatistic).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridViewUsers;
        private Button button1;
        private DataGridView dataGridViewStatistic;
        private Label label1;
        private Label label2;
        private Button button2;
        private Button button3;
        private Button button4;
        private TextBox textBoxName;
        private Label label3;
        private Label label4;
        private TextBox textBoxPassword;
        private Label label5;
        private DateTimePicker dateTimePicker1;
        private CheckBox checkBox1;
        private GroupBox groupBox1;
        private Button button5;
    }
}