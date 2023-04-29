using DTA_2022_23_Battleship.Model.DataBase;
using DTA_2022_23_Battleship.Model;
using Microsoft.EntityFrameworkCore;

namespace DTA_2022_23_Battleship.Model
{
    public partial class AdministratorForm : Form
    {
        private User _activeUser;
        public AdministratorForm(User user)
        {
            _activeUser = user;
            InitializeComponent();
            dataGridViewStatistic.DataSource = DataBaseService.DataBaseContext.Statistics.Where(s => s.IsVisible).ToList();
            dataGridViewUsers.DataSource = DataBaseService.DataBaseContext.Users.Where(u => u.Id != _activeUser.Id).ToList();

        }

        private void Exit(object sender, EventArgs e)
        {
            Hide();
            var batteship = new BattleshipGame(new Game(), _activeUser);
            batteship.ShowDialog();
            Close();
        }

        private void AddUser(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxName.Text)
                || string.IsNullOrEmpty(textBoxPassword.Text)
                || string.IsNullOrEmpty(dateTimePicker1.Text))
            {

            }
            try
            {
                var user = new User();
                user.Name = textBoxName.Text;
                user.Password = textBoxPassword.Text;
                user.BornDate = Convert.ToDateTime(dateTimePicker1.Text);
                user.IsAсtive = true;
                user.IsAdministration = checkBox1.Checked;
                DataBaseService.DataBaseContext.Users.Add(user);
                DataBaseService.DataBaseContext.SaveChanges();
                dataGridViewUsers.DataSource = DataBaseService.DataBaseContext.Users.Where(u => u.Id != _activeUser.Id).ToList();
                MessageBox.Show("Успешно!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void Deactive(object sender, EventArgs e)
        {
            if (dataGridViewStatistic.SelectedRows.Count < 1)
            {
                MessageBox.Show("Выберите пользователя!");
                return;
            }
            try
            {
                var Id = int.Parse(dataGridViewUsers.SelectedRows[0].Cells[0].Value.ToString());
                var user = DataBaseService.DataBaseContext.Users.Where(u => u.Id == Id).FirstOrDefault();
                user.IsAсtive = false;
                DataBaseService.DataBaseContext.SaveChanges();
                dataGridViewUsers.DataSource = DataBaseService.DataBaseContext.Users.Where(u => u.Id != _activeUser.Id).ToList();
                MessageBox.Show("Успешно!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void Delete(object sender, EventArgs e)
        {
            try
            {
                var Id = int.Parse(dataGridViewUsers.SelectedRows[0].Cells[0].Value.ToString());
                DataBaseService.DataBaseContext.Users.Remove(DataBaseService.DataBaseContext.Users.Where(u => u.Id == Id).FirstOrDefault());
                DataBaseService.DataBaseContext.SaveChanges();
                dataGridViewUsers.DataSource = DataBaseService.DataBaseContext.Users.Where(u => u.Id != _activeUser.Id).ToList();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void UnVisibleTable(object sender, EventArgs e)
        {
            var statistic = DataBaseService.DataBaseContext.Statistics
                .Where(c => c.IsVisible).AsEnumerable()
                .Select(c => { c.IsVisible = false; return c; });

            foreach (var s in statistic)
            {
                // Указать, что запись изменилась
                DataBaseService.DataBaseContext.Entry(s).State = EntityState.Modified;
            }
            DataBaseService.DataBaseContext.SaveChanges();
            dataGridViewStatistic.DataSource = DataBaseService.DataBaseContext.Statistics.Where(s => s.IsVisible).ToList();
        }
    }
}
