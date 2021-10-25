using PharmaRestAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PharmaRestAPI.DataTransferModels
{
    public class ContractDetails
    {
        public long ContractID { get; set; }
        public string Name { get; set; }
        public SignState CurrentState { get; set; }
        public UserDetails[] UserDetails { get; set; }
    }
}
