using System;

namespace Test
{
    class Angle
    {
        public int degrees;
        public float minutes;
        public char direction;

        public Angle(int degrees, float minutes, char direction)
        {
            this.degrees = degrees;
            this.minutes = minutes;
            this.direction = direction;
        }
        public string Display_Angle()
        {
            string angle = $"{degrees}\u00b0{minutes}'{direction}";
            return angle;
        }
    }
}