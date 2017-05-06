using System.Windows;
using System.Windows.Data;
using System.Windows.Input;

namespace DoubleOhSeven.Extensions
{
    internal static class CommandExtensions
    {
        public static Binding ToBinding(this ICommand command) =>
            new Binding
            {
                Source = new { Command = command },
                Path = new PropertyPath("Command")
            };
    }
}
