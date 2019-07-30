using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;
using MySql.Web;
using System.Text.RegularExpressions;

namespace SaintLucia
{
    public partial class MapForm : Form
    {
        public MapForm()
        {
            InitializeComponent();

        }

        int Count = 0;

        bool CapEstate = false;
        bool Castries = false;
        bool Bosquet = false;
        bool Soufriere = false;
        bool Vieuxfort = false;
        bool Anbre = false;



        private void MapForm_Load(object sender, EventArgs e)
        {
            weekBox.SelectedIndex = 0;
            dataGridView.AllowUserToAddRows = false;
        }

        private void CapEstateBtn_Click(object sender, EventArgs e)
        {

            if (CapEstate == false)
            {
                CapEstate = true;
                CapEstateBtn.BackgroundImage = Properties.Resources.Red_Circle;

            }
            else if (CapEstate == true)
            {
                CapEstateBtn.BackgroundImage = Properties.Resources.Black_Circle;

                CapEstate = false;
            }


            if (CapEstate && Castries == true)
            {

                CapEstatetoCastries.Visible = true;
            }
            else
            {
                CapEstatetoCastries.Visible = false;
            }


        }

        private void CastriesBtn_Click(object sender, EventArgs e)
        {
            if (Castries == false)
            {
                Castries = true;
                CastriesBtn.BackgroundImage = Properties.Resources.Red_Circle;
            }
            else if (Castries == true)
            {
                CastriesBtn.BackgroundImage = Properties.Resources.Black_Circle;
                Castries = false;
            }

            if (CapEstate && Castries == true)
            {

                CapEstatetoCastries.Visible = true;
            }
            else
            {
                CapEstatetoCastries.Visible = false;
            }

            if (Castries && Bosquet == true)
            {

                CastriesToBosquet.Visible = true;
            }
            else
            {
                CastriesToBosquet.Visible = false;
            }

            if (Castries && Soufriere == true)
            {

                CastriestoSoufriere.Visible = true;
            }
            else
            {
                CastriestoSoufriere.Visible = false;
            }

        }

        private void BosquetBtn_Click(object sender, EventArgs e)
        {
            if (Bosquet == false)
            {
                Bosquet = true;
                BosquetBtn.BackgroundImage = Properties.Resources.Red_Circle;
            }
            else if (Bosquet == true)
            {
                BosquetBtn.BackgroundImage = Properties.Resources.Black_Circle;
                Bosquet = false;
            }

            if (Castries && Bosquet == true)
            {

                CastriesToBosquet.Visible = true;
            }
            else
            {
                CastriesToBosquet.Visible = false;
            }

            if (Bosquet && Anbre == true)
            {

                BosquettoAnbre.Visible = true;
            }
            else
            {
                BosquettoAnbre.Visible = false;
            }
        }

        private void SoufriereBtn_Click(object sender, EventArgs e)
        {
            if (Soufriere == false)
            {
                Soufriere = true;
                SoufriereBtn.BackgroundImage = Properties.Resources.Red_Circle;
            }
            else if (Soufriere == true)
            {
                SoufriereBtn.BackgroundImage = Properties.Resources.Black_Circle;
                Soufriere = false;
            }

            if (Castries && Soufriere == true)
            {

                CastriestoSoufriere.Visible = true;
            }
            else
            {
                CastriestoSoufriere.Visible = false;
            }

            if (Soufriere && Vieuxfort == true)
            {

                SoufreiretoVieux.Visible = true;
            }
            else
            {
                SoufreiretoVieux.Visible = false;
            }
        }

        private void VieuxfortBtn_Click(object sender, EventArgs e)
        {
            if (Vieuxfort == false)
            {
                Vieuxfort = true;
                VieuxfortBtn.BackgroundImage = Properties.Resources.Red_Circle;
            }
            else if (Vieuxfort == true)
            {
                VieuxfortBtn.BackgroundImage = Properties.Resources.Black_Circle;
                Vieuxfort = false;
            }

            if (Soufriere && Vieuxfort == true)
            {

                SoufreiretoVieux.Visible = true;
            }
            else
            {
                SoufreiretoVieux.Visible = false;
            }

            if (Vieuxfort && Anbre == true)
            {

                AnbretoVieux.Visible = true;
            }
            else
            {
                AnbretoVieux.Visible = false;
            }
        }

