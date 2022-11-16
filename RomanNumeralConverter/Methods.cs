using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RomanNumeralConverter
{
    public class Methods
    {
        #region From Arabic Number To Roman Numeral
        public static string ToRoman(int n)
        {
            var nList = n.ToString()
                         .Select(x => int.Parse(x.ToString()))
                         .Reverse()
                         .ToList();

            var rn1 = "";
            var rn2 = "";
            var rn3 = "";
            var rn4 = "";

            switch (nList[0])
            {
                case 0: rn1 = ""; break;
                case 1: rn1 = "I"; break;
                case 2: rn1 = "II"; break;
                case 3: rn1 = "III"; break;
                case 4: rn1 = "IV"; break;
                case 5: rn1 = "V"; break;
                case 6: rn1 = "VI"; break;
                case 7: rn1 = "VII"; break;
                case 8: rn1 = "VIII"; break;
                case 9: rn1 = "IX"; break;
            }

            if (nList.Count() > 1)
            {
                switch (nList[1])
                {
                    case 0: rn2 = ""; break;
                    case 1: rn2 = "X"; break;
                    case 2: rn2 = "XX"; break;
                    case 3: rn2 = "XXX"; break;
                    case 4: rn2 = "XL"; break;
                    case 5: rn2 = "L"; break;
                    case 6: rn2 = "LX"; break;
                    case 7: rn2 = "LXX"; break;
                    case 8: rn2 = "LXXX"; break;
                    case 9: rn2 = "XC"; break;
                }

                if (nList.Count() > 2)
                {
                    switch (nList[2])
                    {
                        case 0: rn3 = ""; break;
                        case 1: rn3 = "C"; break;
                        case 2: rn3 = "CC"; break;
                        case 3: rn3 = "CCC"; break;
                        case 4: rn3 = "CD"; break;
                        case 5: rn3 = "D"; break;
                        case 6: rn3 = "DC"; break;
                        case 7: rn3 = "DCC"; break;
                        case 8: rn3 = "DCCC"; break;
                        case 9: rn3 = "CM"; break;
                    }

                    if (nList.Count() > 3)
                    {
                        switch (nList[3])
                        {
                            case 0: rn4 = ""; break;
                            case 1: rn4 = "M"; break;
                            case 2: rn4 = "MM"; break;
                            case 3: rn4 = "MMM"; break;
                        }
                    }
                }
            }

            return rn4 + rn3 + rn2 + rn1;
        }
        #endregion From Arabic Number To Roman Numeral

        #region From Roman Numeral To Arabic Number
        public static int FromRoman(string romanNumeral)
        {
            //Checking to see if Digit 1 is 9
            var nineCheckX = romanNumeral.LastIndexOf('X');
            var nineCheckI = romanNumeral.IndexOf('I');
            int num1 = (nineCheckX > nineCheckI && nineCheckI != -1) ? 9 : 0;

            if (num1 != 9)
            {
                var num1Switch = String.Join("", romanNumeral.Where(x => x == 'I' || x == 'V'));

                switch (num1Switch)
                {
                    case "I": num1 = 1; break;
                    case "II": num1 = 2; break;
                    case "III": num1 = 3; break;
                    case "IV": num1 = 4; break;
                    case "V": num1 = 5; break;
                    case "VI": num1 = 6; break;
                    case "VII": num1 = 7; break;
                    case "VIII": num1 = 8; break;
                    default: num1 = 0; break;
                }
            }

            //Checking to see if Digit 2 is 90
            var ninetyCheckC = romanNumeral.LastIndexOf('C');
            var ninetyCheckX = romanNumeral.IndexOf('X');
            int num2 = (ninetyCheckC > ninetyCheckX && ninetyCheckX != -1) ? 90 : 0;

            if (num2 != 90)
            {
                string num2Switch;
                if (num1 == 9)
                {
                    var temp2Switch = String.Join("", romanNumeral.Where(x => x == 'X' || x == 'L'));
                    num2Switch = temp2Switch.Remove(temp2Switch.Length - 1);
                }
                else
                {
                    num2Switch = String.Join("", romanNumeral.Where(x => x == 'X' || x == 'L'));
                }

                switch (num2Switch)
                {
                    case "X": num2 = 10; break;
                    case "XX": num2 = 20; break;
                    case "XXX": num2 = 30; break;
                    case "XL": num2 = 40; break;
                    case "L": num2 = 50; break;
                    case "LX": num2 = 60; break;
                    case "LXX": num2 = 70; break;
                    case "LXXX": num2 = 80; break;
                    default: num2 = 0; break;
                }
            }

            //Checking to see if Digit 3 is 900
            var nineHundredCheckM = romanNumeral.LastIndexOf('M');
            var nineHundredCheckC = romanNumeral.IndexOf('C');
            int num3 = (nineHundredCheckM > nineHundredCheckC && nineHundredCheckC != -1) ? 900 : 0;

            if (num3 != 900)
            {
                string num3Switch;
                if (num2 == 90)
                {
                    var temp3Switch = String.Join("", romanNumeral.Where(x => x == 'C' || x == 'D'));
                    num3Switch = temp3Switch.Remove(temp3Switch.Length - 1);
                }
                else
                {
                    num3Switch = String.Join("", romanNumeral.Where(x => x == 'C' || x == 'D'));
                }


                switch (num3Switch)
                {
                    case "C": num3 = 100; break;
                    case "CC": num3 = 200; break;
                    case "CCC": num3 = 300; break;
                    case "CD": num3 = 400; break;
                    case "D": num3 = 500; break;
                    case "DC": num3 = 600; break;
                    case "DCC": num3 = 700; break;
                    case "DCCC": num3 = 800; break;
                    default: num3 = 0; break;
                }
            }

            string num4Switch;
            if (num3 == 900)
            {
                var temp4Switch = String.Join("", romanNumeral.Where(x => x == 'M'));
                num4Switch = temp4Switch.Remove(temp4Switch.Length - 1);
            }
            else
            {
                num4Switch = String.Join("", romanNumeral.Where(x => x == 'M'));
            }

            int num4 = 0;
            switch (num4Switch)
            {
                case "M": num4 = 1000; break;
                case "MM": num4 = 2000; break;
                case "MMM": num4 = 3000; break;
                default: num4 = 0; break;
            }

            return num4 + num3 + num2 + num1;
        }
        #endregion From Roman Numeral To Arabic Number
    }
}
