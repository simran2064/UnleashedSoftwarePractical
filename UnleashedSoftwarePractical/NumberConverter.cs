using System;

namespace UnleashedSoftwarePractical
{
    public class NumberConverter
    {
        public static void Main()
        {
            while (true)
            {
                Console.WriteLine("Please Enter Your Number");
                string number = Console.ReadLine();
                number = Convert.ToDouble(number).ToString();

                if (number == "0")
                {
                    Console.WriteLine("The number in currency format is Zero");
                }
                //Max number code stops decimals. Crashes with input error
                //if (Int64.Parse(number) >= 1000000000000)
                //{
                //    Console.WriteLine("Number too high, Please try again");
                //}
                else
                {
                    Console.WriteLine("The number in currency format is \n" + ConvertToWords(number) + "\nPress Enter To Continue");
                }
                Console.ReadKey();
            }
        }

        public static string ConvertToWords(string number)
        {
            string value = "";
            string wholenumber = number;
            string total = "";
            string andstring = "";
            string totalstring = "";
            string centstring = " ";
            int decimalPlace = number.IndexOf(".");

            if (decimalPlace > 0)
            {
                wholenumber = number.Substring(0, decimalPlace);
                total = number.Substring(decimalPlace + 1);
                if (Convert.ToInt32(total) > 0)
                {
                    andstring = "Dollars and ";//separates dollars and cents  
                    centstring = "Cents";//Cents  
                    totalstring = ConvertToDecimal(total);
                }
            }
            value = string.Format("{0} {1}{2} {3}", convertWholeNumber(wholenumber), andstring, totalstring, centstring);
            return value;
        }

        public static string convertWholeNumber(string number)
        {
            string word = "";
            bool startNumber = false;
            bool numberConverted = false;
            double amount = (Convert.ToDouble(number));
            if (amount > 0)
            {
                startNumber = number.StartsWith("0");

                int dollarNumber = number.Length;
                int digit = 0;
                string place = "";
                switch (dollarNumber)
                {
                    case 1:
                        word = ones(number);
                        numberConverted = true;
                        break;
                    case 2:
                        word = tens(number);
                        numberConverted = true;
                        break;
                    case 3:
                        digit = (dollarNumber % 3) + 1;
                        place = " Hundred ";
                        break;
                    case 4:
                    case 5:
                    case 6:
                        digit = (dollarNumber % 4) + 1;
                        place = " Thousand ";
                        break;
                    case 7:
                    case 8:
                    case 9:
                        digit = (dollarNumber % 7) + 1;
                        place = " Million ";
                        break;
                    case 10:
                    case 11:
                    case 12:

                        digit = (dollarNumber % 10) + 1;
                        place = " Billion ";
                        break;
                    default:
                        numberConverted = true;
                        break;
                }
                if (!numberConverted)
                {
                    if (number.Substring(0, digit) != "0" && number.Substring(digit) != "0")
                    {
                        try
                        {
                            word = convertWholeNumber(number.Substring(0, digit)) + place + convertWholeNumber(number.Substring(digit));
                        }
                        catch { }
                    }
                    else
                    {
                        word = convertWholeNumber(number.Substring(0, digit)) + convertWholeNumber(number.Substring(digit));
                    }

                }
                if (word.Equals(place)) word = "";
            }

            return word;
        }

        public static string tens(string number)
        {
            int _number = Convert.ToInt32(number);
            string name = null;
            switch (_number)
            {
                case 10:
                    name = "Ten";
                    break;
                case 11:
                    name = "Eleven";
                    break;
                case 12:
                    name = "Twelve";
                    break;
                case 13:
                    name = "Thirteen";
                    break;
                case 14:
                    name = "Fourteen";
                    break;
                case 15:
                    name = "Fifteen";
                    break;
                case 16:
                    name = "Sixteen";
                    break;
                case 17:
                    name = "Seventeen";
                    break;
                case 18:
                    name = "Eighteen";
                    break;
                case 19:
                    name = "Nineteen";
                    break;
                case 20:
                    name = "Twenty";
                    break;
                case 30:
                    name = "Thirty";
                    break;
                case 40:
                    name = "Fourty";
                    break;
                case 50:
                    name = "Fifty";
                    break;
                case 60:
                    name = "Sixty";
                    break;
                case 70:
                    name = "Seventy";
                    break;
                case 80:
                    name = "Eighty";
                    break;
                case 90:
                    name = "Ninety";
                    break;
                default:
                    if (_number > 0)
                    {
                        name = tens(number.Substring(0, 1) + "0") + " " + ones(number.Substring(1));
                    }
                    break;
            }
            return name;
        }
        public static string ones(string number)
        {
            int _number = Convert.ToInt32(number);
            string name = null;
            switch (_number)
            {
                case 1:
                    name = "One";
                    break;
                case 2:
                    name = "Two";
                    break;
                case 3:
                    name = "Three";
                    break;
                case 4:
                    name = "Four";
                    break;
                case 5:
                    name = "Five";
                    break;
                case 6:
                    name = "Six";
                    break;
                case 7:
                    name = "Seven";
                    break;
                case 8:
                    name = "Eight";
                    break;
                case 9:
                    name = "Nine";
                    break;
            }
            return name;
        }

        //Code to convert to cents after .
        //Error: Goes to one cent if .10 is entered. Doesnt recognise 0 at the end
        //More then three digits returns first number in tens for eg 
        public static string ConvertToDecimal(string number)
        {
            string digit = "";
            string engOne = "";
            for (int i = 0; i < number.Length; i++)
            {
                digit = number[i].ToString();
                if (number.Equals("0"))
                {
                    engOne = "Zero";
                }
                if (int.Parse(number) >= 1 && int.Parse(number) <= 9)
                {
                    engOne = ones(digit);
                }
                else
                {
                    engOne = tens(number);
                }
            }
            return engOne;
        }
    }
}
