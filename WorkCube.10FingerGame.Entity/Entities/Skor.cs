using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkCube._10FingerGame.Entity.Entities
{
    [Table("Skors")]
    public class Skor
    {
        [Key]
        public int ID { get; set; } //her skorun 1 ıd si var.
        public int DBV { get; set; } //dakika başına vuruş
        public int DBK { get; set; } //dakika başına kelime
        public int Toplam { get; set; }
        public int Dogru { get; set; }
        public int Yanlis { get; set; }

        public int UserID { get; set; } //  1 skorun 1 kullanıcısı olabilir, 1 e 1 ilişiki.

        [ForeignKey("UserID")]
        public User User { get; set; }
    }
}
