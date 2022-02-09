using System;

namespace Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            //Primatives
            //Integrals
            sbyte sbyteValue = 10;
            short shortValue = 20;
            int intValue = 62_543;  //underscores can break up numbers; ignorned by compiler
            long longValue = 40L;

            //Floats
            float floatValue = 45.6F;
            double doubleValue = 5678.115;
            decimal decimalValue = 17.50M;

            //boolean
            bool isSuccessful = true;
            bool isFailing = false;

            //char
            char charizard = 'C';
            string poss = "Awesome opossum!";

            //Non-Primatives
            //DateTime
            //DateOnly
            //TimeOnly
            //TimeSpan

            //Guid - "Globally Unique Identifier" Used to statistically guarantee uniqueness


            //Arithmetic Operators

            // + plus   - minus     * multiply  / divide    % modulus



            //Strings

            var payRate = 8.75;

            var payRateString = payRate.ToString();

            //escape sequences - character sequence that represents something unprintable
            // \n - newline
            //  \t - tab
            //  \\ - single slash
            //  \" - double quote
            string literal = "Hellow World\nBob\t";
            string filePath = "C:\\windows\\system32";
            string filePath2 = @"C:\windows\system32";  //verbatim strings have no escape sequences
                                                        //and are used for file locations
        }
    }
}
