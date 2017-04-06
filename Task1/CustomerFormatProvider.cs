using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace Task1
{
    class CustomerFormatProvider : IFormatProvider, ICustomFormatter
    {
        private IFormatProvider parent;

        public CustomerFormatProvider() : this(CultureInfo.CurrentCulture) { }
        public CustomerFormatProvider(IFormatProvider parent)
        {
            this.parent = parent;
        }

        public object GetFormat(Type formatType)
        {
            if (formatType == typeof(ICustomFormatter))
                return this;
            else
                return null;
        }

        public string Format(string format, object arg, IFormatProvider formatProvider)
        {
            if (ReferenceEquals(arg, null))
                throw new ArgumentNullException();

            if (!(arg is Customer))
                throw new ArgumentException();

            if (string.IsNullOrEmpty(format)) format = "GC";

            Customer customer = (Customer)arg;

            switch (format.Trim().ToUpperInvariant())
            {
                case "GC":
                case "NRCP":
                    return $"Customer record: {customer.Name}, {customer.Revenue.ToString("C", formatProvider)}, {customer.ContactPhone}";
                case "NRC":
                    return $"Customer record: {customer.Name}, {customer.Revenue.ToString("C", formatProvider)}";
                case "RC":
                    return $"Customer record: {customer.Revenue.ToString("C", formatProvider)}";
                case "NP":
                    return $"Customer record: {customer.Name}, {customer.ContactPhone}";                
                default:
                    throw new FormatException($"The {format} format string is not supported");
            }
        }
    }
}
