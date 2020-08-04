using Api.ExpressionExt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Api.Repositorys
{
    public class DBHelper<T>
    {
        public static IList<T> Where(Expression<Func<T, bool>> expression)
        {
            var a = new MyExpressionVisitor();
            a.Visit(expression);
            var sql = a.MarkUp<T>();
            Console.WriteLine(sql);
            return null;
        }
    }
}
