using System;
using Blockfrost.Api.Options;
using CardanoSharp.Wallet.TransactionBuilding;
using Microsoft.Extensions.Options;

namespace Blockfrost.Api
{
    public interface ICardanoSharpService{
        ITransactionBuilder BuildTransaction();
    }
    
    public  class CardanoSharpService : ICardanoSharpService
    {
        private BlockfrostProject _project;
        
        public CardanoSharpService(IOptions<BlockfrostProject> options)
        {
            _project = options.Value;
        }

        public ITransactionBuilder BuildTransaction()
        {
            return TransactionBuilder.Create;
        }
    }
}
