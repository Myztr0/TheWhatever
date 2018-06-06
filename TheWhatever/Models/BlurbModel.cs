using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace TheWhatever.Models
{
    public class BlurbModel
    {

        [Key]
        public int ID { get; set; }
        public string OwnerID { get; set; }
        public string text { get; set; }


    }
}
