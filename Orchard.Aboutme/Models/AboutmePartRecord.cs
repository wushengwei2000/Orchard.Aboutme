using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Orchard.Aboutme.Util;
using Orchard.ContentManagement;
using Orchard.ContentManagement.Records;

namespace Orchard.Aboutme.Models
{
    public class AboutmePart : ContentPart<AboutmePartRecord>
    {
        [Required(ErrorMessage = "About.Me username is mandatory")]
        [AboutmeUrlShouldbeValid(ErrorMessage = "Username is not valid.")]
        public string AboutMeUserName
        {
            get { return Record.AboutMeUserName; }
            set { Record.AboutMeUserName = value; }
        }

        [Description("Not in used now, for potential enhancement")]
        public string UserId
        {
            get { return Record.UserId; }
            set { Record.UserId = value; }
        }

        [Display(Name="Header")]
        public bool ShowHeader
        {
            get { return Record.ShowHeader; }
            set { Record.ShowHeader = value; }
        }

        [Display(Name = "Apps")]
        public bool ShowApps
        {
            get { return Record.ShowApps; }
            set { Record.ShowApps = value; }
        }

        [Display(Name = "Links")]
        public bool ShowLinks
        {
            get { return Record.ShowLinks; }
            set { Record.ShowLinks = value; }
        }
    }

    public class AboutmePartRecord : ContentPartRecord
    {
        public virtual string AboutMeUserName { get; set; }
        public virtual string UserId { get; set; }
        public virtual bool ShowHeader { get; set; }
        public virtual bool ShowApps { get; set; }
        public virtual bool ShowLinks { get; set; }
    }

    public class AboutmeUrlShouldbeValidAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (value == null)
                return false;

            var userInfo = AboutmeHelper.GetAboutmeInfo(value as string);
            return userInfo != null && userInfo["status"] != null && userInfo["status"].ToString() == "200";
        }
    }
}