using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF_Football.Database;
using WPF_Football.Model;

namespace WPF_Football.Repository
{
    internal class PlayerRepository
    {
        private DatabaseConnection db;

        public PlayerRepository(DatabaseConnection player)
        {
            this.db = player;
        }

        public List<Players> GetPlayer()
        {
            return db.Players.ToList();
        }

        public Players GetPlayerByID(int id)
        {
            return db.Players.Find(id);
        }

        public void InsertPlayer(Players player)
        {
            db.Players.Add(player);
        }

        public void DeletePlayer(int id)
        {
            Players player = db.Players.Find(id);
            db.Players.Remove(player);
        }

        public void UpdatePlayer(Players player)
        {
            db.Players.Find(player.id).Firstname = player.Firstname;
            db.Players.Find(player.id).Lastname = player.Lastname;
            db.Players.Find(player.id).Team = player.Team;
            db.Players.Find(player.id).Age = player.Age;
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

