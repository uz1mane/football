using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab12
{
    public partial class Form1 : Form
    {
        public Random rand;

        public Team team1, team2, team3, team4, team5, team6, team7, team8;        

        const double l = 1;
        
        public Form1()
        {            
            InitializeComponent();

            rand = new Random();
        }

        class TeamComparer : IComparer<Team>
        {
            public int Compare(Team team1, Team team2)
            {
                if (team1.score> team2.score)
                    return 1;
                else if (team1.score < team2.score)
                    return -1;
                else
                    return 0;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            team1 = new Team(tb1.Text);
            team2 = new Team(tb2.Text);
            team3 = new Team(tb3.Text);
            team4 = new Team(tb4.Text);
            team5 = new Team(tb5.Text);
            team6 = new Team(tb6.Text);
            team7 = new Team(tb7.Text);
            team8 = new Team(tb8.Text);

            Team[] teams = new Team[8] { team1, team2, team3, team4, team5, team6, team7, team8 };

            for (int i = 0; i < 8; i++)
            {
                for (int k = i; k < 8; k++)
                {
                    int result = Football(teams[i], teams[k]);
                    switch (result)
                    {
                        case 1:
                            teams[i].score += 3;
                            break;

                        case 2:
                            teams[k].score += 3;
                            break;

                        case 0:
                            teams[k].score++;
                            teams[i].score++;
                            break;

                        default:
                            break;
                    }
                }

            }

            Array.Sort(teams, new TeamComparer());

            lbEights.Text = teams[0].name;
            lbSeventh.Text = teams[1].name;
            lbSixth.Text = teams[2].name;
            lbFifth.Text = teams[3].name;
            lbFouth.Text = teams[4].name;
            lbThird.Text = teams[5].name;
            lbSecond.Text = teams[6].name;
            lbFirst.Text = teams[7].name;

            lbScore8.Text = teams[0].score.ToString();
            lbScore7.Text = teams[1].score.ToString();
            lbScore6.Text = teams[2].score.ToString();
            lbScore5.Text = teams[3].score.ToString();
            lbScore4.Text = teams[4].score.ToString();
            lbScore3.Text = teams[5].score.ToString();
            lbScore2.Text = teams[6].score.ToString();
            lbScore1.Text = teams[7].score.ToString();
        }
        public int Football(Team team1, Team team2)
        {
            int score1 = Puasson();
            int score2 = Puasson();
            if (score1 > score2) return 1;
            if (score1 < score2) return 2;
            if (score1 == score2) return 0;
            return 0;
        }
        public int Puasson()
        {
            double S = 0;
            int m = 0;
            do
            {
                double alpha = rand.NextDouble();
                S += Math.Log(alpha);
                m++;
            } 
            while (S >= -l);
            return m - 1;
        }
    }
}
