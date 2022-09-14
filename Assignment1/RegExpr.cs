namespace Assignment1;
using System.Text.RegularExpressions;
using System.Text;
public static class RegExpr
{
    private static List<string> toWord(string str)
{   
    return Regex.Split(str, @"[^a-zA-Z0-9$]+").ToList();
}
    

    public static IEnumerable<string> SplitLine(IEnumerable<string> lines){
        foreach (var item in lines)
        {
            foreach (var line in toWord(item))
            {
                yield return line;
            }
        }
    }
        
    

    public static IEnumerable<(int width, int height)> Resolution(IEnumerable<string> resolutions) {

    var pattern = "(?<width>[0-9]+)x(?<height>[0-9]+)";
    var resolutionsChanged = RegExpr.SplitLine(resolutions);
    foreach (var reso in resolutionsChanged)
    {
        var temp = Regex.Matches(reso, pattern);
        foreach (Match match in temp)
        {
            var width = Int32.Parse(match.Groups["width"].Value);
            var height = Int32.Parse(match.Groups["height"].Value);
            yield return (width, height);
        }
    }

    }

    public static IEnumerable<string> InnerText(string html, string tag){
        var pattern = String.Format("<(?<tag>{0}).*?>(?<text>.*?)</\\k<tag>", tag);
        
            foreach (Match item in Regex.Matches(html, pattern))
            {
                yield return item.Groups["text"].Value;
            }
    }

    
    public static IEnumerable<(Uri url, string title)> Urls(string html) => throw new NotImplementedException();
}