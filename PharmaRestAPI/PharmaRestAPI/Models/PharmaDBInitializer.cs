using PharmaRestAPI.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PharmaRestAPI.Models
{
    public static class PharmaDBInitializer
    {
        public static void Initialize(PharmaDBContext context)
        {
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            if (context.Contracts.Any())
            {
                return;   // DB has been seeded
            }

            var contracts = new Contract[]
            {
            new Contract{Name="Medicine beta", State = SignState.Primary},
            new Contract{Name="Medicine apha", State = SignState.InterDepartment},
            new Contract{Name="Propritery beta 1", State = SignState.External},
            new Contract{Name="paramount delta 1", State = SignState.Primary},
            new Contract{Name="One lougne", State = SignState.InterDepartment},
            new Contract{Name="care fare ", State = SignState.External},
            new Contract{Name="all tax included", State = SignState.InterDepartment},
            };
            foreach (Contract c in contracts)
            {
                context.Contracts.Add(c);
            }
            context.SaveChanges();

            var users = new User[]
            {
            new User{UserName="hcl1", Email="hcl1.user1@hcl.com"},
            new User{UserName="hcl2", Email="hcl2.user2@hcl.com"},
            new User{UserName="hcl3", Email="hcl3.user3@hcl.com"},
            new User{UserName="hcl4", Email="hcl4.user4@hcl.com"},
            new User{UserName="stake Holder", Email="stake.holder@hcl.com"},
            };
            foreach (User u in users)
            {
                context.Users.Add(u);
            }
            context.SaveChanges();

            var contractUserAllocations = new ContractUserAllocation[]
            {
                new ContractUserAllocation{ContractID = 1, UserID = 1, StateOwned = SignState.Primary },
                new ContractUserAllocation{ContractID = 1, UserID = 2, StateOwned = SignState.InterDepartment },
                new ContractUserAllocation{ContractID = 1, UserID = 5, StateOwned = SignState.External },
                new ContractUserAllocation{ContractID = 3, UserID = 1, StateOwned = SignState.Primary },
                new ContractUserAllocation{ContractID = 3, UserID = 2, StateOwned = SignState.InterDepartment },
                new ContractUserAllocation{ContractID = 2, UserID = 3, StateOwned = SignState.External },
                new ContractUserAllocation{ContractID = 4, UserID = 4, StateOwned = SignState.Primary },
                new ContractUserAllocation{ContractID = 4, UserID = 1, StateOwned = SignState.External },
                new ContractUserAllocation{ContractID = 5, UserID = 3, StateOwned = SignState.Primary },
                new ContractUserAllocation{ContractID = 5, UserID = 4, StateOwned = SignState.InterDepartment },
                new ContractUserAllocation{ContractID = 7, UserID = 4, StateOwned = SignState.Primary },
                new ContractUserAllocation{ContractID = 7, UserID = 2, StateOwned = SignState.InterDepartment },
                new ContractUserAllocation{ContractID = 7, UserID = 3, StateOwned = SignState.External },
                new ContractUserAllocation{ContractID = 6, UserID = 3, StateOwned = SignState.Primary },
                new ContractUserAllocation{ContractID = 6, UserID = 1, StateOwned = SignState.External },
            };
            foreach (ContractUserAllocation cua in contractUserAllocations)
            {
                context.ContractUserAllocations.Add(cua);
            }
            context.SaveChanges();
        }
    }
}
