/* ==============================================================================
 * Function：  serialization and deserialization of candidates
 * Creator：Kaiqiang Chen
 * Creation time：16-Jan-2019
 * ==============================================================================*/

using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace lotterycore.newy2019
{
    public class CandidateSerialization:ICandidatesSerialization
    {

        public void serializeCandidates(Candidates candidates, string dstfile)
        {
            return;
        }
        public Candidates unserializeCandidates(string srcfile, string position)
        {
            Candidates candidates = new Candidates();
            if(File.Exists(srcfile))
            {
                using (StreamReader sr = new StreamReader(srcfile, Encoding.UTF8))
                {
                    string name;
                    while ((name = sr.ReadLine())!=null)
                    {
                        if(name!=String.Empty)
                        {
                            Candidate candidate = new Candidate(name, position);
                            candidates.Add(candidate);
                        }
                    }
                }
            }
            return candidates;
        }
    }
}
