using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace WPF_Football.Model
{
    [Table("teams")]
    class Teams
    {
        [Column("id")]
        public int id { get; set; }
        [Column("name")]
        public string Name { get; set; }
        [Column("stadium")]
        public string Stadium{ get; set; }
        
        [Column("coach")]
        public string Coach { get; set; }

    }
}
