using System.Collections.Generic;

namespace Mono.Common
{
    public interface IEmbedCollection
    {
        ICollection<string> EmbedCollectionOfStrings { get; set; }
        string Embed { get; set; }
    }
}