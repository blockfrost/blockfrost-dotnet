using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace Blockfrost.Cli.Commands
{
    public abstract class CommandBase : ICommand
    {
        private IEnumerable<string> _args;
        public JsonSerializerOptions Options { get; set; }
        public IEnumerable<string> Args
        {
            get => _args;
            set
            {
                if (_args == value)
                {
                    return;
                }

                _args = value;
            }
        }

        public void SetCommandLineArguments(string[] args)
        {
            Args = args;
            foreach (var (prop, att) in UnassignedParameters)
            {
                try
                {
                    string item = _args.ElementAt(att.Position);
                    prop.SetValue(this, item);
                }
                catch (Exception)
                {
                    if (att.Required)
                    {
                        throw;
                    }
                }
            }
        }

        private IEnumerable<KeyValuePair<System.Reflection.PropertyInfo, ParameterAttribute>> UnassignedParameters => GetPropertyAttributes<ParameterAttribute>().Where(kvp => kvp.Key.GetValue(this) == null && kvp.Value != null);

        private Dictionary<System.Reflection.PropertyInfo, TAttribute> GetPropertyAttributes<TAttribute>() where TAttribute : Attribute
        {
            return GetType().GetProperties().ToDictionary(p => p, p => (TAttribute)p.GetCustomAttributes(typeof(TAttribute), true).SingleOrDefault());
        }

        public abstract ValueTask<CommandResult> ExecuteAsync(CancellationToken ct);

        protected bool IsSubcommand(params string[] names)
        {
            return names.Any(name => Args.Contains(name, StringComparer.OrdinalIgnoreCase));
        }
    }
}
