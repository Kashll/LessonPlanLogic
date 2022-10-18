using System;
using System.Collections.Generic;

namespace LessonPlanLogic
{
    public class TopicEqualityComparer : IEqualityComparer<Topic>
    {
        public bool Equals(Topic x, Topic y)
        {
            if (ReferenceEquals(x, y)) return true;
            if (ReferenceEquals(x, null)) return false;
            if (ReferenceEquals(y, null)) return false;
            if (x.GetType() != y.GetType()) return false;
            return x.Name == y.Name;
        }

        public int GetHashCode(Topic obj)
        {
            return HashCode.Combine(obj.Name);
        }
    }
}