using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Mono.Common
{
    public class EmbedCollection : IEmbedCollection
    {
        public ICollection<string> EmbedCollectionOfStrings { get; set; } = new Collection<string>(); 

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

        public EmbedCollection(string item)
        {
            EmbedCollectionOfStrings.Add(item);
        }
    }
}
