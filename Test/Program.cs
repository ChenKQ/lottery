using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using lotterycore.newy2019;
using lotterycore;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {

            lotterycore.ICandidatesSerialization ser = new CandidateSerialization();
            lotterycore.Candidates candidates = ser.unserializeCandidates("candidates.txt");

            lotterycore.IRaffle raffle = new lotterycore.newy2019.Raffle2019();

            lotterycore.Award lvsp = new lotterycore.Award("特等奖", 2);
            lotterycore.Award lv1 = new lotterycore.Award("一", 20);
            lotterycore.Award lv2 = new lotterycore.Award("二", 25);
            lotterycore.Award lv3 = new lotterycore.Award("三", 50);


            raffle.shake(candidates, lv3);
            raffle.shake(candidates, lv2);
            raffle.shake(candidates, lv1);
            raffle.shake(candidates, lvsp);
            foreach (Candidate c in lv3.Winners)
            {
                if (candidates.Contains(c))
                {
                    Console.Write("error:" + c.Name + "\n");
                }
                else
                {
                    Console.Write(c.Name);
                }
            }

            foreach (Candidate c in lv2.Winners)
            {
                if (candidates.Contains(c))
                {
                    Console.WriteLine("error:" + c.Name + '\n');
                }
                else
                {
                    Console.Write(c.Name);
                }
            }

            foreach (Candidate c in lv1.Winners)
            {
                if(candidates.Contains(c))
                {
                    Console.WriteLine("error:" + c.Name + '\n');
                }
                else
                {
                    Console.Write(c.Name);
                }
            }

            foreach (Candidate c in lvsp.Winners)
            {
                if (candidates.Contains(c))
                {
                    Console.WriteLine("error:" + c.Name + '\n');
                }
                else
                {
                    Console.Write(c.Name);
                }
            }
            //Console.WriteLine(award.Winners[0].Name);

            //lotterycore.IAwardSerialization awardser = new AwardSerialization();
            //awardser.serializeAward(award, "特等奖.txt");


            //lotterycore.Award loadaward = awardser.unSerializeAward("特等奖.txt");
            //Console.WriteLine(loadaward.Winners[0].Name);

        }
    }
}
