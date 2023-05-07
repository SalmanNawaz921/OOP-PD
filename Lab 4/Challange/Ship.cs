using System;

namespace Test
{
    class Ship
    {
        public string serialNo;
        public Angle latitude;
        public Angle longitude;

        public Ship(string serialNo, int latDegree, float latMin, char latDir, int lonDegree, float lonMin, char lonDir)
        {
            this.serialNo = serialNo;
            this.latitude = new Angle(latDegree, latMin, latDir);
            this.longitude = new Angle(lonDegree, lonMin, lonDir);
        }
        public void Ship_Position()
        {
            Console.WriteLine("Ship is at: " + latitude.Display_Angle() + " and " + longitude.Display_Angle());
        }
        public void Ship_Serial()
        {
            Console.WriteLine("Ships serial number is: " + serialNo);
        }
    }
}