using FilmsUi.Models;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text.Json;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Foundation.Metadata;
using Windows.Media.Protection.PlayReady;
using Windows.System;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace FilmsUi
{
    /// <summary>
    /// An empty window that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class SeriesWindow : Window
    {
        public SeriesWindow()
        {
            this.InitializeComponent();
            LoadDataFromApi();
        }

        public async void LoadDataFromApi()
        {
            // get Zapdos data form api
            string url = "https://localhost:7275/api/Series";

            var client = new HttpClient();
            var response = await client.GetAsync(url);
            var content = await response.Content.ReadAsStringAsync();

            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
            };

            var SeriesList = JsonSerializer.Deserialize<List<SeriesDto>>(content, options);
            SeriesListView.ItemsSource = SeriesList;

        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private async void NameButton_Click(object sender, RoutedEventArgs e)
        {
            string url = "https://localhost:7275/api/Series";

            var client = new HttpClient();
            var response = await client.GetAsync(url);
            var content = await response.Content.ReadAsStringAsync();

            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
            };

            var SeriesList = JsonSerializer.Deserialize<List<Series>>(content, options);
            var Ordered = SeriesList.OrderBy(f => f.Title);
            SeriesListView.ItemsSource = Ordered;
        }

        private async void DateButton_Click(object sender, RoutedEventArgs e)
        {
            string url = "https://localhost:7275/api/Series";

            var client = new HttpClient();
            var response = await client.GetAsync(url);
            var content = await response.Content.ReadAsStringAsync();

            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
            };

            var SeriesList = JsonSerializer.Deserialize<List<Series>>(content, options);
            var Ordered = SeriesList.OrderBy(f => f.Date);
            SeriesListView.ItemsSource = Ordered;
        }

        private async void RatingButton_Click(object sender, RoutedEventArgs e)
        {
            string url = "https://localhost:7275/api/Series";

            var client = new HttpClient();
            var response = await client.GetAsync(url);
            var content = await response.Content.ReadAsStringAsync();

            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
            };

            var SeriesList = JsonSerializer.Deserialize<List<Series>>(content, options);
            var Ordered = SeriesList.OrderByDescending(f => f.Rating);
            SeriesListView.ItemsSource = Ordered;
        }

        private async void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            Button deleteButton = (Button)sender; // Cast sender object to Button
            var tag = deleteButton.Tag;
            int id = (int)tag;

            string url = "https://localhost:7275/api/Series";

            var client = new HttpClient();
            var response = await client.GetAsync(url);
            var content = await response.Content.ReadAsStringAsync();

            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
            };

            var SeriesList = JsonSerializer.Deserialize<List<SeriesDto>>(content, options);

            foreach(var serie in SeriesList)
            {
                if(serie.Id == id)
                {
                    var responseSerie = await client.DeleteAsync($"https://localhost:7275/api/Series/{serie.Id}");
                    if (!responseSerie.IsSuccessStatusCode)
                    {
                        var error = await response.Content.ReadAsStringAsync();
                    }
                }
            }

            LoadDataFromApi();
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            Button deleteButton = (Button)sender; // Cast sender object to Button
            var tag = deleteButton.Tag;
            int id = (int)tag;
            EditWindow EditWindow = new EditWindow(id, "Serie");
            EditWindow.Activate();
        }
    }
}
