using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blockfrost.Api.Generate.Contexts;
using Microsoft.OpenApi.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Blockfrost.Api.Generate.Tests
{
    [TestClass]
    public class GenerateModelTests
    {
        private static OpenApiDocument s_specs;
        [ClassInitialize]
        public static async Task Setup(TestContext context)
        {
            s_specs = await TemplateHelper.ReadSpecsAsync(@"C:\dev\tweakch\blockfrost-dotnet\oas\0.1.27\swagger_simple.yaml");
        }

        [TestMethod]
        public void RootEndpointMethodName()
        {
            var successSchemas = s_specs.SchemasWhere(r => r.IsSuccessStatusCode()).Where(m => m.Key.StartsWith("block_content")).ToList();
            Assert.AreEqual(2, successSchemas.Count);

            var arraySchema = successSchemas[0];
            var itemSchema = successSchemas[1];

            ModelContext arrayContext = new ModelContext(s_specs, arraySchema);
            ModelContext itemContext = new ModelContext(s_specs, itemSchema);

            Assert.AreEqual(arrayContext.ClassName, itemContext.ClassName);
        }

    }
    [TestClass]
    public class GenerateServiceTests
    {
        private static OpenApiDocument s_specs;
        [ClassInitialize]
        public static async Task Setup(TestContext context)
        {
            s_specs = await TemplateHelper.ReadSpecsAsync(@"C:\dev\tweakch\blockfrost-dotnet\oas\0.1.27\swagger_simple.yaml");
        }


        [TestMethod]
        public void RootEndpointMethodName()
        {
            var successSchemas = s_specs.SchemasWhere(r => r.IsSuccessStatusCode());
            ServiceContext context = new ServiceContext(s_specs, s_specs.Tags.First());

            Assert.AreEqual("GetRoot", context.Operations.First().GetOperations.First().MethodName);
        }

        [TestMethod]
        public void ReturnTypeFormat()
        {

            foreach (var tag in s_specs.Tags)
            {
                ServiceContext context = new ServiceContext(s_specs, tag);

                foreach (var operations in context.Operations.Where(o => !o.PathContext.Key.Equals("/")).ToList())
                {
                    foreach (var operation in operations.GetOperations)
                    {
                        var signature = new List<string>(operation.Signature);
                        signature.Insert(0, operation.Context.ServiceContext.ServiceName);
                        signature.Insert(0, operation.HttpMethod.ToString());

                        var returnType = string.Concat(string.Join(string.Empty, signature), "Response");
                        var methodName = string.Concat(signature.Distinct());
                        Assert.AreEqual(methodName, operation.MethodName);
                    }
                }
            }
        }

        [TestMethod]
        public void MethodNameFormat()
        {
            var successSchemas = s_specs.SchemasWhere(r => r.IsSuccessStatusCode());

            foreach (var tag in s_specs.Tags)
            {
                ServiceContext context = new ServiceContext(s_specs, tag);
                foreach (var operations in context.Operations.Where(o => !o.PathContext.Key.Equals("/")).ToList())
                {
                    foreach (var operation in operations.GetOperations)
                    {
                        var signature = new List<string>(operation.Signature);
                        signature.Insert(0, operation.Context.ServiceContext.ServiceName);
                        signature.Insert(0, operation.HttpMethod.ToString());

                        var returnType = string.Concat(string.Join(string.Empty, signature), "Response");
                        var MethodName = string.Concat(signature.Distinct());

                        Assert.AreEqual(returnType, operation.ReturnType);
                    }
                }
            }
        }
    }
}

