using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace FlightPlanning_UTSA
{
    class Program
    {
        Plane Zlin;

        List<Airport> Airports = new List<Airport>();

        static int tableWidth = 95;
        static async Task Main(string[] args)
        {
            var program = new Program();
            
            bool run = true;
            
            while(run) {
                await program.RunProgram();
            }

        }

        public async Task RunProgram() {

            addPlanes();

            //weightAndBalance();

            await weatherInfo();

        }

        public void addPlanes(){
            
            Zlin = new Plane(0.653, 0.956, 0.956, 0.750, 0.948, 1.766);
        }

        public void weightAndBalance() {
            double response;

            response = doubleAskUser("Basic empty mass:");
            Zlin.BEM_Mass = response;
            Zlin.addToTotalMass(response);

            response = doubleAskUser("Left Seat mass:");
            Zlin.LeftSeat_Mass = response;
            Zlin.addToTotalMass(response);

            response = doubleAskUser("Right Seat mass:");
            Zlin.RightSeat_Mass = response;
            Zlin.addToTotalMass(response);

            response = doubleAskUser("Main FuelTank mass:");
            Zlin.FuelMain_Mass = response;
            Zlin.addToTotalMass(response);

            response = doubleAskUser("Auxilary FuelTank mass:");
            Zlin.FuelAux_Mass = response;
            Zlin.addToTotalMass(response);

            response = doubleAskUser("Baggage mass:");
            Zlin.Baggage_Mass = response;
            Zlin.addToTotalMass(response);

            Zlin.calculateMassArmS();
            Zlin.calculateTotalArm();


            MakeTable_Zlin_MB();
        }

        public async Task weatherInfo()
        {
            int i = 0;
            while(i < 2)
                { 
                List<int> metarData = new List<int>();
                string textMessage;
                bool departure;

                if (i == 0)
                {
                    textMessage = "Departure  Airport (ICAO): ";
                    departure = true;
                } else
                {
                    textMessage = "Arrival Airport (ICAO): ";
                    departure = false;
                }
                string icaoCode = StringAskUser(textMessage).ToUpper();

                if(i == 0 || icaoCode != Airports[0].ICAOCODE)
                {
                    
                    Client client = new Client();

                    string metarInfo = await client.getMetarInfo(icaoCode);

                    Metarinfohandler metarinfohandler = new Metarinfohandler();
                    metarData = metarinfohandler.HandleMetarInfo(metarInfo);

                    Airports.Add(new Airport(icaoCode, metarData[0], metarData[1], departure));
                    
                }
                i++;
            }
            
            MakeTable_METAR();
        }

        public double doubleAskUser(string question) {
            double answer;

            Console.WriteLine(question);
            answer = Convert.ToDouble(Console.ReadLine());

            return answer;
        }
        public string StringAskUser(string question)
        {
            string answer;

            Console.WriteLine(question);
            answer = Console.ReadLine();

            return answer;
        }

        public void Display(String[] message) {
            foreach (String value in message)
            {
                Console.WriteLine(value.ToString());
            }

        }

        

        public void MakeTable_Zlin_MB()
        {
            Console.Clear();
            PrintLine();
            PrintRow("", "Mass", "Arm", "MassArm");
            PrintLine();
            PrintRow("Basic Empty Mass", Zlin.BEM_Mass.ToString(), Zlin.BEM_Arm.ToString(), Zlin.BEM_MassArm.ToString());
            PrintLine();
            PrintRow("Left Seat", Zlin.LeftSeat_Mass.ToString(), Zlin.LeftSeat_Arm.ToString(), Zlin.LeftSeat_MassArm.ToString());
            PrintLine();
            PrintRow("Right Seat", Zlin.RightSeat_Mass.ToString(), Zlin.RightSeat_Arm.ToString(), Zlin.RightSeat_MassArm.ToString());
            PrintLine();
            PrintRow("Main Tank", Zlin.FuelMain_Mass.ToString(), Zlin.FuelMain_Arm.ToString(), Zlin.FuelMain_MassArm.ToString());
            PrintLine();
            PrintRow("Auxiliary Tank", Zlin.FuelAux_Mass.ToString(), Zlin.FuelAux_Arm.ToString(), Zlin.FuelAux_MassArm.ToString());
            PrintLine();
            PrintRow("Baggage", Zlin.Baggage_Mass.ToString(), Zlin.Baggage_Arm.ToString(), Zlin.Baggage_MassArm.ToString());
            PrintLine();
            PrintLine();
            PrintRow("Total Takeoff Mass", Zlin.total_Mass.ToString(), Zlin.total_Arm.ToString(), Zlin.total_MassArm.ToString());
            Console.ReadLine();
        }

        public void MakeTable_METAR()
        {
            Console.Clear();
            PrintLine();
            PrintRow("", "ICAO", "TEMP", "QNH");
            PrintLine();
            PrintRow("Departure Airport", Airports[0].ICAOCODE.ToString(), Airports[0].temp.ToString(), Airports[0].QNH.ToString());
            PrintLine();
            PrintRow("Arrival Airport", Airports[1].ICAOCODE.ToString(), Airports[1].temp.ToString(), Airports[1].QNH.ToString());
            Console.ReadLine();
        }

        static void PrintLine()
        {
            Console.WriteLine(new string('-', tableWidth));
        }

        static void PrintRow(params string[] columns)
        {
            int width = (tableWidth - columns.Length) / columns.Length;
            string row = "|";

            foreach (string column in columns)
            {
                row += AlignCentre(column, width) + "|";
            }

            Console.WriteLine(row);
        }

        static string AlignCentre(string text, int width)
        {
            text = text.Length > width ? text.Substring(0, width - 3) + "..." : text;

            if (string.IsNullOrEmpty(text))
            {
                return new string(' ', width);
            }
            else
            {
                return text.PadRight(width - (width - text.Length) / 2).PadLeft(width);
            }
        }


    }
}
