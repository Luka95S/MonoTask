using System.Collections.Generic;

namespace Mono.Common
{
    public interface IEmbedCollection
    {
        /// <summary>
        /// Gets or sets EmbedCollectionOfStrings
        /// </summary>
        ICollection<string> EmbedCollectionOfStrings { get; set; }

        /// <summary>
        /// Gets or sets Embed
        /// </summary>
        string Embed { get; set; }
    }
}