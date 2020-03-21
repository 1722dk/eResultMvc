using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IIT.EResult.Models;
using FluentNHibernate.Mapping;

namespace IIT.EResult.Mappings
{
    public class RegisterMap : ClassMap<RegisterModel>
    {
        public RegisterMap()
        {
            Table("UserProfile");
            Id(x => x.Id);
            Map(x => x.UserName);
            Map(x => x.Password);
        }
    }
}