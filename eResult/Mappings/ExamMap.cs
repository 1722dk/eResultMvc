using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IIT.EResult.Models;
using FluentNHibernate.Mapping;

namespace IIT.EResult.Mappings
{
    public class ExamMap : ClassMap<ExamModel>
    {
        public ExamMap()
        {
            Table("Exam");
            Id(x => x.Id);
            Map(x => x.BatchNo);
            Map(x => x.CourseId);
            Map(x => x.ExamType);
            Map(x => x.ExamNo);
            Map(x => x.ExamMarks);
        }
    }
}