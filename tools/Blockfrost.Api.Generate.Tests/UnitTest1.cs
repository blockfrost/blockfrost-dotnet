using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.OpenApi.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Blockfrost.Api.Generate.Tests
{
    [TestClass]
    public class UnitTest1
    {
        private static OpenApiDocument s_doc;
        [ClassInitialize]
        public static async Task Setup(TestContext context)
        {
            s_doc = await TemplateHelper.ReadSpecsAsync(@"C:\dev\tweakch\blockfrost-dotnet\tools\Blockfrost.Api.Generate.Tests\dat\swagger_simple.json");
        }

        [TestMethod]
        public void ModelNamesMatchServiceResponse()
        {
            var serviceContext = new ServiceContext(s_doc, s_doc.Tags[0]);
            var methodContext = serviceContext.Operations.First().GetOperations.First();
            var response = methodContext.Current.Responses.First();

            var schemas = s_doc.SchemasWhere(r => r.IsSuccessStatusCode());

            var modelContext = new ModelContext(s_doc, schemas.Distinct().First());

            Assert.AreEqual(methodContext.ReturnType, modelContext.ReturnType);
        }

        [TestMethod]
        public void WriteSafe()
        {

            Assert.AreEqual("Hello, Ada! 1518...", TemplateHelper.WriteSafe("Hello,\nAda&!_$15&18..."));
        }
    }
}

