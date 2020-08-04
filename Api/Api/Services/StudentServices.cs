using Api.Models;
using Api.Repositorys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection.Emit;
using System.Threading.Tasks;

namespace Api.Services
{
    public class StudentServices
    {
        public StudentServices()
        {

        }

        public IList<Student> GetAllStudent()
        {
            var res = DBHelper<Student>.Where(x => x.Id == 1 && x.Name == "张三" && x.Age == 18 && x.Name.StartsWith("张")&& x.Name.EndsWith("三")&&x.Name.Contains("三"));
            return res;
        }
    }
}
