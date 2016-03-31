using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bridge.Crossroads
{
    [External]
    [Namespace(false)]
    public class Route
    {
        /// <summary>
        /// Signal dispatched every time a request matches the route pattern.
        /// </summary>
        /// <remarks>Signal handlers will receive all parameters captured by the Route pattern.</remarks>
        public Signal Matched;

        /// <summary>
        /// Signal dispatched every time a request "leaves" the route.
        /// </summary>
        /// <remarks>Signal handlers will receive the "request" string passed to crossroads.parse()</remarks>
        public Signal<string> Switched;

        /// <summary>
        /// Object used to configure parameters/segments validation rules.
        ///
        /// Validation rules can be an Array, a RegExp or a Function:
        /// 
        /// * If rule is an Array, crossroads will try to match a request segment against items of the Array, 
        ///   if item is found parameter is valid.
        /// * If rule is a RegExp, crossroads will try to match a request segment against it.
        /// * If rule is a Function, crossroads will base validation on value returned by Function(should 
        ///   return a Boolean).
        /// 
        /// Rules keys should match route pattern segment names or should be a numeric value, starting at 
        /// index 0, that match each RegExp capturing group or path segment.
        /// 
        /// The rules object can also contain 2 special properties request_ and normalize_:
        /// 
        /// normalize_:Function(request, values)
        ///     Used to modify/normalize values before dispatching the matched Signal. It should return an 
        ///     Array with parameters that should be passed to listeners.
        /// 
        ///     Can be used to create route aliases and also to convert data format.
        ///     
        ///     Works exactly like crossroads.normalizeFn.It will overwrite crossroads.normalizeFn if present.
        /// 
        /// request_:*
        ///     Rule used to validate whole request.
        /// 
        ///     It is important to note that values and requests are typecasted if 
        ///     Router.shouldTypecast = true(it's false by default).
        /// 
        /// 
        /// All the properties of the rules object are optional, you can specify only the segments you 
        /// want to validate.
        /// </summary>
        public object Rules;

        /// <summary>
        /// If crossroads should try to match this Route even after matching another Route.
        /// 
        /// Default value is false.
        /// 
        /// Crossroads will trigger all "greedy" Routes that matches the request during parse.
        /// </summary>
        public bool Greedy;

        /// <summary>
        /// Remove route from crossroads and destroy it, releasing memory.
        /// </summary>
        public extern void Dispose();

        /// <summary>
        /// Test if Route matches against request.
        /// </summary>
        /// <param name="request">request to match.</param>
        /// <returns>true if request validates against route rules and pattern.</returns>
        public extern bool Match(string request);

        /// <summary>
        /// Return a string that matches the route replacing the capturing groups with the values provided 
        /// in the replacements object. If the generated string doesn't pass the validation rules it 
        /// throws an error.
        /// </summary>
        /// <param name="replacements">Replacements to insert in the string</param>
        /// <returns>The interpolated string.</returns>
        public extern string Interpolate(object replacements);
    }
}
