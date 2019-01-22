/* ==============================================================================
 * Function：  the interface for serialization
 * Creator：Kaiqiang Chen
 * Creation time：16-Jan-2019
 * ==============================================================================*/

using System;
using System.Collections.Generic;
using System.Text;

namespace lotterycore
{
    public interface ICandidatesSerialization
    {
        void serializeCandidates(Candidates candidates, string dstfile);
        Candidates unserializeCandidates(string srcfile, string position="");
    }
}
