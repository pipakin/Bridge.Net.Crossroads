using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bridge.Crossroads
{
    [External]
    [Namespace(false)]
    public class Hasher : IDisposable
    {
        [Template("hasher")]
        public static Hasher Instance;

        [Name("VERSION")]
        public string Version;

        public bool Raw;

        public string AppendHash;

        public string PrependHash;

        public string Separator;

        public Signal<string, string> Changed;

        public Signal<string> Stopped;

        public Signal<string> Initialized;

        public extern void Init();

        public extern void Stop();

        public extern bool IsActive();

        public extern string GetURL();

        public extern string GetBaseURL();

        public extern void SetHash(string hash);

        public extern void ReplaceHash(string hash);

        public extern string GetHash();

        public extern string[] GetHashAsArray();

        public extern void Dispose();
    }
}
