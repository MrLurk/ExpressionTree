using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Models
{
    public class TableAttribute : Attribute
    {
        public string TableName { get; set; }
        public TableAttribute(string tableName)
        {
            this.TableName = tableName;
        }
    }
}
