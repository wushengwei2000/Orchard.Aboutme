using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Orchard.Aboutme.Models;
using Orchard.ContentManagement.Handlers;
using Orchard.Data;

namespace Orchard.Aboutme.Handlers
{
    public class AboutmePartHandler : ContentHandler
    {
        public AboutmePartHandler(IRepository<AboutmePartRecord> repository)
        {
            Filters.Add(StorageFilter.For(repository));
        }
    }
}