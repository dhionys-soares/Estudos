using System.Text.RegularExpressions;
using UtmBuider.ValueObjects.Exceptions;

namespace UtmBuider.ValueObjects
{
    public class Url : ValueObject
    {
        /// <summary>
        /// Create a new URL
        /// </summary>
        /// <param name="address">Address of URL (Website link)</param>
        public Url(string address)
        {
            Address = address;
            InvalidUrlException.TrhowIfInvalidUrl(address);
        }
        /// <summary>
        /// Address of URL (Website link)
        /// </summary>
        public string Address { get; }
    }
}