        private void AnbreBtn_Click(object sender, EventArgs e)
        {
            if (Anbre == false)
            {
                Anbre = true;
                AnbreBtn.BackgroundImage = Properties.Resources.Red_Circle;
            }
            else if (Anbre == true)
            {
                AnbreBtn.BackgroundImage = Properties.Resources.Black_Circle;
                Anbre = false;
            }

            if (Bosquet && Anbre == true)
            {

                BosquettoAnbre.Visible = true;
            }
            else
            {
                BosquettoAnbre.Visible = false;
            }

            if (Vieuxfort && Anbre == true)
            {

                AnbretoVieux.Visible = true;
            }
            else
            {
                AnbretoVieux.Visible = false;
            }

        }

        private void OriginLst_SelectedIndexChanged(object sender, EventArgs e)
        {
            Connections();

        }

        private void DestLst_SelectedIndexChanged(object sender, EventArgs e)
        {
            Connections();


        }

        public int booleanCounter()
        {
            Count = 0;

            if (CapEstate == true) { Count++; }

            if (Castries == true) { Count++; }

            if (Bosquet == true) { Count++; }

            if (Soufriere == true) { Count++; }

            if (Vieuxfort == true) { Count++; }

            if (Anbre == true) { Count++; }

            return Count;
        }


        int Origin = -1;
        int Destination = -1;
        int Route = -1;

