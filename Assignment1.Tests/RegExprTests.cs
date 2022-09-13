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
}