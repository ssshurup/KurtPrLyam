using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace KurtPrLyam.Pages
{
    /// <summary>
    /// Логика взаимодействия для AddP.xaml
    /// </summary>
    public partial class AddP : Page
    {
        films Context;
        public AddP()
        {
            InitializeComponent();
            CountryCB.ItemsSource = App.DB.country.ToList();
            DirectorCB.ItemsSource = App.DB.director.ToList();
            films film = new films();
            Context = film;
            DataContext = Context;
            
        }

        private void AddBT_Click(object sender, RoutedEventArgs e)
        {
            if(Context != null)
            {
                Context.idCountry = CountryCB.SelectedIndex + 1;
                Context.idDirector = DirectorCB.SelectedIndex + 1;
                App.DB.films.Add(Context);
                App.DB.SaveChanges();
                MessageBox.Show("Succes!");
                NavigationService.Navigate(new AddP());
            }
        }
    }
}
