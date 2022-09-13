using FluentAssertions;
using Xunit;
using System.Collections;

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

    
}