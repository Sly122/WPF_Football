using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_Football.Model
{
    [Table("players")]
    class Players
    {
        [Key]
        [Column("id")]
        public int id { get; set; }
        [Column("firstname")]
        public string Firstname { get; set; }
        [Column("lastname")]
        public string Lastname { get; set; }
        
        [Column("age")]
        public int Age { get; set; }

        [Column("team")]
        public string Team { get; set; }
    }
}
