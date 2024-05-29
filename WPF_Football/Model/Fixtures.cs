using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_Football.Model
{
    [Table("fixtures")]
    class Fixtures
    {
        [Key]
        [Column("id")]
        public int id { get; set; }
        [Column("home_team")]
        public string Home_Team { get; set; }
        [Column("away_team")]
        public string Away_Team { get; set; }
        [Column("result")]
        public string Result { get; set; }
    }
}
