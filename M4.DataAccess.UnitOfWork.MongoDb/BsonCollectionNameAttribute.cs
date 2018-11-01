using System;
using System.Collections.Generic;
using System.Text;

namespace M4.DataAccess.UnitOfWork.MongoDb
{
    [AttributeUsage(AttributeTargets.Class)]
    public class BsonCollectionNameAttribute : Attribute
    {
		public string Name { get; set; }

		public BsonCollectionNameAttribute(string name)
        {
            this.Name = name;
        }
    }
}
