using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab2_1_sem_2_kurs_oop
{
    class MyTime
    {
        private  int Hour { get; set; }
        private int Minute { get; set; }
        private int Second { get; set; }
        //public int _Hour
        //{
        //    get { return Hour; }
        //    set
        //    {
        //        if (value >= 0 && value <= 23)
        //            Hour = value;
        //        else if (value < 0)
        //            Hour = 0;
        //        else
        //            Hour = 23;
        //    }
        //}

        //public int _Minute
        //{
        //    get { return Minute; }
        //    set
        //    {
        //        if (value >= 0 && value <= 59)
        //            Minute = value;
        //        else if (value < 0)
        //            Minute = 0;
        //        else
        //            Minute = 59;
        //    }
        //}

        //public int _Second
        //{
        //    get { return Second; }
        //    set
        //    {
        //        if (value >= 0 && value <= 59)
        //            Second = value;
        //        else if (value < 0)
        //            Second = 0;
        //        else
        //            Second = 59;
        //    }
        //}
        // if for hours
        public MyTime(int hour, int minute, int second)
        {
            if (hour >= 25 || hour < 0)
            {
                throw new Exception("Input time is not in correct format");
            }
            Hour = hour;
            if (minute >= 60 || minute < 0)
            {
                throw new Exception("Input time is not in correct format");
            }
            Minute = minute;
            if (second >= 60 || second < 0)
            {
                throw new Exception("Input time is not in correct format");
            }
            Second = second;
        }

        public MyTime AddSeconds(int seconds)
        {
            int totalSeconds = Hour * 3600 + Minute * 60 + Second;
            totalSeconds += seconds;

            totalSeconds = (totalSeconds % 86400 + 86400) % 86400;

            return new MyTime(totalSeconds / 3600, (totalSeconds % 3600) / 60, totalSeconds % 60);
        }

        public MyTime AddMinutes(int minutes)
        {
            return AddSeconds(minutes * 60);
        }

        public MyTime AddHours(int hours)
        {
            return AddSeconds(hours * 3600);
        }

        public int Difference(MyTime otherTime)
        {
            int totalSeconds1 = Hour * 3600 + Minute * 60 + Second;
            int totalSeconds2 = otherTime.Hour * 3600 + otherTime.Minute * 60 + otherTime.Second;

            int difference = totalSeconds1 - totalSeconds2;
            difference = (difference + 43200) % 86400 - 43200; 

            return difference;
        }

        public string WhatLesson()
        {
            MyTime[] lessonStartTimes = {
            new MyTime(8, 0, 0),
            new MyTime(9, 40, 0),
            new MyTime(11, 20, 0),
            new MyTime(13, 0, 0),
            new MyTime(14, 40, 0),
            new MyTime(16, 10, 0)
        };

            MyTime[] lessonEndTimes = {
            new MyTime(9, 20, 0),
            new MyTime(11, 0, 0),
            new MyTime(12, 40, 0),
            new MyTime(14, 20, 0),
            new MyTime(16, 0, 0),
            new MyTime(17, 30, 0)
        };

            for (int i = 0; i < lessonStartTimes.Length; i++)
            {
                if (IsBefore(this, lessonStartTimes[i]))
                {
                    return "Lessons have not started yet";
                }
                else if (IsBetween(this, lessonStartTimes[i], lessonEndTimes[i]))
                {
                    return $"{i + 1}-st lesson";
                }
                else if (i < lessonEndTimes.Length - 1 && IsBetween(this, lessonEndTimes[i], lessonStartTimes[i + 1]))
                {
                    return $"Break between {i + 1}-st and {i + 2}-nd lessons";
                }
            }

            return "Lessons have ended";
        }

        public override string ToString()
        {
            return $"{Hour:D}:{Minute:D2}:{Second:D2}";
        }

        private static bool IsBefore(MyTime time, MyTime referenceTime)
        {
            return time.Hour < referenceTime.Hour ||
                   (time.Hour == referenceTime.Hour && time.Minute < referenceTime.Minute) ||
                   (time.Hour == referenceTime.Hour && time.Minute == referenceTime.Minute && time.Second < referenceTime.Second);
        }

        private static bool IsBetween(MyTime time, MyTime startTime, MyTime endTime)
        {
            return (IsAfterOrEqual(time, startTime) || time.Equals(startTime)) &&
                   (IsBefore(time, endTime) || time.Equals(endTime));
        }

        private static bool IsAfterOrEqual(MyTime time, MyTime referenceTime)
        {
            return time.Hour > referenceTime.Hour ||
                   (time.Hour == referenceTime.Hour && time.Minute > referenceTime.Minute) ||
                   (time.Hour == referenceTime.Hour && time.Minute == referenceTime.Minute && time.Second >= referenceTime.Second);
        }
    }
}
