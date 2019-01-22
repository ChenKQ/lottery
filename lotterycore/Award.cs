/* ==============================================================================
 * Function：  award
 * Creator：Kaiqiang Chen
 * Creation time：16-Jan-2019
 * ==============================================================================*/

using System;
using System.Collections.Generic;

namespace lotterycore
{
    public class Award
    {
        public Award()
        { }

        public Award(string name, int count)
        {
            this._name = name;
            this._count = count;
            this.Winners = null;
        }

        public void addWinner(Candidate winner)
        {
            winner.Win = true;
            if (this._winners == null)
                this._winners = new Candidates();
            this._winners.Add(winner);
        }

        public void removeWinner(Candidate winner)
        {
            if(this._winners !=null && this._winners.Count>0)
            {
                if(this._winners.Contains(winner))
                {
                    winner.Win = false;
                    this._winners.Remove(winner);
                }
                else
                {
                    throw new Exception("the winner is not in the winner list");
                }
                
            }
            else
            {
                throw new Exception("Nothing in the winner list");
            }
        }

        private string _name = String.Empty;
        private int _count = 0;
        private Candidates _winners = null;

        /// <summary>
        /// the name of the award
        /// </summary>
        public string Name { get => _name; }

        /// <summary>
        /// the number of winners
        /// </summary>
        public int Count { get => _count; }

        /// <summary>
        /// the winners who won this award
        /// </summary>
        public Candidates Winners { get => _winners; set => _winners = value; }
    }
}
