using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IIT.EResult.Models;
using FluentNHibernate.Mapping;

namespace IIT.EResult.Mappings
{
    public class StudentMap : ClassMap<StudentModel>
    {
        public StudentMap()
        {
            Table("Student");
            Id(x => x.Id);
            Map(x => x.Name);
            Map(x => x.BatchNo);
            Map(x => x.Session);
            Map(x => x.Email);
            Map(x => x.ContactNo);
        }
    }
}