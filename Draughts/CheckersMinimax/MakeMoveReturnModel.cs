using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckersMinimax
{
    public class MakeMoveReturnModel
    {
        
        /// Gets or sets a value indicating whether [was move made].

        /// <value>
        ///   <c>true</c> if [was move made]; otherwise, <c>false</c>.
        /// </value>
        public bool WasMoveMade { get; set; }

        
        /// Gets or sets a value indicating whether this instance is turn over.

        /// <value>
        ///   <c>true</c> if this instance is turn over; otherwise, <c>false</c>.
        /// </value>
        public bool IsTurnOver { get; set; }
    }
}
