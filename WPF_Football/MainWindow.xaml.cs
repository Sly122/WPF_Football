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
using WPF_Football.Database;
using WPF_Football.Database;
using WPF_Football.Model;
using WPF_Football.View;

namespace WPF_Football
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private FixturesUserControl FControl;
        private PlayersUserControl PControl;
        private TeamsUserControl TControl;
        

        public MainWindow()
        {
            InitializeComponent();
            CheckDataBaseConnection();
            InitializeUserControls();
            
        }
        
        private void InitializeUserControls()
        {
            FControl = new FixturesUserControl();
            PControl = new PlayersUserControl();
            TControl = new TeamsUserControl();
        }

        private void BtnFixtures_Click(object sender, RoutedEventArgs e)
        {
            MainContent.Content = FControl;
        }

        private void BtnPlayers_Click(object sender, RoutedEventArgs e)
        {
            MainContent.Content = PControl;
        }

        private void BtnTeams_Click(object sender, RoutedEventArgs e)
        {
            MainContent.Content = TControl;
        }

        private void CheckDataBaseConnection()
        {
            try
            {
                DatabaseConnection db = new DatabaseConnection();
                if (!db.Database.CanConnect())
                {
                    MessageBox.Show("Database connection failed!");
                    Environment.Exit(1);
                }
            }
            catch
            {
                MessageBox.Show("Database connection failed!");
                Environment.Exit(1);
            }
        }

        private void BtnExit_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(1);
        }
    }
}