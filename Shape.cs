using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpTipsAndTricksLunchLearn
{
    public class Shape
    {
        public int Width { get; set; }

        public int Height { get; set; }

        public int Length { get; set; }
    }

    public class Circle : Shape
    {
        public int Radius { get; set; }
    }

    public class Rectangle : Shape
    {

    }

    public class Square : Shape
    {

    }
}
