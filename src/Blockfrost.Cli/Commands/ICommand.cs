using System;
using System.Threading;
using System.Threading.Tasks;

namespace Blockfrost.Cli.Commands
{
    [AttributeUsage(AttributeTargets.Class)]
    public class CommandAttribute : Attribute
    {
        public CommandAttribute()
        {
        }

        public string Name { get; set; }
        public string Description { get; set; }
    }

    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    public class ParameterAttribute : Attribute
    {
        public ParameterAttribute()
        {
        }

        public int Position { get; set; }
        public string Description { get; set; }
        public bool Required { get; set; }
    }

    [AttributeUsage(AttributeTargets.Property)]
    public class SwitchAttribute : Attribute
    {
        public SwitchAttribute()
        {
        }

        public int Position { get; set; }
        public string Description { get; set; }
        public bool Required { get; set; }
    }

    public interface ICommand
    {
        ValueTask<CommandResult> ExecuteAsync(CancellationToken ct);
    }
}
