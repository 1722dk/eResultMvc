using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IIT.EResult.Models;
using FluentNHibernate.Mapping;

namespace IIT.EResult.Mappings
{
    public class CourseMap : ClassMap<CourseModel>
    {
        public CourseMap()
        {
            Table("Course");
            Id(x => x.Id);
            Map(x => x.CourseId);
            Map(x => x.CourseCredit);
            Map(x => x.CourseTitle);
        }
    }
}