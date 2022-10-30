using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
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

namespace Workshop8_Client
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        private FolderEvent actualFolder;
        TokenModel tokenModel;
        public ObservableCollection<FolderEvent> FolderEvents { get; set; }
        UserInfo UserInfo { get; set; }

        HttpClient client;
        HubConnection conn;

        public MainWindow(TokenModel token)
        {
            InitializeComponent();

            this.tokenModel = token;

            client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:44349");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
              new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Authorization =
                new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token.Token);

            Task.Run(async () =>
            {
                FolderEvents = new ObservableCollection<FolderEvent>(await GetFolders());
                ;
                //UserInfo = await GetUserInfos();
            }).Wait();

            conn = new HubConnectionBuilder().WithUrl("https://localhost:44349/events").Build();
            conn.Closed += async (error) =>
            {
                await Task.Delay(new Random().Next(0, 5) * 1000);
                await conn.StartAsync();
            };
            conn.On<FolderEvent>("folderEventCreated", async t => await Refresh());

            Task.Run(async () =>
            {
                await conn.StartAsync();
            }).Wait();

            this.DataContext = this;
        }
        async Task Refresh()
        {
            FolderEvents = new ObservableCollection<FolderEvent>(await GetFolders());
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("FolderEvents"));
        }

        async Task<IEnumerable<FolderEvent>> GetFolders()
        {
            var response = await client.GetAsync("/folderEvent");
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsAsync<IEnumerable<FolderEvent>>();
            }
            throw new Exception("something wrong...");
        }


        async Task<UserInfo> GetUserInfos()
        {
            var response = await client.GetAsync("/Auth");
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsAsync<UserInfo>();
            }
            throw new Exception("something wrong...");
        }

        private async void Create(object sender, RoutedEventArgs e)
        {
            this.actualFolder.Id = "";
            var response = await client.PostAsJsonAsync("/folderEvent/folderEventCreated", this.actualFolder);
            if (response.StatusCode == System.Net.HttpStatusCode.BadRequest)
            {
                var error = await response.Content.ReadAsAsync<ErrorModel>();
                MessageBox.Show(error.Message + " at: " + error.Date.ToShortTimeString(), "Error",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                //await Refresh();
            }

        }
    }

    public class UserInfo
    {
        public string Email { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhotoContentType { get; set; }
        public byte[] PhotoData { get; set; }
        public List<string> Roles { get; set; }

    }
}
