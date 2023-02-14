using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using ApiGateway.Dtos;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Ocelot.Middleware;
using Ocelot.Multiplexer;

namespace ApiGateway.Aggregators
{
    public class UsersPostsAggregator : IDefinedAggregator
    {
        public async Task<DownstreamResponse> Aggregate(List<HttpContext> responses /*Recibe una peticion de Responses*/) 
        {
            if (responses.Any(r => r.Items.Errors().Count > 0))
            {
                return new DownstreamResponse(null, HttpStatusCode.BadRequest, (List<Header>) null, null);
            }
            
            /*En ocelot.json en el Aggregator hacemos dos peticiones por lo tanto vamos a tener dos responses*/
            var userResponseContent = await responses[0].Items.DownstreamResponse().Content.ReadAsStringAsync();
            var postResponseContent = await responses[1].Items.DownstreamResponse().Content.ReadAsStringAsync();

            /*LLamo a los endpoints de user y post y devuelvo un listado de user y otro de post*/
            var users = JsonConvert.DeserializeObject<List<User>>(userResponseContent);
            var posts = JsonConvert.DeserializeObject<List<Post>>(postResponseContent);

            /*Por cada usuario recorrido filtro su post y los agrego a su lista de posts*/
            foreach (var user in users)
            {
                var userPosts = posts.Where(p => p.UserId == user.Id).ToList();
                user.Posts.AddRange(userPosts);
            }

            /*Lo serializamos y lo devolvemos*/
            var postByUserString = JsonConvert.SerializeObject(users);

            var stringContent = new StringContent(postByUserString)
            {
                Headers = { ContentType = new MediaTypeHeaderValue("application/json") }
            };

            return new DownstreamResponse(stringContent, HttpStatusCode.OK, new List<KeyValuePair<string, IEnumerable<string>>>(), "OK");
        }
    }
}
