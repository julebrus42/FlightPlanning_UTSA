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

            String[] message = {    "Total Mass: " + Zlin.total_Mass.ToString(),
                                    "Total Arm: " + Zlin.total_Arm,
                                    "Total MassArm: " + Zlin.total_MassArm};

            Display(message);
        }

        public double AskUser(string question) {
            double answer;

            Console.WriteLine(question);
            answer = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine(answer);

            return answer;
        }

        public void Display(String[] message) {
            foreach (String value in message)
            {
                Console.WriteLine(value.ToString());
            }

        }


    }
}
