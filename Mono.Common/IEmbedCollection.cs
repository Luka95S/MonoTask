using System.Collections.Generic;

namespace Mono.Common
{
    public interface IEmbedCollection
    {
        ICollection<string> Embed { get; set; }
    }
}