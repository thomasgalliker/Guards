using System;
using Guards;

namespace GuardsConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Guard.ArgumentNotNull(args, nameof(args));
            //Guard.ArgumentIsTrue(args.Length == 2, nameof(args));

            var helloParameter = args[0];
            var worldParameter = args[1];
            Guard.ArgumentNotNull(helloParameter, nameof(helloParameter));
            Guard.ArgumentNotNull(worldParameter, nameof(worldParameter));

            Console.WriteLine($"{helloParameter} {worldParameter}");

            Console.ReadKey();
        }
    }
}
