using Projeto_POO.Scripts;
using Projeto_POO.Scripts.Plataform;
using System.Collections.ObjectModel;
using System.Net.NetworkInformation;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using static System.Net.WebRequestMethods;

namespace Projeto_POO
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ObservableCollection<Game> Games { get; set; } = new ObservableCollection<Game>();

        private List<Game> AllGames = new();

        private bool ShowingFavorites = false;

        public MainWindow()
        {
            InitializeComponent();


            Games = GameRepository.Get();
            Games = new ObservableCollection<Game>(Games.OrderByDescending(x => x.Installed).ToList());
            AllGames = Games.ToList();

            LoadFavorites();
            DataContext = this;
        }
        private void PlayGame_Click(object sender, RoutedEventArgs e)
        {
            if (sender is FrameworkElement element &&
                element.DataContext is Game game)
            {
                game.PlayCount++;
                game.Run();
                RefreshUI();
            }
        }
        private void InstallGame_Click(object sender, RoutedEventArgs e)
        {
            if (sender is FrameworkElement element &&
                element.DataContext is Game game)
            {
                game.Install();

                MessageBox.Show($"{game.Name} foi instalado.");

                RefreshUI();
            }
        }
        private void UninstallGame_Click(object sender, RoutedEventArgs e)
        {
            if (sender is FrameworkElement element &&
                element.DataContext is Game game)
            {
                game.Uninstall();

                MessageBox.Show($"{game.Name} foi desinstalado.");

                RefreshUI();
            }
        }
        private void SearchBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            string search = SearchBox.Text.ToLower();

            Games.Clear();

            foreach (Game game in AllGames)
            {
                if (game.Name.ToLower().Contains(search))
                {
                    Games.Add(game);
                }
            }
        }
        private void RefreshUI()
        {
            GameList.Items.Refresh();
        }
        private void Favorite_Click(object sender, RoutedEventArgs e)
        {
            if (sender is FrameworkElement element &&
                element.DataContext is Game game)
            {
                game.Favorite = !game.Favorite;

                SaveFavorites();

                RefreshUI();
            }
        }
        private void Star_Click(object sender, RoutedEventArgs e)
        {
            if (sender is FrameworkElement element &&
                element.DataContext is Game game &&
                int.TryParse(element.Tag?.ToString(), out int rating))
            {
                game.Rating = rating;
                RefreshUI();
            }
        }
        private void AllGames_Click(object sender, RoutedEventArgs e)
        {
            Games.Clear();

            foreach (Game game in AllGames)
            {
                Games.Add(game);
            }

            RefreshUI();
        }
        private void Favorites_Click(object sender, RoutedEventArgs e)
        {
            Games.Clear();

            foreach (Game game in AllGames)
            {
                if (game.Favorite)
                {
                    Games.Add(game);
                }
            }

            RefreshUI();
        }
        private void SortRating_Click(object sender, RoutedEventArgs e)
        {
            var sortedList = Games.OrderByDescending(x => x.Rating).ToList();
            Games.Clear();
            foreach (var game in sortedList)
            {
                Games.Add(game);
            }
            RefreshUI();
        }
        private void SortMostPlayed_Click(object sender, RoutedEventArgs e)
        {
            var sortedList = Games.OrderByDescending(x => x.PlayCount).ToList();
            Games.Clear();
            foreach (var game in sortedList)
            {
                Games.Add(game);
            }
            RefreshUI();
        }
        private void SaveFavorites()
        {
            //Monte uma estrutura aplicando conceitos em JSON para salvar a lista de favoritos
        }
        private void LoadFavorites()
        {
            //Carregue o arquivo gerado para ler todos os favoritos salvos.
        }
    }
}