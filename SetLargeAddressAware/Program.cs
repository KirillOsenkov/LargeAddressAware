using System.IO;
using PEFile;

namespace SetLargeAddressAware
{
    class Program
    {
        static int Main(string[] args)
        {
            if (args.Length != 1)
            {
                return 1;
            }

            var filePath = args[0];
            if (!File.Exists(filePath))
            {
                return 2;
            }

            LargeAddressAware.SetLargeAddressAware(filePath);
            return 0;
        }
    }
}