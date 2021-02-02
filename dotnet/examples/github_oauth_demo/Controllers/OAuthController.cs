using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace github_oauth_demo.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OAuthController : ControllerBase
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ILogger<OAuthController> _logger;

        public OAuthController(IHttpClientFactory httpClientFactory,
            ILogger<OAuthController> logger)
        {
            _httpClientFactory = httpClientFactory;
            _logger = logger;
        }

        [HttpGet("github_callback")]
        public async Task<IActionResult> GithubCallback(string code)
        {
            var httpClient = _httpClientFactory.CreateClient();
            var url = new StringBuilder("https://github.com/login/oauth/access_token");

            url.Append(QueryString.Create("client_id", "d8553e7d43c65fdb5812")
                .Add("client_secret", "0d5dbe8e2c7ffe5fb042fcdea325cded8d3484e1")
                .Add("code", code)
                .ToUriComponent());

            httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
            var res = await httpClient.PostAsync(url.ToString(), null);
            res.EnsureSuccessStatusCode();

            // var json = await res.Content.ReadAsStringAsync();
            // // _logger.LogInformation("response:{0}", json);

            await using var responseStream = await res.Content.ReadAsStreamAsync();
            var tokenInfo = await JsonSerializer.DeserializeAsync<GithubAccessTokenInfo>(responseStream);

            if (tokenInfo == null) throw new ArgumentNullException(nameof(tokenInfo));
            if (string.IsNullOrEmpty(tokenInfo.AccessToken))
                throw new ArgumentNullException(nameof(tokenInfo.AccessToken));

            _logger.LogInformation("AccessToken:{0}", tokenInfo.AccessToken);

            httpClient.DefaultRequestHeaders.UserAgent.Add(
                new ProductInfoHeaderValue("dotNetHttpClient", "1.1"));
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("token",
                tokenInfo.AccessToken);
            res = await httpClient.GetAsync("https://api.github.com/user");
            res.EnsureSuccessStatusCode();

            //var json = await res.Content.ReadAsStringAsync();
            await using var responseStream2 = await res.Content.ReadAsStreamAsync();
            var userInfo = await JsonSerializer.DeserializeAsync<GithubUserInfo>(responseStream2);

            // return Ok(userInfo);
            return Redirect($"/hello.html?name={userInfo.Name}");
        }

        private class GithubAccessTokenInfo
        {
            [JsonPropertyName("access_token")]
            public string AccessToken { get; set; }

            [JsonPropertyName("token_type")]
            public string TokenType { get; set; }

            [JsonPropertyName("scope")]
            public string Scope { get; set; }
        }

        private class GithubUserInfo
        {
            [JsonPropertyName("login")]
            public string Login { get; set; }

            [JsonPropertyName("id")]
            public int Id { get; set; }

            [JsonPropertyName("node_id")]
            public string NodeId { get; set; }

            [JsonPropertyName("avatar_url")]
            public string AvatarUrl { get; set; }
            // [JsonPropertyName("gravatar_id")]
            // public string GravatarId { get; set; }
            // [JsonPropertyName("url")]
            // public string Url { get; set; }
            [JsonPropertyName("html_url")]
            public string HtmlUrl { get; set; }
            // [JsonPropertyName("followers_url")]
            // public string FollowersUrl { get; set; }
            // [JsonPropertyName("following_url")]
            // public string FollowingUrl { get; set; }
            // [JsonPropertyName("gists_url")]
            // public string GistsUrl { get; set; }
            // [JsonPropertyName("starred_url")]
            // public string StarredUrl { get; set; }
            // [JsonPropertyName("subscriptions_url")]
            // public string SubscriptionsUrl { get; set; }
            // [JsonPropertyName("organizations_url")]
            // public string OrganizationsUrl { get; set; }
            // [JsonPropertyName("repos_url")]
            // public string ReposUrl { get; set; }
            // [JsonPropertyName("events_url")]
            // public string EventsUrl { get; set; }
            // [JsonPropertyName("received_events_url")]
            // public string ReceivedEventsUrl { get; set; }
            // [JsonPropertyName("type")]
            // public string Type { get; set; }
            // [JsonPropertyName("site_admin")]
            // public string SiteAdmin { get; set; }
            [JsonPropertyName("name")]
            public string Name { get; set; }
            // [JsonPropertyName("company")]
            // public string Company { get; set; }
            // [JsonPropertyName("blog")]
            // public string Blog { get; set; }
            // [JsonPropertyName("location")]
            // public string Location { get; set; }
            [JsonPropertyName("email")]
            public string Email { get; set; }
            // [JsonPropertyName("hireable")]
            // public string Hireable { get; set; }
            [JsonPropertyName("bio")]
            public string Bio { get; set; }
            // [JsonPropertyName("twitter_username")]
            // public string TwitterUsername { get; set; }
            // [JsonPropertyName("public_repos")]
            // public int PublicRepos { get; set; }
            // [JsonPropertyName("public_gists")]
            // public int PublicGists { get; set; }
            // [JsonPropertyName("followers")]
            // public int Followers { get; set; }
            // [JsonPropertyName("following")]
            // public int Following { get; set; }
            [JsonPropertyName("created_at")]
            public string CreatedAt { get; set; }

            [JsonPropertyName("updated_at")]
            public string UpdatedAt { get; set; }
        }
    }
}