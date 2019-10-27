using System;
using System.Collections.Generic;
using System.Text;

namespace TestTriangle.Entities.Extensions
{
    public static class IEntityExtensions
    {
        public static bool IsObjectNull(this IEntity entity)
        {
            return entity == null;
        }

        public static bool IsEmptyObject(this IEntity entity)
        {
            return entity.EmployeeId.Equals(0);
        }
    }
}
