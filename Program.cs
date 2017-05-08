using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpTipsAndTricksLunchLearn
{
    class Program
    {
        static void Main(string[] args)
        {
            // property initializers (see Person.cs)

            // NullPropDemo();

            // StringInterpolationDemo();

            // StringJoinDemo();

            // NullCoalescing();

            // NameOfDemo();

            // EqualsAndCompare();

            // IsAndAssignment();

            // SoMuchBetterOutputParameters();

            // ExceptionFilterDemo();

            Console.WriteLine("Press any key");
            Console.ReadKey();
        }

        static void StringInterpolationDemo()
        {
            // old
            Console.WriteLine(string.Format("It is now {0:yyyy-MM-dd HH:mm} on computer {1}", DateTimeOffset.Now, Environment.MachineName));

            // new
            Console.WriteLine($"It is now {DateTimeOffset.Now:yyyy-MM-dd HH:mm} on computer {Environment.MachineName}.");

            string firstName = "Justin";

            var birthDate = new DateTimeOffset(1981, 09, 25, 0, 0, 0, TimeSpan.Zero);
            var now = DateTimeOffset.Now;

            Console.WriteLine($"I was born on {birthDate} so I guess I'm {(now - birthDate).TotalDays} days old. Crap.");
        }

        static void NullPropDemo()
        {
            Person user = null;

            try
            {
                // New in C# 6.0, this is called "null propagation"

                if (user?.IsActive == true)
                {
                    Console.WriteLine("This won't thrown a null ref exception. Yay!");
                }

                if (user.IsActive == false)
                {
                    Console.WriteLine("You'll never see me");
                }
            }
            catch (Exception ex) 
            {
                Console.WriteLine($"Oh noes! An error! {ex.Message}");
            }


            try
            {
                var peeps = new string[] { "Justin", "Jason" };

                if (peeps?[2] == null)
                {
                    Console.WriteLine("This won't thrown a index exception. Yay!");
                }

                if (peeps[2] == "Justin")
                {
                    Console.WriteLine("You'll never see me");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Oh noes! An error! {ex.Message}");
            }
        }

        static void NullCoalescing()
        {
            string defaultText = "Hello World";
            string customText = null;
            string someOtherThing = "Foo";

            Console.WriteLine($"Message: {customText ?? defaultText ?? someOtherThing}");

            string message = customText ?? defaultText;
            Console.WriteLine($"Message: {message}");

            var creator = new Person() { FirstName = "Bob" };
            Person modifiedBy = null;

            Console.WriteLine($"Last touched by: {(modifiedBy ?? creator).FirstName}");
        }

        public IEnumerable<Person> GetPersons(string firstNameFilter)
        {

            if (firstNameFilter == null)
            {
                throw new ArgumentNullException(nameof(firstNameFilter));
            }

            if (true)
            {
                return Enumerable.Empty<Person>();
            }
        }
        
        static void StringJoinDemo()
        {




            var thingsToDisplay = new string[] { "Some", "Text", "That", "Needs", "To", "Be", "Seperated" };

            //nope
            bool first = true;
            var result = new StringBuilder();
            for (int i = 0; i < thingsToDisplay.Length; i++)
            {
                if (!first)
                {
                    result.Append("-");
                }

                result.Append(thingsToDisplay[i]);

                first = false;
            }
            Console.WriteLine(result.ToString());

            //yep
            Console.WriteLine(string.Join("-", thingsToDisplay));

        }

        static void NameOfDemo()
        {
            var person = new Person()
            {
                FirstName = "Jane",
                LastName = "Doe"                
            };
            
            Console.WriteLine($"The value of {nameof(Person.FirstName)} is {person.FirstName}");
            Console.WriteLine($"The value of {nameof(Person.LastName)} is {person.LastName}");
            Console.WriteLine($"CurrentThread: {nameof(System.Threading.Thread.CurrentThread)}");
        }


        static void EqualsAndCompare()
        {
            var test1 = "Bob";
            var test2 = "bob";


            Console.WriteLine($"{test1} equals {test2} (Ordinal): {test1.Equals(test2, StringComparison.Ordinal)}");
            Console.WriteLine($"{test1} equals {test2} (OrdinalIgnoreCase): {test1.Equals(test2, StringComparison.OrdinalIgnoreCase)}");

        }

        static void IsAndAssignment()
        {
            object somethin = GetSomething();

            if (somethin is Person person && person.IsActive)
            {
                Console.WriteLine($"yes is a person: {person.FullName}.");
            }
            else
            {
                Console.WriteLine("not a person");
            }
        }

        static object GetSomething()
        {
            return new Person()
            {
                FirstName = "Bob",
                LastName = "Dole"
            };
        }

        static void SoMuchBetterOutputParameters()
        {
            //This is supported in C# 7

            Console.WriteLine("Enter a number:");
            string input = Console.ReadLine();

            //double number;

            if (double.TryParse(input, out double number))
            {
                Console.WriteLine($"Yep, {number} is a number.");
            }
            else
            {
                Console.WriteLine("Nope, not a number.");
            }
        }
        
        static void CaseConditionssDemo()
        {
            var shape = new Shape();

            // blah blah blah

            //This is supported in C# 7

            switch (shape)
            {
                // type-based case conditions
                case Circle c:
                    Console.WriteLine($"circle with radius {c.Radius}");
                    break;
                    // when
                case Rectangle s when (s.Length == s.Height):
                    Console.WriteLine($"{s.Length} x {s.Height} square");
                    break;
                case Rectangle r:
                    Console.WriteLine($"{r.Length} x {r.Height} rectangle");
                    break;
                default:
                    Console.WriteLine("<unknown shape>");
                    break;
                case null:
                    throw new ArgumentNullException(nameof(shape));
            }
        }

        static void ExceptionFilterDemo()
        {
            //This is supported in C# 7

            try
            {
                throw new Exception("Foo");
                throw new Exception("Bar");
            }
            catch (Exception ex) when (ex.Message.Contains("Foo"))
            {
                Console.WriteLine($"The Foo exception was thrown: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}