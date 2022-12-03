using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Data;

namespace pz3
{    

    //public partial class MainWindow : Window
    //{
    //    public MainWindow()
    //    {
    //        InitializeComponent();
    //    }   
    //}
    public partial class MainWindow : Window
    {
        public static A7_AGROEntities db = new A7_AGROEntities();
        List<Troubles> troubles = new List<Troubles>();
        List<Reports> reports = new List<Reports>();


        public MainWindow()
        {
            

            InitializeComponent();

            cbBinding();

            //  таблицы
            dataGridTroubles.ItemsSource = db.Reports.ToList();
            //dataGridBrands.ItemsSource             = db.Brands.ToList();
            //dataGridCategories.ItemsSource      = db.Categories.ToList();
            //dataGridCharacteristics.ItemsSource = db.Characteristics.ToList();
            //dataGridDrivers.ItemsSource           = db.Drivers.ToList();
            //dataGridMechanics.ItemsSource       = db.Mechanics.ToList();
            //dataGridParking.ItemsSource           = db.Parking.ToList();
            //dataGridSpecializations.ItemsSource         = db.Specializations.ToList();
            //dataGridVehicles.ItemsSource         = db.Vehicles.ToList();
            //dataGridReports.ItemsSource         = db.Reports.ToList();
        }

        //public static A7_AGROEntities db = new A7_AGROEntities();

        //public List<Troubles> troubles { get; set; }

        //  список комбобокса
        void cbBinding()
        {
            var item = db.Troubles.ToList();
            troubles = item;
            DataContext = troubles;
        }

        private void comboBoxTables_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            #region MoreTables
            //var a = db.GetType().GetProperties().Where(x => x.GetMethod.IsPublic).Select(x => x.Name).ToArray();
            //MessageBox.Show(String.Join("; ", a));
            //for (int i = 0; i < a.Length; i++)
            //{
            //    if (a[i]==comboBoxTables.SelectedItem.ToString())
            //    {
            //        dataGrid0.ItemsSource = db.{ a[i]}.T oList();
            //    }
            //}

            //var dgs = new List<DataGrid>
            //{
            //    dataGridTroubles,
            //    dataGridBrands,
            //    dataGridCategories,
            //    dataGridCharacteristics,
            //    dataGridDrivers,
            //    dataGridMechanics,
            //    dataGridParking,
            //    dataGridSpecializations,
            //    dataGridVehicles,
            //    dataGridReports
            //};

            //foreach (var item in dgs) item.Visibility = Visibility.Hidden;

            //if (comboBoxTables.SelectedItem.ToString() == "Troubles") dataGridTroubles.Visibility = Visibility.Visible;
            //if (comboBoxTables.SelectedItem.ToString() == "Brands") dataGridBrands.Visibility = Visibility.Visible;
            //if (comboBoxTables.SelectedItem.ToString() == "Categories") dataGridCategories.Visibility = Visibility.Visible;
            //if (comboBoxTables.SelectedItem.ToString() == "Characteristics") dataGridCharacteristics.Visibility = Visibility.Visible;
            //if (comboBoxTables.SelectedItem.ToString() == "Drivers") dataGridDrivers.Visibility = Visibility.Visible;
            //if (comboBoxTables.SelectedItem.ToString() == "Mechanics") dataGridMechanics.Visibility = Visibility.Visible;
            //if (comboBoxTables.SelectedItem.ToString() == "Parking") dataGridParking.Visibility = Visibility.Visible;
            //if (comboBoxTables.SelectedItem.ToString() == "Specializations") dataGridSpecializations.Visibility = Visibility.Visible;
            //if (comboBoxTables.SelectedItem.ToString() == "Vehicles") dataGridVehicles.Visibility = Visibility.Visible;
            //if (comboBoxTables.SelectedItem.ToString() == "Reports") dataGridReports.Visibility = Visibility.Visible;

            //switch (comboBoxTables.Items)
            //{


            //    default:
            //        break;
            //}
            #endregion

        }

