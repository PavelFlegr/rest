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
using System.IO;
using RestSharp;

namespace server
{
    /// <summary>
    /// Interakční logika pro MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Download(object sender, RoutedEventArgs e)
        {
            var client = new RestClient("https://jsonplaceholder.typicode.com");
            var request = new RestRequest("/posts", Method.GET);
            var response = new Dictionary<string, object> {
                { "posts", client.Execute<List<Post>>(request).Data },
                { "time", DateTime.Now.ToString() }
            };
            File.WriteAllText("data.txt", SimpleJson.SerializeObject(response));
            MessageBox.Show("saved");
        }
    }
}
