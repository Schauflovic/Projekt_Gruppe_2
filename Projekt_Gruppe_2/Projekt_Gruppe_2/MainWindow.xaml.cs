using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
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

namespace Projekt_Gruppe_2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        int test;
        int test1;
        int testGina;
        int Michiii;


        SqlConnection con = new SqlConnection();
        SqlCommand com = new SqlCommand();
        SqlDataReader dr;
        public MainWindow()
        {
            InitializeComponent();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString.ToString();
            DatenbankRead();
            DatenbankRead_Entschluesseln();
        }
        private void DatenbankRead()
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SELECT TimestampUnix from Messages ";
            cmd.Connection = con;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable("Messages");

            da.Fill(dt);
            g1.ItemsSource = dt.DefaultView;
            con.Close();
        }

        private void DatenbankRead_Entschluesseln()
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "Select TimestampUnix, Cast (Payload as varchar(max))from Messages ";
            cmd.Connection = con;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable("Messages2");

            da.Fill(dt);
            g1.ItemsSource = dt.DefaultView;
            con.Close();
        }
        /*   private void DatenbankWrite() tee
           {
               SqlConnection con = new SqlConnection();
               con.ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
               con.Open();
               SqlCommand cmd = new SqlCommand();
               cmd.CommandText = "INSERT INTO [Speiseplan] (Datum, Name_Essen_VK, Name_Essen_VG) Values(@dt, @vk, @vg)";
               cmd.Parameters.AddWithValue("@dt", AddDatum.Text);
               cmd.Parameters.AddWithValue("@vk", AddM1.Text);
               cmd.Parameters.AddWithValue("@vg", AddM2.Text);
               cmd.Connection = con;
               int a = cmd.ExecuteNonQuery();
               if (a == 1)
               {
                   MessageBox.Show("Daten erfolgreich hinzugefügt");
                   binddatagrid();
               }
               con.Close();
           }*/

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}