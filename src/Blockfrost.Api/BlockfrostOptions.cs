using System;
using System.Collections.Generic;using System.ComponentModel.DataAnnotations;using System.Text.Json.Serialization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blockfrost.Api
{
    public class BlockfrostOptions : Dictionary<string, BlockfrostProject>
    {
    }
}
