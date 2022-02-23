using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ReadJSON
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window ,INotifyPropertyChanged

    {

        private WebRequest httpRequest;
        private List<cStation> _stations = new List<cStation>();

        public event PropertyChangedEventHandler PropertyChanged;

        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
            getWeatherData();
            cmbStation.SelectionChanged += CmbStation_SelectionChanged;
        }

        private void CmbStation_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SelectedStation  = (cStation)cmbStation.SelectedItem;
            NotifyPropertyChanged("SelectedStation");
        }

        public void getWeatherData()
        {
            string url = Properties.Settings.Default.URI; 
            httpRequest = WebRequest.Create(url);
            httpRequest.BeginGetResponse(new AsyncCallback(FinishWebRequest), null);
        }

        private void FinishWebRequest(IAsyncResult ar)
        {
            WebResponse resp = httpRequest.EndGetResponse(ar);
            string r = null;
            using (StreamReader str = new StreamReader(resp.GetResponseStream()))
            {
                r = str.ReadToEnd();
                JObject o = JObject.Parse(r);
                JToken JSONStations = o.SelectToken("actual.stationmeasurements");
                foreach(JToken item in JSONStations)
                {
                    Debug.WriteLine(item);
                    cStation station = JsonConvert.DeserializeObject<cStation>(item.ToString());
                    _stations.Add(station);
                   
                }

            }

        }

        public List<cStation> stations
        {
            get
            {
                return _stations;
            }
            set
            {
                _stations = value;
            }
        }

        public cStation SelectedStation { get; set; }


        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