        public void Connections()
        {
            displayStationBtn.PerformClick();

            if (OriginLst.SelectedIndex == DestLst.SelectedIndex)
            {
                MessageBox.Show("You are already at this destination");
                CasBlank.Image = Properties.Resources.Home;
                CapBlank.Image = Properties.Resources.Home;
                BosquetBlank.Image = Properties.Resources.Home;
                SouBlank.Image = Properties.Resources.Home;
                VieuxBlank.Image = Properties.Resources.Home;
                AnbreBlank.Image = Properties.Resources.Home;
            }

            //Cap Estate
            if (OriginLst.SelectedIndex == 0)
            {
                UnClickEveryButton();
                CapEstateBtn.PerformClick();
                CapBlank.Image = Properties.Resources.Home;
                CapBlank.Visible = true;



                if (DestLst.SelectedIndex == 1)
                {

                    Route = 1;

                    CastriesBtn.PerformClick();
                }
                else if (DestLst.SelectedIndex == 2)
                {
                    Route = 2;
                    CastriesBtn.PerformClick();
                    BosquetBtn.PerformClick();
                }

                else if (DestLst.SelectedIndex == 3)
                {
                    Route = 3;
                    CastriesBtn.PerformClick();
                    SoufriereBtn.PerformClick();
                }
                else if (DestLst.SelectedIndex == 4)
                {
                    Route = 4;
                    CastriesBtn.PerformClick();
                    SoufriereBtn.PerformClick();
                    VieuxfortBtn.PerformClick();
                }
                else if (DestLst.SelectedIndex == 5)
                {
                    Route = 5;
                    CastriesBtn.PerformClick();
                    BosquetBtn.PerformClick();
                    AnbreBtn.PerformClick();
                }
            }
            //Castries
            if (OriginLst.SelectedIndex == 1)
            {
                UnClickEveryButton();
                CastriesBtn.PerformClick();
                CasBlank.Image = Properties.Resources.Home;
                CasBlank.Visible = true;
                if (DestLst.SelectedIndex == 0)
                {
                    Route = 6;
                    CapEstateBtn.PerformClick();
                }
                else if (DestLst.SelectedIndex == 2)
                {
                    Route = 7;
                    BosquetBtn.PerformClick();
                }

                else if (DestLst.SelectedIndex == 3)
                {
                    Route = 8;
                    SoufriereBtn.PerformClick();
                }
                else if (DestLst.SelectedIndex == 4)
                {
                    Route = 9;
                    SoufriereBtn.PerformClick();
                    VieuxfortBtn.PerformClick();
                }
                else if (DestLst.SelectedIndex == 5)
                {
                    Route = 10;
                    BosquetBtn.PerformClick();
                    AnbreBtn.PerformClick();
                }
            }
            //Bosquet
            if (OriginLst.SelectedIndex == 2)
            {
                UnClickEveryButton();
                BosquetBtn.PerformClick();
                BosquetBlank.Image = Properties.Resources.Home;
                BosquetBlank.Visible = true;
                if (DestLst.SelectedIndex == 0)
                {
                    CapEstateBtn.PerformClick();
                    CastriesBtn.PerformClick();
                }
                else if (DestLst.SelectedIndex == 1)
                {
                    CastriesBtn.PerformClick();
                }

                else if (DestLst.SelectedIndex == 3)
                {
                    CastriesBtn.PerformClick();
                    SoufriereBtn.PerformClick();
                }
                else if (DestLst.SelectedIndex == 4)
                {
                    AnbreBtn.PerformClick();
                    VieuxfortBtn.PerformClick();
                }
                else if (DestLst.SelectedIndex == 5)
                {
                    AnbreBtn.PerformClick();
                }
            }
            //Soufriere
            if (OriginLst.SelectedIndex == 3)
            {
                UnClickEveryButton();
                SoufriereBtn.PerformClick();
                SouBlank.Image = Properties.Resources.Home;
                SouBlank.Visible = true;
                if (DestLst.SelectedIndex == 0)
                {
                    CapEstateBtn.PerformClick();
                    CastriesBtn.PerformClick();
                }
                else if (DestLst.SelectedIndex == 1)
                {
                    CastriesBtn.PerformClick();
                }

                else if (DestLst.SelectedIndex == 2)
                {
                    CastriesBtn.PerformClick();
                    BosquetBtn.PerformClick();
                }

                else if (DestLst.SelectedIndex == 4)
                {
                    VieuxfortBtn.PerformClick();

                }
                else if (DestLst.SelectedIndex == 5)
                {
                    AnbreBtn.PerformClick();
                    VieuxfortBtn.PerformClick();
                }
            }
            //Vieuxfort
            if (OriginLst.SelectedIndex == 4)
            {
                UnClickEveryButton();
                VieuxfortBtn.PerformClick();
                VieuxBlank.Image = Properties.Resources.Home;
                VieuxBlank.Visible = true;
                if (DestLst.SelectedIndex == 0)
                {
                    CapEstateBtn.PerformClick();
                    CastriesBtn.PerformClick();
                    SoufriereBtn.PerformClick();
                }
                else if (DestLst.SelectedIndex == 1)
                {
                    CastriesBtn.PerformClick();
                    SoufriereBtn.PerformClick();
                }

                else if (DestLst.SelectedIndex == 2)
                {
                    AnbreBtn.PerformClick();
                    BosquetBtn.PerformClick();
                }

                else if (DestLst.SelectedIndex == 3)
                {
                    SoufriereBtn.PerformClick();

                }

                else if (DestLst.SelectedIndex == 5)
                {
                    AnbreBtn.PerformClick();
                }
            }
            //Anbre
            if (OriginLst.SelectedIndex == 5)
            {
                UnClickEveryButton();
                AnbreBtn.PerformClick();
                AnbreBlank.Image = Properties.Resources.Home;
                AnbreBlank.Visible = true;
                if (DestLst.SelectedIndex == 0)
                {
                    CapEstateBtn.PerformClick();
                    CastriesBtn.PerformClick();
                    BosquetBtn.PerformClick();
                }
                else if (DestLst.SelectedIndex == 1)
                {
                    CastriesBtn.PerformClick();
                    BosquetBtn.PerformClick();
                }

                else if (DestLst.SelectedIndex == 2)
                {
                    BosquetBtn.PerformClick();
                }

                else if (DestLst.SelectedIndex == 3)
                {
                    VieuxfortBtn.PerformClick();
                    SoufriereBtn.PerformClick();

                }

                else if (DestLst.SelectedIndex == 4)
                {
                    VieuxfortBtn.PerformClick();
                }
            }

            //Destination
            if (DestLst.SelectedIndex == 0)
            {
                CapBlank.Image = Properties.Resources.Location;
                CapBlank.Visible = true;
            }
            else if (DestLst.SelectedIndex == 1)
            {
                CasBlank.Image = Properties.Resources.Location;
                CasBlank.Visible = true;
            }
            else if (DestLst.SelectedIndex == 2)
            {
                BosquetBlank.Image = Properties.Resources.Location;
                BosquetBlank.Visible = true;
            }
            else if (DestLst.SelectedIndex == 3)
            {
                SouBlank.Image = Properties.Resources.Location;
                SouBlank.Visible = true;
            }
            else if (DestLst.SelectedIndex == 4)
            {
                VieuxBlank.Image = Properties.Resources.Location;
                VieuxBlank.Visible = true;
            }
            else if (DestLst.SelectedIndex == 5)
            {
                AnbreBlank.Image = Properties.Resources.Location;
                AnbreBlank.Visible = true;
            }

            if (OriginLst.SelectedIndex == DestLst.SelectedIndex)
            {
                CasBlank.Image = Properties.Resources.Home;
                CapBlank.Image = Properties.Resources.Home;
                BosquetBlank.Image = Properties.Resources.Home;
                SouBlank.Image = Properties.Resources.Home;
                VieuxBlank.Image = Properties.Resources.Home;
                AnbreBlank.Image = Properties.Resources.Home;
            }

            OriginConnection();
            DestinationConnection();
        }


