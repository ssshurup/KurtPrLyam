using System;
using System.Collections.Generic;
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
    /// Логика взаимодействия для MainP.xaml
    /// </summary>
    public partial class MainP : Page
    {
        
        public MainP()
        {
            InitializeComponent();
            GenreCB.ItemsSource = App.DB.genre.ToList();
            DirectorCB.ItemsSource = App.DB.director.ToList();
            CountryCB.ItemsSource= App.DB.country.ToList();
        }

        private void Show_Click(object sender, RoutedEventArgs e)
        {
            var ff = App.DB.films.ToList();
            if(GenreCB.SelectedIndex != -1 )
                ff = ff.Where(a => a.genre.name == GenreCB.Text).ToList();
            if (NameFilmTB.Text != string.Empty)
                ff = ff.Where(a => a.name.ToLower().Contains(NameFilmTB.Text.ToLower())).ToList();
            if(CountryCB.SelectedIndex != -1)
                ff = ff.Where(a => a.country.name == CountryCB.Text).ToList();
            if(DirectorCB.SelectedIndex != -1)
                ff = ff.Where(a => a.director.name == DirectorCB.Text).ToList();



            FilmListDG.ItemsSource = ff;
        }

        private void ClearBT_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new MainP());
        }
    }
}
