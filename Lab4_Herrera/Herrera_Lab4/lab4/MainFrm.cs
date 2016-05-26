using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab3new
{
    public partial class MainFrm : Form
    {
        public static myLeagueDataContext database = new myLeagueDataContext();
        List<Query4> query4List;

        public static bool game_flag = false;
        public MainFrm()
        {
            InitializeComponent();
            dataGridView1.DataSource = bindingSource1;
            dataGridView1.AutoGenerateColumns = true;
        //    bindingSource1.DataSource = database.player_tbls;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            comboBox1.DataSource = database.team_tbls;
            comboBox1.DisplayMember = "name";//fill combobox         
            comboBox2.DataSource = database.team_tbls;
            comboBox2.DisplayMember = "name";//fill combobox 
        }

        private void button1_Click(object sender, EventArgs e)
        {
            playerFrm pf = new playerFrm();
            pf.Show();
                  
        }

        private void button2_Click(object sender, EventArgs e)
        {
            player_stats_frm psf = new player_stats_frm();
            psf.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            teamFrm tf = new teamFrm();
            tf.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            game_results gf = new game_results();
            gf.Show();
        }

        private void MainFrm_Load(object sender, EventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)//Query #1
        {
            string selected = this.comboBox1.GetItemText(this.comboBox1.SelectedItem);
            if (selected == "All")
                MessageBox.Show("All is not required for this query");
            game_flag = false;//Query 1 list all players on a specified team
                    bindingSource1.DataSource =
                        from team in database.team_tbls
                        
                        where (team.name).ToString() == (comboBox1.Text)

                        from playerhist in database.player_team_histories
                        from pl in database.player_tbls
                        where team.team_ID == playerhist.team_ID
                        where playerhist.player_ID == pl.player_ID && team.team_ID == playerhist.team_ID
                        where playerhist.start_date <= dateTimePicker3.Value && (playerhist.end_date >= dateTimePicker3.Value || playerhist.end_date==null) //make sure player is matched with his past teams for the year specified
                       
                        
                        orderby pl.lastname.ToString(), pl.firstname.ToString()
                        select new { pl.firstname, pl.lastname, pl.height, pl.weight, pl.salary, pl.birthdate,
                        Age = ((DateTime.Today.Month < pl.birthdate.Value.Month) || (DateTime.Today.Month == pl.birthdate.Value.Month && DateTime.Today.Day < pl.birthdate.Value.Day)) ? 
(int)(DateTime.Today.Year - pl.birthdate.Value.Year) - 1 : (int)(DateTime.Today.Year - pl.birthdate.Value.Year)
                        };
        }

        private void button8_Click(object sender, EventArgs e)//#2
        {
            game_flag = true;//Query 2 Game Query
            bindingSource1.DataSource =
                        from game in database.game_tbls
                        where game.date.Year >= dateTimePicker1.Value.Year && game.date.Year <= dateTimePicker2.Value.Year
                        
                        from team in database.team_tbls 
                        where team.team_ID == game.home_team_ID
                        
                        from team2 in database.team_tbls
                        where team2.team_ID == game.away_team_ID

                        select new { game.game_ID,Home=team.name,Away=team2.name,Score_Home=game.score_home,Score_Away=game.score_away,game.location, game.date };
            
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (game_flag == true)
            {
                int recordnr = int.Parse(dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells["game_ID"].Value.ToString());
                MessageBox.Show(recordnr.ToString());
                game_results gf = new game_results(recordnr);//Calls Query 3
                gf.Show();
            }

        }

        private void button5_Click(object sender, EventArgs e)
        {
            game_flag = false;
            string selected = this.comboBox2.GetItemText(this.comboBox1.SelectedItem);
            if (selected != "All")
            {
                MessageBox.Show("This will show stats for selected team");//Query 4 #1 selected team
                var query4 =
                    from stats in database.player_stats_tbls
                    from game in database.game_tbls
                    from player in database.player_tbls
                    from team in database.team_tbls
                    from teamHistory in database.player_team_histories
                    where game.date >= dateTimePicker4.Value
                    where game.date <= dateTimePicker5.Value
                    where teamHistory.start_date <= game.date && (teamHistory.end_date >= game.date || teamHistory.end_date == null)
                    where team.name.ToString() == comboBox2.Text && (team.team_ID == game.home_team_ID || team.team_ID == game.away_team_ID) && team.team_ID == teamHistory.team_ID
                    where stats.game_ID == game.game_ID
                    where player.player_ID == teamHistory.player_ID && player.player_ID == stats.player_ID
                    select new Query4(
                        player.firstname,
                        player.lastname,
                        stats.goals,
                        stats.assists,
                        stats.penalties,
                        stats.min_played);
                //  bindingSource1.DataSource = query4;
                query4List = query4.ToList<Query4>();

                var sel_team_avg =
                from name_avg in query4List
                group name_avg by name_avg.NAME into group1
                select new { Name = group1.Key, Goals = group1.Average(x => x.Goals), Assists = group1.Average(x => x.Asist), Penalties = group1.Average(x => x.Pen), Min_Played = group1.Average(x => x.Min) };

                bindingSource1.DataSource = sel_team_avg;
            }

            else//Query 4 #2 All teams
            {
                MessageBox.Show("This will show stats from all Teams");
                var query5 =
                    from stats in database.player_stats_tbls
                    from game in database.game_tbls
                    from player in database.player_tbls
                    from team in database.team_tbls
                    from teamHistory in database.player_team_histories
                    where game.date >= dateTimePicker4.Value
                    where game.date <= dateTimePicker5.Value
                    where teamHistory.start_date <= game.date && (teamHistory.end_date >= game.date || teamHistory.end_date == null)
                    where (team.team_ID == game.home_team_ID || team.team_ID == game.away_team_ID) && team.team_ID == teamHistory.team_ID//key line
                    where stats.game_ID == game.game_ID
                    where player.player_ID == teamHistory.player_ID && player.player_ID == stats.player_ID
                    select new Query4(
                        player.firstname,
                        player.lastname,
                        stats.goals,
                        stats.assists,
                        stats.penalties,
                        stats.min_played);
                //  bindingSource1.DataSource = query4;
                query4List = query5.ToList<Query4>();
                //cascading style sheets
                var all_avarage =
                from name_avg in query4List
                group name_avg by name_avg.NAME into group1 
                select new { Name = group1.Key, Goals = group1.Average(x => x.Goals), Assists = group1.Average(x => x.Asist), Penalties = group1.Average(x => x.Pen), Min_Played = group1.Average(x => x.Min) };

                bindingSource1.DataSource = all_avarage;
            }

        }

        class Query4
        {
            public string NAME { get; set; }
            public int Goals { get; set; }
            public int Asist { get; set; }
            public int Pen { get; set; }
            public int Min {get; set;}

            public Query4(string fn,string ln, int goals, int asist,int pen,int min)
            {
                NAME = fn + " " + ln;
                Goals = goals;
                Asist = asist;
                Pen = pen;
                Min = min;
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            var sort_goals =
              from name_avg in query4List
              orderby name_avg.Goals descending
              group name_avg by name_avg.NAME into group1
              select new { Name = group1.Key, Goals = group1.Average(x => x.Goals), Assists = group1.Average(x => x.Asist), Penalties = group1.Average(x => x.Pen), Min_Played = group1.Average(x => x.Min) };

            bindingSource1.DataSource = sort_goals;
           // this.dataGridView1.Sort(this.dataGridView1.Columns["Goals"], ListSortDirection.Ascending);
           // dataGridView1.Columns["Goals"].SortMode = DataGridViewColumnSortMode.Automatic;
           // dataGridView1.Sort(dataGridView1.Columns[1], ListSortDirection.Ascending);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            var sort_asists =
              from name_avg in query4List
              orderby name_avg.Asist descending
              group name_avg by name_avg.NAME into group1
              select new { Name = group1.Key, Goals =  group1.Average(x =>x.Goals), Assists = group1.Average(x => x.Asist), Penalties = group1.Average(x => x.Pen), Min_Played = group1.Average(x => x.Min) };

            bindingSource1.DataSource = sort_asists;
        }

        private void button10_Click(object sender, EventArgs e)
        {
            var sort_pen =
              from name_avg in query4List
              orderby name_avg.Pen descending
              group name_avg by name_avg.NAME into group1
              select new { Name = group1.Key, Goals = group1.Average(x => x.Goals), Assists = group1.Average(x => x.Asist), Penalties = group1.Average(x => x.Pen), Min_Played = group1.Average(x => x.Min) };

            bindingSource1.DataSource = sort_pen;
        }

        private void button11_Click(object sender, EventArgs e)
        {
            var sort_min =
              from name_avg in query4List
              orderby name_avg.Min descending
              group name_avg by name_avg.NAME into group1
              select new { Name = group1.Key, Goals = group1.Average(x => x.Goals), Assists = group1.Average(x => x.Asist), Penalties = group1.Average(x => x.Pen), Min_Played = group1.Average(x => x.Min) };

            bindingSource1.DataSource = sort_min;
        }

    }
}
