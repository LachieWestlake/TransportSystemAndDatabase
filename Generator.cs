using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SaintLucia
{
    public partial class Generator : Form
    {
        public Generator()
        {
            InitializeComponent();
        }

        private static readonly Random random = new Random();
        private static readonly object syncLock = new object();
        public static int RandomNumber(int min, int max)
        {
            lock (syncLock)
            { // synchronize
                return random.Next(min, max);
            }
        }


        
        int i = 0;
        private void button1_Click(object sender, EventArgs e)
        {
           
            while (i < 3)
            {
                OperatingDay = "Monday";
                Generate();
                i++;
            }
            i = 0;
            while (i < 3)
            {
                OperatingDay = "Monday";
                Generate();
                i++;
            }
            /* while (i < 3)
            {
                OperatingDay = "Tuesday";
                Generate();
                i++;
            }
            i = 0;
            while (i < 3)
            {
                OperatingDay = "Wednesday";
                Generate();
                i++;
            }
            i = 0;
            while (i < 3)
            {
                OperatingDay = "Thursday";
                Generate();
                i++;
            }
            i = 0;
            while (i < 3)
            {
                OperatingDay = "Friday";
                Generate();
                i++;
            }
            i = 0;
            while (i < 3)
            {
                OperatingDay = "Saturday";
                Generate();
                i++;
            }
            i = 0;
            while (i < 3)
            {
                OperatingDay = "Sunday";
                Generate();
                i++;
            } */


        }

        string theData;
        public void Generate()
        {
            theData = string.Format("('{0}', '{1}', '{2}', '{3}'),", RouteID , OperatingDay, DepartureTime, ArrivalTime);
            RouteIDData();
            OperatingDayData();
            textBox1.Text += theData;

        }
        
        int RouteID;
        string OperatingDay = "";
        string DepartureTime;
        string ArrivalTime;
        

        // INSERT INTO `routeschedule`(`RouteID`, `OperatingDay`, `DepartureTime`, `ArrivalTime`, `JourneyTime`) VALUES ('3','Monday','07:00','13:00','6')
        public void RouteIDData()
        {
          
            RouteID = RandomNumber(1, 30); // creates a number between 1 and 30
        }

        public void OperatingDayData()
        {

            
            int twentyfour = RandomNumber(1, 22);

            int twelve = RandomNumber(1, 12);

            int sixty = RandomNumber(1, 58);

            int rando = RandomNumber(1, 2);

            int randol = RandomNumber(1, 2);

            int use = twentyfour;

            string ampm = "am";

            if (use > 10) 
            {
                ampm = "pm";
            }

            if (use > 12)
            {
                twentyfour = twentyfour - 12;
            }

            string sixty2 = sixty.ToString();

            if (sixty < 10)
            {
                sixty2 = "0" + sixty;
            }

            string twentyfour2 = twentyfour.ToString();

            if (twentyfour < 10)
            {
                twentyfour2 = "0" + twentyfour;
            }

            int bigrnd = twelve + rando + rando;
            string bigrnd2 = bigrnd.ToString();

            if (bigrnd< 12)
            {
                bigrnd2 = "0" + bigrnd;
            }

            int smallrnd = twelve + twelve + twelve + twelve;
            string smallrnd2 = smallrnd.ToString();

            if (smallrnd < 10)
            {
                smallrnd2 = "0" + smallrnd;
            }

            DepartureTime = string.Format("{0}:{1}{2}", twentyfour2, sixty2, ampm);
            ArrivalTime = string.Format("{0}:{1}{2}", bigrnd2, smallrnd2, ampm);
        }

        private void Generator_Load(object sender, EventArgs e)
        {

        }
    }
}
