using PharmaRestAPI.DataTransferModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PharmaRestAPI.Business
{
    public interface IContractOperationService
    {
        Task<List<ContractDetails>> GetContractDetails();

        Task<ContractDetails> CreateOrUpdateContractDetail(ContractDetails contractDetail);

        Task<ContractDetails> CreateOrUpdateContractUserAssociation(ContractDetails contractDetail);

        Task<bool> DeleteContractDetail(int id);

        Task<bool> DeleteContractUserAssociation(int id);
    }
}
