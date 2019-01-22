/* ==============================================================================
 * Function：  the interface for raffle
 * Creator：Kaiqiang Chen
 * Creation time：16-Jan-2019
 * ==============================================================================*/

using System;
using System.Collections.Generic;
using System.Text;

namespace lotterycore
{
    public interface IRaffle
    {
        void shake(Candidates candidates, Award award);
    }
}
