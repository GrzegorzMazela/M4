using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Text;

namespace M4.DataAccess.UnitOfWork.MongoDb
{
    public interface IBaseEntity
    {
        ObjectId Id { get; set; }
    }
}
