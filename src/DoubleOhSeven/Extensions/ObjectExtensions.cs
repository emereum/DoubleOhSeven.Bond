namespace DoubleOhSeven.Extensions
{
    internal static class ObjectExtensions
    {
        public static void InvokeMethod(this object @object, string methodName, params object[] args)
        {
            @object
                .GetType()
                .GetMethod(methodName)
                .Invoke(@object, args);
        }
    }
}
