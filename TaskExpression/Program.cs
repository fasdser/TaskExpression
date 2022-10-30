using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace TaskExpression
{
    internal class Program
    {
        static void Main(string[] args)
        {

            ParameterExpression x =Expression.Parameter(typeof(int), "x");

            var const1 = Expression.Constant(3);
            var const2 = Expression.Constant(2);
            var const3 = Expression.Constant(4);
            var minusSet = Expression.Subtract(x, const1);
            var multiplySet = Expression.Multiply(minusSet,const2);
            var plusSet = Expression.Add(multiplySet,x);
            var minSet = Expression.Subtract(plusSet, const3);

            var expression = Expression.Lambda<Func<int, int>>(minSet, x);

            Console.WriteLine(expression);

            Func<int, int> func = expression.Compile();

            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("Результыт: {0}",func(i));
       
            }

            Console.ReadLine();
        }
       
    }
}
