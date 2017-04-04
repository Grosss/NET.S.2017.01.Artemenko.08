using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace Task1
{
    /// <summary>
    /// Information about customer
    /// </summary>
    public class Customer : IFormattable
    {
        #region Properties

        public string Name { get; set; }
        public string ContactPhone { get; set; }
        public decimal Revenue { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Constructor with parameters
        /// </summary>
        /// <param name="name">Customer's name</param>
        /// <param name="contactPhone">Customer's contact phone</param>
        /// <param name="revenue">Customer's  revenue</param>
        public Customer(string name, string contactPhone, decimal revenue)
        {
            Name = name;
            ContactPhone = contactPhone;
            Revenue = revenue;
        }

        /// <summary>
        /// Default constructor
        /// </summary>
        public Customer()
        {
            Name = string.Empty;
            ContactPhone = string.Empty;
            Revenue = 0;
        }

        #endregion

        #region String representation methods

        public override string ToString()
        {
            return $"Customer record: {Name} {Revenue.ToString("N02", CultureInfo.InvariantCulture)} {ContactPhone}"; 
        }

        public string ToString(string format)
        {
            return ToString(format, CultureInfo.InvariantCulture);
        }

        public string ToString(string format, IFormatProvider formatProvider)
        {
            if (string.IsNullOrEmpty(format)) format = "G";

            if (formatProvider == null)
                formatProvider = CultureInfo.InvariantCulture;

            switch (format.Trim().ToUpperInvariant())
            {
                case "G":
                case "NRP":
                    return $"Customer record: {Name} {Revenue.ToString("N02", formatProvider)} {ContactPhone}";
                case "NR":
                    return $"Customer record: {Name} {Revenue.ToString("N02", formatProvider)}";
                case "N":
                    return $"Customer record: {Name}";
                case "R":
                    return Revenue.ToString("N02", formatProvider);
                case "P":
                    return ContactPhone;
                default:
                    throw new FormatException($"The {format} format string is not supported");
            }            
        }

        #endregion
    }
}