        public void UnClickEveryButton()
        {
            if (CapEstate == true) { CapEstateBtn.PerformClick(); CapBlank.Visible = false; }

            if (Castries == true) { CastriesBtn.PerformClick(); CasBlank.Visible = false; }

            if (Bosquet == true) { BosquetBtn.PerformClick(); BosquetBlank.Visible = false; }

            if (Soufriere == true) { SoufriereBtn.PerformClick(); SouBlank.Visible = false; }

            if (Vieuxfort == true) { VieuxfortBtn.PerformClick(); VieuxBlank.Visible = false; }

            if (Anbre == true) { AnbreBtn.PerformClick(); AnbreBlank.Visible = false; }


        }

        string conn;
        MySqlConnection connect;

        public void db_connection()
        {

            try
            {
                conn = "Server=localhost;Database=saintlucia;Uid=root;Pwd=;";
                connect = new MySqlConnection(conn);
                connect.Open();
            }
            catch (MySqlException e)
            {
                throw;
            }
        }


        int OriginSID;

        public void OriginConnection()
        {
            OriginSID = OriginLst.SelectedIndex + 1;
            db_connection();
            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandText = "Select * from stations where StationID=@OriginSID";
            cmd.Parameters.AddWithValue("@OriginSID", OriginSID);

            cmd.Connection = connect;
            MySqlDataReader myReader = cmd.ExecuteReader();

            try
            {
                while (myReader.Read())
                {
                    OriginTxt.Text = "ID:" + " " + (myReader.GetString(0)) + "\r\n" + "Name" + " " + (myReader.GetString(1)) + "\r\n" + "Address:" + " " + (myReader.GetString(2));
                }
            }
            finally
            {
                myReader.Close();
                connect.Close();
            }
        }

        int DestinationSID;

        public void DestinationConnection()
        {
            DestinationSID = DestLst.SelectedIndex + 1;
            db_connection();
            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandText = "Select * from stations where StationID=@DestSID";
            cmd.Parameters.AddWithValue("@DestSID", DestinationSID);

            cmd.Connection = connect;
            MySqlDataReader myReader = cmd.ExecuteReader();

            try
            {
                while (myReader.Read())
                {
                    DestinationTxt.Text = "ID:"  + " " + (myReader.GetString(0)) + "\r\n" + "Name" + " " +(myReader.GetString(1)) + "\r\n" + "Address:" + " " + (myReader.GetString(2));
                }
            }
            finally
            {
                myReader.Close();
                connect.Close();
            }
        }

