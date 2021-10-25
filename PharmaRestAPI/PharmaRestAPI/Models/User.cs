using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PharmaRestAPI.Models
{
    public class User
    {
        public long UserID { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }

        public Contract Contract { get; set; }
    }
}
