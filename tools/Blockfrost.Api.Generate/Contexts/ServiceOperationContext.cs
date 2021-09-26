using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.OpenApi.Models;

namespace Blockfrost.Api.Generate.Contexts
{
    public class ServiceOperationContext
    {
        private KeyValuePair<KeyValuePair<string, OpenApiPathItem>, Dictionary<OperationType, OpenApiOperation[]>> _context;

        public ServiceOperationContext(ServiceContext serviceContext, KeyValuePair<KeyValuePair<string, OpenApiPathItem>, Dictionary<OperationType, OpenApiOperation[]>> o)
        {
            ServiceContext = serviceContext;
            _context = o;
            DocsLink = new StringBuilder()
                    .Append(ServiceContext.DocsLink)
                    .Append('/').Append("paths")
                    .Append('/').Append(Route.Replace("/", "~1")).ToString();
        }

        public KeyValuePair<string, OpenApiPathItem> PathContext => _context.Key;
        public string Route => PathContext.Key;
        public string DocsLink { get; set; }

        public OpenApiPathItem PathItem => PathContext.Value;

        public Dictionary<OperationType, OpenApiOperation[]> OperationContext => _context.Value;

        public IEnumerable<MethodContext> GetOperations => LoadOperations(OperationType.Get);
        public IEnumerable<MethodContext> PostOperations => LoadOperations(OperationType.Post);
        public IEnumerable<MethodContext> PutOperations => LoadOperations(OperationType.Put);
        public IEnumerable<MethodContext> DeleteOperations => LoadOperations(OperationType.Delete);

        public ServiceContext ServiceContext { get; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="method"></param>
        /// <returns></returns>
        private IEnumerable<MethodContext> LoadOperations(OperationType method)
        {
            return OperationContext.ContainsKey(method) ? OperationContext[method].Select(op => new MethodContext(this, method, op)) : System.Array.Empty<MethodContext>();
        }

    }
}
