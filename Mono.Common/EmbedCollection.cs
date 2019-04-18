using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Mono.Common
{
    public class EmbedCollection : IEmbedCollection
    {
        /// <summary>
        /// Gets or sets EmbedCollectionOfStrings
        /// </summary>
        public ICollection<string> EmbedCollectionOfStrings { get; set; } = new Collection<string>();

        /// <summary>
        /// Gets or sets Embed
        /// </summary>
        public string Embed
        {
            get
            {
                string completeEmbed = "";
                foreach (string item in EmbedCollectionOfStrings)
                {
                    if (completeEmbed == "")
                    {
                        completeEmbed = item;
                    }
                    else
                    {
                        completeEmbed = completeEmbed + "." + item;
                    }
                }
                return completeEmbed;
            }
            set { }
        }

        /// <summary>
        /// Constructor . adds first item to collection
        /// </summary>
        /// <param name="item"></param>
        public EmbedCollection(string item)
        {
            EmbedCollectionOfStrings.Add(item);
        }
    }
}
