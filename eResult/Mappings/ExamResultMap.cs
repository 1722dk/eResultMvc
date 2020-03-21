using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IIT.EResult.Models;
using FluentNHibernate.Mapping;

namespace IIT.EResult.Mappings
{
    public class ExamResultMap : ClassMap<ExamResultModel>
    {
        public ExamResultMap()
        {
            Table("ExamResult");
            Id(x => x.Id);
            Map(x => x.CourseId);
            Map(x => x.StudentId);
            Map(x => x.BatchNo);
            Map(x => x.ExamType);
            Map(x => x.ExamNo);
            Map(x => x.Mark);
        }
    }
}