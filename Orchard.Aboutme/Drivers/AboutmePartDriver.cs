using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Orchard.Aboutme.Models;
using Orchard.ContentManagement;
using Orchard.ContentManagement.Drivers;
using Orchard.DisplayManagement.Shapes;

namespace Orchard.Aboutme.Drivers
{
    public class AboutmePartDriver : ContentPartDriver<AboutmePart>
    {
        protected override DriverResult Display(AboutmePart part, string displayType, dynamic shapeHelper)
        {
            return ContentShape("Parts_Aboutme", () => shapeHelper.Parts_Aboutme());
        }

        protected override DriverResult Editor(AboutmePart part, dynamic shapeHelper)
        {
            return Editor(part, null, shapeHelper);
        }

        protected override DriverResult Editor(AboutmePart part, IUpdateModel updater, dynamic shapeHelper)
        {
            return ContentShape("Parts_Aboutme_Edit", () =>
            {
                if (updater != null)
                {
                    updater.TryUpdateModel(part, Prefix, null, null);
                }

                return shapeHelper.EditorTemplate(TemplateName: "Parts.Aboutme", Model: part, Prefix: Prefix);
            });
        }
    }
}