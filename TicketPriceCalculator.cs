using System;
using System.Collections.Generic;

namespace FlowAndString
{
    internal class TicketPriceCalculator
    {
        int youthPrice = 80;
        int standardPrice = 120;
        int seniorPrice = 90;

        internal string CalculateTicketPriceByAge(int age)
        {
            if (age < 0)
            {
                throw new FormatException("Age cannot be negative.");
            }

            if (age < 5)
            {
                return "Under 5 år. Gratis biljett";
            }

            if (age >= 5)
            {
                if (age <= 20)
                {
                    return $"Ungdomspris: {youthPrice}kr";
                }

                if (age > 20)
                {
                    if (age < 65)
                    {
                        return $"Standardpris: {standardPrice}kr";
                    }

                    if (age >= 65)
                    {
                        if (age > 100)
                        {
                            return "Över 100 år. Gratis biljett";
                        }

                        return $"Pensionärspris: {seniorPrice}kr";
                    }
                }
            }
            else
            {
                throw new Exception($"Unknown error in age size. \"{age}\" is not a recognized number.");
            }

            //this should never be reached...
            return string.Empty;
        }

        internal string CalculateTicketPriceForGroup(List<int> groupAges)
        {
            string result = $"Antal: {groupAges.Count}";
            int priceTotal = 0;
            
            foreach(int age in groupAges)
            {
                if(age >= 5 && age is < 20)
                {
                    //youth
                    priceTotal += youthPrice;
                }
                else if(age >= 20 && age < 65)
                {
                    //standard
                    priceTotal += standardPrice;
                }
                else if(age >= 65 && age <= 100 )
                {
                    priceTotal += seniorPrice;
                }

                //age below 5 and over 100 are free
            }

            result += $" Totalkostnad {priceTotal}kr";

            return result;
        }
    }
}