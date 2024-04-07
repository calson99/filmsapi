using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using System.Text.Json;
using System.Net.Http;
using FilmsUi.Models;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace FilmsUi
{
    /// <summary>
    /// An empty window that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class EditWindow : Window
    {
        int id;
        public EditWindow(int Id, string type)
        {
            this.InitializeComponent();
            id = Id;
            LoadDataFromApi(id, type);
        }

        public async void LoadDataFromApi(int id, string type)
        {
            // get Zapdos data form api
            string url = "https://localhost:7275/api/Genres";

            var client = new HttpClient();
            var response = await client.GetAsync(url);
            var content = await response.Content.ReadAsStringAsync();

            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
            };

            var List = JsonSerializer.Deserialize<List<Genres>>(content, options);
            lbGenres.ItemsSource = List;

            if(type == "Film") 
            {
                url = "https://localhost:7275/api/Films";

                client = new HttpClient();
                response = await client.GetAsync(url);
                content = await response.Content.ReadAsStringAsync();

                var FilmsList = JsonSerializer.Deserialize<List<FilmsDto>>(content, options);
                foreach(var Film in FilmsList)
                {
                    if( Film.Id == id)
                    {
                        cmbType.SelectedIndex = 1;
                        txtTitle.Text = Film.Title;
                        txtPlatform.Text = Film.Platform;
                        cmbRating.SelectedIndex = (Film.Rating - 1);
                    }
                }
            }
            else if (type == "Serie")
            {
                url = "https://localhost:7275/api/Series";

                client = new HttpClient();
                response = await client.GetAsync(url);
                content = await response.Content.ReadAsStringAsync();

                var SeriesList = JsonSerializer.Deserialize<List<SeriesDto>>(content, options);
                foreach (var Series in SeriesList)
                {
                    if (Series.Id == id)
                    {
                        cmbType.SelectedIndex = 0;
                        txtTitle.Text = Series.Title;
                        txtPlatform.Text = Series.Platform;
                        cmbRating.SelectedIndex = (Series.Rating - 1);
                    }
                }
            }
        }
        public async void EditButton_Click(object sender, RoutedEventArgs e)
        {
            var client = new HttpClient();
            string type = ((ComboBoxItem)cmbType.SelectedItem).Content.ToString();
            string title = txtTitle.Text;
            string platform = txtPlatform.Text;
            int rating = int.Parse(((ComboBoxItem)cmbRating.SelectedItem).Content.ToString());
            string inputDateString = (dpReleaseDate.SelectedDate).ToString();

            if (type == "Serie")
            {
                var Series = new SeriesDto
                {
                    Id = id,
                    Title = title,
                    Platform = platform,
                    Date = inputDateString,
                    Rating = rating,
                };

                var SeriesJson = JsonSerializer.Serialize(Series);
                var content = new StringContent(SeriesJson, System.Text.Encoding.UTF8, "application/json");
                var response = await client.PutAsync($"https://localhost:7275/api/Series/{id}", content);

                if (!response.IsSuccessStatusCode)
                {
                    var error = await response.Content.ReadAsStringAsync();
                }
            }
            else if (type == "Film")
            {
                var Film = new FilmsDto
                {
                    Id = id,
                    Title = title,
                    Platform = platform,
                    Date = inputDateString,
                    Rating = rating,
                };

                var FilmJson = JsonSerializer.Serialize(Film);
                var content = new StringContent(FilmJson, System.Text.Encoding.UTF8, "application/json");
                var response = await client.PutAsync($"https://localhost:7275/api/Films/{id}", content);

                if (!response.IsSuccessStatusCode)
                {
                    var error = await response.Content.ReadAsStringAsync();
                }
            }
            this.Close();
        }
    }
}
