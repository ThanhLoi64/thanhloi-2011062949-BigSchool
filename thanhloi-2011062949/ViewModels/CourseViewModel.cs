using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Web;
using thanhloi_2011062949.Models;

namespace thanhloi_2011062949.ViewModels
{
    public class CourseViewModel
    {
        public class CoursesViewModels
        {
            public IEnumerable<Course> UpcommingCourses { get; set; }
            public bool ShowAction { get; set; }
        }
        [Required]
        public string Place { get; set; }

        [Required]
        [FutureDate]
        public string Date { get; set; }
        [Required]
        [ValidTime]
        public string Time { get; set; }

        [Required]
        public byte Category { get; set; }

        public IEnumerable<Category> Categories { get; set; }

        private IQueryable<Course> upcommingCourses;

        public IQueryable<Course> GetUpcommingCourses()
        {
            return upcommingCourses;
        }

        internal void SetUpcommingCourses(IQueryable<Course> value)
        {
            upcommingCourses = value;
        }

        public bool ShowAction { get; internal set; }
        public IQueryable<Course> UpcommingCourses { get; internal set; }

        public DateTime GetDateTime()
        {
            return DateTime.Parse(string.Format("{0} {1}", Date, Time));
        }
    }
}

namespace thanhloi_2011062949
{
    public class FutureDate : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            DateTime dateTime;
            var isValid = DateTime.TryParseExact(Convert.ToString(value),
                "dd/M/yyyy",
                CultureInfo.CurrentCulture,
                DateTimeStyles.None,
                out dateTime);
            return (isValid && dateTime > DateTime.Now);
        }
    }


    public class ValidTime : ValidationAttribute
    {
       
        public override bool IsValid(object value)
        {

            DateTime dateTime;
            var isValid = DateTime.TryParseExact(Convert.ToString(value),
                "HH:mm",
                CultureInfo.CurrentCulture,
                DateTimeStyles.None,
                out dateTime);
            return isValid;
        }
    }
}