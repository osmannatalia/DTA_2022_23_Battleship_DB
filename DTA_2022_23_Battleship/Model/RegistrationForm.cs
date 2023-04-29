using DTA_2022_23_Battleship.Model.DataBase;
using Microsoft.EntityFrameworkCore;
using System.Xml.Linq;

namespace DTA_2022_23_Battleship.Model
{
    public partial class RegistrationForm : Form
    {
        public RegistrationForm()
        {
            InitializeComponent();
        }

        private void EnterClick(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxLogin.Text)
                || string.IsNullOrEmpty(textBoxPassword.Text))
            {
                MessageBox.Show("Заполните все поля!");
                return;
            }
            var user = DataBaseService.DataBaseContext.Users.
                FirstOrDefault(u => u.Name == textBoxLogin.Text
                && u.Name == textBoxPassword.Text);

            if (user is null)
            {
                MessageBox.Show("Пользователь не найден!");
                return;
            }
            if (!user.IsAсtive)
            {
                MessageBox.Show("Пользователь деактивирован!");
                return;
            }

            MessageBox.Show("Вход успешно выполнен!");
            Hide();
            var batteship = new BattleshipGame(new Game(), user);
            batteship.ShowDialog();
            Close();
        }

        private void RegistrationClick(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxLogin.Text)
                            || string.IsNullOrEmpty(textBoxPassword.Text))
            {
                MessageBox.Show("Заполните все поля!");
                return;
            }
            try
            {
                var user = new User();
                user.Name = textBoxLogin.Text;
                user.Password = textBoxPassword.Text;
                user.BornDate = dateTimePicker1.Value;
                user.IsAdministration = checkBoxAdmin.Checked;
                user.IsAсtive = true;
                if(DataBaseService.DataBaseContext.Users.Where(u=>u.Name == user.Name).FirstOrDefault() is not  null)
                {
                    MessageBox.Show("В база данных уже есть пользователь с данным именем!");
                    return;
                }
                DataBaseService.DataBaseContext.Users.Add(user);
                DataBaseService.DataBaseContext.SaveChanges();

                MessageBox.Show("Регистрация успешно пройдена!");

                Hide();
                var batteship = new BattleshipGame(new Game(), user);
                batteship.ShowDialog();
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void RegistrationForm_Load(object sender, EventArgs e)
        {
            // гарантируем, что база данных создана
            DataBaseService.DataBaseContext.Database.EnsureCreated();
            // загружаем данные из БД
            DataBaseService.DataBaseContext.Statistics.Load();
            DataBaseService.DataBaseContext.Users.Load();

            DataBaseService.DataBaseContext.SaveChanges();
        }
    }
}
