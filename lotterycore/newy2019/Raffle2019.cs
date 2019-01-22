/* ==============================================================================
 * Function：a simple implementation of the raffle for 2019
 * Creator：Kaiqiang Chen
 * Creation time：16-Jan-2019
 * ==============================================================================*/

using System;
using System.Collections.Generic;
using System.Text;

namespace lotterycore.newy2019
{
    public class Raffle2019:IRaffle
    {
        public void shake(Candidates candidates, Award award)
        { 
            for (int i= 0; i < award.Count; ++i  )
            {
                Random rand = new Random((unchecked((int)DateTime.Now.Ticks + i)));
                int index = rand.Next(0,candidates.Count);
                Candidate winner = candidates[index];
                award.addWinner(winner);
                candidates.Remove(winner);
            }

        }
    }
}
