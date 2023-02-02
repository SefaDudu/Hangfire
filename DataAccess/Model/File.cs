using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Model
{
    public class File
    {
        [Key]
        public long Id { get; set; }
        public string FileName { get; set; }
        public DateTime Date { get; set; }
        public bool Check { get; set; }
    }
}
