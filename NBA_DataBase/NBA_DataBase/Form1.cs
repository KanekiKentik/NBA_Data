using System.Xml.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace NBA_DataBase
{
    public partial class Form1 : Form
    {
        public static Form1 Instance { get; private set; }
        public Form1()
        {
            Form1.Instance = this;

            InitializeComponent();
        }


        private void OnSearchBoxKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                playerBox.Items.Clear();

                string url = $"https://api.balldontlie.io/v1/players?search={searchBox.Text}&per_page=100";

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
                            Player found = JsonConvert.DeserializeObject<Player>(obj.ToString());
                            playerBox.Items.Add(found);
                        }
                    }
                    catch (HttpRequestException exeption)
                    {
                        Console.WriteLine($"Ошибка запроса: {exeption.Message}");
                    }
                }
            }
        }

        private void playerBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (playerBox.SelectedItem != null)
            {
                Player selected = playerBox.SelectedItem as Player;

                if (selected != null)
                {
                    UpdatePlayerData(selected);
                }
            }
        }

        private void UpdatePlayerData(Player player)
        {
            pdata_College.Text = player.college;
            pdata_Country.Text = player.country;
            pdata_DraftRN.Text = $"{player.draft_round}/{player.draft_number}";
            pdata_DraftYear.Text = player.draft_year;
            pdata_FName.Text = player.first_name;
            pdata_LName.Text = player.last_name;
            pdata_Height.Text = player.height;
            pdata_Jersey.Text = player.jersey_number;
            pdata_PositionBox.Text = player.position;
            pdata_TeamBox.Text = player.team.full_name;
            pdata_Weight.Text = player.weight;
        }
    }
}
