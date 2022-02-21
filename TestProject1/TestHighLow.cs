using System.Threading.Tasks;
using ClassLibrary1;
using FluentAssertions;
using Xunit;

namespace TestProject1;

public class TestHighLow
{
    [Fact]
    public async Task Test4LowApoiHigh()
    {
        //arrange
        var ruleta = new Ruleta(new Ruleta.SimData() { Bankroll = 10000 ,RuleazaHighLow = true});
        //4 l
        await ruleta.ProceseazaNumar(2);
        await ruleta.ProceseazaNumar(4);
        await ruleta.ProceseazaNumar(6);
        await ruleta.ProceseazaNumar(8);
        //h
        await ruleta.ProceseazaNumar(19);
        
        
        ruleta.Bankroll.Should().Be(10100);
        ruleta.StreakLow.Should().HaveCount(1).And.Contain(p => p.Key == 4);
        ruleta.StreakHigh.Should().HaveCount(0);
    }
    [Fact]
    public async Task Test5HighApoiLow()
    {
        //arrange
        var ruleta = new Ruleta(new Ruleta.SimData() { Bankroll = 10000 ,RuleazaHighLow = true});
        //5 h
        await ruleta.ProceseazaNumar(20);
        await ruleta.ProceseazaNumar(24);
        await ruleta.ProceseazaNumar(36);
        await ruleta.ProceseazaNumar(19);
        await ruleta.ProceseazaNumar(22);
        //l
        await ruleta.ProceseazaNumar(18);
        
        
        ruleta.Bankroll.Should().Be(10000);
        ruleta.StreakHigh.Should().HaveCount(1).And.Contain(p => p.Key == 5);
        ruleta.StreakLow.Should().HaveCount(0);
    }
    [Fact]
    public async Task Test3LowApoi6HighApoiLow()
    {
        //arrange
        var ruleta = new Ruleta(new Ruleta.SimData() { Bankroll = 10000 ,RuleazaHighLow = true});
        //3 l
        await ruleta.ProceseazaNumar(2);
        await ruleta.ProceseazaNumar(4);
        await ruleta.ProceseazaNumar(6);

        //6 h
        await ruleta.ProceseazaNumar(21);
        await ruleta.ProceseazaNumar(25);
        await ruleta.ProceseazaNumar(33);
        await ruleta.ProceseazaNumar(27);
        await ruleta.ProceseazaNumar(31);
        await ruleta.ProceseazaNumar(19);
        
        //1 l
        await ruleta.ProceseazaNumar(18);
        
        ruleta.Bankroll.Should().Be(10000);
        ruleta.StreakHigh.Should().HaveCount(1).And.Contain(p => p.Key == 6);
        ruleta.StreakLow.Should().HaveCount(0);
    }
    [Fact]
    public async Task Test3HApoi7LApoiH()
    {
        //arrange
        var ruleta = new Ruleta(new Ruleta.SimData() { Bankroll = 10000 ,RuleazaHighLow = true});
        //3 h
        await ruleta.ProceseazaNumar(32);
        await ruleta.ProceseazaNumar(24);
        await ruleta.ProceseazaNumar(36);

        //7 l
        await ruleta.ProceseazaNumar(1);
        await ruleta.ProceseazaNumar(5);
        await ruleta.ProceseazaNumar(3);
        await ruleta.ProceseazaNumar(7);
        await ruleta.ProceseazaNumar(11);
        await ruleta.ProceseazaNumar(2);
        await ruleta.ProceseazaNumar(3);
        
        //1 h
        await ruleta.ProceseazaNumar(32);
        
        ruleta.Bankroll.Should().Be(9900);
        ruleta.StreakLow.Should().HaveCount(1).And.Contain(p => p.Key == 7);
        ruleta.StreakHigh.Should().HaveCount(0);
    }
    
    
    [Fact]
    public async Task Test3L10H1L()
    {
        //arrange
        var ruleta = new Ruleta(new Ruleta.SimData() { Bankroll = 10000,RuleazaHighLow = true});
        //3 L
        await ruleta.ProceseazaNumar(1);
        await ruleta.ProceseazaNumar(3);
        await ruleta.ProceseazaNumar(5);

        //10 H
        await ruleta.ProceseazaNumar(32);
        await ruleta.ProceseazaNumar(34);
        await ruleta.ProceseazaNumar(36);
        await ruleta.ProceseazaNumar(28);
        await ruleta.ProceseazaNumar(30);
        await ruleta.ProceseazaNumar(22);
        await ruleta.ProceseazaNumar(19);
        await ruleta.ProceseazaNumar(20);
        await ruleta.ProceseazaNumar(26);
        await ruleta.ProceseazaNumar(36);
        
        //L
        await ruleta.ProceseazaNumar(7);
        
        ruleta.Bankroll.Should().Be(8000);
        ruleta.StreakHigh.Should().HaveCount(1).And.Contain(p => p.Key == 10);
        ruleta.StreakLow.Should().HaveCount(0);
    }
    
