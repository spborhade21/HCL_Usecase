using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static IdentityServer4.IdentityServerConstants;

namespace IdentityServer.Controllers
{
    [ApiController]
    [Authorize(LocalApi.PolicyName)]
    public class AdminController : ControllerBase
    {
        //[HttpGet]
        //[Route("admin/v1/user")]
        //public async Task<List<ContractDetails>> Get()
        //{
        //    return await _contractOperationService.GetContractDetails();
        //}
    }
}
