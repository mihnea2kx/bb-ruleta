using System.Threading.Tasks;
using ClassLibrary1;
using FluentAssertions;
using Xunit;

namespace TestProject1;

public class TestParImpar
{
    [Fact]
    public async Task Test4PareApoiImpar()
    {
        //arrange
        var ruleta = new Ruleta(new Ruleta.SimData() { Bankroll = 10000 ,RuleazaParImpar = true});
        //4 pare
        await ruleta.ProceseazaNumar(2);
        await ruleta.ProceseazaNumar(4);
        await ruleta.ProceseazaNumar(6);
        await ruleta.ProceseazaNumar(8);
        //impar
        await ruleta.ProceseazaNumar(1);
        
        
        ruleta.Bankroll.Should().Be(10100);
        ruleta.StreakPare.Should().HaveCount(1).And.Contain(p => p.Key == 4);
        ruleta.StreakImpare.Should().HaveCount(0);
    }
    [Fact]
    public async Task Test5PareApoiImpar()
    {
        //arrange
        var ruleta = new Ruleta(new Ruleta.SimData() { Bankroll = 10000 ,RuleazaParImpar = true});
        //5 pare
        await ruleta.ProceseazaNumar(2);
        await ruleta.ProceseazaNumar(4);
        await ruleta.ProceseazaNumar(6);
        await ruleta.ProceseazaNumar(8);
        await ruleta.ProceseazaNumar(18);
        //impar
        await ruleta.ProceseazaNumar(1);
        
        
        ruleta.Bankroll.Should().Be(10000);
        ruleta.StreakPare.Should().HaveCount(1).And.Contain(p => p.Key == 5);
        ruleta.StreakImpare.Should().HaveCount(0);
    }
    [Fact]
    public async Task Test3PareApoi6ImpareApoiPar()
    {
        //arrange
        var ruleta = new Ruleta(new Ruleta.SimData() { Bankroll = 10000 ,RuleazaParImpar = true});
        //2 pare
        await ruleta.ProceseazaNumar(2);
        await ruleta.ProceseazaNumar(4);
        await ruleta.ProceseazaNumar(6);

        //6 impare
        await ruleta.ProceseazaNumar(1);
        await ruleta.ProceseazaNumar(5);
        await ruleta.ProceseazaNumar(3);
        await ruleta.ProceseazaNumar(7);
        await ruleta.ProceseazaNumar(11);
        await ruleta.ProceseazaNumar(21);
        
        //1 pare
        await ruleta.ProceseazaNumar(2);
        
        ruleta.Bankroll.Should().Be(10000);
        ruleta.StreakImpare.Should().HaveCount(1).And.Contain(p => p.Key == 6);
        ruleta.StreakPare.Should().HaveCount(0);
    }
    [Fact]
    public async Task Test3PareApoi7ImpareApoiPar()
    {
        //arrange
        var ruleta = new Ruleta(new Ruleta.SimData() { Bankroll = 10000 ,RuleazaParImpar = true});
        //2 pare
        await ruleta.ProceseazaNumar(2);
        await ruleta.ProceseazaNumar(4);
        await ruleta.ProceseazaNumar(6);

        //7 impare
        await ruleta.ProceseazaNumar(1);
        await ruleta.ProceseazaNumar(5);
        await ruleta.ProceseazaNumar(3);
        await ruleta.ProceseazaNumar(7);
        await ruleta.ProceseazaNumar(11);
        await ruleta.ProceseazaNumar(21);
        await ruleta.ProceseazaNumar(31);
        
        //1 pare
        await ruleta.ProceseazaNumar(2);
        
        ruleta.Bankroll.Should().Be(9900);
        ruleta.StreakImpare.Should().HaveCount(1).And.Contain(p => p.Key == 7);
        ruleta.StreakPare.Should().HaveCount(0);
    }
    [Fact]
    public async Task Test3PareApoi8ImpareApoiPar()
    {
        //arrange
        var ruleta = new Ruleta(new Ruleta.SimData() { Bankroll = 10000 ,RuleazaParImpar = true});
        //2 pare
        await ruleta.ProceseazaNumar(2);
        await ruleta.ProceseazaNumar(4);
        await ruleta.ProceseazaNumar(6);

        //8 impare
        await ruleta.ProceseazaNumar(1);
        await ruleta.ProceseazaNumar(5);
        await ruleta.ProceseazaNumar(3);
        await ruleta.ProceseazaNumar(7);
        await ruleta.ProceseazaNumar(11);
        await ruleta.ProceseazaNumar(21);
        await ruleta.ProceseazaNumar(31);
        await ruleta.ProceseazaNumar(31);
        
        //1 pare
        await ruleta.ProceseazaNumar(2);
        
        ruleta.Bankroll.Should().Be(9800);
        ruleta.StreakImpare.Should().HaveCount(1).And.Contain(p => p.Key == 8);
        ruleta.StreakPare.Should().HaveCount(0);
    }
    