        /*     public void Routes()
             {
                 OriginSID = OriginLst.SelectedIndex;
                 DestinationSID = DestLst.SelectedIndex;
                 db_connection();
                 MySqlCommand cmd = new MySqlCommand();
                 cmd.CommandText = "Select * from route where OriginStation=@OriginSID and DestinationStation=@DestSID";
                 cmd.Parameters.AddWithValue("@OriginSID", OriginSID);
                 cmd.Parameters.AddWithValue("@DestSID", DestinationSID);
                 cmd.Connection = connect;
                 MySqlDataReader myReader = cmd.ExecuteReader();

                 try
                 {
                     while (myReader.Read())
                     {
                         RoutesTxt.Text = (myReader.GetString(0)) + " " + (myReader.GetString(1)) + " " + (myReader.GetString(2));
                     }
                 }
                 finally
                 {
                     myReader.Close();
                     connect.Close();
                 }
             } 

             string route;
             public void RouteJoiner()
             {
                 OriginSID = OriginLst.SelectedIndex;
                 DestinationSID = DestLst.SelectedIndex;
                 db_connection();
                 MySqlCommand cmd = new MySqlCommand();
                 cmd.CommandText = "SELECT RouteID, StationName, OriginStation, DestinationStation FROM stations INNER JOIN route ON StationID = @OriginSID or StationID = @DestSID";
                 cmd.Parameters.AddWithValue("@OriginSID", OriginSID);
                 cmd.Parameters.AddWithValue("@DestSID", DestinationSID);
                 cmd.Connection = connect;
                 MySqlDataReader myReader = cmd.ExecuteReader();



                 try
                 {
                     while (myReader.Read())
                     {
                         // RoutesTxt.Text = (myReader.GetString(0)) + " " + (myReader.GetString(1)) + " " + (myReader.GetString(2)) + " " + (myReader.GetString(3));
                         // RoutesTxt.Text = myReader.GetSchemaTable

                         route = String.Format("{0}, {1}, {2}", myReader[0], myReader[1], myReader[2]);
                         RoutesTxt.Text += route;
                     }
                 }
                 finally
                 {
                     myReader.Close();
                     connect.Close();
                 }




             }*/

        string weekday;

        private void displayStationBtn_Click(object sender, EventArgs e)
        {
            weekday = weekBox.SelectedItem.ToString();
            //RouteJoiner();
            if (weekday == "Entire Week")
            {
                Table();
            }
            else
            {
                TableWeekday();
                
            }
            
        }




        private void Table()
        {
            OriginSID = OriginLst.SelectedIndex + 1;
            DestinationSID = DestLst.SelectedIndex + 1;
            db_connection();
            MySqlCommand cmd = new MySqlCommand();
            // cmd.CommandText = "SELECT RouteID, StationName, OriginStation, DestinationStation FROM stations INNER JOIN route ON StationID = @OriginSID or StationID = @DestSID";
            cmd.CommandText = "SELECT a.* FROM routeschedule AS a JOIN route AS b ON b.RouteID = a.RouteID WHERE b.OriginStation = @OriginSID and b.DestinationStation = @DestSID ORDER BY a.RouteID Asc";
            cmd.Parameters.AddWithValue("@OriginSID", OriginSID);
            cmd.Parameters.AddWithValue("@DestSID", DestinationSID);
            cmd.Connection = connect;
            MySqlDataReader myReader = cmd.ExecuteReader();


            DataTable dataTable = new DataTable();


            dataTable.Load(myReader);
            dataGridView.DataSource = dataTable;
            // dataTable.Load(myReader);
        }
        

