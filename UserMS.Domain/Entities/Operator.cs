using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserMS.Commons.Enums;

namespace UserMS.Domain.Entities
{
    public class Operator
    {
        public Guid OperatorId { get; private set; }
        public string? Name { get;  set; }
        public int Age { get;  set; }
        public OpState State { get;  set; }

        public Operator( String name, int age, OpState state) { 
            
            OperatorId = new Guid();
            Name = name;
            Age = age;
            State = state;
        
        }

        public Operator() { }


    }


}
