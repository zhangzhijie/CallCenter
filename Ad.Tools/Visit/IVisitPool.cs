using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ad.Visit
{
    public interface IVisitPool<T>
    {
        int Count { get; }
        void Input(T visitData);
        T Remove();

        void Clear();
    }
}
