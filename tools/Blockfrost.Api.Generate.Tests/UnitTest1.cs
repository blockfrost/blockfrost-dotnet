using System.Threading.Tasks;
using Blockfrost.Api.Generate.Contexts;
using Microsoft.OpenApi.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Blockfrost.Api.Generate.Tests
{
    [TestClass]
    public class OpenApiGenerateIntegrationTest
    {
        public static OpenApiDocument s_specs;
        [ClassInitialize]
        public static async Task Setup(TestContext context)
        {
            s_specs = await TemplateHelper.ReadSpecsAsync(@"C:\dev\tweakch\blockfrost-dotnet\oas\0.1.27\swagger.yaml");
        }

        [TestMethod]
        public void TestLoadModels()
        { 
            var ctx = new OpenApiDocumentContext(new System.IO.DirectoryInfo(@"C:\dev\tweakch\blockfrost-dotnet\oas\0.1.27\"), s_specs);
            ctx.Load();

            foreach (var item in ctx.Models)
            {
                Assert.IsTrue(item.IsArray != item.IsObject, $"{item.ClassName} cannot be an object and an array at the same time");
            }
        }
    }

    [TestClass]
    public class OpenApiDocumentGeneratorContextTest
    {
        public static OpenApiDocument s_specs;
        [ClassInitialize]
        public static async Task Setup(TestContext context)
        {
           s_specs = await TemplateHelper.ReadSpecsAsync(@"C:\dev\tweakch\blockfrost-dotnet\tools\Blockfrost.Api.Generate.Tests\dat\swagger_simple.json");
        }

        [TestMethod]
        public void TestLoadModels()
        {
            var ctx = new OpenApiDocumentContext(new System.IO.DirectoryInfo(@"C:\dev\tweakch\blockfrost-dotnet\oas\0.1.27\"),s_specs);
            ctx.Load();
            Assert.AreEqual(7, ctx.Models.Count);

            ModelContext info = ctx.Models[0];
            Assert.IsFalse(info.HasItem);
            Assert.IsNull(info.ItemName);
            Assert.AreEqual("Info", info.ClassName);

            ModelContext blockContent = ctx.Models[3];
            Assert.AreEqual("BlockContent", blockContent.ClassName);
            Assert.IsFalse(blockContent.IsArray);
            Assert.IsFalse(blockContent.HasItem);
            Assert.IsNull(blockContent.ItemName);

            ModelContext blockContentTxsCollection = ctx.Models[4];
            Assert.AreEqual("BlockContentTxsCollection", blockContentTxsCollection.ClassName);
            Assert.IsTrue(blockContentTxsCollection.IsArray);
            Assert.IsTrue(blockContentTxsCollection.HasItem);
            Assert.IsFalse(blockContentTxsCollection.ItemContext.IsClass);
            Assert.AreEqual("string", blockContentTxsCollection.ItemName);

            Assert.AreEqual("BlockContentCollection", ctx.Models[5].ClassName);
            Assert.IsTrue(ctx.Models[5].IsArray);
            Assert.IsTrue(ctx.Models[5].HasItem);
            Assert.AreEqual("BlockContent", ctx.Models[5].ItemName);

            ModelContext poolMetadata = ctx.Models[6];
            Assert.AreEqual("PoolMetadata", poolMetadata.ClassName);
            Assert.IsTrue(poolMetadata.IsMultiple);
            Assert.IsFalse(poolMetadata.HasItem);
            Assert.IsNull(poolMetadata.ItemName);
        }
    }

    [TestClass]
    public class UnitTest1
    {
        private static OpenApiDocument s_doc;
        [ClassInitialize]
        public static async Task Setup(TestContext context)
        {
            s_doc = await TemplateHelper.ReadSpecsAsync(@"C:\dev\tweakch\blockfrost-dotnet\tools\Blockfrost.Api.Generate.Tests\dat\swagger_simple.json");
        }

        //[TestMethod]
        //public void ModelNamesMatchServiceResponse()
        //{
        //    var serviceContext = new ServiceContext(s_doc, s_doc.Tags[0]);
        //    var methodContext = serviceContext.Operations.First().GetOperations.First();
        //    var response = methodContext.Current.Responses.First();

        //    var schemas = s_doc.SchemasWhere(r => r.IsSuccessStatusCode());

        //    var modelContext = new ModelContext(s_doc, schemas.Distinct().First());

        //    Assert.AreEqual(methodContext.ReturnType, modelContext.ReturnType);
        //}

        [TestMethod]
        public void WriteSafe()
        {

            Assert.AreEqual("Hello, Ada! 1518...", TemplateHelper.WriteSafe("Hello,\nAda&!_$15&18..."));
        }
    }
}