    [Fact]
    public async Task Test3L10H1LDArCuRestartPariu()
    {
        //arrange
        var ruleta = new Ruleta(new Ruleta.SimData() { Bankroll = 10000,RuleazaHighLow = true,RestartPariuDeLaMinimDupaCeAPierdutMizaMaximaInAcelasiStreak = true});
        //3 L
        await ruleta.ProceseazaNumar(1);
        await ruleta.ProceseazaNumar(3);
        await ruleta.ProceseazaNumar(5);

        //10 H
        await ruleta.ProceseazaNumar(32);
        await ruleta.ProceseazaNumar(24);
        await ruleta.ProceseazaNumar(36);
        await ruleta.ProceseazaNumar(28);
        await ruleta.ProceseazaNumar(30);
        await ruleta.ProceseazaNumar(32);
        await ruleta.ProceseazaNumar(22);
        await ruleta.ProceseazaNumar(24);
        await ruleta.ProceseazaNumar(36);
        await ruleta.ProceseazaNumar(19);
        
        //L
        await ruleta.ProceseazaNumar(7);
        
        ruleta.Bankroll.Should().Be(8100);
        ruleta.StreakHigh.Should().HaveCount(1).And.Contain(p => p.Key == 10);
        ruleta.StreakLow.Should().HaveCount(0);
    }
    
    [Fact]
    public async Task Test5LApoiZero()
    {
        //arrange
        var ruleta = new Ruleta(new Ruleta.SimData() { Bankroll = 10000,RuleazaHighLow = true});
        //5 L
        await ruleta.ProceseazaNumar(1);
        await ruleta.ProceseazaNumar(3);
        await ruleta.ProceseazaNumar(5);
        await ruleta.ProceseazaNumar(7);
        await ruleta.ProceseazaNumar(7);
        
        ruleta.Bankroll.Should().Be(9900);
        //zero
        await ruleta.ProceseazaNumar(0);
        
        
        ruleta.Bankroll.Should().Be(9800);
        ruleta.StreakLow.Should().HaveCount(1).And.Contain(p => p.Key == 5);
        ruleta.StreakHigh.Should().HaveCount(0);
    }
    
    [Fact]
    public async Task Test5HApoiZeroApoi5LApoiZero()
    {
        //arrange
        var ruleta = new Ruleta(new Ruleta.SimData() { Bankroll = 10000,RuleazaHighLow = true});
        //5 i
        await ruleta.ProceseazaNumar(21);
        await ruleta.ProceseazaNumar(23);
        await ruleta.ProceseazaNumar(35);
        await ruleta.ProceseazaNumar(27);
        await ruleta.ProceseazaNumar(27);
        
        ruleta.Bankroll.Should().Be(9900);
        //zero
        await ruleta.ProceseazaNumar(0);
        
        
        ruleta.Bankroll.Should().Be(9800);
        ruleta.StreakHigh.Should().HaveCount(1).And.Contain(p => p.Key == 5);
        ruleta.StreakLow.Should().HaveCount(0);
        
        await ruleta.ProceseazaNumar(2);
        await ruleta.ProceseazaNumar(4);
        await ruleta.ProceseazaNumar(6);
        await ruleta.ProceseazaNumar(8);
        await ruleta.ProceseazaNumar(10);
        
        ruleta.Bankroll.Should().Be(9700);
        //zero
        await ruleta.ProceseazaNumar(0);
        
        
        ruleta.Bankroll.Should().Be(9600);
        ruleta.StreakHigh.Should().HaveCount(1).And.Contain(p => p.Key == 5);
        ruleta.StreakLow.Should().HaveCount(1).And.Contain(p => p.Key == 5);
    }
}