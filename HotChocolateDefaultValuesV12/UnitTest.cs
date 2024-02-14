using HotChocolate.Execution;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json.Linq;

namespace HotChocolateDefaultValues
{
    public class UnitTest
    {
        [Fact]
        public void Test1()
        {
            // Arrange
            var services = new ServiceCollection();
            services
                .AddGraphQLServer()
                .AddQueryType<Queries>()
                .AddMutationType<Mutations>();

            var serviceProvider = services.BuildServiceProvider();
            var executorResolver = serviceProvider.GetRequiredService<IRequestExecutorResolver>();
            IRequestExecutor executor = executorResolver.GetRequestExecutorAsync().Result;

            // Act
            IExecutionResult result = executor.ExecuteAsync("mutation{ doSomething(input: { }) { result } }").Result;

            // Extract the data from the result
            var jsonResult = result.ToJson();

            // Parse the JSON result and extract the 'result' value
            var jObject = JObject.Parse(jsonResult);
            var actualResult = jObject["data"]["doSomething"]["result"].Value<int>();

            // Assert
            Assert.Equal(500, actualResult);
        }
    }
}