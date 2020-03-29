using CustomerLibrary;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace BlazorAppIntergrationTest
{
    [TestClass]
    public class CustomerAPiIntergrationTest
    {
        string baseUrl = "https://localhost:44311/";
        HttpClient Http = new HttpClient();
       
        [Fact]
        public async Task Test_Get_All()
        {
            using (var client = new TestClientProvider().client)
            {                
                var responce = await client.GetAsync($"{baseUrl}api/customers/getall?pagenum=1&customersPerPage=100"); 
                

              responce.EnsureSuccessStatusCode();

              responce.StatusCode.Should().Be(HttpStatusCode.OK);
            }
        }
        [Fact]
        public async Task Test_Get_One_Customer()
        {
            using (var client = new TestClientProvider().client)
            {
                var responce = await client.GetAsync($"{baseUrl}api/customers/5e6040d6ce88531c06715598");

                responce.EnsureSuccessStatusCode();

                responce.StatusCode.Should().Be(HttpStatusCode.OK);
            }
        }
        [Fact(Skip = "This Test is broken need to find how to post")]
        public async Task Test_Create() 
        {
            using (var client = new TestClientProvider().client)
            {             
                var responce = await client.PostAsync($"{baseUrl}api/customers/", new StringContent(
                  Newtonsoft.Json.JsonConvert.SerializeObject(new Customer() { Id = "6815623112585486a8w45158", Address = "Test", Phone = "Test", City = "Test", CompanyName = "Test", ContactName = "Test", Country = "Test", PostalCode = "54646", Region = "Test" }),Encoding.UTF8,"application/bson"));
                           

                responce.StatusCode.Should().Be(HttpStatusCode.BadRequest);
            }

        }
    }
}
