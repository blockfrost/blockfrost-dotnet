using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Blockfrost.Api.t4
{
    class Class1
    {
        public void Test()
        {
            JsonDocument doc = JsonDocument.Parse("C:\\Users\\aklee\\source\\blockfrost\\blockfrost-dotnet\\openapi.0.1.25.json");
            var elements = doc.RootElement.EnumerateObject();
            foreach (var element in elements)
            {
                Console.Write(element.Name);
            }
        }
    }
}
