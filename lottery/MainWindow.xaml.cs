using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using lottery.modelview;
using lotterycore;
using lotterycore.newy2019;

namespace lottery
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            loadCandidates();
            loadAward();
            InitializeComponent();
            bind();
            
        }

        private Candidates _allCandidates = null;
        private modelview.LVAwardMV _awardMV = null;
        private Award _lv3 = null;
        private Award _lv2 = null;
        private Award _lv1 = null;
        private Award _lvsp = null;
        private Award _currentLV = null;
        private bool allowRoll = false;
        private int _numWinner = 2;

        public LVAwardMV AwardMV { get => _awardMV; set => _awardMV = value; }

        private void loadCandidates()
        {
            if (this._allCandidates == null)
            {
                this._allCandidates = new Candidates();
            }
            string currentDir = Directory.GetCurrentDirectory();
            string candidatesDir = System.IO.Path.Combine(currentDir, "candidates");
            DirectoryInfo dirCan = new DirectoryInfo(candidatesDir);
            FileInfo[] files = dirCan.GetFiles();

            foreach(FileInfo f in files)
            {
                string filePrefixName = System.IO.Path.GetFileNameWithoutExtension(f.Name);
                ICandidatesSerialization canser = new lotterycore.newy2019.CandidateSerialization();
                Candidates cans = canser.unserializeCandidates(f.FullName, filePrefixName);
                this._allCandidates.AddRange(cans);
            }
        }

        private void loadAward()
        {
            this.AwardMV = new modelview.LVAwardMV("三等奖", this._numWinner, this._allCandidates);
            this._lv3 = new Award("三等奖", Properties.Settings.Default.lv3award);
            this._currentLV = this._lv3;
            this.AwardMV.AwardName = "三等奖";
        }

        private void reset()
        {
            this._allCandidates = null;
            this._awardMV = null;
            this._lv1 = null;
            this._lv2 = null;
            this._lv3 = null;
            this._lvsp = null;
            this._currentLV = this._lv1;
            this.allowRoll = false;
            this._numWinner = 2;
            this.loadCandidates();
            this.loadAward();
            this.bind();
        }


        private void bind()
        {
            this.lb_awardName.DataContext = this.AwardMV;
            this.listbox_winners.DataContext = this.AwardMV.Winners;
        }

        private void Bt_close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            App.Current.Shutdown();
        }

        private void Grid_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            try
            {
                this.DragMove();
            }
            catch
            { }
            
        }

        private void Lb_lv3_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            this.allowRoll = !this.allowRoll;
        }

        private void Menu_reset_Click(object sender, RoutedEventArgs e)
        {
            reset();
        }


        private void Lb_awardName_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.allowRoll = !this.allowRoll;
            if(!this.allowRoll)
            {
                this._awardMV.writeto(this._currentLV);
            }
        }

        private void Lb_awardName_MouseMove(object sender, MouseEventArgs e)
        {
            if (allowRoll)
            {
                this._awardMV.roll();
            }
        }

        private void Menu_lv3_Click(object sender, RoutedEventArgs e)
        {
            this._lv3 = new Award("三等奖", Properties.Settings.Default.lv3award);
            this._currentLV = this._lv3;
            this.AwardMV.AwardName = "三等奖";


            this._lv3 = new Award("三等奖", Properties.Settings.Default.lv3award);
            this._currentLV = this._lv3;
            this.AwardMV.AwardName = "三等奖";

        }

        private void Menu_lv2_Click(object sender, RoutedEventArgs e)
        {
            this.AwardMV.AwardName = "二等奖";
            this._lv2 = new Award("二等奖", Properties.Settings.Default.lv2award);
            this._currentLV = this._lv2;

            this._lv2 = new Award("二等奖", Properties.Settings.Default.lv2award);
            this._currentLV = this._lv2;
            this.AwardMV.AwardName = "二等奖";
        }

        private void Menu_lv1_Click(object sender, RoutedEventArgs e)
        {
            this._lv1 = new Award("一等奖", Properties.Settings.Default.lv1award);
            this._currentLV = this._lv1;
            this.AwardMV.AwardName = "一等奖";

            this._lv1 = new Award("一等奖", Properties.Settings.Default.lv1award);
            this._currentLV = this._lv1;
            this.AwardMV.AwardName = "一等奖";
        }

        private void Menu_lvsp_Click(object sender, RoutedEventArgs e)
        {
            this._lvsp = new Award("特等奖", Properties.Settings.Default.lvspaward);
            this._currentLV = this._lvsp;
            this.AwardMV.AwardName = "特等奖";

            this._lvsp = new Award("特等奖", Properties.Settings.Default.lvspaward);
            this._currentLV = this._lvsp;
            this.AwardMV.AwardName = "特等奖";
        }

        private void Menu_num1_Click(object sender, RoutedEventArgs e)
        {
            this._numWinner = 1;
            this.AwardMV.NumWinner = this._numWinner;
        }

        private void Menu_num2_Click(object sender, RoutedEventArgs e)
        {
            this._numWinner = 2;
            this.AwardMV.NumWinner = this._numWinner;
        }

        private void Menu_num3_Click(object sender, RoutedEventArgs e)
        {
            this._numWinner = 3;
            this.AwardMV.NumWinner = this._numWinner;
        }

        private void Menu_reset_cur_Click(object sender, RoutedEventArgs e)
        {
            this._awardMV.reraffle(this._currentLV);
        }

        private void Menu_save_Click(object sender, RoutedEventArgs e)
        {
            IAwardSerialization ser = new AwardSerialization();
            ser.serializeAward(this._lv3,"lv3.txt");
            ser.serializeAward(this._lv2, "lv2.txt");
            ser.serializeAward(this._lv1, "lv1.txt");
            ser.serializeAward(this._lvsp, "lvsp.txt");
        }
    }
}
