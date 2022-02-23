using System.Collections.Generic;
using System.Threading.Tasks;
using ClassLibrary1;
using FluentAssertions;
using Xunit;

namespace TestProject1;

public class TestDuzine
{
    private readonly List<int> numereDuzina1 = new List<int>()
    {
        32, 15, 19, 4, 21, 2, 25, 17, 34, 6, 27, 13
    };

    private readonly List<int> numereDuzina2 = new List<int>()
    {
        36, 11, 30, 8, 23, 10, 5, 24, 16, 33, 1, 20
    };

    private readonly List<int> numereDuzina3 = new List<int>()
    {
        14, 31, 9, 22, 18, 29, 7, 28, 12, 35, 3, 26
    };
    [Fact]
    public async Task Test3D1Apoi6D2Apoi6D3ApoiZero()
    {
        var ruleta = new Ruleta(new Ruleta.SimData() { Bankroll = 10000,RuleazaDuzine = true,PariuriStabilite = "100,100,200,300,500,800"});
        
        //3D1
        await ruleta.ProceseazaNumar(32);
        await ruleta.ProceseazaNumar(15);
        await ruleta.ProceseazaNumar(19);
        ruleta.counterLipsaDuzina2.Should().Be(3);
        ruleta.counterLipsaDuzina3.Should().Be(3);
        //6D2
        await ruleta.ProceseazaNumar(36);
        await ruleta.ProceseazaNumar(11);
        await ruleta.ProceseazaNumar(30);
        await ruleta.ProceseazaNumar(8);
        await ruleta.ProceseazaNumar(23);
        ruleta.counterLipsaDuzina1.Should().Be(5);
        ruleta.counterLipsaDuzina3.Should().Be(8);
        ruleta.pariuDuzina3.Should().Be(1);
        await ruleta.ProceseazaNumar(10);
        ruleta.counterLipsaDuzina1.Should().Be(6);
        ruleta.counterLipsaDuzina3.Should().Be(9);
        ruleta.pariuDuzina3.Should().Be(2);
        ruleta.Bankroll.Should().Be(9900);
        //6D3
        await ruleta.ProceseazaNumar(14);
        ruleta.Bankroll.Should().Be(10100);
        ruleta.counterLipsaDuzina1.Should().Be(7);
        ruleta.counterLipsaDuzina3.Should().Be(0);
        await ruleta.ProceseazaNumar(31);
        ruleta.counterLipsaDuzina1.Should().Be(8);
        ruleta.pariuDuzina1.Should().Be(1);
        await ruleta.ProceseazaNumar(9);
        ruleta.Bankroll.Should().Be(10000);
        ruleta.counterLipsaDuzina1.Should().Be(9);
        await ruleta.ProceseazaNumar(14);
        await ruleta.ProceseazaNumar(31);
        ruleta.Bankroll.Should().Be(9700);
        ruleta.counterLipsaDuzina1.Should().Be(11);
        await ruleta.ProceseazaNumar(0);
        ruleta.Bankroll.Should().Be(9400);
        ruleta.counterLipsaDuzina1.Should().Be(0);

    }
}