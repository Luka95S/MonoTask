using System;
using System.Collections.Generic;
using System.Text;

namespace Mono.Common
{
    /// <summary>
    /// Model used for filtering, paging and sorting. 
    /// Prop: int Page, int NumberOfItmes, string SortOrder, string SortBy, int Skip, string SearchBy
    /// </summary>
    public class Filter : IFilter 
    {
       /// <summary>
        /// Gets or sets SearchBy value.
        /// It's used for filtering by argument
        /// </summary>
        public string SearchBy { get; set; }
    }

}
