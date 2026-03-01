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
            int hour12;
            if (Hour >= 12)
            {
                hour12 = Hour - 12;
                return $"{hour12:00}:{Minute:00}:{Second:00}.{Millisecond:000} PM";
            }
            return $"{Hour:00}:{Minute:00}:{Second:00}.{Millisecond:000} AM";
        }


        private int ValidHour(int hour)
        {
            if (hour < 0 || hour > 23)
            {
                throw new Exception($"The hour: {hour}, is not valid");
            }
            return hour;
        }

        private int ValidMinute(int minute)
        {
            if (minute < 0 || minute > 59)
            {
                throw new Exception($"The hour: {minute}, is not valid");
            }
            return minute;
        }

        private int ValidSecond(int second)
        {
            if (second < 0 || second > 59)
            {
                throw new Exception($"The hour: {second}, is not valid");
            }
            return second;
        }

        private int ValidMillisecond(int millisecond)
        {
            if (millisecond < 0 || millisecond > 999)
            {
                throw new Exception($"The hour: {millisecond}, is not valid");
            }
            return millisecond;
        }

        public int ToMillisecond() => (Hour * 3600000) + (Minute * 60000) + (Second * 1000) + Millisecond;

        public int ToSecond() => (Hour * 3600) + (Minute * 60) + Second;

        public int ToMinute() => (Hour * 60) + Minute;

        public Time Add(Time myTimeT3)
        {
            int totalMilliseconds = myTimeT3.Millisecond + Millisecond;
            int saveSeconds = totalMilliseconds / 1000;
            int finalMilliseconds = totalMilliseconds % 1000;

            int totalSeconds = myTimeT3.Second + Second + saveSeconds;
            int saveMinutes = totalSeconds / 60;
            int finalSeconds = totalSeconds % 60;

            int totalMinutes = myTimeT3.Minute + Minute + saveMinutes;
            int saveHour = totalMinutes / 60;
            int finalMinutes = totalMinutes % 60;

            int totalHours = myTimeT3.Hour + Hour + saveHour;
            int finalHours = totalHours % 24;

            return new Time(finalHours, finalMinutes, finalSeconds, finalMilliseconds);
        }

        public bool IsOtherDay(Time myTimeT4)
        {
           int totalMilliseconds = ToMillisecond() + myTimeT4.ToMillisecond();
           return totalMilliseconds > 86400000;
        }



    }
} 
