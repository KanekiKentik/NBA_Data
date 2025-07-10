using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace NBA_DataBase
{
    public partial class Form2 : Form
    {
        private static Form2 _instance;
        public static Form2 Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new Form2();
                }
                return _instance;
            }
        }
        public Form2()
        {
            InitializeComponent();
        }

        private void UpdateTeams()
        {
            teamBox.Items.Clear();

            string url = $"https://api.balldontlie.io/v1/teams?per_page=100";

            using (HttpClient client = new HttpClient())
            {
                try
                {
                    client.DefaultRequestHeaders.Add("Authorization", "9eeb2b78-5992-438a-9da4-d26daf11ae48");
                    HttpResponseMessage response = client.GetAsync(url).Result;
                    string responseResult = response.Content.ReadAsStringAsync().Result;

                    JObject jsonResult = JObject.Parse(responseResult);

                    foreach (JObject obj in jsonResult["data"])
                    {
                        Team team = JsonConvert.DeserializeObject<Team>(obj.ToString());
                        teamBox.Items.Add(team);
                    }
                }
                catch (HttpRequestException exeption)
                {
                    Console.WriteLine($"Ошибка запроса: {exeption.Message}");
                }
            }
        }
        private void teamBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (teamBox.SelectedItem != null)
            {
                Team selected = teamBox.SelectedItem as Team;

                if (selected != null)
                {
                    UpdateTeamData(selected);
                }
            }
        }
        private void UpdateTeamData(Team team)
        {
            tdata_Abbrv.Text = team.abbreviation;
            tdata_City.Text = team.city;
            tdata_Conference.Text = team.conference;
            tdata_Division.Text = team.division;
            tdata_FullName.Text = team.full_name;
            tdata_Name.Text = team.name;
        }
        private void switchFormButton_Click(object sender, EventArgs e)
        {
            this.Hide();

            Form1.Instance.Show();
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            UpdateTeams();
        }
    }
}
