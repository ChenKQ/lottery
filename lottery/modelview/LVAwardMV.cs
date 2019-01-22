using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using lotterycore;
using lotterycore.newy2019;

namespace lottery.modelview
{
    public class LVAwardMV : INotifyPropertyChanged
    {
        public LVAwardMV(string awardName, int numWinner, Candidates cans)
        {
            this._candidates = cans;
            this._awardName = awardName;
            this._numWinner = numWinner;
            this.Winners = new ObservableCollection<Candidate>();
        }

        private Candidates _candidates = null;
        private Award _award = null;
        private string _awardName = String.Empty;
        private int _numWinner = 0;
        public ObservableCollection<Candidate> Winners = null;

        public void writeto(Award award)
        {
            foreach(Candidate can in this.Winners)
            {
                award.addWinner(can);
                can.Win = true;
                this._candidates.Remove(can);
                this._award = null;
            }
        }

        public void reraffle(Award award)
        {
            foreach(Candidate can in this.Winners)
            {
                award.removeWinner(can);
            }
        }

        public void roll()
        {
            if (this._award != null)
            {
                foreach (Candidate can in this._award.Winners)
                {
                    can.Win = false;
                    this._candidates.Add(can);
                }
            }
            this._award = new Award(this._awardName, this._numWinner);
            IRaffle raffle = new Raffle2019();
            raffle.shake(this._candidates, this._award);

            this.Winners.Clear();
            for (int i = 0; i < this._award.Count; ++i)
            {
                this.Winners.Add(this._award.Winners[i]);
            }
        }

        public Award Award { get => _award; set => _award = value; }
        public string AwardName
        {
            get => _awardName;
            set
            {
                OnPropertyChanged("AwardName");
                _awardName = value;
            }
        }

        public int NumWinner { get => _numWinner; set => _numWinner = value; }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
