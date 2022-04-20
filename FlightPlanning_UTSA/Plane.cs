using System;
using System.Collections.Generic;
using System.Text;


namespace FlightPlanning_UTSA
{
    class Plane
    {
        //Mass
        public double BEM_Mass {get; set;}
        public double LeftSeat_Mass {get; set;}
        public double RightSeat_Mass {get; set;}
        public double FuelMain_Mass {get; set;}
        public double FuelAux_Mass {get; set;}
        public double Baggage_Mass {get; set;}

        //Arm
        public double BEM_Arm {get; set;}
        public double LeftSeat_Arm {get; set;}
        public double RightSeat_Arm {get; set;}
        public double FuelMain_Arm {get; set;}
        public double FuelAux_Arm {get; set;}
        public double Baggage_Arm {get; set;}

        //MassArm
        public double BEM_MassArm {get; set;}
        public double LeftSeat_MassArm {get; set;}
        public double RightSeat_MassArm {get; set;}
        public double FuelMain_MassArm {get; set;}
        public double FuelAux_MassArm {get; set;}
        public double Baggage_MassArm {get; set;}

        public double total_Mass {get; set;} = 0;
        public double total_MassArm{get; set;} = 0;
        public double total_Arm{get; set;} = 0;


        public Plane() {
            
        }

        public Plane(double bEM_Arm, double leftSeat_Arm, double rightSeat_Arm, double fuelMain_Arm, double fuelAux_Arm, double baggage_Arm)
            {
                BEM_Arm = bEM_Arm;
                LeftSeat_Arm = leftSeat_Arm;
                RightSeat_Arm = rightSeat_Arm;
                FuelMain_Arm = fuelMain_Arm;
                FuelAux_Arm = fuelAux_Arm;
                Baggage_Arm = baggage_Arm;
            }
        public void addToTotalMass(double mass) {
            total_Mass += mass;
        }

        public void calculateMassArmS() {
            
            BEM_MassArm = BEM_Mass * BEM_Arm;
            total_MassArm += BEM_MassArm;

            LeftSeat_MassArm = LeftSeat_Mass * LeftSeat_Arm;
            total_MassArm += LeftSeat_MassArm;

            RightSeat_MassArm = RightSeat_Mass * RightSeat_Arm;
            total_MassArm += RightSeat_MassArm;

            FuelMain_MassArm = FuelMain_Mass * FuelMain_Arm;
            total_MassArm += FuelMain_MassArm;

            FuelAux_MassArm = FuelAux_Mass * FuelAux_Arm;
            total_MassArm += FuelAux_MassArm;

            Baggage_MassArm = Baggage_Mass * Baggage_Arm;
            total_MassArm += Baggage_MassArm;
        }

        public void calculateTotalArm() {
            total_Arm = total_MassArm / total_Mass;
        }

    }
}
