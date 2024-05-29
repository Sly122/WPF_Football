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
using System.Windows.Shapes;
using System.Windows.Controls;
using WPF_Football.Repository;
using WPF_Football.Database;
using WPF_Football.Model;
using Org.BouncyCastle.Crypto.Macs;
using System.Xml.Linq;
namespace WPF_Football.View
{
    /// <summary>
    /// Interaction logic for PlayersWindow.xaml
    /// </summary>
    public partial class PlayersUserControl : UserControl
    {
        private PlayerRepository Prepo;
        private List<Players> Plist;
        private Op operation = Op.No;
        enum Op
        {
            Add,
            Upd,
            No
        }
        public PlayersUserControl()
        {
            InitializeComponent();
            Prepo = new PlayerRepository(new DatabaseConnection());
            LoadPlayers();
        }
        
        private void LoadPlayers()
        {
            Plist = Prepo.GetPlayer();
            Players_DataGrid.DataContext = Plist;
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            operation = Op.Add;
            if (operation == Op.Add)
            {
                Prepo.InsertPlayer(new Players
                {
                    Firstname = firstname.Text,
                    Lastname = lastname.Text,
                    Age = int.Parse(age.Text),
                    Team = team.Text
                }
                );
                
                Prepo.Save();
                LoadPlayers();
            }
            else
            {
                MessageBox.Show("Sikertelen hozzaadas!");
            }
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            operation = Op.Upd;
            if (operation == Op.Upd)
            {
                Players player = Prepo.GetPlayerByID(Plist[Players_DataGrid.SelectedIndex].id);
                player.Firstname = firstname.Text;
                player.Lastname = lastname.Text;
                player.Age = int.Parse(age.Text);
                player.Team = team.Text;
                Prepo.UpdatePlayer(player);
                Prepo.Save();
                LoadPlayers();
                operation = Op.No;
            }
            else
            {
                MessageBox.Show("Sikertelen update!");
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            operation = Op.Upd;
            Players player = Prepo.GetPlayerByID(Plist[Players_DataGrid.SelectedIndex].id);
            if (operation == Op.Upd)
            {
                Prepo.DeletePlayer(player.id);
                Prepo.Save();
                LoadPlayers();
                operation = Op.No;
            }
        }

        private void Players_DataGrid_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (Plist.Count != 0)
            {
                firstname.Text = Plist[Players_DataGrid.SelectedIndex].Firstname;
                lastname.Text = Plist[Players_DataGrid.SelectedIndex].Lastname;
                age.Text = Plist[Players_DataGrid.SelectedIndex].Age.ToString();
                team.Text = Plist[Players_DataGrid.SelectedIndex].Team;
                operation = Op.Upd;
                Prepo.Save();
            }
        }
    }
}
