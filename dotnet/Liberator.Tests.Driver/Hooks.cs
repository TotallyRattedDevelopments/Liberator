using Liberator.Driver;
using NUnit.Framework;

namespace Liberator.Tests.Driver
{
    public static class Hooks
    {

        public static IRodent ratDriver;

        [TearDown]
        public static void TearDown()
        {
            if (ratDriver != null)
            {
                if (ratDriver.DriverName != null)
                {
                    ratDriver.ReturnEncapsulatedDriver().Close();
                }
            }
        }
    }
}
