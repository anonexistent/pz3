using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace pz3
{
    /// <summary>
    /// Логика взаимодействия для MainMenu.xaml
    /// </summary>
    public partial class MainMenu : Window
    {
        int? TOTAL = 0;
        object LastSelectedTrouble;

        public MainMenu()
        {
            InitializeComponent();

            if (Window2.currentRole!=0) TablesSettings.IsEnabled = false;

            //doubleDg.ItemsSource = MainWindow.db.Troubles_list.ToList();

            cbVIN.ItemsSource = GetVehiclesVINs();
            cbWorker.ItemsSource = GetWorkers();
            cbTroublesMain.ItemsSource = GetTroubles();

            cbTrouble2.ItemsSource = GetTroubles();
            cbTrouble3.ItemsSource = GetTroubles();
            cbTrouble4.ItemsSource = GetTroubles();

            tbReportNumber.Text = GetCurrentId();

            dgUsers.ItemsSource = MainWindow.db.Users.ToList();
            dgTroubles.ItemsSource = MainWindow.db.Troubles.ToList();

            tbkCancatDog.Text = new String('—', 30);
        }

        void ToDoDgViewsGood()
        {

        }

        List<string> GetVehiclesVINs()
        {
            List<string> result = new List<string>();

            foreach (var item in MainWindow.db.Vehicles.ToList())
            {
                result.Add(item.VIN);
            }

            return result;
        }

        List<string> GetWorkers()
        {
            List<string> result = new List<string>();

            foreach (var item in MainWindow.db.Mechanics.ToList())
            {
                result.Add(item.Id + " " + item.FirstName + " " + item.SeconName + " " + item.ThirdName);
            }

            return result;
        }

        List<string> GetTroubles()
        {
            List<string> result = new List<string>();

            foreach (var item in MainWindow.db.Troubles.ToList())
            {
                result.Add(item.Name0);
            }

            return result;
        }

        string GetCurrentId()
        {
            string result;

            var temp = (from x in MainWindow.db.Reports select x.Id).ToList();

            result = (temp[temp.Count - 1] + 1).ToString();

            return result;
        }

        void DoNewReportAndSomethingInTableTroublesListNow()
        {
            int temp;
            int.TryParse(string.Join("", cbWorker.SelectedItem.ToString().Where(c => char.IsDigit(c))), out temp);

            Reports report = new Reports();
            report.Id = int.Parse(GetCurrentId());
            report.VIN = cbVIN.SelectedItem.ToString();
            report.Date = DateTime.Now;
            report.Mechanics = MainWindow.db.Mechanics.Where(x => x.Id == temp).First();

            MainWindow.db.Reports.Add(report);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void btnNextTroubles_Click(object sender, RoutedEventArgs e)
        {
            if (!cbTrouble2.IsVisible)
            {
                cbTrouble2.Visibility = Visibility.Visible;
                return;
            }
            if (cbTrouble2.IsVisible && !cbTrouble3.IsVisible)
            {
                cbTrouble3.Visibility = Visibility.Visible;
                return;
            }
            if (cbTrouble3.IsVisible && !cbTrouble4.IsVisible)
            {
                cbTrouble4.Visibility = Visibility.Visible;
                return;
            }
        }

        private void btnBackTroubles_Click(object sender, RoutedEventArgs e)
        {
            if (cbTrouble4.IsVisible)
            {
                cbTrouble4.Visibility = Visibility.Hidden;
                return;
            }
            if (cbTrouble3.IsVisible)
            {
                cbTrouble3.Visibility = Visibility.Hidden;
                return;
            }
            if (cbTrouble2.IsVisible)
            {
                cbTrouble2.Visibility = Visibility.Hidden;
                return;
            }

        }

        private void cbTroublesMain_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ((ComboBox)sender).IsEnabled = false;

            var b = ((ComboBox)sender).SelectedItem;

            System.Threading.Thread.Sleep(50);
            var a = MainWindow.db.Troubles.Where(x => x.Name0 == b.ToString()).ToList();
            TOTAL += a[0].Repair_price;
            tbTOTAL.Text = TOTAL.ToString();
        }

        private void cbVIN_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ((ComboBox)sender).IsEnabled = false;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string filename = "./" + ($"{DateTime.Now}").Replace(' ', '_').Replace(':', '_').Replace('.', '_') + ".txt";

            string result = "report n: " + $"{tbReportNumber.Text}" + "\nVIN: " + $"{cbVIN.Text}" + "\nworker: " + $"{cbWorker.Text}" + "\ntroubles: " +
                $"\t\t{cbTroublesMain.SelectedItem}" + $"\n\t\t{cbTrouble2.SelectedItem}" + $"\n\t\t{cbTrouble3.SelectedItem}" + $"\n\t\t{cbTrouble4.SelectedItem}"
                +$"\nTOTAL:\t{tbTOTAL.Text}";

            FileStream file = new FileStream(filename, FileMode.OpenOrCreate);
            StreamWriter sw = new StreamWriter(file);
            sw.Write(result);
            sw.Close();

            DoNewReportAndSomethingInTableTroublesListNow();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            dgUsers.ItemsSource = MainWindow.db.Users.Where(x => x.login0.Contains(((TextBox)sender).Text)).ToList();
        }
    }
}
