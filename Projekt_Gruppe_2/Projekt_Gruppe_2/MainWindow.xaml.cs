using Newtonsoft.Json;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Projekt_Gruppe_2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int fileCounter = 1;
        
        Message message = new Message()
            {
                TimestampUnix = ((DateTimeOffset)DateTime.Now).ToUnixTimeSeconds(),
                Payload = "",
                IPSender = "",
                AliasSender = "",
                DataFormat = "",
                IPEmpfaenger = "",
                Port = 900
            };

        

        public MainWindow()
        {            
            InitializeComponent();            
        }

        private void btnSenden_Click(object sender, RoutedEventArgs e)
        {
            message.Payload = textboxTest.Text;
            string stringjson = JsonConvert.SerializeObject(message);
            ausgabeTest.Text = stringjson;

            using (StreamWriter file = File.CreateText(@"C:\Users\user\Documents\message" + fileCounter + ".txt"))
            {
                string _file = Convert.ToString(file);
                JsonSerializer serializer = new JsonSerializer();
                serializer.Serialize(file, message);
            }
        }

        public static Message messageReader(string path)
        {
            string json = File.ReadAllText(path);
            return JsonConvert.DeserializeObject<Message>(json);
        }

        private void btnLesen_Click(object sender, RoutedEventArgs e)
        {
            string path = @"C:\Users\user\Documents\message" + fileCounter + ".txt";
            Message m = messageReader(path);
            ausgabeTest.Text = m.Payload;
        }
    }
}
