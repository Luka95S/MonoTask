using System;
using System.Collections.Generic;
using System.Text;

namespace Mono.Common
{
    public interface IFilter
    {
        /// <summary>
        /// Gets or sets SearchBy value.
        /// It's used for filtering by argument
        /// </summary>
        string SearchBy { get; set; }
    }
}
