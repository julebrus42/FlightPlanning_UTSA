using System;

namespace FlightPlanning_UTSA
{
    class Program
    {
        Plane Zlin;
        
        static void Main(string[] args)
        {
            
            var program = new Program();
            
            bool run = true;
            
            while(run) {
                program.RunProgram();
            }
        }


        public void RunProgram() {

                addPlanes();

                weightAndBalance();

        }

        public void addPlanes(){
            
            Zlin = new Plane(0.653, 0.956, 0.956, 0.750, 0.948, 1.766);
        }

        public void weightAndBalance() {
            double response;

            response = AskUser("Basic empty mass:");
            Zlin.BEM_Mass = response;
            Zlin.addToTotalMass(response);

            response = AskUser("Left Seat mass:");
            Zlin.LeftSeat_Mass = response;
            Zlin.addToTotalMass(response);

            response = AskUser("Right Seat mass:");
            Zlin.RightSeat_Mass = response;
            Zlin.addToTotalMass(response);

            response = AskUser("Main FuelTank mass:");
            Zlin.FuelMain_Mass = response;
            Zlin.addToTotalMass(response);

            response = AskUser("Auxilary FuelTank mass:");
            Zlin.FuelAux_Mass = response;
            Zlin.addToTotalMass(response);

            response = AskUser("Baggage mass:");
            Zlin.Baggage_Mass = response;
            Zlin.addToTotalMass(response);

            Zlin.calculateMassArmS();
            Zlin.calculateTotalArm();

            String[] message = {    "   Mass    |   Arm    |    MassArm",
                                    "   " + Zlin.BEM_Mass + "   |   " + Zlin.BEM_Arm + "    |   " + Zlin.BEM_MassArm,
                                    "   " + Zlin.LeftSeat_Mass + "   |   " + Zlin.LeftSeat_Arm + "    |   " + Zlin.LeftSeat_MassArm

                                    };
            //Display(message);

            MakeTable();
        }

        public double AskUser(string question) {
            double answer;

            Console.WriteLine(question);
            answer = Convert.ToDouble(Console.ReadLine());

            return answer;
        }

        public void Display(String[] message) {
            foreach (String value in message)
            {
                Console.WriteLine(value.ToString());
            }

        }

        static int tableWidth = 73;

        public void MakeTable()
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
