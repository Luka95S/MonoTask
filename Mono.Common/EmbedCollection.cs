using System;
using System.Collections.Generic;
using System.Text;

namespace Mono.Common
{
    public class EmbedCollection : IEmbedCollection
    {
        public ICollection<string> Embed { get; set; }
    }
}
