using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckersMinimax.Clone
{
// Interface for a clonable object

    public interface IMinimaxClonable
    {
    
        // Gets the minimax clone.
     
        // return:A clone to be used in the minimax algoritm
        object GetMinimaxClone();
    }
}
