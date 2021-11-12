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

namespace Software_Biblioteca
{
    /// <summary>
    /// Logica di interazione per MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Biblioteca biblioteca;
        public MainWindow()
        {
            InitializeComponent();

            biblioteca = new Biblioteca("Malatestiana","piazza",new List<DateTime>(),new List<DateTime>(),new List<Libro>());

            bibliotecaNL.Content = biblioteca.Nome;

            indirizzoBL.Content = biblioteca.Indirizzo;


        }

        private void cercaB_Click(object sender, RoutedEventArgs e)
        {
            if (titoloRB.IsChecked == true)
            {
                Libro l = biblioteca.CercaTitolo(cercaT.Text);

                cercaLi.Items.Clear();

                cercaLi.Items.Add(l);
            }
            else
            {
                List<Libro> libri = biblioteca.CercaAutore(cercaT.Text);

                cercaLi.ItemsSource = null;

                cercaLi.ItemsSource = libri;
            }

            
        }

        private void cercaLi_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Libro l = (Libro)cercaLi.SelectedItem;

            titoloT.Text = l.Titolo;

            autoreT.Text = l.Autore;

            editoreT.Text = l.Editore;

            nPagineT.Text = l.Pagine.ToString();

            annoT.Text = l.Pubblicazione.Year;


        }

        private void creaB_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int nPagine = int.Parse(nPagineT.Text);

                DateTime data = DateTime.Parse(annoT.Text);

                Libro l = new Libro(titoloT.Text,autoreT.Text,data,editoreT.Text,nPagine);
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
