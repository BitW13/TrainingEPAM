using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW6
{    
    public class Man
    {
        private string _name;
        private int _age;
        private Gender _gender;
        private int _weight;

        public enum Gender
        {
            MALE,
            FEMALE
        }

        public Man(string name, int age, Gender gender, int weight)
        {
            _name = name;
            _age = age;
            _gender = gender;
            _weight = weight;
        }

        public string GetName()
        {
            return _name;
        }
        public int GetAge()
        {
            return _age;
        }
        public Gender GetGender()
        {
            return _gender;
        }
        public int GetWeight()
        {
            return _weight;
        }

        public void SetName(string value)
        {
            _name = value;
        }
        public void SetAge(int value)
        {
            _age = value;
        }
        public void SetGender(Gender value)
        {
            _gender = value;
        }
        public void SetWeight(int value)
        {
            _weight = value;
        }
    }
}
