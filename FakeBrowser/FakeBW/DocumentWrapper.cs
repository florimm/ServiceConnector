using System.Collections.Generic;
using System.Linq;
using System.Text;
using CsQuery;

namespace FakeBW
{
    /// <summary>
    /// A basic wrapper around CsQuery
    /// </summary>
    public class DocumentWrapper
    {
        private readonly CQ document;

        /// <summary>
        /// Initializes a new instance of the <see cref="DocumentWrapper"/> class.
        /// </summary>
        /// <param name="buffer">The document represented as a byte array.</param>
        public DocumentWrapper(IEnumerable<byte> buffer)
        {
            var characters =
                Encoding.UTF8.GetString(buffer.ToArray()).ToCharArray();

            this.document = CQ.Create(characters);
        }

        /// <summary>
        /// Gets elements from CSS3 selectors
        /// </summary>
        /// <param name="selector">The CSS3 selector that should be applied.</param>
        /// <returns>A <see cref="QueryWrapper"/> instance.</returns>
        public QueryWrapper this[string selector]
        {
            get { return this.document.Select(selector); }
        }
    }
}