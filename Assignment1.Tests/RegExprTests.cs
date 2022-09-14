using FluentAssertions;
using Xunit;
using System.Collections;
using System.Text;

namespace Assignment1.Tests;

public class RegExprTests
{
    [Fact]
    public void TestName()
    {
        // Given
        List<string> arrayList = new List<string>();
        var counter = 0;
        arrayList.Add("1   2    3    4     5");
        arrayList.Add("a b c d e");
        arrayList.Add("f         g");
        arrayList.Add("heu32 i   jererter34 ø k l m æ æ n");
        
        
        
        // When
        var output = RegExpr.SplitLine(arrayList);
        // Then
        foreach (var elem in output)
        {   
            counter++;
            //elem.Should().Be("hej");
        }
        counter.Should().Be(19);
        //output.Should().AllBe("");
    }

    [Fact]
    public void resolution_given_some_input_return_stream()
    {
        // Given
        List<string> input = new List<string>();
        input.Add("1920x1080");
        
        
        // When
        var output = RegExpr.Resolution(input);
    

        // Then
        output.Count().Should().Be(1);
        foreach (var item in output)
        {
            item.width.Should().Be(1920);
            item.height.Should().Be(1080);
        }
        
    }

    [Fact]
    public void resolution_given_multiple_inputs_return_stream()
    {
        // Given
        List<string> input = new List<string>();
        input.Add("1920x1080 !!1920x1080");
        input.Add("1920x1080");
        
        
        
        // When
        var output = RegExpr.Resolution(input);
    

        // Then
        output.Count().Should().Be(3);
        foreach (var item in output)
        {
            item.width.Should().Be(1920);
            item.height.Should().Be(1080);
        }
        
    }

    [Fact]
    public void TestInnerText()
    {
        // Given
        string html = "<div>    <p>A <b>regular expression</b>, <b>regex</b> or <b>regexp</b> (sometimes called a <b>rational expression</b>) is, in <a href=\\”https://en.wikipedia.org/wiki/Theoretical_computer_science\\” title=\\”Theoretical computer science\\”>theoretical computer science</a> and <a href=\\”https://en.wikipedia.org/wiki/Formal_language\\” title=\\”Formal language\\”>formal language</a> theory, a sequence of <a href=\\”https://en.wikipedia.org/wiki/Character_(computing)\\” title=\\”Character (computing)\\”>characters</a> that define a <i>search <a href=\\”https://en.wikipedia.org/wiki/Pattern_matching\\” title=\\”Pattern matching\\”>pattern</a></i>. Usually this pattern is then used by <a href=\\”https://en.wikipedia.org/wiki/String_searching_algorithm\\” title=\\”String searching algorithm\\”>string searching algorithms</a> for \\”find\\” or \\”find and replace\\” operations on <a href=\\”https://en.wikipedia.org/wiki/String_(computer_science)\\” title=\\”String (computer science)\\”>strings</a>.</p></div>";


        var output = RegExpr.InnerText(html, "a");
        // When
    
        // Then
        output.Count().Should().Be(6);
        List<string> correct = new List<string>();
        

        correct.Add("theoretical computer science");
        correct.Add("formal language");
        correct.Add("characters");
        correct.Add("pattern");
        correct.Add("string searching algorithms");
        correct.Add("strings");

        for (int i = 0; i < correct.Count(); i++)
        {
            output.ElementAt(i).Should().Be(correct[i]);
        }
    }

    [Fact]
    public void TestURL()
    {
        // Given
            List<string> correct = new List<string>();
        

            correct.Add("theoretical computer science");
            correct.Add("formal language");
            correct.Add("characters");
            correct.Add("pattern");
            correct.Add("string searching algorithms");
            correct.Add("strings");
            string html = "<div>    <p>A <b>regular expression</b>, <b>regex</b> or <b>regexp</b> (sometimes called a <b>rational expression</b>) is, in <a href=\\”https://en.wikipedia.org/wiki/Theoretical_computer_science\\” title=\\”Theoretical computer science\\”>theoretical computer science</a> and <a href=\\”https://en.wikipedia.org/wiki/Formal_language\\” title=\\”Formal language\\”>formal language</a> theory, a sequence of <a href=\\”https://en.wikipedia.org/wiki/Character_(computing)\\” title=\\”Character (computing)\\”>characters</a> that define a <i>search <a href=\\”https://en.wikipedia.org/wiki/Pattern_matching\\” title=\\”Pattern matching\\”>pattern</a></i>. Usually this pattern is then used by <a href=\\”https://en.wikipedia.org/wiki/String_searching_algorithm\\” title=\\”String searching algorithm\\”>string searching algorithms</a> for \\”find\\” or \\”find and replace\\” operations on <a href=\\”https://en.wikipedia.org/wiki/String_(computer_science)\\” title=\\”String (computer science)\\”>strings</a>.</p></div>";

        // When
            var output = RegExpr.Urls(html);
        // Then
            output.Count().Should().Be(6);

            for (int i = 0; i < correct.Count(); i++)
        {
            output.ElementAt(i).title.Should().Be(correct[i]);
        }
    }

   

    
}