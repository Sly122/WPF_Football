using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF_Football.Database;
using WPF_Football.Model;
using WPF_Football.View;

namespace WPF_Football.Repository
{
    internal class TeamRepository
    {
        private DatabaseConnection db;

        public TeamRepository(DatabaseConnection team)
        {
            this.db = team;
        }

        public List<Teams> GetTeam()
        {
            return db.Teams.ToList();
        }

        public Teams GetTeamByID(int id)
        {
            return db.Teams.Find(id);
        }

        public void InsertTeam(Teams team)
        {
            db.Teams.Add(team);
        }

        public void DeleteTeam(int id)
        {
            Teams team = db.Teams.Find(id);
            db.Teams.Remove(team);
        }

        public void UpdateTeam(Teams team)
        {
            db.Teams.Find(team.id).Name = team.Name;
            db.Teams.Find(team.id).Stadium = team.Stadium;
            db.Teams.Find(team.id).Coach = team.Coach;


        }

        public void Save()
        {
            db.SaveChanges();
        }

        public void Dispose()
        {
            db.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}

