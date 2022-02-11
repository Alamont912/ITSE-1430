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
            payRateString = (5+4).ToString();

            //escape sequences - character sequence that represents something unprintable
            // \n - newline
            //  \t - tab
            //  \\ - single slash
            //  \" - double quote
            string literal = "Hellow World\nBob\t";
            string filePath = "C:\\windows\\system32";
            string filePath2 = @"C:\windows\system32";  //verbatim strings have no escape sequences
                                                        //and are used for file locations

            string nullString = null;   //these ain't equal
            string emptyString = "";    //many things will crash if used with a null string
            string emptyString2 = String.Empty;
            //to determine if a string is empty, check for BOTH null OR emptiness
            bool isEmpty = (emptyString == null || emptyString == "");  //don't do this

            //useful string functions:
            isEmpty = String.IsNullOrEmpty(emptyString);    //returns true if empty
            isEmpty = emptyString.Length == 0;          // .Length, if length = null, program crashes


            //case-sensitivity
            string lowerName = "jasper", upperName = "JASPER";
            bool areStringsEqual = lowerName == upperName;  //false!
            areStringsEqual = lowerName.ToUpper() == upperName.ToUpper();   //normalization, true

            String.Compare(lowerName, upperName, true);   //returns an int, <0 - A<B, 0 - A==B, <0 - A>B
            //StringComparison.IgnoreCase ------ ^^^^      //handles null cases

            String.Equals(lowerName, upperName, StringComparison.CurrentCultureIgnoreCase);


            string doof = "Curse you, Perry The Platypus!!  ";
            bool startsWithLetter = doof.StartsWith("C");

            string doofur = doof.Trim();     //these remove spacing     .TrimStart     .TrimEnd

            doofur = doofur.PadLeft(3);      //these add spacing
            doofur = doofur.PadRight(4);


            //Joining Strings
            String.Join(' ', "John", "Jacob", "Jakenheimer", "Schmidt");//his name is my name too
            string numbers = String.Join(", ", 1, 2, 3, 4);

            //Splitting Strings
            var tokens = "1|2|3|4".Split("|");
        }
    }
}
