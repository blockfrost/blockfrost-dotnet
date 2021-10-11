using System.Collections.Generic;
using System.Net;
using Blockfrost.Api.Services;

namespace Blockfrost.Api.Tests.Services
{
    public abstract class AddressServiceMethodTestBase<TModel> : AServiceMethodTestBase<IAddressesService, ICollection<AddressUTxOResponse>>
    {
        protected AddressServiceMethodTestBase(string methodName, HttpStatusCode statusCode = HttpStatusCode.OK) : base(methodName, statusCode)
        {
        }
    }
}
