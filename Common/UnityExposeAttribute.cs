using System;
using System.Collections.Generic;

namespace Common
{
    [AttributeUsage(AttributeTargets.Class)]
    public class UnityExposeAttribute: Attribute
    {
        public List<Type> ExposedInterfaces { get; private set; }

        public UnityExposeAttribute()
        {
            ExposedInterfaces = null;
        }

        public UnityExposeAttribute(Type exposedInterface)
        {
            ExposedInterfaces = new List<Type>
            {
                exposedInterface
            };
        }

        public UnityExposeAttribute(List<Type> exposedInterfaces)
        {
            ExposedInterfaces = exposedInterfaces;
        }

    }
}
