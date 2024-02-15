using Moq;
using Moq.
    Protected;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Services;

namespace VAL_UnitTests
{
    [TestClass]
    public class UnitTestWithHttpClient
    {
        /// <summary>
        /// Mock Http Client object using MoQ nuget package
        /// 
        /// </summary>
        /// <param name="content"></param>
        /// <param name="statusCode"></param>
        /// <returns></returns>
        private Mock<HttpMessageHandler> CreateMockHttpMessageHandler(string content = "test content", HttpStatusCode statusCode = HttpStatusCode.OK)
        {
            var mockMessageHandler = new Mock<HttpMessageHandler>();
            mockMessageHandler.Protected()
                .Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.IsAny<HttpRequestMessage>(),
                    ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = statusCode,
                    Content = new StringContent(content)
                });
            return mockMessageHandler;
        }

        /// <summary>
        /// Test for valid user, With response status "OK" from mock client
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task Test_UserAuthorization_Success()
        {
            var httpMessageHandler = CreateMockHttpMessageHandler();
            HttpClient mockClient = new HttpClient(httpMessageHandler.Object);
            HTTPClientClass localCLient = new HTTPClientClass();
            var result = await localCLient.IsUserAuthorized("https://testmock.com", "mockAccessToken", mockClient);
            Assert.IsTrue(result);   
        }

        /// <summary>
        /// Test for valid user, With response status "UnAuthorized" from mock client
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task Test_UserAuthorization_Failure()
        {
            var httpMessageHandler = CreateMockHttpMessageHandler("Test Content",HttpStatusCode.Unauthorized);
            HttpClient mockClient = new HttpClient(httpMessageHandler.Object);
            HTTPClientClass localCLient = new HTTPClientClass();
            var result = await localCLient.IsUserAuthorized("https://testmock.com", "mockAccessToken", mockClient);
            Assert.IsFalse(result);
        }
    }
}
