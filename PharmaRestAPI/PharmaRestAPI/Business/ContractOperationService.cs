using Microsoft.EntityFrameworkCore;
using PharmaRestAPI.DataAccess;
using PharmaRestAPI.DataTransferModels;
using PharmaRestAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PharmaRestAPI.Business
{
    public class ContractOperationService : IContractOperationService
    {
        PharmaDBContext _pharmaDBContext;
        public ContractOperationService(PharmaDBContext pharmaDBContext)
        {
            _pharmaDBContext = pharmaDBContext;
        }

        public async Task<List<ContractDetails>> GetContractDetails()
        {
            var data = await _pharmaDBContext.Contracts.Join(_pharmaDBContext.ContractUserAllocations,
                                                       contract => contract.ContractID,
                                                       contractUser => contractUser.ContractID,
                                                       (contract, contractUser) => new { contract, contractUser })
                                                 .Join(_pharmaDBContext.Users,
                                                       join1 => join1.contractUser.UserID,
                                                       user => user.UserID,
                                                       (join1, user) => new
                                                       {
                                                           join1.contract.ContractID,
                                                           join1.contract.Name,
                                                           join1.contract.State,
                                                           user.UserID,
                                                           user.UserName,
                                                           join1.contractUser.StateOwned
                                                       }).ToListAsync();

            var finalResult = data.GroupBy(g => g.ContractID, (key, group) =>
                new ContractDetails
                {
                    Name = group.ElementAtOrDefault(0).Name,
                    ContractID = group.ElementAtOrDefault(0).ContractID,
                    CurrentState = group.ElementAtOrDefault(0).State,
                    UserDetails = group.Select(g => new UserDetails { UserID = g.UserID, UserName = g.UserName, UserOwnedState = g.StateOwned }).ToArray()
                }
            ).ToList();

            return finalResult;
        }

        public async Task<ContractDetails> CreateOrUpdateContractDetail(ContractDetails contractDetail)
        {
            try
            {
                Contract contract = null;
                if (contractDetail.ContractID > 0)
                {
                    contract = await _pharmaDBContext.Contracts.FindAsync(contractDetail.ContractID);
                    contract.Name = contractDetail.Name;
                    contract.State = contractDetail.CurrentState;
                    _pharmaDBContext.Contracts.Update(contract);
                    await _pharmaDBContext.SaveChangesAsync();
                    return contractDetail;
                }
                contract = new Contract { Name = contractDetail.Name, State = contractDetail.CurrentState };
                await _pharmaDBContext.Contracts.AddAsync(contract);
                await _pharmaDBContext.SaveChangesAsync();
                contractDetail.ContractID = contract.ContractID;
                return contractDetail;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }

        public async Task<ContractDetails> CreateOrUpdateContractUserAssociation(ContractDetails contractDetail)
        {
            try
            {
                await _pharmaDBContext.ContractUserAllocations.AddAsync(new Models.ContractUserAllocation 
                { 
                    ContractID = contractDetail.ContractID, 
                    UserID = contractDetail.UserDetails[0].UserID,
                    StateOwned = contractDetail.UserDetails[0].UserOwnedState
                });
                await _pharmaDBContext.SaveChangesAsync();
                return contractDetail;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }

        public async Task<bool> DeleteContractDetail(int id)
        {
            try
            {
                var record = await _pharmaDBContext.Contracts.Where(x=> x.ContractID == id).FirstOrDefaultAsync();
                 _pharmaDBContext.Contracts.Remove(record);

                var contractUserAssociations = await _pharmaDBContext.ContractUserAllocations.Where(x => x.ContractID == id).ToListAsync();
                _pharmaDBContext.ContractUserAllocations.RemoveRange(contractUserAssociations);
                await _pharmaDBContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
            return true;
        }

        public async Task<bool> DeleteContractUserAssociation(int id)
        {
            try
            {
                var record = await _pharmaDBContext.ContractUserAllocations.Where(x => x.UserID == id).FirstOrDefaultAsync();
                _pharmaDBContext.ContractUserAllocations.Remove(record);
                await _pharmaDBContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
            return true;
        }
    }
}
