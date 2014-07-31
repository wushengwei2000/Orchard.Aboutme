using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Orchard.Mvc.Routes;

namespace Orchard.Aboutme
{
    public class Routes : IRouteProvider
    {
        public IEnumerable<RouteDescriptor> GetRoutes()
        {
            yield return new RouteDescriptor
            {
                Name = "AboutmeAccess",
                Priority = 1,
                Route = new Route(
                    url: "AbouteMeAccess/UserInfo/{username}",
                    defaults: new RouteValueDictionary {
                        { "action", "UserInfo" },
                        { "controller", "AbouteMeAccess" },
                        { "area", "Orchard.Aboutme" },
                    },
                    constraints: new RouteValueDictionary(),
                    dataTokens: new RouteValueDictionary {
                        { "area", "Orchard.Aboutme" }
                    },
                    routeHandler: new MvcRouteHandler())
            };
        }

        public void GetRoutes(ICollection<RouteDescriptor> routes)
        {
            foreach (var route in GetRoutes())
            {
                routes.Add(route);
            }
        }
    }
}