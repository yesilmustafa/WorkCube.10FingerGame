using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkCube._10FingerGame.Entity.Entities
{
    [Table("Users")]
    public class User
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public List<Skor> Skors { get; set; } = new List<Skor>(); //1 kullanıcının 1den fazla skoru olabilir. 1 e çok ilişki.
    }
}
