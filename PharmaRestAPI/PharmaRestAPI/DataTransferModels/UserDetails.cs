using PharmaRestAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PharmaRestAPI.DataTransferModels
{
    public class UserDetails
    {
        public long UserID { get; set; }
        public string UserName { get; set; }
        public SignState UserOwnedState { get; set; }
    }
}
