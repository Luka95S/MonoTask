using System;
using System.Collections.Generic;
using System.Text;

namespace Mono.Common
{
    public interface ISorting
    {
        /// <summary>
        /// Gets or sets SortOrder value.
        /// It's used for passing parameter for sorting (ascending or descending)
        /// </summary>
        string SortOrder { get; set; }

        /// <summary>
        /// Gets or sets SortBy value.
        /// It's used for passing parameter for sorting by specific property
        /// etc. Name or Abrv 
        /// </summary>
        string SortBy { get; set; }
    }
}
