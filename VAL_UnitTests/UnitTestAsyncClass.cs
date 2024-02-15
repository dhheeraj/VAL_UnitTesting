using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace VAL_UnitTests
{
    [TestClass]
    public class UnitTestAsyncClass
    {
        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public async Task TestAsyncMethod_HandleExceptionWithAnnotation() {
            AsyncClass ac = new AsyncClass();
            await ac.GetTemperature("Goa");
            

        }
        [TestMethod]
        public async Task TestAsyncMethod_IsNull()
        {
            AsyncClass ac = new AsyncClass();
            var acc = await ac.GetTemperature(string.Empty);
            string expectedValue = "City Name is empty";
            Assert.AreEqual(acc, expectedValue);

        }

        [TestMethod]
        public async Task TestAsyncMethod_HandleExceptionWithMessageEqual()
        {
            AsyncClass ac = new AsyncClass();
            string InvalidFormatExceptionMessage = "Input string was not in a correct format.";
            var e = await Assert.ThrowsExceptionAsync< FormatException > (async ()=>await ac.GetTemperature("Goa"));
            Assert.AreEqual(e.Message, InvalidFormatExceptionMessage);
        }
    }
}