    [Fact]
    public async Task Test3Impare10Pare1Impar()
    {
        //arrange
        var ruleta = new Ruleta(new Ruleta.SimData() { Bankroll = 10000,RuleazaParImpar = true});
        //3 i
        await ruleta.ProceseazaNumar(1);
        await ruleta.ProceseazaNumar(3);
        await ruleta.ProceseazaNumar(5);

        //10 p
        await ruleta.ProceseazaNumar(2);
        await ruleta.ProceseazaNumar(4);
        await ruleta.ProceseazaNumar(6);
        await ruleta.ProceseazaNumar(8);
        await ruleta.ProceseazaNumar(10);
        await ruleta.ProceseazaNumar(12);
        await ruleta.ProceseazaNumar(12);
        await ruleta.ProceseazaNumar(16);
        await ruleta.ProceseazaNumar(16);
        await ruleta.ProceseazaNumar(16);
        
        //impar
        await ruleta.ProceseazaNumar(7);
        
        ruleta.Bankroll.Should().Be(8000);
        ruleta.StreakPare.Should().HaveCount(1).And.Contain(p => p.Key == 10);
        ruleta.StreakImpare.Should().HaveCount(0);
    }
    
    [Fact]
    public async Task Test3Impare10Pare1ImparDArCuRestartPariu()
    {
        //arrange
        var ruleta = new Ruleta(new Ruleta.SimData() { Bankroll = 10000,RuleazaParImpar = true,RestartPariuDeLaMinimDupaCeAPierdutMizaMaximaInAcelasiStreak = true});
        //3 i
        await ruleta.ProceseazaNumar(1);
        await ruleta.ProceseazaNumar(3);
        await ruleta.ProceseazaNumar(5);

        //10 p
        await ruleta.ProceseazaNumar(2);
        await ruleta.ProceseazaNumar(4);
        await ruleta.ProceseazaNumar(6);
        await ruleta.ProceseazaNumar(8);
        await ruleta.ProceseazaNumar(10);
        await ruleta.ProceseazaNumar(12);
        await ruleta.ProceseazaNumar(12);
        await ruleta.ProceseazaNumar(14);
        await ruleta.ProceseazaNumar(16);
        await ruleta.ProceseazaNumar(16);
        
        //i
        await ruleta.ProceseazaNumar(7);
        
        ruleta.Bankroll.Should().Be(8100);
        ruleta.StreakPare.Should().HaveCount(1).And.Contain(p => p.Key == 10);
        ruleta.StreakImpare.Should().HaveCount(0);
    }
    
    [Fact]
    public async Task Test5ImpareApoiZero()
    {
        //arrange
        var ruleta = new Ruleta(new Ruleta.SimData() { Bankroll = 10000,RuleazaParImpar = true});
        //5 i
        await ruleta.ProceseazaNumar(1);
        await ruleta.ProceseazaNumar(3);
        await ruleta.ProceseazaNumar(5);
        await ruleta.ProceseazaNumar(7);
        await ruleta.ProceseazaNumar(7);
        
        ruleta.Bankroll.Should().Be(9900);
        //zero
        await ruleta.ProceseazaNumar(0);
        
        
        ruleta.Bankroll.Should().Be(9800);
        ruleta.StreakImpare.Should().HaveCount(1).And.Contain(p => p.Key == 5);
        ruleta.StreakPare.Should().HaveCount(0);
    }
    
    [Fact]
    public async Task Test5ImpareApoiZeroApoi5PareApoiZero()
    {
        //arrange
        var ruleta = new Ruleta(new Ruleta.SimData() { Bankroll = 10000,RuleazaParImpar = true});
        //5 i
        await ruleta.ProceseazaNumar(1);
        await ruleta.ProceseazaNumar(3);
        await ruleta.ProceseazaNumar(5);
        await ruleta.ProceseazaNumar(7);
        await ruleta.ProceseazaNumar(7);
        
        ruleta.Bankroll.Should().Be(9900);
        //zero
        await ruleta.ProceseazaNumar(0);
        
        
        ruleta.Bankroll.Should().Be(9800);
        ruleta.StreakImpare.Should().HaveCount(1).And.Contain(p => p.Key == 5);
        ruleta.StreakPare.Should().HaveCount(0);
        
        await ruleta.ProceseazaNumar(2);
        await ruleta.ProceseazaNumar(4);
        await ruleta.ProceseazaNumar(6);
        await ruleta.ProceseazaNumar(8);
        await ruleta.ProceseazaNumar(10);
        
        ruleta.Bankroll.Should().Be(9700);
        //zero
        await ruleta.ProceseazaNumar(0);
        
        
        ruleta.Bankroll.Should().Be(9600);
        ruleta.StreakImpare.Should().HaveCount(1).And.Contain(p => p.Key == 5);
        ruleta.StreakPare.Should().HaveCount(1).And.Contain(p => p.Key == 5);
    }
}