using Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection.Emit;
using System.Threading.Tasks;

namespace Api.Services
{
    public class ExpressionServices
    {
        /// <summary>
        /// 加法相加表达式树测试
        /// </summary>
        public void NoParaPlusExpressionTest()
        {
            // Expression<Func<int>> expression = () => 2+ 3;
            var left = Expression.Constant(2);
            var right = Expression.Constant(3);
            var plus = Expression.Add(left, right);

            Expression<Func<int>> exp = Expression.Lambda<Func<int>>(plus);
            var res = exp.Compile().Invoke();
            Console.WriteLine($"无参数加法表达式树结果为:{res}");
        }

        /// <summary>
        /// 加法相加表达式树测试
        /// </summary>
        public void ParaPlusMultiplyExpressionTest()
        {
            // Expression<Func<int, int, int>> expression = (m, n) => m * n + m + n * 2 + 2;
            ParameterExpression m = Expression.Parameter(typeof(int), "m");
            ParameterExpression n = Expression.Parameter(typeof(int), "n");
            var _2 = Expression.Constant(2);
            var expMutiply1 = Expression.Multiply(m, n);
            var plus1 = Expression.Add(expMutiply1, m);
            var expMutiply2 = Expression.Multiply(n, _2);
            var plus2 = Expression.Add(plus1, expMutiply2);
            var plus3 = Expression.Add(plus2, _2);

            Expression<Func<int, int, int>> exp = Expression.Lambda<Func<int, int, int>>(plus3, m, n);
            var res = exp.Compile().Invoke(2, 3);
            Console.WriteLine($"带参数加法,乘法表达式树结果为:{res}");
        }


        public void ParaObjectExpressionTest()
        {
            // Expression<Func<Student, bool>> expression = x => x.Age.ToString().Equals("18");
            ParameterExpression x = Expression.Parameter(typeof(Student), "x");
            var _age = Expression.Constant("18");
            var propAge = typeof(Student).GetProperty("Age");
            var methodToString = typeof(int).GetMethod("ToString", new Type[] { });
            var methodEquals = typeof(string).GetMethod("Equals", new Type[] { typeof(string) });
            var exp1 = Expression.Property(x, propAge);
            var exp2 = Expression.Call(exp1, methodToString);
            var exp3 = Expression.Call(exp2, methodEquals, _age);

            Expression<Func<Student, bool>> expression = Expression.Lambda<Func<Student, bool>>(exp3, x);
            var res = expression.Compile()(new Student()
            {
                Id = 1,
                Age = 18,
                Name = "张三"
            });
            Console.WriteLine($"带参数对象表达式树结果为:{res}");
        }
    }
}