        //  список комбобокса
        void FillComboBox0(ComboBox cb)
        {
            var a = db.GetType().GetProperties().Where(x => x.GetMethod.IsPublic).Select(x => x.Name).ToArray();

            for (int i = 0; i < a.Length; i++) if (char.IsUpper(a[i][0])) cb.Items.Add(a[i]);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            FillComboBox0(comboBoxTables);
        }

        //удаление
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int idfordelte = int.Parse(tbid.Text);
            var selecteditemidandthing = db.Troubles.Where(x => x.Id == idfordelte).FirstOrDefault();
            db.Troubles.Remove(selecteditemidandthing);
            db.SaveChanges();
            dataGridTroubles.ItemsSource = db.Troubles.ToList();
        }

        //добавление
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Troubles t = new Troubles();
            t.Id = int.Parse(tbid.Text);
            t.Name0 = tbname.Text;
            t.Description0 = tbdis.Text;
            t.Repair_price = int.Parse(tbdprice.Text);
            db.Troubles.Add(t);
            db.SaveChanges();
            dataGridTroubles.ItemsSource = db.Troubles.ToList();
        }

        //изменение
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            int selectedIdChange = int.Parse(tbid.Text);
            var selectedIdChangeThing = db.Troubles.Where(x => x.Id == selectedIdChange).FirstOrDefault();
            selectedIdChangeThing.Id = int.Parse(tbid.Text);
            selectedIdChangeThing.Name0 = tbname.Text;
            selectedIdChangeThing.Description0 = tbdis.Text;
            selectedIdChangeThing.Repair_price = int.Parse(tbdprice.Text);
            db.SaveChanges();
            dataGridTroubles.ItemsSource = db.Troubles.ToList();
        }

        //новая таблица
        private void btnChildTable_Click(object sender, RoutedEventArgs e)
        {
            Window1 w = new Window1();
            MessageBox.Show(Window2.currentRole.ToString());
            w.ShowDialog();
        }

        //  фильтрация
        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            dataGridTroubles.ItemsSource = db.Troubles.Where(x => x.Id == cbT.SelectedIndex).ToList();
        }

        //      П Д Ф
        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            #region inPDF
            //Document document = new Document();
            //PdfWriter writer = PdfWriter.GetInstance(document, new FileStream("c://sample.pdf", FileMode.Create));
            //document.Open();

            //DataTable df = new DataTable();
            //df = dataGridTroubles;

            //Font font5 = FontFactory.GetFont(FontFactory.HELVETICA, 5);

            //PdfPTable table = new PdfPTable(dataGridTroubles.Columns.Count);

            //Array floatArray = Array.CreateInstance(typeof(float), dataGridTroubles.Columns.Count);
            ////float[] widths = new float[] { };
            //for (int i = 0; i < dataGridTroubles.Columns.Count; i++)
            //    floatArray.SetValue(4f, i);

            //table.SetWidths((float[])floatArray);

            //table.WidthPercentage = 100;
            //PdfPCell cell = new PdfPCell(new Phrase("Products"));

            //cell.Colspan = dataGridTroubles.Columns.Count;

            //foreach (DataColumn c in dataGridTroubles.Columns)
            //{
            //    table.AddCell(new Phrase(c.ColumnName, font5));
            //}

            //foreach (DataRow r in dataGridTroubles.Rows)
            //{
            //    if (dataGridTroubles.Rows.Count > 0)
            //    {
            //        for (int i = 0; i < dataGridTroubles.Columns.Count; i++)
            //        {
            //            table.AddCell(new Phrase(r[i].ToString(), font5));
            //        }
            //    }
            //}
            //document.Add(table);
            //document.Close();
            #endregion

            try
            {
                this.IsEnabled = false;
                PrintDialog pd = new PrintDialog();
                if (pd.ShowDialog() == true)
                {
                    pd.PrintVisual(dataGridTroubles, "Troubles");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                this.IsEnabled = true;
            }
        }

        //  сброс фильтра
        private void Button_Click_3(object sender, RoutedEventArgs e) => dataGridTroubles.ItemsSource = db.Troubles.ToList();

    }
}
