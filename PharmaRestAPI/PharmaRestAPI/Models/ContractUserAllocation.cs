using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PharmaRestAPI.Models
{
    public class ContractUserAllocation
    {
        public long ContractUserAllocationID { get; set; }
        public long ContractID { get; set; }
        public long UserID { get; set; }
        public SignState StateOwned { get; set; }
    }
}
