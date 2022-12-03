using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace pz3
{
    internal class MyComboBox : ComboBox
    {
        public MyComboBox()
        {
            this.ItemsSource = MainWindow.db.Troubles.ToList().Select(x=>x.Name0);
        }
    }
}
