using System;
using System.Linq.Expressions;

namespace lambdaLearn
{
    class Program
    {
        delegate int del(int i);  //定义一个委托类型

        static void Main(string[] args)
        {
            //For example, the lambda expression x => x * x specifies a parameter 
            //that’s named x and returns the value of x squared. You can assign this expression to a delegate type

            del myDelegate = x => x * x;  //采用lambda定义委托 
            int j = myDelegate(5);

            Expression<del> myET = x => x * x;  //采用lambda定义表达式类型 

            int y = Myfun(5);

        
            
        }

         static int Myfun(int s) => s* s;
    }
}
