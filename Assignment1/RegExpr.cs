namespace Assignment1;
using System.Text.RegularExpressions;
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
        
    

    public static IEnumerable<(int width, int height)> Resolution(IEnumerable<string> resolutions) => throw new NotImplementedException();

    public static IEnumerable<string> InnerText(string html, string tag) => throw new NotImplementedException();
}