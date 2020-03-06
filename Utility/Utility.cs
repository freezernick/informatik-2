using System;
using System.Collections.Generic;
using System.Linq;

namespace GameMaster
{
    public static class Utility
    {
        public static IEnumerable<Type> FindSubClassesOf<TBaseType>()
        {
            var baseType = typeof(TBaseType);
            var assembly = baseType.Assembly;

            return assembly.GetTypes().Where(t => t.IsSubclassOf(baseType));
        }
    }
}