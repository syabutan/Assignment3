using Assignment5.Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Assignment3.Models
{
    public class SessionCollection : Collection
    {
        public static Collection GetCollection(IServiceProvider services)
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;
            SessionCollection collection = session?.GetJson<SessionCollection>("Collection")
                ?? new SessionCollection();
            collection.Session = session;
            return collection;
        }
        [JsonIgnore]
        public ISession Session { get; set; }
        public override void RemoveLine(MovieInfo movieInfo)
        {
            base.RemoveLine(movieInfo);
            Session.SetJson("Collection", this);
        }
        public override void Clear()
        {
            base.Clear();
            Session.Remove("Collection");
                
        }

    }
}
