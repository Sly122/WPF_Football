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
using WPF_Football.Repository;
using WPF_Football.Database;
using WPF_Football.Model;


namespace WPF_Football.View
{
    /// <summary>
    /// Interaction logic for TeamsWindow.xaml
    /// </summary>

    public partial class TeamsUserControl : UserControl
    {
        private TeamRepository Trepo;
        private List<Teams> Tlist;
        private Op operation = Op.No;
        enum Op
        {
            Add,
            Upd,
            No
        }
        public TeamsUserControl()
        {
            InitializeComponent();
            Trepo = new TeamRepository(new DatabaseConnection());
            LoadTeams();
        }

        private void LoadTeams()
        {
            Tlist = Trepo.GetTeam();
            Teams_DataGrid.DataContext = Tlist;
        }

        

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            operation = Op.Add;
            if (operation == Op.Add)
            {
                Trepo.InsertTeam(new Teams
                {
                    Name = name.Text,
                    Stadium = stadium.Text,
                    Coach = coach.Text
                }
                );
                Trepo.Save();
                LoadTeams();
            }
            else
            {
                MessageBox.Show("Sikertelen mentes!");
            }
            
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            operation = Op.Upd;
            if (operation == Op.Upd)
            {
                Teams team = Trepo.GetTeamByID(Tlist[Teams_DataGrid.SelectedIndex].id);
                team.Name = name.Text;
                team.Stadium = stadium.Text;
                team.Coach = coach.Text;
                Trepo.UpdateTeam(team);
                Trepo.Save();
                LoadTeams();
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
            Teams team = Trepo.GetTeamByID(Tlist[Teams_DataGrid.SelectedIndex].id);
            if (operation == Op.Upd)
            {
                Trepo.DeleteTeam(team.id);
                Trepo.Save();
                LoadTeams();
                operation = Op.No;
            }
        }

        private void Teams_DataGrid_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (Tlist.Count != 0)
            {
                name.Text = Tlist[Teams_DataGrid.SelectedIndex].Name;
                stadium.Text = Tlist[Teams_DataGrid.SelectedIndex].Stadium;
                coach.Text = Tlist[Teams_DataGrid.SelectedIndex].Coach;
                operation = Op.Upd;
                Trepo.Save();
            }
        }
    }


}
