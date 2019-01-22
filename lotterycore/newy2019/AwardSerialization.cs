/* ==============================================================================
 * Function：  serialization and deserialization of award
 * Creator：Kaiqiang Chen
 * Creation time：16-Jan-2019
 * ==============================================================================*/


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Web.Script.Serialization;
using System.Runtime.Serialization;

namespace lotterycore.newy2019
{
    public class AwardSerialization:IAwardSerialization
    {
        public void serializeAward(Award award, string dstfile)
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            string contents = serializer.Serialize(award);
            using (StreamWriter sw = new StreamWriter(dstfile))
            {
                sw.Write(contents);
            }
        }

        /// <summary>
        /// TODO: DEBUG, some bugs with this method
        /// </summary>
        /// <param name="srcfile"></param>
        /// <returns></returns>
        public Award unSerializeAward(string srcfile)
        {           
            if (File.Exists(srcfile))
            {
                JavaScriptSerializer deser = new JavaScriptSerializer();
                string contents;
                using (StreamReader sr = new StreamReader(srcfile))
                {
                    contents = sr.ReadToEnd();
                }
                Type c = typeof(Candidates);
                Award award = deser.Deserialize<Award>(contents);
                return award;
            }
            else
                throw new Exception("file: " + srcfile + " does not exist.");

        }
    }
}
