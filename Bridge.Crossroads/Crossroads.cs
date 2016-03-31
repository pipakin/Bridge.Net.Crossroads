using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bridge.Html5;

namespace Bridge.Crossroads
{
    [External]
    [Namespace(false)]
    public class Router
    {
        public extern Route AddRoute(string pattern);
        public extern Route AddRoute(string pattern, Delegate handler);
        public extern Route AddRoute(string pattern, Delegate handler, int priority);

        public extern void RemoveRoute(Route route);

        public extern void RemoveAllRoutes();

        public extern void Parse(string request);
        public extern void Parse(string request, object[] defaultArgs);

        public extern int GetNumRoutes();

        public Signal<string> Bypassed;

        public Signal<string, dynamic> Routed;

        public extern Router Create();

        public Func<string, dynamic, object> NormalizeFn;

        public bool ShouldTypecast;

        public bool IgnoreState;

        public extern void Pipe(Router router);

        public extern void Unpipe(Router router);

    }

    [External]
    [Namespace(false)]
    public static class Crossroads
    {
        [Name("NORM_AS_ARRAY")]
        public static extern object NormalizeAsArray(string request, dynamic vals);

        [Name("NORM_AS_OBJECT")]
        public static extern object NormalizeAsObject(string request, dynamic vals);

        [Name("VERSION")]
        public static string Version;

        public static bool Greedy;
        public static bool GreedyEnabled;

        public static extern Route AddRoute(string pattern);
        public static extern Route AddRoute(string pattern, Delegate handler);
        public static extern Route AddRoute(string pattern, Delegate handler, int priority);

        public static extern void RemoveRoute(Route route);

        public static extern void RemoveAllRoutes();

        public static  extern void Parse(string request);
        public static extern void Parse(string request, object[] defaultArgs);

        public static extern int GetNumRoutes();

        public static Signal<string> Bypassed;

        public static Signal<string, dynamic> Routed;

        public static extern Router Create();

        public static Func<string, dynamic, object> NormalizeFn;

        public static bool ShouldTypecast;

        public static bool IgnoreState;

        public static extern void Pipe(Router router);

        public static extern void Unpipe(Router router);
    }
}
