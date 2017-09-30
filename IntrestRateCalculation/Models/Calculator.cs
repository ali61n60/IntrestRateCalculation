using System;

namespace IntrestRateCalculation.Models
{
    public class Calculator
    {
        internal double CalculateIntrestRatePercent(double totalLoan, double payPerMonth, int totalMonths)
        {
            if (totalLoan > (totalMonths * payPerMonth))
            {
                throw new PaymentNotEnoughException("the payPerMonth is not enough");
            }
            double intrestRate = 15;
            int totalIterations = 400;
            double tempTotalLoan;

            try
            {
                for (int i = 1; i < totalIterations; i++)
                {
                    tempTotalLoan = totalLoan;
                    for (int j = 0; j < totalMonths; j++)
                    {
                        tempTotalLoan = tempTotalLoan + tempTotalLoan * intrestRate / 1200 - payPerMonth;
                    }

                    if (tempTotalLoan > payPerMonth)
                    {
                        intrestRate -= 0.25;
                    }
                    else if (tempTotalLoan < 0)
                    {
                        intrestRate += 0.25;
                    }
                    else
                    {
                        break;
                    }
                }

            }
            catch (Exception ex)
            {

            }
            return intrestRate;
        }
    }
}