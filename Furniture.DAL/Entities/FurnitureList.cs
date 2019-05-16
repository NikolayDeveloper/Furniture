using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Furniture.DAL
{
    [Table("FurnitureList")]
    public class FurnitureList
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        
        public byte[] Photo { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [MaxLength(100)]
        public string Material { get; set; }

        [MaxLength(100)]
        public string Characteristic { get; set; }

        [Required]
        public bool IsExist { get; set; }

        [Required]
        public int Price { get; set; }

        [Index("EX_IdStuff", IsClustered = false)]
        public int IdStuff { get; set; }
        [ForeignKey("IdStuff")]
        public Stuff Stuff { get; set; }
    }
}
