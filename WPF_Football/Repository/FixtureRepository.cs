using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF_Football.Model;
using WPF_Football.Database;

namespace WPF_Football.Repository
{
    internal class FixtureRepository
    {
        private DatabaseConnection db;

        public FixtureRepository(DatabaseConnection fix)
        {
            this.db = fix;
        }

        public List<Fixtures> GetFixture()
        {
            return db.Fixtures.ToList();
        }

        public Fixtures GetFixtureByID(int id)
        {
            return db.Fixtures.Find(id);
        }

        public void InsertFixture(Fixtures fix)
        {
            db.Fixtures.Add(fix);
        }

        public void DeleteFixture(int id)
        {
            Fixtures fix = db.Fixtures.Find(id);
            db.Fixtures.Remove(fix);
        }

        public void UpdateFixture(Fixtures fix)
        {
            db.Fixtures.Find(fix.id).Home_Team = fix.Home_Team;
            db.Fixtures.Find(fix.id).Away_Team = fix.Away_Team;
            db.Fixtures.Find(fix.id).Result = fix.Result;
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
