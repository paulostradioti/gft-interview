using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entites
{
    /// <summary>
    /// Base Entity provides an Id and a Name that are being used by severam entities in the system. 
    /// It could be used by persistence purposes, for example.
    /// </summary>
    public class BaseEntity
    {
        public BaseEntity(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public int Id { get; private set; }
        public String Name { get; private set; }
    }
}
