using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

//Attribute 运用范围 程序集，模块，类型（类，结构，枚举，接口，委托），字段，方法（含构造），方法，参数，方法返回值，属性（property)
namespace CSharpLearn
{
    [AttributeUsage(AttributeTargets.All)]
    public class TestAttribute : Attribute
    {
    }

    [Test]
    public enum TestEnum { }

    [Test]
    public class TestClass
    {
        [Test]
        public TestClass() { }

        [Test]
        private string _TestField;

        [Test]
        private string TestProperty { get; set; }

        [Test]
        [return: Test] //返回值上
        public string TestMethod([Test] string testParam)   //参数上
        {
            throw new NotImplementedException();
        }
    }
}

namespace CSharpAttributeLearn
{
    //Test  AttributeUsage
    [AttributeUsage(AttributeTargets.Property)]
    public class StringLengthAttribute : Attribute
    {
        private int _maximumLength;
        public StringLengthAttribute(int maximumLength)
        {
            _maximumLength = maximumLength;
        }

        public int MaximumLength
        {
            get { return _maximumLength; }
        }
    }

    public class People
    {
        [StringLength(8)]
        public string Name { get; set; }

        [StringLength(15)]
        public string Description { get; set; }
    }

    //如果长度大于最大长度，抛出异常
    public class ValidationModel
    {
        public void Validate( object obj)
        {
            var t = obj.GetType();
            var properties = t.GetProperties();
            foreach (var property in properties)
            {
                if (!property.IsDefined(typeof(StringLengthAttribute),false)) continue;

                var attributes = property.GetCustomAttributes(false);

                foreach (var attribute in attributes)
                {
                    var maxinumLength = (int)attribute.GetType().GetProperty("MaximumLength").GetValue(attribute);

                    //获取属性的值
                    var propertyValue = property.GetValue(obj) as string;
                    if (propertyValue == null)
                        throw new Exception("exception info");//这里可以自定义，也可以用具体系统异常类

                    if (propertyValue.Length > maxinumLength)
                        throw new Exception(string.Format("属性{0}的值{1}的长度超过了{2}", property.Name, propertyValue, maxinumLength));
                }
            }
        }
    }
}

namespace CSharpAttributeLearn
{
    [Obsolete("discard")]
    class TestObsolete
    {
        [Obsolete("discard",true)]  //true 编译错误，该方法不能在使用， false 会有warnning 提示，该方法还可以使用
        public void fun1()
        {
            Console.WriteLine("fun 1.");
        }

        public void fun2()
        {
            Console.WriteLine("fun 2.");
        }
    }
}


namespace CSharpAttributeLearn
{ 
    class TestConditional
    {
        [Conditional("add1")]  
        public void add1()
        {
            Console.WriteLine("fun 1.");
        }

        [Conditional("add2")]
        public void add2()
        {
            Console.WriteLine("fun 2.");
        }
    }
}

