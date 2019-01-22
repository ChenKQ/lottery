/* ==============================================================================
 * Function：  candidate of the lottery
 * Creator：Kaiqiang Chen
 * Creation time：16-Jan-2019
 * ==============================================================================*/

using System;

namespace lotterycore
{
    public class Candidate
    {
        public Candidate()
        { }

        public Candidate(string name, string position, uint proweight = 1, bool qualified = true, bool win = false)
        {
            this._name = name;
            this._position = position;
            this._probweight = proweight;
            this._quialified = qualified;
            this._win = false;
            this._win = win;
        }

        private string _name = String.Empty;
        private string _position = String.Empty;
        private uint _probweight = 1;
        private bool _quialified = true;
        private bool _win = false;

        /// <summary>
        /// The name of the candicate.
        /// </summary>
        public string Name { get => _name; set => _name = value; }

        /// <summary>
        /// The position of the candidate: student, leader, employee and so on.
        /// </summary>
        public string Position { get => _position; set => _position = value; }

        /// <summary>
        /// Weight of the probalility to increase the possibility.
        /// </summary>
        public uint Probweight { get => _probweight; set => _probweight = value; }

        /// <summary>
        /// If this candidate is qualified to win the lottery.
        /// </summary>
        public bool Quialified { get => _quialified; set => _quialified = value; }

        /// <summary>
        /// If this candidate has won a lottery.
        /// </summary>
        public bool Win { get => _win; set => _win = value; }
    }
}
