using Nethereum.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RealStateWebAPI.Services
{
  public interface IRealStateService
    {
        Task<decimal> GetBalance(string Address);
        Task<string> AddAccount(string Password);
        Task<Contract> GetContract(string name);
    }
}
