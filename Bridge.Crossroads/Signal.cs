using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bridge.Crossroads
{
    [External]
    [Namespace(false)]
    public class Signal
    {
        public extern void Add(Delegate functionDelegate);
    }

    [External]
    [Namespace(false)]
    public class Signal<T>
    {
        public extern void Add(Action<T> functionDelegate);
    }

    [External]
    [Namespace(false)]
    public class Signal<T1, T2>
    {
        public extern void Add(Action<T1, T2> functionDelegate);
    }
}
