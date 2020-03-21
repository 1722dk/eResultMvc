using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IIT.EResult.Models;
using FluentNHibernate.Mapping;

namespace IIT.EResult.Mappings
{
    public class LoginMap : ClassMap<LoginModel>
    {
        public LoginMap()
        {
            Table("UserProfile");
            Id(x => x.Id);
            Map(x => x.UserName);
            Map(x => x.Password);
        }
    }
}