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
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace FilmsUi
{
    /// <summary>
    /// An empty window that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainWindow : Window
    {
        public MainWindow()
        {
            this.InitializeComponent();
        }

        private void FilmsButton_Click(object sender, RoutedEventArgs e)
        {
            /*var selectedItem = (Game)e.ClickedItem;*/
            /*int geselecteerdeBewonerId = selectedItem.Id;*/
            FilmsWindow FilmsWindow = new FilmsWindow();
            FilmsWindow.Activate();
        }
        private void SeriesButton_Click(object sender, RoutedEventArgs e)
        {
            SeriesWindow SeriesWindow = new SeriesWindow();
            SeriesWindow.Activate();
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            AddWindow AddWindow = new AddWindow();
            AddWindow.Activate();
        }
    }
}
