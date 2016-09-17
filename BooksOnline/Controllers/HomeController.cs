using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using BooksOnline.Models;
using Microsoft.IdentityModel.Clients.ActiveDirectory;
using System.Net.Http.Headers;

namespace BooksOnline.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        public async Task<ActionResult> Index()
        {
            using (var client = new HttpClient())
            {
                var url = "http://localhost:5000/books";
                //var token = await GetAccessToken();
                //client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                var response = await client.GetAsync(url);
                var content = await response.Content.ReadAsStringAsync();
                var books = Newtonsoft.Json.JsonConvert.DeserializeObject<IEnumerable<Book>>(content);
                return View(books);
            }
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Find and suggest books online.";
            return View();
        }

        public IActionResult Error()
        {
            return View();
        }

        [AllowAnonymous]
        public IActionResult PostLogOut()
        {
            return View();
        }

        internal async Task<string> GetAccessToken()
        {
            // TODO: enter STS authority
            var authority = "<STS authority>";
            // TODO: enter client id
            var clientId = "<client id>";
            // TODO: enter client secret
            var clientSecret = "<client secret>";
            var resourceId = "http://localhost:5000/";

            var authContext = new AuthenticationContext(authority);
            var credential = new ClientCredential(clientId, clientSecret);
            var userAssertion = GetUserAssertion();

            if (userAssertion == null)
            {
                var result = await authContext.AcquireTokenAsync(
                    resourceId,
                    credential);

                return result.AccessToken;
            }

            authContext.TokenCache.Clear();

            var impersonatedResult = await authContext.AcquireTokenAsync(
                resourceId,
                credential,
                userAssertion);

            return impersonatedResult.AccessToken;
        }

        internal UserAssertion GetUserAssertion()
        {
            var identity = HttpContext.User.Identity as System.Security.Claims.ClaimsIdentity;
            var token = identity?.BootstrapContext as string;
            return string.IsNullOrWhiteSpace(token) ? null : new UserAssertion(token);
        }
    }
}
