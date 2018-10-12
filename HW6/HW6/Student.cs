using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW6
{
    public class Student:Man
    {
        private int _studyYears;

        public Student(string name, int age, Gender gender, int weight, int studyYears):base(name, age, gender, weight)
        {
            _studyYears = studyYears;
        }

        public int GetStudyYears()
        {
            return _studyYears;
        }
        public void SetStudyYears(int value)
        {
            _studyYears = value;
        }
        public void IncreaseStudyYears()
        {
            _studyYears++;
        }
    }
}
