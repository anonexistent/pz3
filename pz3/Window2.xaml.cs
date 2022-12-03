using System;
using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace pz3
{
    public partial class Window2 : Window
    {
        public static int? currentRole = 10;

        public Window2() => InitializeComponent();

        private void out_Click(object sender, RoutedEventArgs e) => Application.Current.Shutdown();

        //  перетаскивание окна (стиль окна - нон)
        private void Label_MouseLeftButtonDown(object sender, MouseButtonEventArgs e) => this.DragMove();

        private void in_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //  проверка наличия пользователя в бд
                if (MainWindow.db.Users.Where(x => (x.login0 == tbLogin.Text && x.password0 == tbPassword.Password)).FirstOrDefault() != null)
                {
                    currentRole = MainWindow.db.Users.Where(x => x.login0 == tbLogin.Text).Select(x => x.Role0).First();
                    new MainMenu().Show();
                    this.Close();
                }
                else MessageBox.Show("bad\t☺ ☻");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}