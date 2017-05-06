using System;
using System.Windows;
using System.Windows.Markup;
using DoubleOhSeven.Extensions;

namespace DoubleOhSeven
{
    /// <summary>
    /// Binds a command to a ViewModel's method without requiring a Command
    /// property on the ViewModel.
    /// 
    /// See: https://blogs.msdn.microsoft.com/alexdan/2008/10/30/binding-to-a-markupextension-that-returns-a-binding/
    /// </summary>
    public class Bond : MarkupExtension
    {
        private readonly string methodName;

        public Bond(string methodName)
        {
            this.methodName = methodName;
        }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            var frameworkElement =
                serviceProvider
                .GetService<IProvideValueTarget>()?
                .TargetObject as FrameworkElement;

            return new Command(() =>
                {
                    frameworkElement?
                        .DataContext?
                        .InvokeMethod(methodName);
                })
                .ToBinding()
                .ProvideValue(serviceProvider);
        }
    }
}
