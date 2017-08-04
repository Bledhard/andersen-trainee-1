using System;

namespace AndersenTrainee1.Domain
{
    public class BaseEntity
    {
        public int Id { get; set; }

        public virtual string SqlValuesString()
        {
            throw new NotImplementedException();
        }

        public virtual string SqlKeysString()
        {
            throw new NotImplementedException();
        }

        public virtual string SqlUpdateString()
        {
            throw new NotImplementedException();
        }
    }
}