using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealStateWebAPI.Services;

namespace RealStateWebAPI.Controllers
{
    [Route("api/{controller}")]
    [ApiController]
    public class RealStateController : ControllerBase
    {
        private IRealStateService _realStateService;
        public RealStateController(IRealStateService realStateService)
        {
            _realStateService = realStateService;
        }
        [HttpGet("GetBalance/{accountAddres}")]
        public async Task<decimal> GetBalance(string accountAddres)
        {
            var balance = await _realStateService.GetBalance(accountAddres);
            return balance;
        }
        [HttpGet]
        [Route("AddAccount/{password}")]
        public async Task<string> AddAccount(string password)
        {
            return await _realStateService.AddAccount(password);
        }
        [HttpGet]
        [Route("RunContract/{ContractName}/{ContractMethod}/{value}")]
        public async Task<string> RunContract(string ContractName,string ContractMethod,int value)
        {
            var contract =await _realStateService.GetContract(ContractName);
            var method = contract.GetFunction(ContractMethod);
            try
            {
                var result =await method.CallAsync<int>(value);
                return result.ToString();
            }
            catch (Exception)
            {

                return "Error";
            }
        }
    }
}