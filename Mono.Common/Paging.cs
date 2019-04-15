using System;
using System.Collections.Generic;
using System.Text;

namespace Mono.Common
{
    public class Paging : IPaging
    {
        /// <summary>
        /// Gets or sets Page value.
        /// Default value Page = 1
        /// </summary>
        public int Page { get; set; } = 1;

        /// <summary>
        /// Gets or sets NumberOfItems value (per page)
        /// In constructor is defined default value
        /// </summary>
        public int NumberOfItems { get; set; }

        /// <summary>
        /// Gets or sets Skip value for skipping number of items defined by number of page.
        /// The geter is defined and calculated by the algorithm
        /// (Page - 1 ) * NumberOfItems
        /// </summary>
        public int Skip
        {
            get
            {
                return (Page - 1) * NumberOfItems;
            }
            set { }
        }

        /// <summary>
        /// Filter constructor
        /// - sets value for number of items on page when a new instance is initialized
        /// </summary>
        public Paging()
        {
            NumberOfItems = 5;
        }
    }
}
