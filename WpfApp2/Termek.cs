using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfAppSQLTermekek
{
    public class Termek
    {
        string kategoria;
        string gyarto;
        string nev;
        int ar;
        int garido;

        public Termek(string kategoria, string gyarto, string nev, int ar, int garido)
        {
            this.kategoria = kategoria;
            this.gyarto = gyarto;
            this.nev = nev;
            this.ar = ar;
            this.garido = garido;
        }

        public string Kategoria { get => kategoria; set => kategoria = value; }
        public string Gyarto { get => gyarto; set => gyarto = value; }
        public string Nev { get => nev; set => nev = value; }
        public int Ar { get => ar; set => ar = value; }
        public int Garido { get => garido; set => garido = value; }

    }
    public void TermekekBetolteseListaba() { 
    string SQLOsszesTermek = "SELECT * FROM termékek;";
        MySqlCommand SQLparancs = new MySqlCommand(SQLOsszesTermek, SQLkapcsolat);
        MySqlDataReader eredmenyOlvaso = SQLparancs.ExecuteReader();

        while (eredmenyOlvaso.Read())
        {
            Termek uj = new Termek(eredmenyOlvaso.GetString("Kategória"), eredmenyOlvaso.GetString("Gyártó"), eredmenyOlvaso.GetString("Név"), eredmenyOlvaso.GetInt32("Ár"), eredmenyOlvaso.GetInt32("Garidő"));
            termekek.Add(uj);
        }
        eredmenyOlvaso.Close();
        dgTermekek.ItemSource = termekek;
    }
    private void KategoriaBetoltese() {
        string SQLKategoriakRendezve = "SELECT DISTINCT kategória FROM termékek ORDER BY kategória;";
        MySqlCommand SQLparancs = new MySqlCommand(SQLKategoriakRendezve, SQLkapcsolat);
        MySqlDataReader eredmenyOlvaso = SQLparancs.ExecuteReader();
        cbKategoria.Items.Add("- Nincs megadva -");
        while (eredmenyOlvaso.Read()) {
            cbKategoria.Items.Add(eredmenyOlvaso.GetString("kategória"));
        }
        eredmenyOlvaso.Close();
        cbKategoria.SelectedIndex = 0;

    }
    private void GyartokBetoltese() {
        string SQLGyartokRendezve = "SELECT DISTINCT gyártó FROM termékek ORDER BY gyártó;";
        MySqlCommand SQLparancs = new MySqlCommand(SQLKategoriakRendezve, SQLkapcsolat);
        MySqlDataReader eredmenyOlvaso = SQLparancs.ExecuteReader();
    }
}
