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

        /// <summary>
        /// Converts fields of this instance to a specific string representation    
        /// </summary>
        /// <returns>Customer's string representation</returns>
        public override string ToString()
        {
            return $"Customer record: {Name} {Revenue.ToString("N02", CultureInfo.InvariantCulture)} {ContactPhone}"; 
        }

        /// <summary>
        /// Converts fields of this instance to a specific string representation 
        /// </summary>
        /// <param name="format">A custom format string</param>
        /// <returns>Customer's string representation</returns>
        public string ToString(string format)
        {
            return ToString(format, CultureInfo.InvariantCulture);
        }

        /// <summary>
        /// Converts fields of this instance to a specific string representation 
        /// </summary>
        /// <param name="format">A custom format string</param>
        /// <param name="formatProvider">An object that supplies culture-specific formatting information</param>
        /// <returns>Customer's string representation</returns>
        /// <exception cref="FormatException">The format string is not supported</exception>
        public string ToString(string format, IFormatProvider formatProvider)
        {
            if (string.IsNullOrEmpty(format)) format = "G";

            if (ReferenceEquals(formatProvider, null))
                formatProvider = CultureInfo.InvariantCulture;

            switch (format.Trim().ToUpperInvariant())
            {
                case "G":
                case "NRP":
                    return $"Customer record: {Name}, {Revenue.ToString("N02", formatProvider)}, {ContactPhone}";
                case "NR":
                    return $"Customer record: {Name}, {Revenue.ToString("N02", formatProvider)}";
                case "N":
                    return $"Customer record: {Name}";
                case "R":
                    return $"Customer record: {Revenue.ToString("N02", formatProvider)}";
                case "P":
                    return $"Customer record: {ContactPhone}";
                default:
                    throw new FormatException($"The {format} format string is not supported");
            }            
        }

        #endregion
    }
}
