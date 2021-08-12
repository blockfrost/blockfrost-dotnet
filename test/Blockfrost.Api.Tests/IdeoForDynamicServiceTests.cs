using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Blockfrost.Api.Tests
{
    [TestClass]
    public class IdeoForDynamicServiceTests
    {
        //[TestMethod]
        //public async Task Test()
        //{
        //    using var http = new HttpClient();

        //    var s = new Service(http);
        //    var p = new BlockfrostService.RouteParam<Account>();

        //    //Account a = await s.Accounts.GetAsync();
        //}

        //public sealed class Service : ABlockfrostService
        //{
        //    public Service(HttpClient httpClient) : base(httpClient)
        //    {
        //    }

        //    public IAccountService Accounts => this;

        //    private bool Predicator(MethodInfo account)
        //    {
        //        throw new NotImplementedException();
        //    }

        //    public async Task<TValue> GetAsync<TParam, TValue>(TParam account, CancellationToken cancellationToken) where TParam : IRouteParam<TValue>
        //    {
        //        var candidates = GetType().GetMethods(BindingFlags.InvokeMethod)
        //            .Where(m => m.ReturnParameter != null && m.ReturnParameter.ParameterType == typeof(TValue));

        //        try
        //        {
        //            var method = candidates.SingleOrDefault(Predicator);
        //            var parameters = new object[] { cancellationToken };

        //            return await Task.FromResult((TValue)method.Invoke(this, parameters));
        //        }
        //        catch (Exception e)
        //        {
        //            Console.WriteLine(e);
        //            throw;
        //        }

        //    }
        //}
    }
}
