using System;
using System.Collections.Generic;
using System.Linq;

namespace Statistics
{
    public class StatsComputer
    {
        public double average;
        public double max;
        public double min;

        public Stats CalculateStatistics(List<double> numbers) {
            //Implement statistics here

            average = Stats.CalculateAverage(numbers);
            min = Stats.CalculateMin(numbers);
            max = Stats.CalculateMax(numbers);

            return new Stats();
        }
    }

    public class Stats
    {
        public int _average { get; set; }
        public int _max { get; set; }
        public int _min { get; set; }

        private static bool IsNanNumber(List<double> numbers)
        {
            Boolean result = false;

            if (numbers.Count > 0)
            {
                numbers.ForEach(x => result = double.IsNaN(x)); 
            }
            else
            {
                result = true;
            }

            return result;
        }

        public static double CalculateAverage(List<double> numbers)
        {
            double average = 0;
           if(!IsNanNumber(numbers))
            {
                average = numbers.Average();
                //double sam = Math.Abs(average - 4.525);
            }
            
            return average;
        }
        public static double CalculateMax(List<double> numbers)
        {
            double average = 0;
            if (!IsNanNumber(numbers))
            {
                average = numbers.Max();
                //double sam = Math.Abs(average - 4.525);
            }

            return average;
        }

        public static double CalculateMin(List<double> numbers)
        {
            double average = 0;
            if (!IsNanNumber(numbers))
            {
                average = numbers.Min();
                //double sam = Math.Abs(average - 4.525);
            }

            return average;
        }
    }

    public class StatsAlerter
    {
        private double _maxThreshold;
        readonly IAlerter[] _Ialerts;
        public StatsAlerter(double maxThreshold, IAlerter[] alerters)
        {
            _maxThreshold = maxThreshold;
            _Ialerts = alerters;
        }

        public void checkAndAlert(List<double> inputData)
        {
            EmailAlert emailAlert = (EmailAlert)_Ialerts[0];
            LEDAlert lEDAlert = (LEDAlert)_Ialerts[1];

            var maxData = inputData.Max();

            if(maxData > _maxThreshold)
            {
                emailAlert.emailSent = true;
                lEDAlert.ledGlows = true;
            }
        }

    }

    public interface IAlerter
    {
      
    }

    public class EmailAlert: IAlerter
    {
       public bool emailSent { get; set; }
        
    }

    public class LEDAlert: IAlerter
    {
        public bool ledGlows { get; set; }
        
    }
}
