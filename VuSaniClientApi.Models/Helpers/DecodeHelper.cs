using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace VuSaniClientApi.Models.Helpers
{
    public static class DecodeHelper
    {
        public static string? DecodeSingle(string? data)
        {
            if (string.IsNullOrWhiteSpace(data))
                return null;

            // Decode repeatedly until no more changes (handles double/triple encoded data)
            string decoded = data;
            string previous;
            int maxIterations = 5; // Safety limit
            int iteration = 0;
            
            do
            {
                previous = decoded;
                decoded = WebUtility.HtmlDecode(decoded);
                iteration++;
            } while (decoded != previous && iteration < maxIterations);

            return decoded;
        }

        public static void DecodeField<T>(List<T> list, Func<T, string?> getter, Action<T, string?> setter)
        {
            foreach (var item in list)
            {
                setter(item, DecodeSingle(getter(item)));
            }
        }
    }

}
