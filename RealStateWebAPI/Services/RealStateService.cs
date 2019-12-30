using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Nethereum.Contracts;
using Nethereum.Web3;

namespace RealStateWebAPI.Services
{
    public class RealStateService : IRealStateService
    {
       private Web3 _web3 = new Web3("HTTP://127.0.0.1:7545");
      
        private string _accountAddress = "0x3f613Dcc61Ff0e3F5dAC2a6Cb48dc3C2BA31B12E";
        private string _accountPassword = "istech";
        private string _contractAddress = "0x495202205EFD9949237d226CAbcE06A55d2aaDFb";
        private string _abi = @"[{""constant"": true,""inputs"": [{""internalType"": ""int256"",""name"": ""amount"",""type"": ""int256""}],""name"": ""CommissionComput"",""outputs"": [{""internalType"": ""int256"",""name"": """",""type"": ""int256""}],""payable"": false,""stateMutability"": ""pure"",""type"": ""function""}]";
      

        public async Task<string> AddAccount(string Password)
        {
            var account = await _web3.Personal.NewAccount.SendRequestAsync(Password);
            return account;
        }
       
        public async Task<decimal> GetBalance(string address)
        {
            var balance =await _web3.Eth.GetBalance.SendRequestAsync(address);
            return Web3.Convert.FromWei(balance.Value, 18);
           
        }

        public async Task<Contract> GetContract(string name)
        {
            var result = await _web3.Personal.UnlockAccount.SendRequestAsync(_accountAddress, _accountPassword, 60);
            if(result)
            {
                return _web3.Eth.GetContract(_abi, _contractAddress);
            }
            return null;
          
           
        }
    }
}
