using System.Threading.Tasks;
using ClassLibrary1;
using FluentAssertions;
using Xunit;

namespace TestProject1;

public class TestMix
{
    [Fact]
    public async Task TestRNPIHL()
    {
        var ruleta = new Ruleta(new Ruleta.SimData()
            { Bankroll = 10000, RuleazaRosuNegru = true, RuleazaHighLow = true, RuleazaParImpar = true });

        await ruleta.ProceseazaNumar(2);//1 negru 1 Par 1 Low
        await ruleta.ProceseazaNumar(4);//2 negru 2 Par 2 Low
        await ruleta.ProceseazaNumar(6);//3 negru 3 Par 3 Low
        await ruleta.ProceseazaNumar(8);//4 negru 4 Par 4 Low
        //Se pun pariuri pe rosie impar si high
        await ruleta.ProceseazaNumar(2);//5 negru 5 Par 5 Low
        //se pierd pariurile pe rosie impar si high: -300
        ruleta.Bankroll.Should().Be(9700);
        //Cresc pariurile pe rosie impar si high
        await ruleta.ProceseazaNumar(20);//6 negru 6 Par 1H
        //se pierd pariurile pe rosie impar: -200
        //se castiga pariul pe high: +100
        ruleta.Bankroll.Should().Be(9600);
        //Cresc pariurile pe rosie impar
        await ruleta.ProceseazaNumar(24);//7 negru 7 Par 2H
        //se pierd pariurile pe rosie impar: -400
        ruleta.Bankroll.Should().Be(9200);
        //Cresc pariurile pe rosie impar
        await ruleta.ProceseazaNumar(28);//8 negru 8 Par 3H
        //se pierd pariurile pe rosie impar: -600
        ruleta.Bankroll.Should().Be(8600);
        //Cresc pariurile pe rosie impar
        await ruleta.ProceseazaNumar(29);//9 negru 1 Impar 4H
        //se pierde pariul pe rosie: -500
        //se castiga pariul pe impar: +500
        //Creste pariuriul pe rosie si pe High
        await ruleta.ProceseazaNumar(0);//0
        //se pierd pariurile pe rosie si high: -800 -100
        ruleta.Bankroll.Should().Be(7700);
    }
}