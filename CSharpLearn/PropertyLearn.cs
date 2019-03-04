using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpLearn
{
    class PropertyLearn
    {
        private string name;
        public string Name
        {
            set { name = "ss"+ value; }
        }

        public string Age
        {
            set { Age = value; }
        }

        public string getName()
        {
            return name;
        }
    }

    class peoples
    {
        public string name;
        public int age;
  
    }
    class TestProperty
    {
        public peoples peoples { get; set;}
    }
}
