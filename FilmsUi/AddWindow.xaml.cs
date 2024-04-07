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
using Windows.Gaming.Input;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace FilmsUi
{
    /// <summary>
    /// An empty window that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class AddWindow : Window
    {
        public AddWindow()
        {
            this.InitializeComponent();
            LoadDataFromApi();
        }

        public async void LoadDataFromApi()
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

            var FilmsList = JsonSerializer.Deserialize<List<Genres>>(content, options);
            lbGenres.ItemsSource = FilmsList;
        }

        public async void AddButton_Click(object sender, RoutedEventArgs e)
        {
            var client = new HttpClient();
            string type = ((ComboBoxItem)cmbType.SelectedItem).Content.ToString();
            string title = txtTitle.Text;
            string platform = txtPlatform.Text;
            int rating = int.Parse(((ComboBoxItem)cmbRating.SelectedItem).Content.ToString());
            string inputDateString = (dpReleaseDate.SelectedDate).ToString();
            int id = 0;

            if (type == "Serie")
            {
                var Serie = new SeriesDto
                {
                    Title = title,
                    Platform = platform,
                    Date = inputDateString,
                    Rating = rating,
                };

                var SerieJson = JsonSerializer.Serialize(Serie);
                var content = new StringContent(SerieJson, System.Text.Encoding.UTF8, "application/json");
                var response = await client.PostAsync($"https://localhost:7275/api/Series", content);

                if(!response.IsSuccessStatusCode)
                {
                    var error = await response.Content.ReadAsStringAsync();
                }

                string url = "https://localhost:7275/api/Series";
                var responseSeries = await client.GetAsync(url);
                var contentSeries = await responseSeries.Content.ReadAsStringAsync();

                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true,
                };

                var SeriesList = JsonSerializer.Deserialize<List<Series>>(contentSeries, options);
                
                foreach (var Series in SeriesList)
                {
                    if(Series.Title == title)
                    {
                        id = Series.Id;
                    }
                }

                foreach (Genres item in lbGenres.SelectedItems)
                {
                    var GenresSeries = new GenresSeries
                    {
                        SeriesId = id,
                        GenresId = item.Id
                    };
                    var GenreSeriesJson = JsonSerializer.Serialize(GenresSeries);
                    var contentGenreSeries = new StringContent(GenreSeriesJson, System.Text.Encoding.UTF8, "application/json");
                    var responseGenreSeries = await client.PostAsync($"https://localhost:7275/api/GenresSeries", contentGenreSeries);
                }
            }
            else if (type == "Film"){
                var Film = new FilmsDto
                {
                    Title = title,
                    Platform = platform,
                    Date = inputDateString,
                    Rating = rating,
                };

                var FilmJson = JsonSerializer.Serialize(Film);
                var content = new StringContent(FilmJson, System.Text.Encoding.UTF8, "application/json");
                var response = await client.PostAsync($"https://localhost:7275/api/Films", content);

                if (!response.IsSuccessStatusCode)
                {
                    var error = await response.Content.ReadAsStringAsync();
                }

                string url = "https://localhost:7275/api/Films";
                var responseFilms = await client.GetAsync(url);
                var contentFilms = await responseFilms.Content.ReadAsStringAsync();

                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true,
                };

                var FilmsList = JsonSerializer.Deserialize<List<Series>>(contentFilms, options);

                foreach (var Films in FilmsList)
                {
                    if (Films.Title == title)
                    {
                        id = Films.Id;
                    }
                }

                foreach (Genres item in lbGenres.SelectedItems)
                {
                    var FilmsGenres = new FilmsGenres
                    {
                        FilmsId = id,
                        GenresId = item.Id
                    };
                    var GenreSeriesJson = JsonSerializer.Serialize(FilmsGenres);
                    var contentGenreSeries = new StringContent(GenreSeriesJson, System.Text.Encoding.UTF8, "application/json");
                    var responseGenreSeries = await client.PostAsync($"https://localhost:7275/api/FilmsGenres", contentGenreSeries);
                }
            }
            this.Close();
        }
    }
}
