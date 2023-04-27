using System;
using WpfAppSQLTermekek;
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
using System.IO;
using MySql.Data.MySqlClient;

namespace WpfApp2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private const string kapcsolatLeiro = "datasource=127.0.0.1;port=3306;username=root;password=;database=hardver;charset=utf8;";
        List<Termek> termekek = new List<Termek>();
        MySqlConnection SQLkapcsolat;
        
        public MainWindow()
        {
            InitializeComponent();

            AdatbazisMegnyitas();
            KategoriaBetoltese();
            GyartokBetoltese();

            TermekekBetolteseListaba();

            AdatbazisLezarasa();
        }

        private void btnSzukit_Click(object sender, RoutedEventArgs e)
        {
            termekek.Clear();
            string SQLSzukitettLista= SzukitoLekerdezesEloallitasa();
            MySqlCommand SQLparancs = new MySqlCommand(SQLSzukitettLista, SQLkapcsolat);
            MySqlDataReader eredmenyolvaso = SQLparancs.ExecuteReader();
            while (eredmenyolvaso.Read())
            {
                Termek uj = new Termek(eredmenyolvaso.GetString("Kategória"), eredmenyolvaso.GetString("Gyártó"),eredmenyolvaso.GetString("Név"), eredmenyolvaso.GetInt32("Ár"), eredmenyolvaso.GetInt32("Garidő"));
                termekek.Add(uj);
            }
            eredmenyolvaso.Close();
            dgTermekek.Items.Refresh();
              
        }

        private void btnMentes_Click(object sender, RoutedEventArgs e)
        {
            StreamWriter sw = new StreamWriter("blabla.csv");
            foreach (var item in termekek);
            {
                sw.WriteLine(ItemCollection.toCSVString());
            }
            sw.Close();
        }
    }
}
