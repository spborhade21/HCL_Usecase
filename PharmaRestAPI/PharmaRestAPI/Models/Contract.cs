using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PharmaRestAPI.Models
{
    public enum SignState
    {
        Primary,
        InterDepartment,
        External
    }
    public class Contract
    {
        public long ContractID { get; set; }
        public string Name { get; set; }
        public SignState State { get; set; }

        public ICollection<User> Users { get; set; }

    }
}
