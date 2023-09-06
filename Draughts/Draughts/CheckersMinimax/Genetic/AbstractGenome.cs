using CheckersMinimax.Properties;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace CheckersMinimax.Genetic
{
    
    /// Abstract Genome Class. Holds information about the Genome
    /// </summary>
    [XmlRoot]
    public class AbstractGenome
    {
        
        /// Gets or sets the king worth gene.

        /// <value>
        /// The king worth gene.
        /// </value>
        [XmlElement]
        public int KingWorthGene { get; set; }

        
        /// Gets or sets the pawn worth gene.

        /// <value>
        /// The pawn worth gene.
        /// </value>
        [XmlElement]
        public int PawnWorthGene { get; set; }

        
        /// Gets or sets the pawn danger value gene.

        /// <value>
        /// The pawn danger value gene.
        /// </value>
        [XmlElement]
        public int PawnDangerValueGene { get; set; }

        
        /// Gets or sets the king danger value gene.

        /// <value>
        /// The king danger value gene.
        /// </value>
        [XmlElement]
        public int KingDangerValueGene { get; set; }
    }
}
