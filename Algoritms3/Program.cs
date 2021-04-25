using System;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

namespace Algoritms3
{
    public class PointClass
    {
        public float X;
        public float Y;
    }
    public struct PointStruct
    {
        public float X;
        public float Y;
    }
    public struct PointStructDouble
    {
        public double X;
        public double Y;
    }

    public class Program
    {
        static void Main(string[] args)
        {
            BenchmarkSwitcher.FromAssembly(typeof(Program).Assembly).Run(args);
        }
    }
    public class BenchMarkClass
    {
      
        PointClass ClassPoint1 = new PointClass()
        { X = 2, Y = -15 };

        PointClass ClassPoint2 = new PointClass()
        { X = 5, Y = 9 };

        PointStruct StructPoint1 = new PointStruct()
        { X = -2, Y = 10 };

        PointStruct StructPoint2 = new PointStruct()
        { X = 11, Y = -15 };

        PointStructDouble StructPoint1D = new PointStructDouble()
        { X = 1.255858, Y = 2.449896 };

        PointStructDouble StructPoint2D = new PointStructDouble()
        { X = 2.18654654654654, Y = 4.9898979879 };

        public static float PointDistFloatClass(PointClass pointOne, PointClass pointTwo)
        {
            float x = pointOne.X - pointTwo.X;
            float y = pointOne.Y - pointTwo.Y;
            return (float)Math.Sqrt((x * x) + (y * y));
        }

        public static float PointDistFloatStruct(PointStruct pointOne, PointStruct pointTwo)
        {
            float x = pointOne.X - pointTwo.X;
            float y = pointOne.Y - pointTwo.Y;
            return (float)Math.Sqrt((x * x) + (y * y));
        }
        public static double PointDistDoubleClass(PointStructDouble pointOne, PointStructDouble pointTwo)
        {
            double x = pointOne.X - pointTwo.X;
            double y = pointOne.Y - pointTwo.Y;
            return Math.Sqrt((x * x) + (y * y));
        }

        public static double PointDistFloatStructShort(PointStruct pointOne, PointStruct pointTwo)
        {
            float x = pointOne.X - pointTwo.X;
            float y = pointOne.Y - pointTwo.Y;
            return (x * x) + (y * y);
        }


        [Benchmark]
        public void TestPointDistFloatClass()
        {
            PointDistFloatClass(ClassPoint1, ClassPoint2);
        }

        [Benchmark]
        public void TestPointDistFloatStruct()
        {
            PointDistFloatStruct(StructPoint1, StructPoint2);
        }

        [Benchmark]
        public void TestPointDistDoubleClass()
        {
            PointDistDoubleClass(StructPoint1D, StructPoint2D);
        }

        [Benchmark]
        public void TestPointDistDoubleStructShort()
        {
            PointDistFloatStructShort(StructPoint1, StructPoint2);
        }

    }

}


