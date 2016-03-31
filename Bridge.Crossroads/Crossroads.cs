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
    [Name("crossroads")]
    public class Crossroads
    {
        [Name("NORM_AS_ARRAY")]
        public static extern object NormalizeAsArray(string request, dynamic vals);

        [Name("NORM_AS_OBJECT")]
        public static extern object NormalizeAsObject(string request, dynamic vals);

        [Name("VERSION")]
        public static string Version;

        public static bool Greedy;

        public static bool GreedyEnabled;

        [Template("crossroads")]
        public static Crossroads Instance;

        public extern Route AddRoute(string pattern);
        public extern Route AddRoute(string pattern, Delegate handler);
        public extern Route AddRoute(string pattern, Delegate handler, int priority);

        public extern void RemoveRoute(Route route);

        public extern void RemoveAllRoutes();

        public  extern void Parse(string request);
        public extern void Parse(string request, object[] defaultArgs);

        public extern int GetNumRoutes();

        public Signal<string> Bypassed;

        public Signal<string, dynamic> Routed;

        public extern Crossroads Create();

        public Func<string, dynamic, object> NormalizeFn;

        public bool ShouldTypecast;

        public bool IgnoreState;

        public extern void Pipe(Crossroads router);

        public static extern void Unpipe(Crossroads router);
    }
}
