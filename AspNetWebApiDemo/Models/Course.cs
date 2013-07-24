using System.Collections.Generic;

namespace AspNetWebApiDemo.Models
{
    public class Course
    {
        private static readonly IEnumerable<Course> allCourses = new List<Course>
            {
                new Course("C#"), new Course("JavaScript")
            };

        protected Course()
        {
        }

        public Course(string name)
        {
            Name = name;
        }

        public string Name { get; set; }

        public static IEnumerable<Course> All()
        {
            return allCourses;
        }

        public bool Equals(Course other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Equals(other.Name, Name);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != typeof (Course)) return false;
            return Equals((Course) obj);
        }

        public override int GetHashCode()
        {
            return (Name != null ? Name.GetHashCode() : 0);
        }
    }
}