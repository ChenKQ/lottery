/* ==============================================================================
 * Function：a list of candidates
 * Creator：Kaiqiang Chen
 * Creation time：16-Jan-2019
 * ==============================================================================*/


using System.Collections.Generic;


namespace lotterycore
{

    public class Candidates : List<Candidate>
    {
        public Candidates() : base()
        {

        }

        public Candidates(IEnumerable<Candidate>  src) : base(src)
        {
        }
    }
}
