using System.ComponentModel;

namespace Task.Backend
{
    public class Time
    {
        private int _hour;
        private int _minute;
        private int _second;
        private int _millisecond;

        public Time()
        {
        }

        public Time(int hour)
        {
            Hour = hour;
        }

        public Time(int hour, int minute)
        {
            Hour = hour;
            Minute = minute;
        }

        public Time(int hour, int minute, int second)
        {
            Hour = hour;
            Minute = minute;
            Second = second;
        }

        public Time(int hour, int minute, int second, int millisecond)
        {
            Hour = hour;
            Minute = minute;
            Second = second;
            Millisecond = millisecond;
        }

        public int Hour
        {
          get => _hour;
          set => _hour = ValidHour(value);
        }
        public int Minute
        { 
          get => _minute;
          set => _minute = ValidMinute(value);
        }
        public int Second
        { 
          get => _second;
          set => _second = ValidSecond(value);
        }
        public int Millisecond
        { 
          get => _millisecond;
          set => _millisecond = ValidMillisecond(value);
        }

        public override string ToString()
        {
            if (Hour >= 12)
            {
                Hour -= 12;
                return $"{Hour:00}:{Minute:00}:{Second:00}.{Millisecond:00} PM";
            }            
            return $"{Hour:00}:{Minute:00}:{Second:00}.{Millisecond:00} AM";
        }


        private int ValidHour(int hour)
        {
            if (hour < 0 || hour > 23)
            {
                throw new ArgumentOutOfRangeException(nameof(hour), "The hour value must be between 0 and 23");
            }
            return hour;
        }

        private int ValidMinute(int minute)
        {
            if (minute < 0 || minute > 59)
            {
                throw new ArgumentOutOfRangeException(nameof(minute), "The hour value must be between 0 and 59");
            }
            return minute;
        }

        private int ValidSecond(int second)
        {
            if (second < 0 || second > 59)
            {
                throw new ArgumentOutOfRangeException(nameof(second), "The hour value must be between 0 and 59");
            }   
            return second;
        }

        private int ValidMillisecond(int millisecond)
        {
            if (millisecond < 0 || millisecond > 999)
            {
                throw new ArgumentOutOfRangeException(nameof(millisecond), "The hour value must be between 0 and 999");
            }
            return millisecond;
        }

        //public int ToMillisecond()
        //{

        //}

    }
} 
