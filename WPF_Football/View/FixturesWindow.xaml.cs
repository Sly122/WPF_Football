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

namespace WPF_Football.View
{
    /// <summary>
    /// Interaction logic for FixturesWindow.xaml
    /// </summary>
    public partial class FixturesUserControl : UserControl
    {
        private FixtureRepository Frepo;
        private List<Fixtures> Flist;
        private Op operation = Op.No;
        enum Op
        {
            Add,
            Upd,
            No
        }
        public FixturesUserControl()
        {
            InitializeComponent();
            Frepo = new FixtureRepository(new DatabaseConnection());
            LoadFixtures();
        }
        
        private void LoadFixtures()
        {
            Flist = Frepo.GetFixture();
            Fixtures_DataGrid.DataContext = Flist;
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            operation = Op.Add;
            if (operation == Op.Add)
            {
                Frepo.InsertFixture(new Fixtures
                {
                    Home_Team = hometeam.Text,
                    Away_Team = awayteam.Text,
                    Result = result.Text
                }
                );
                Frepo.Save();
                LoadFixtures();
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
                Fixtures fix = Frepo.GetFixtureByID(Flist[Fixtures_DataGrid.SelectedIndex].id);
                fix.Home_Team = hometeam.Text;
                fix.Away_Team = awayteam.Text;
                fix.Result = result.Text;
                Frepo.UpdateFixture(fix);
                Frepo.Save();
                LoadFixtures();
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
            Fixtures fix = Frepo.GetFixtureByID(Flist[Fixtures_DataGrid.SelectedIndex].id);
            if (operation == Op.Upd)
            {
                Frepo.DeleteFixture(fix.id);
                Frepo.Save();
                LoadFixtures();
                operation = Op.No;
            }
        }

        private void Fixtures_DataGrid_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (Flist.Count != 0)
            {
                hometeam.Text = Flist[Fixtures_DataGrid.SelectedIndex].Home_Team;
                awayteam.Text = Flist[Fixtures_DataGrid.SelectedIndex].Away_Team;
                result.Text = Flist[Fixtures_DataGrid.SelectedIndex].Result;
                operation = Op.Upd;
                Frepo.Save();
            }
        }
    }

    
}