        private void TableWeekday()
        {
            OriginSID = OriginLst.SelectedIndex + 1;
            DestinationSID = DestLst.SelectedIndex + 1;
            weekday = weekBox.SelectedItem.ToString();
            
            
            

            db_connection();
            MySqlCommand cmd = new MySqlCommand();
            // cmd.CommandText = "SELECT RouteID, StationName, OriginStation, DestinationStation FROM stations INNER JOIN route ON StationID = @OriginSID or StationID = @DestSID";
            cmd.CommandText = "SELECT a.* FROM routeschedule AS a JOIN route AS b ON (b.RouteID = a.RouteID) WHERE b.OriginStation = @OriginSID and b.DestinationStation = @DestSID and a.OperatingDay = @Weekday ORDER BY a.RouteID Asc";
            cmd.Parameters.AddWithValue("@OriginSID", OriginSID);
            cmd.Parameters.AddWithValue("@DestSID", DestinationSID);
            cmd.Parameters.AddWithValue("@Weekday", weekday);
            cmd.Connection = connect;
            MySqlDataReader myReader = cmd.ExecuteReader();


            DataTable dataTable2 = new DataTable();


            dataTable2.Load(myReader);
            dataGridView.DataSource = dataTable2;

            if (dataGridView.Rows.Count == 0)
            {
                MessageBox.Show("There are no trains running on " + weekday + " for this service");
            }
            // dataTable.Load(myReader);
        }

        private void weekBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            TableWeekday();
        }

        private void submitBtn_Click(object sender, EventArgs e)
        {
           if (!Regex.Match(DepartTxt.Text, "([0-1])([0-2])(:)([0-6])([0-9])([A-z])([A-z])").Success && !Regex.Match(ArriveTxt.Text, "([0-1])([0-2])(:)([0-6])([0-9])([A-z])([A-z])").Success)
                {
                    // first name was incorrect
                    MessageBox.Show("Invalid input");
                }
            else
            {
                OriginSID = OriginLst.SelectedIndex + 1;
                DestinationSID = DestLst.SelectedIndex + 1;
                weekday = weekBox.SelectedItem.ToString();


                FindRoute();

                db_connection();
                MySqlCommand cmd = new MySqlCommand();
                // cmd.CommandText = "SELECT RouteID, StationName, OriginStation, DestinationStation FROM stations INNER JOIN route ON StationID = @OriginSID or StationID = @DestSID";
                cmd.CommandText = "INSERT INTO `routeschedule`(`RouteID`,`OperatingDay`, `DepartureTime`, `ArrivalTime`) VALUES (@RouteID, @Weekday , @DepartureTime, @ArrivalTime)";
                cmd.Parameters.AddWithValue("@DepartureTime", DepartTxt.Text);
                cmd.Parameters.AddWithValue("@ArrivalTime", ArriveTxt.Text);
                cmd.Parameters.AddWithValue("@Weekday", weekday);
                cmd.Parameters.AddWithValue("@RouteID", RouteID3);
                cmd.Connection = connect;
                MySqlDataReader myReader = cmd.ExecuteReader();
            }

        }

        string RouteID3;
        int RouteId2;

        public void FindRoute()
        {
            {
                OriginSID = OriginLst.SelectedIndex + 1;
                DestinationSID = DestLst.SelectedIndex + 1;
                
                db_connection();
                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandText = "Select RouteID from route where OriginStation=@OriginSID and DestinationStation=@DestSID";
                cmd.Parameters.AddWithValue("@OriginSID", OriginSID);
                cmd.Parameters.AddWithValue("@DestSID", DestinationSID);
                cmd.Connection = connect;
                MySqlDataReader myReader = cmd.ExecuteReader();

                try
                {
                    while (myReader.Read())
                    {
                         RouteIDBox.Text = (myReader.GetString(0));
                        RouteID3 = RouteIDBox.Text;
                       // RouteId2 = RouteIDBox.Text;
                    }
                }
                finally
                {
                    myReader.Close();
                    connect.Close();
                }
            }
        }
        
        
   
    }

}
    
