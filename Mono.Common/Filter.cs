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
        /// Gets or sets SortOrder value.
        /// It's used for passing parameter for sorting (ascending or descending)
        /// </summary>
        public string SortOrder { get; set; }

        /// <summary>
        /// Gets or sets SortBy value.
        /// It's used for passing parameter for sorting by specific property
        /// etc. Name or Abrv 
        /// </summary>
        public string SortBy { get; set; }

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
        /// Gets or sets SearchBy value.
        /// It's used for filtering by argument
        /// </summary>
        public string SearchBy { get; set; }

        /// <summary>
        /// Filter constructor
        /// - sets value for number of items on page when a new instance is initialized
        /// </summary>
        public Filter() 
        {
            NumberOfItems = 5;
        }
    }

}
