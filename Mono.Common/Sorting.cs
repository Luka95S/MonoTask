using System;
using System.Collections.Generic;
using System.Text;

namespace Mono.Common
{
    public class Sorting : ISorting
    {
        /// <summary>
        /// Gets or sets SortOrder value.
        /// It's used for passing parameter for sorting (ascending or descending)
        /// </summary>
        public string SortOrder { get; set; } = "asc";

        /// <summary>
        /// Gets or sets SortBy value.
        /// It's used for passing parameter for sorting by specific property
        /// etc. Name or Abrv 
        /// </summary>
        public string SortBy { get; set; }
    }
}
