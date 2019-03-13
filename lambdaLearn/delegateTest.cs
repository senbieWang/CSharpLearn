using System;
using System.Collections.Generic;
using System.Text;

namespace lambdaLearn
{
    class delegateTest
    {

        public delegate int del(int i);  //定义一个委托类型

        public int add(int i)
        {
            return i + i;
        }

         public int mty(int i)
        {
            return i * i;
        }

        public int div(int i)
        {
            return i - i;
        }

        public int get(del fun,int i)
        {
            return fun(i);
        }


        //.net中已经定义好的委托类型  
        //Action  两种方式： 1、无参数无返回   2、有1-16个参数无返回值额泛型委托
        // 1、无参数无返回   public delegate void Action();
        // 2、有1-16个参数无返回值额泛型委托  public delegate void Action<in T>(T obj);

        public void Say1()
        {
            Console.WriteLine("hellow");
        }

        public void Say(string say)
        {
            Console.WriteLine(say);
        }

        public void Say2(string say,string say2)
        {
            Console.WriteLine(say+say2);
        }

        public void GetAction(Action<string,string> action,string i)
        {
             action(i,i);
        }
        public void GetAction(Action<string> action, string i)
        {
            action(i);
        }

        //.net中已经定义好的委托类型   
        //有输入，有返回的委托 func  必须有返回值，输入参数 1-16
       
        //总结：
        //Action：无参数无返回值委托。
        //Action<T>：泛型委托，无返回值，根据输入参数的个数不同有十六个重载。
        //Func< out T>：无输入参数，有返回值。
        //Func<in T,out T>：有输入参数，有返回值，根据输入参数个数不同，有十六个重载。
        //Action和Func中可以使用Lambda和匿名方法处理方法体内逻辑。
    }
}
