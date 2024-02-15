



using Services;

namespace VAL_UnitTests
{
    [TestClass]
    public class UnitTestString
    {
        /// <summary>
        /// Test case to handle null input
        /// </summary>
        [TestMethod]
        public void TestString_Empty()
        {
            StringClass cc = new StringClass();
            var result = cc.AlwaysReturnString(string.Empty);
            Assert.AreEqual(string.Empty, result);
        }

        /// <summary>
        /// Test actual and expected value are exactly equals
        /// </summary>
        [TestMethod]
        public void TestString_NotEmpty()
        {
            StringClass cc = new StringClass();
            string input = "Alex";
            string expectedValue = $"Hello {input}";
            var result = cc.AlwaysReturnString(input);
            Assert.AreEqual(expectedValue, result);
        }

        /// <summary>
        /// Test catch block exception handling based on exception type using  Assert.ThrowsException & Assert.IsInstanceOfType
        /// </summary>
        [TestMethod]
        public void TestExceptionHandlingWithType()
        {
            StringClass cc = new StringClass();
            string str1 = "Alex";
            string str2 = null;            
            var e = Assert.ThrowsException<NullReferenceException>(() => cc.HandleException(str1, str2));
            Assert.IsInstanceOfType(e,typeof(NullReferenceException));
        }

        /// <summary>
        /// Test to Handle exception and validate it is equal with expected exception message
        /// </summary>
        [TestMethod]
        public void TestExceptionHandlingWithMessage()
        {
            StringClass cc = new StringClass();
            string str1 = "Alex";
            string str2 = null;
            string NullExceptionMessage = "Object reference not set to an instance of an object.";
            var e = Assert.ThrowsException<NullReferenceException>(() => cc.HandleException(str1, str2));
            Assert.AreEqual(NullExceptionMessage, e.Message);
        }

        /// <summary>
        /// Test to Handle exception and validate it using Assert.Istrue.
        /// Incombination of based on exception message exactly matching as expected.
        /// </summary>
        [TestMethod]
        public void TestExceptionHandlingWithMessageUsing_Istrue()
        {
            StringClass cc = new StringClass();
            string str1 = "Alex";
            string str2 = null;
            string NullExceptionMessage = "Object reference not set to an instance of an object.";
            var e = Assert.ThrowsException<NullReferenceException>(() => cc.HandleException(str1, str2));
            Assert.IsTrue(string.Equals(NullExceptionMessage, e.Message));
        }

        /// <summary>
        /// Handle exception via annotations on test method
        /// 
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void TestExceptionHandlingUsing_Annotation()
        {
            StringClass cc = new StringClass();
            string str1 = "Alex";
            string str2 = null;            
            cc.HandleException(str1, str2);
           
        }

        /// <summary>
        /// Test is null as outcome
        /// </summary>
        [TestMethod]
        public void TestAssertIsNull()
        {
            StringClass cc = new StringClass();
            var e = cc.AppendToStringInCollection(null);
            Assert.IsNull(e);  
           
        }

        /// <summary>
        /// Test actual value is same as expected value.
        /// When expected and actual are collections data type.
        /// </summary>
        [TestMethod]
        public void TestAssertIsEqualByType()
        {
            StringClass stringClass = new StringClass();
            List<string> expectedValue = new List<string>() { "Hi First", "Hi Second" };
            List<string> testData = new List<string>() { "First", "Second" };
            List<string> e = stringClass.AppendToStringInCollection(testData);
            CollectionAssert.AreEqual(expectedValue,e);
        }

        /// <summary>
        /// Inconclusive is used when test case have dependencies like data to be fetched from 3rd party, internet connection etc
        /// It actualy skips the unit test case if falls under conditions
        /// Also prints the inclusive message in console.
        /// </summary>
        [TestMethod]
        public void TestAssertInclusive()
        {
            List<string> items = new List<string>();           
            if (items.Count == 0)
            {
                Assert.Inconclusive("No customers to test");  
                
            }
            
        }


        /// <summary>
        /// Tests the object type of actual and expected values
        /// </summary>
        [TestMethod]
        public void TestAssertIsEqualByReference()
        {
            StringClass stringClass = new StringClass();
            List<string> expectedValue = new List<string>() { "Hi First", "Hi Second" };
            List<string> testData = new List<string>() { "First", "Second" };
            List<string> e = stringClass.AppendToStringInCollection(testData);
            Assert.ReferenceEquals(expectedValue,e);
            
        }





    }
}