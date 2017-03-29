namespace Reflow.Data
{
    public class Data
    {
        private static ReflowContext context;
        public static ReflowContext Context => context ?? (context = new ReflowContext());
    }
}
