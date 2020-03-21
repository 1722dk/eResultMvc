using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IIT.EResult.Models;
using FluentNHibernate.Mapping;

namespace IIT.EResult.Mappings
{
    public class ResultMap : ClassMap<ResultModel>
    {
        public ResultMap()
        {
            Table("Result");
            Id(x => x.Id);
            Map(x => x.CourseId);
            Map(x => x.BatchNo);
            Map(x => x.StudentId);
            Map(x => x.ExamType);
            Map(x => x.ExamNo);
            Map(x => x.Mark);

            Map(x => x.Quiz);
            Map(x => x.Assignment);
            Map(x => x.Presentation);
            Map(x => x.Attendance);
            Map(x => x.MidTerm);
            Map(x => x.Final);
            Map(x => x.Total);
            Map(x => x.GradePoint);
            Map(x => x.GradePointLetter);
        }
    }
}