using System;
using System.Collections.Generic;


using BMIList = SegmentsList.SegmentsList<double, string>;
using AgesBMIList = SegmentsList.SegmentsList<int, SegmentsList.SegmentsList<double, string>>;


namespace SegmentsList
{
    class Program
    {
        static void TestSegmentsList()
        {
            BMIList middle = new BMIList();
            middle.Add(0, "Дефицит массы тела");
            middle.Add(19.5, "Норма");
            middle.Add(23, "Избыток массы тела");
            middle.Add(27.5, "Ожирение 1 степени");
            middle.Add(30, "Ожирение 2 степени");
            middle.Add(35, "Ожирение 3 степени");
            middle.Add(40, "Ожирение 4 степени");

            BMIList old = new BMIList();
            old.Add(0, "Дефицит массы тела");
            old.Add(20, "Норма");
            old.Add(26, "Избыток массы тела");
            old.Add(28, "Ожирение 1 степени");
            old.Add(31, "Ожирение 2 степени");
            old.Add(36, "Ожирение 3 степени");
            old.Add(41, "Ожирение 4 степени");

            AgesBMIList list = new AgesBMIList();
            list.Add(18, middle);
            list.Add(30, old);

            for (int age = 18; age < 100; ++age)
            {
                Console.WriteLine("==========   age = {0}   ===========", age);
                for (double bmi = 0.0; bmi < 50; bmi += 0.5)
                    Console.WriteLine("BMI = {0}; {1}", bmi, list[age][bmi]);
                Console.WriteLine("===================================");
            }
        }

        static void Main(string[] args)
        {
            TestSegmentsList();
        }
    }
}
