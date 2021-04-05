using System;

namespace ET
{
    public class ResponseTypeAttribute: BaseAttribute
    {
        public Type Type { get; }

        public ResponseTypeAttribute(Type type)
        {
            Type = type;
        }
    }
}