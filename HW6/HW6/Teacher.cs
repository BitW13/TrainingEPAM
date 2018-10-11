using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW6
{
    public class Teacher:Man
    {
        private int _workYears;
        private Subject _subject;

        public enum Subject
        {
            MATH,
            FISICS,
            ENGLISH,
            RUSSIAN,
            BIOLOGY
        }

        public Teacher(string name, int age, Gender gender, int weight, int workYears, Subject subject):base(name, age, gender, weight)
        {
            _workYears = workYears;
            _subject = subject;
        }

        public int GetWorkYears()
        {
            return _workYears;
        }
        public void SetWorkYears(int value)
        {
            _workYears = value;
        }
        public void IncreaseWorkYears()
        {
            _workYears++;
        }

        public Subject GetSubject()
        {
            return _subject;
        }
        public void SetSubject(Subject value)
        {
            _subject = value;
        }
    }
}
