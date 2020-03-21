using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IIT.EResult.Models;
using FluentNHibernate.Mapping;

namespace IIT.EResult.Mappings
{
    public class TeacherMap : ClassMap<TeacherModel>
    {
        public TeacherMap()
        {
            Table("Teacher");
            Id(x => x.Id);
            Map(x => x.Name);
            Map(x => x.Designation);
            Map(x => x.Email);
            Map(x => x.ContactNo);
        }
    }
}