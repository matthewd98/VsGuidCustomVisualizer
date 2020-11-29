using System;

namespace GuidVisualizerTestApp
{
    class Program
    {
        static void Main(string[] _)
        {
            var guid = new Guid("{DBC4A89B-FB5A-4616-9DC3-211259C8F1F4}");

            // Set breakpoint on line below and then use the custom visualizer.
            Console.WriteLine(guid);
        }
    }
}