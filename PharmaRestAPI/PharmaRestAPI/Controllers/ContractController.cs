using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PharmaRestAPI.Business;
using PharmaRestAPI.DataTransferModels;

namespace PharmaRestAPI.Controllers
{
    [ApiController]
    [Authorize]
    public class ContractController : ControllerBase
    {
        private readonly IContractOperationService _contractOperationService;

        public ContractController(IContractOperationService contractOperationService)
        {
            _contractOperationService = contractOperationService;
        }

        [HttpGet]
        [Route("/v1/Contracts")]
        public async Task<List<ContractDetails>> Get()
        {
            return await _contractOperationService.GetContractDetails();
        }

        [HttpPost]
        [Route("/v1/Contracts")]
        public async Task<ContractDetails> Post([FromBody] ContractDetails contract)
        {
            return await _contractOperationService.CreateOrUpdateContractDetail(contract);
        }

        [HttpDelete]
        [Route("/v1/Contracts/{id}")]
        public async Task<bool> Delete(int id)
        {
            return await _contractOperationService.DeleteContractDetail(id);
        }
    }
}
