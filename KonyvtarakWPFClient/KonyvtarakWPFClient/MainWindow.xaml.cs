using KonyvtarakWPFClient.DTOs;
using KonyvtarakWPFClient.Models;
using KonyvtarakWPFClient.Services;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace KonyvtarakWPFClient
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private static HttpClient myClient = new()
        {
            BaseAddress = new Uri("http://localhost:5000")
        }; 
        private static List<KonyvtarakDTO> konyvtarak = new List<KonyvtarakDTO>();

        public MainWindow()
        {
            InitializeComponent();
            Feltolt();
        }

        private async void btnUj_Click(object sender, RoutedEventArgs e)
        {
            Konyvtarak ujKonyvtar = new()
            {
                KonyvtarNev = tbxKonyvtarNev.Text,
                Irsz = int.Parse(tbxIrsz.Text),
                Cim = tbxCim.Text,
                IrszNavigation = null,
            };
            await KonyvtarakService.POST(myClient, ujKonyvtar);
            Task.Delay(500).Wait();
            Feltolt();
        }

        private async void btnModosit_Click(object sender, RoutedEventArgs e)
        {
            Konyvtarak modositKonyvtar = new()
            {
                Id = int.Parse(tbxId.Text),
                KonyvtarNev = tbxKonyvtarNev.Text,
                Irsz = int.Parse(tbxIrsz.Text),
                Cim = tbxCim.Text,
                IrszNavigation = null,
            };
            await KonyvtarakService.PUT(myClient, modositKonyvtar);
            Task.Delay(500).Wait();
            Feltolt();
        }

        private async void btnTorol_Click(object sender, RoutedEventArgs e)
        {
            Konyvtarak modositKonyvtar = new()
            {
                Id = int.Parse(tbxId.Text),
            };
            await KonyvtarakService.DELETE(myClient, modositKonyvtar);
            Task.Delay(500).Wait();
            Feltolt();
        }

        private async void Feltolt()
        {
            //aszinkron módon lekérjük a DTO listá a backendről --> Services
            konyvtarak = await KonyvtarakService.GetDTOList(myClient);
            Task.Delay(500).Wait();
            //beállítjuk az adatbázis ItemSource tulajdonságát
            dgrKonyvtarak.ItemsSource = konyvtarak;
        }

        private void dgrKonyvtarak_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            KonyvtarakDTO valasztott = dgrKonyvtarak.SelectedItem as KonyvtarakDTO;
            if (valasztott is not null)
            {
                tbxId.Text = valasztott.Id.ToString();
                tbxCim.Text = valasztott.Cim.ToString();
                tbxIrsz.Text = valasztott.Irsz.ToString();
                tbxKonyvtarNev.Text = valasztott.KonyvtarNev.ToString();
                tbxTelepulesNev.Text = valasztott.TelepulesNev.ToString();
                tbxMegyeNev.Text = valasztott.MegyeNev.ToString();
            }
        }
    }
}