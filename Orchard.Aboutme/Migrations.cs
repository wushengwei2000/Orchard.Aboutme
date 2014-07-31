using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Orchard.ContentManagement.MetaData;
using Orchard.Core.Contents.Extensions;
using Orchard.Data.Migration;

namespace Orchard.Aboutme
{
    public class Migrations : DataMigrationImpl
    {
        public int Create()
        {
            SchemaBuilder.CreateTable("AboutmePartRecord",
                table => table.ContentPartRecord()
                    .Column<string>("UserId")
                    .Column<string>("AboutMeUserName"));

            ContentDefinitionManager.AlterPartDefinition("AboutmePart",
                part => part.Attachable(true).WithDescription("A widget used for showing user About.Me account"));

            ContentDefinitionManager.AlterTypeDefinition("AboutmeWidget", type => type
                .WithPart("CommonPart")
                .WithPart("WidgetPart")
                .WithPart("AboutmePart")
                .WithSetting("Stereotype", "Widget")
                .Creatable(false)
                .Draftable(false));
            return 1;
        }

        public int UpdateFrom1()
        {
            SchemaBuilder.AlterTable("AboutmePartRecord", table =>
            {
                table.AddColumn<bool>("ShowHeader");
                table.AddColumn<bool>("ShowApps");
                table.AddColumn<bool>("ShowLinks");
            });
            return 2;
        }
    }
}