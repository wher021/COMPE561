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
    public partial class game_results : Form
    {
        public static myLeagueDataContext database = new myLeagueDataContext();
        public game_results()
        {
            InitializeComponent();
            dataGridView1.DataSource = bindingSource1;
            dataGridView1.AutoGenerateColumns = true;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridView2.DataSource = bindingSource2;
            dataGridView2.AutoGenerateColumns = true;
            dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

        }
        public game_results(int gameid)
        {
            InitializeComponent();
            dataGridView1.DataSource = bindingSource1;
            dataGridView1.AutoGenerateColumns = true;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridView2.DataSource = bindingSource2;
            dataGridView2.AutoGenerateColumns = true;
            dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            bindingSource1.DataSource =//Query 3 stats for a selected game
                from game in database.game_tbls//selects the correct game
                where game.game_ID == gameid

                from playerhist in database.player_team_histories//selects correct historic team
                where playerhist.team_ID == game.home_team_ID //// where playerhist.team_ID == game.home_team_ID || playerhist.team_ID == game.away_team_ID //
                where game.date.Year >= playerhist.start_date.Year && game.date.Year <= playerhist.end_date.Year

                from pl in database.player_tbls//selects corresponding players to the historic team
                where pl.player_ID == playerhist.player_ID

                from st in database.player_stats_tbls//get player stats
                where st.game_ID == game.game_ID
                where st.player_ID == pl.player_ID

                from team in database.team_tbls//sets home team name 
                where team.team_ID == playerhist.team_ID

                select new {Team_name = team.name, pl.firstname, pl.lastname, st.goals, st.assists, st.penalties };

            bindingSource2.DataSource =
                  from game in database.game_tbls//selects the correct game
                  where game.game_ID == gameid

                  from playerhist in database.player_team_histories//selects correct historic team
                  where playerhist.team_ID == game.away_team_ID //
                  where game.date.Year >= playerhist.start_date.Year && game.date.Year <= playerhist.end_date.Year

                  from pl in database.player_tbls//selects corresponding players to the historic team
                  where pl.player_ID == playerhist.player_ID

                  from st in database.player_stats_tbls//get player stats
                  where st.game_ID == game.game_ID
                  where st.player_ID == pl.player_ID

                  from team in database.team_tbls//sets home team name 
                  where team.team_ID == playerhist.team_ID

                  select new { Team_name = team.name, pl.firstname, pl.lastname, st.goals, st.assists, st.penalties };
        }

        private void game_results_FormClosed(object sender, FormClosedEventArgs e)
        {
            //MainFrm.game_flag = false;
        }
    }
}
