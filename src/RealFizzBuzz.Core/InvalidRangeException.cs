using System;

namespace RealFizzBuzz.Core
{
    public class InvalidRangeException : Exception
    {
        public InvalidRangeException(int lower, int upper): base($"Invalid range error. {lower} is bigger then {upper}")
        {
        }
    }
}