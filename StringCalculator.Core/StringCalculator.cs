using System;
using System.Collections.Generic;
using System.Linq;

namespace Calculator.Core
{
    public class StringCalculator
    {
        /// <summary>
        /// Adds the number on a string less than 1000
        /// Negative numbers are not allowed on the string
        /// </summary>
        /// <param name="numbers">String to calculate</param>
        /// <returns><see cref="int"/>Sum</returns>
        public int Add(string numbers)
        {
            // initializing the result to 0 or default value
            int result = 0;
            // initializing the default delimiter of coma
            string delimiters = ",";
            // initializing a list to keep any negative numbers to be displayed 
            // on the custom exception
            List<int> negativeNumbers = new List<int>();
            // checking if the input is empty or null, if it is
            // then returning immediately 0 as there is no calculations to do
            if (string.IsNullOrEmpty(numbers))
            {
                return result;
            }
            // detecting the special set of chars to identify the delimiters to be used
            if (numbers.Substring(0, 2) == "//")
            {
                // removing the special chars from the string as it will not be used anymore
                numbers = numbers.Substring(2, numbers.Length - 2);
                // getting only the first line that contains the delimiter and trying to return
                // the default delimiter if something goes wrong
                try
                {
                    delimiters = numbers.Split("\n")[0].ToLower() ?? ",";
                }
                catch
                {
                    delimiters = ",";
                }
            }
            // adding the return char to the delimiters to detect several lines 
            delimiters += "\n";
            // breaking the remaining string using the delimiters found or the default one and removing any 
            // empty data that exists. there will always be some empties, thats live :)
            string[] strArray = numbers.Split(delimiters.ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            // checking if the string only contains one number or one entry. if this is the case we will
            // raise a custom exception InvalidInputException
            if (strArray.Count() == 1)
            {
                throw new InvalidInputException("There is only one item in the input and we need at least two to tango!!!");
            }
            // all seems good to start the calculation so proceeding with the loop
            for (var i = 0; i < strArray.Length; i++)
            {
                // trying to parse the string into int, in case fails it will return 0 and will  not affect calculations.
                // this will help if there is any invalid characters on the string and we can still calculate the rest
                int.TryParse(strArray[i], out int parsedNumber);
                // if the number is less than 0 then we will add it to the list of negatives for later raise of the exception
                if (parsedNumber < 0)
                {
                    negativeNumbers.Add(parsedNumber);
                }
                // if the number is bigger than 1000 we will add it otherwise will be ignored
                if (parsedNumber <= 1000)
                {
                    result += parsedNumber;
                }
            }
            // if we have negatives we then need to raise a custom exception showing them
            if (negativeNumbers.Count() > 0)
            {
                // starting to build the message to show with all the detected negative numbers
                string negativeExceptionMessage = string.Empty;
                // iterating throw the loop of the list containing the negative numbers
                foreach (int negative in negativeNumbers)
                {
                    if (negativeExceptionMessage.Length > 0)
                    {
                        negativeExceptionMessage += ", ";
                    }
                    negativeExceptionMessage += $"{negative}";

                }
                // setting the result back to 0 or default, this is not really needed as we will never get to the return 
                // but just in case.
                result = 0;
                // checking if we have a number or numbers for the message
                string plural = (negativeNumbers.Count() == 1) ? " is: " : "s are: ";
                // throwing the custom exception with the gathered negative numbers
                throw new NegativeNotAllowedException($"Negatives are not allowed. The number{plural} {negativeExceptionMessage}");
            }
            // returning the result
            return result;
        }
    }
}
