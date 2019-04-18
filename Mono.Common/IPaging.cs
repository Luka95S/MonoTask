using System;
using System.Collections.Generic;
using System.Text;

namespace Mono.Common
{
    public interface IPaging
    {
        /// <summary>
        /// Gets or sets Page value.
        /// Default value Page = 1
        /// </summary>
        int Page { get; set; }

        /// <summary>
        /// Gets or sets NumberOfItems value (per page)
        /// In constructor is defined default value
        /// </summary>
        int NumberOfItems { get; set; }

        /// <summary>
        /// Gets or sets Skip value for skipping number of items defined by number of page.
        /// The geter is defined and calculated by the algorithm
        /// (Page - 1 ) * NumberOfItems
        /// </summary>
        int Skip { get; set; }

    }
}
