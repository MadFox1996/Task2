using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace Task2.Extentions
{
    public static class MyExtensions
    {
        public static string FormatBool(this IHtmlHelper html, bool value)
        {
            return html.Encode(value ? "Finished" : "Active");
        }
    }
}
