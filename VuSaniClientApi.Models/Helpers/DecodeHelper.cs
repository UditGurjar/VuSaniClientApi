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

            return WebUtility.HtmlDecode(data);
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
