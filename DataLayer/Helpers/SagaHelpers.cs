using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace DataLayer.Helpers
{
    public static class SagaHelpers
    {
        /// <summary>
        /// Datetime convertors can be error prone and ALWAYS needs to seperated from the control flow. Also having it in a helper class helps you to maintain and monitor easily. 
        /// </summary>
        /// <param name="dateString">This is a string comes in representing DataTime and later get coverted to en-GB "g" format</param>
        /// <returns></returns>
        public static DateTime convertDateTime(string dateString)
        {
            string format = "g";
            CultureInfo provider = new CultureInfo("en-GB");
            DateTime result = new DateTime();

            try
            {
                result = DateTime.ParseExact(dateString, format, provider);
            }
            catch (FormatException)
            {
                // add to Saga erorr log - perhaps Mongo collection db
            }

            return result;
        }

        /// <summary>
        /// Error Free beautiful CSV to Object Constructor - taken out of Basket class to comply with Single Responsibility (SOLID) and sake of having maintainable clean code
        /// </summary>
        /// <param line="String"> This brings in each line of the CSV file and construct Basket objects </param>
        /// <returns></returns>
        public static Basket FromCSV(string line)
        {
            string[] valuesFromCSV = line.Split(',');

            return new Basket()
            {
                TransactionNumber = valuesFromCSV[0],
                NumberOfPassengers =  valuesFromCSV[1] != "" ? Int32.Parse(valuesFromCSV[1].ToString()) : (int?) null,
                Domain = valuesFromCSV[2] != "" ? Int32.Parse(valuesFromCSV[2].ToString()) : (int?)null,
                AgentId = valuesFromCSV[3] != "" ? Int32.Parse(valuesFromCSV[3].ToString()) : (int?)null,
                ReferrerUrl = valuesFromCSV[4],
                CreatedDateTime = SagaHelpers.convertDateTime(valuesFromCSV[5]),
                UserId = valuesFromCSV[6],
                SelectedCurrency = valuesFromCSV[7],
                ReservationSystem = valuesFromCSV[8]
            };

        }
    }
}
