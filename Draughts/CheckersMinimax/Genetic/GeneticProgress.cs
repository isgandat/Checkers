using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace CheckersMinimax.Genetic
{
    [XmlRoot]
    public class GeneticProgress
    {
        private static readonly object Lock = new object();
        private static readonly string Filepath = FileNameHelper.GetExecutingDirectory() + @"GeneticProgress.xml";

        private static GeneticProgress instance;

        
        /// Gets or sets the number of random genome wins.

        /// <value>
        /// The number of random genome wins.
        /// </value>
        [XmlElement]
        public int NumberOfRandomGenomeWins
        {
            get
            {
                return numberOfRandomGenomeWins;
            }

            set
            {
                numberOfRandomGenomeWins = value;
                this.Serialize(Filepath);
            }
        }

        
        /// Gets or sets the number of games.

        /// <value>
        /// The number of games.
        /// </value>
        [XmlElement]
        public int NumberOfGames
        {
            get
            {
                return numberOfGames;
            }

            set
            {
                numberOfGames = value;
                this.Serialize(Filepath);
            }
        }

        
        /// Gets or sets the number of rounds.

        /// <value>
        /// The number of rounds.
        /// </value>
        public int NumberOfRounds
        {
            get
            {
                return numberOfRounds;
            }

            set
            {
                numberOfRounds = value;
                this.Serialize(Filepath);
            }
        }


        private int numberOfGames;
        private int numberOfRandomGenomeWins;
        private int numberOfRounds;

        
        /// Initializes a new instance of the <see cref="GeneticProgress"/> class.

        public GeneticProgress()
        {
        }

        
        /// Gets the genetic progress instance.

        /// returns= Genetic progress singleton
        public static GeneticProgress GetGeneticProgressInstance()
        {
            if (instance == null)
            {
                lock (Lock)
                {
                    if (instance == null)
                    {
                        if (File.Exists(Filepath))
                        {
                            try
                            {
                                instance = XmlSerializationHelper.Deserialize<GeneticProgress>(Filepath);
                            }
                            catch (Exception ex)
                            {
                                //If there is a problem with the progress file, just make a new one
                                instance = new GeneticProgress();
                                instance.Serialize(Filepath);
                            }
                        }
                        else
                        {
                            //create new file and save it
                            instance = new GeneticProgress();
                            instance.Serialize(Filepath);
                        }
                    }
                }
            }

            return instance;
        }

        
        /// Resets the values for this singleton.

        public void ResetValues()
        {
            numberOfGames = 0;
            numberOfRandomGenomeWins = 0;
            this.Serialize(Filepath);
        }

        
        /// Deletes the file from the disk

        public void Delete()
        {
            if (File.Exists(Filepath))
            {
                File.Delete(Filepath);
            }
        }
    }
}
