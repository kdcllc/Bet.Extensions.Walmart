using System.Text;

namespace Bet.Extensions.Walmart
{
    public static class StringExtensions
    {
        private static string Base64Encode(this string header)
        {
            if (string.IsNullOrEmpty(header))
            {
                return string.Empty;
            }

            var bt = Encoding.UTF8.GetBytes(header);
            return Convert.ToBase64String(bt);
        }
    }
}
