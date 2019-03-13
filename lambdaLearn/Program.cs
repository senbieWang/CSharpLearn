using System;
using System.Linq.Expressions;

namespace lambdaLearn
{
    class Program
    {
        
        //匿名函数、lambda、委托、Action委托、Funs委托
        static void Main(string[] args)
        {
            //委托学习
            delegateTest delegateTest = new delegateTest();
            delegateTest.get(delegateTest.add, 5);
            delegateTest.get(delegateTest.div, 5);
            delegateTest.get(delegateTest.mty, 5);

        }
    }
}
