using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace UnityEssentials
{
    [Serializable]
    public struct ClockTime : IComparable<ClockTime>, IEquatable<ClockTime>
    {
        [field: SerializeField]
        public int Hour {get; private set;}

        [field: SerializeField]
        public int Minute { get; private set; }
        public ClockTime(int hour, int minute = 0)
        {
            (Hour, Minute) = (hour, minute);
        }

        public float InSeconds()
        {
            return Hour * 3600 + Minute * 60;
        }

        public static float InSeconds(int days=0, int hours=0, int minutes=0)
        {
            return 86400 * days + 3600 * hours + minutes * 60;
        }

        public bool IsInInterval(ClockTime start, ClockTime end)
        {
            if (start < end)
            {
                if (start <= this && this <= end) return true;
                return false;
            }

            if (start > end)
            {
                if (this >= start && this > end) return true;

                if (this < start && this <= end) return true;

                return false;
            }

            if (this == start) return true;

            return false;
        }

        public static ClockTime SecondsToClockTime(float seconds)
        {
            int hours = (int)seconds / 3600;
            seconds -= hours * 3600;
            int minutes = (int)(seconds / 60);
            return new ClockTime(hours, minutes);
        }

        public int CompareTo(ClockTime other)
        {
            if (other.Hour < Hour) return 1;
            if (other.Hour > Hour) return -1;
            return Minute.CompareTo(other.Minute);
        }

        public bool Equals(ClockTime other)
        {
            if (Hour == other.Hour && Minute == other.Minute) return true;
            return false;
        }

        public static bool operator >(ClockTime operand1, ClockTime operand2)
        {
            return operand1.CompareTo(operand2) > 0;
        }

        // Define the is less than operator.
        public static bool operator <(ClockTime operand1, ClockTime operand2)
        {
            return operand1.CompareTo(operand2) < 0;
        }

        // Define the is greater than or equal to operator.
        public static bool operator >=(ClockTime operand1, ClockTime operand2)
        {
            return operand1.CompareTo(operand2) >= 0;
        }

        // Define the is less than or equal to operator.
        public static bool operator <=(ClockTime operand1, ClockTime operand2)
        {
            return operand1.CompareTo(operand2) <= 0;
        }

        public static bool operator ==(ClockTime operand1, ClockTime operand2)
        {
            return operand1.CompareTo(operand2) == 0;
        }

        public static bool operator !=(ClockTime operand1, ClockTime operand2)
        {
            return operand1.CompareTo(operand2) != 0;
        }

        public override string ToString()
        {
            return $"{Hour}:{Minute}";
        }

        public static ClockTime Parse(string operand)
        {
            Console.WriteLine(operand.Substring(0, 2) + " " + operand.Substring(3, 2));

            ClockTime time = new ClockTime(int.Parse(operand.Substring(0, 2)), int.Parse(operand.Substring(3, 2)) );
            Console.WriteLine(time.Hour + " " + time.Minute);

            return time;
        }

        public override bool Equals(object obj)
        {
            if (obj is ClockTime other)
            {
                if (Hour == other.Hour && Minute == other.Minute) return true;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }

}
