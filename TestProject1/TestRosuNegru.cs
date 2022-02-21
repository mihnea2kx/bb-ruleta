using System.Threading.Tasks;
using ClassLibrary1;
using FluentAssertions;
using Xunit;

namespace TestProject1;

public class TestRosuNegru
{
    [Fact]
    public async Task Test4RosiiApoiNegru()
    {
        //arrange
        var ruleta = new Ruleta(new Ruleta.SimData() { Bankroll = 10000 ,RuleazaRosuNegru = true});
        //4 rosii
        await ruleta.ProceseazaNumar(1);
        await ruleta.ProceseazaNumar(3);
        await ruleta.ProceseazaNumar(5);
        await ruleta.ProceseazaNumar(7);
        //negru
        await ruleta.ProceseazaNumar(2);
        
        
        ruleta.Bankroll.Should().Be(10100);
        ruleta.StreakRosii.Should().HaveCount(1).And.Contain(p => p.Key == 4);
        ruleta.StreakNegre.Should().HaveCount(0);
    }
    [Fact]
    public async Task Test5RosiiApoiNegru()
    {
        //arrange
        var ruleta = new Ruleta(new Ruleta.SimData() { Bankroll = 10000 ,RuleazaRosuNegru = true});
        //5 rosii
        await ruleta.ProceseazaNumar(1);
        await ruleta.ProceseazaNumar(3);
        await ruleta.ProceseazaNumar(5);
        await ruleta.ProceseazaNumar(7);
        await ruleta.ProceseazaNumar(7);
        //negru
        await ruleta.ProceseazaNumar(2);
        
        
        ruleta.Bankroll.Should().Be(10000);
        ruleta.StreakRosii.Should().HaveCount(1).And.Contain(p => p.Key == 5);
        ruleta.StreakNegre.Should().HaveCount(0);
    }
    [Fact]
    public async Task Test3Rosii6Negre1Rosie()
    {
        //arrange
        var ruleta = new Ruleta(new Ruleta.SimData() { Bankroll = 10000 ,RuleazaRosuNegru = true});
        //3 rosii
        await ruleta.ProceseazaNumar(1);
        await ruleta.ProceseazaNumar(3);
        await ruleta.ProceseazaNumar(5);

        //6negre
        await ruleta.ProceseazaNumar(2);
        await ruleta.ProceseazaNumar(4);
        await ruleta.ProceseazaNumar(6);
        await ruleta.ProceseazaNumar(8);
        await ruleta.ProceseazaNumar(10);
        await ruleta.ProceseazaNumar(11);
        
        //rosu
        await ruleta.ProceseazaNumar(7);
        
        ruleta.Bankroll.Should().Be(10000);
        ruleta.StreakNegre.Should().HaveCount(1).And.Contain(p => p.Key == 6);
        ruleta.StreakRosii.Should().HaveCount(0);
    }
    
    [Fact]
    public async Task Test3Rosii7Negre1Rosie()
    {
        //arrange
        var ruleta = new Ruleta(new Ruleta.SimData() { Bankroll = 10000 ,RuleazaRosuNegru = true});
        //3 rosii
        await ruleta.ProceseazaNumar(1);
        await ruleta.ProceseazaNumar(3);
        await ruleta.ProceseazaNumar(5);

        //7negre
        await ruleta.ProceseazaNumar(2);
        await ruleta.ProceseazaNumar(4);
        await ruleta.ProceseazaNumar(6);
        await ruleta.ProceseazaNumar(8);
        await ruleta.ProceseazaNumar(10);
        await ruleta.ProceseazaNumar(11);
        await ruleta.ProceseazaNumar(13);
        
        //rosu
        await ruleta.ProceseazaNumar(7);
        
        ruleta.Bankroll.Should().Be(9900);
        ruleta.StreakNegre.Should().HaveCount(1).And.Contain(p => p.Key == 7);
        ruleta.StreakRosii.Should().HaveCount(0);
    }
    
    [Fact]
    public async Task Test3Rosii8Negre1Rosie()
    {
        //arrange
        var ruleta = new Ruleta(new Ruleta.SimData() { Bankroll = 10000 ,RuleazaRosuNegru = true});
        //3 rosii
        await ruleta.ProceseazaNumar(1);
        await ruleta.ProceseazaNumar(3);
        await ruleta.ProceseazaNumar(5);

        //8negre
        await ruleta.ProceseazaNumar(2);
        await ruleta.ProceseazaNumar(4);
        await ruleta.ProceseazaNumar(6);
        await ruleta.ProceseazaNumar(8);
        await ruleta.ProceseazaNumar(10);
        await ruleta.ProceseazaNumar(11);
        await ruleta.ProceseazaNumar(13);
        await ruleta.ProceseazaNumar(13);
        
        //rosu
        await ruleta.ProceseazaNumar(7);
        
        ruleta.Bankroll.Should().Be(9800);
        ruleta.StreakNegre.Should().HaveCount(1).And.Contain(p => p.Key == 8);
        ruleta.StreakRosii.Should().HaveCount(0);
    }
    
    [Fact]
    public async Task Test3Rosii9Negre1Rosie()
    {
        //arrange
        var ruleta = new Ruleta(new Ruleta.SimData() { Bankroll = 10000 ,RuleazaRosuNegru = true});
        //3 rosii
        await ruleta.ProceseazaNumar(1);
        await ruleta.ProceseazaNumar(3);
        await ruleta.ProceseazaNumar(5);

        //9negre
        await ruleta.ProceseazaNumar(2);
        await ruleta.ProceseazaNumar(4);
        await ruleta.ProceseazaNumar(6);
        await ruleta.ProceseazaNumar(8);
        await ruleta.ProceseazaNumar(10);
        await ruleta.ProceseazaNumar(11);
        await ruleta.ProceseazaNumar(11);
        await ruleta.ProceseazaNumar(13);
        await ruleta.ProceseazaNumar(13);
        
        //rosu
        await ruleta.ProceseazaNumar(7);
        
        ruleta.Bankroll.Should().Be(9600);
        ruleta.StreakNegre.Should().HaveCount(1).And.Contain(p => p.Key == 9);
        ruleta.StreakRosii.Should().HaveCount(0);
    }
    
    [Fact]
    public async Task Test3Rosii10Negre1Rosie()
    {
        //arrange
        var ruleta = new Ruleta(new Ruleta.SimData() { Bankroll = 10000,RuleazaRosuNegru = true});
        //3 rosii
        await ruleta.ProceseazaNumar(1);
        await ruleta.ProceseazaNumar(3);
        await ruleta.ProceseazaNumar(5);

        //10negre
        await ruleta.ProceseazaNumar(2);
        await ruleta.ProceseazaNumar(4);
        await ruleta.ProceseazaNumar(6);
        await ruleta.ProceseazaNumar(8);
        await ruleta.ProceseazaNumar(10);
        await ruleta.ProceseazaNumar(11);
        await ruleta.ProceseazaNumar(11);
        await ruleta.ProceseazaNumar(13);
        await ruleta.ProceseazaNumar(13);
        await ruleta.ProceseazaNumar(13);
        
        //rosu
        await ruleta.ProceseazaNumar(7);
        
        ruleta.Bankroll.Should().Be(8000);
        ruleta.StreakNegre.Should().HaveCount(1).And.Contain(p => p.Key == 10);
        ruleta.StreakRosii.Should().HaveCount(0);
    }
    [Fact]
    public async Task Test3Rosii10Negre1RosieDArCuRestartPariu()
    {
        //arrange
        var ruleta = new Ruleta(new Ruleta.SimData() { Bankroll = 10000,RuleazaRosuNegru = true,RestartPariuDeLaMinimDupaCeAPierdutMizaMaximaInAcelasiStreak = true});
        //3 rosii
        await ruleta.ProceseazaNumar(1);
        await ruleta.ProceseazaNumar(3);
        await ruleta.ProceseazaNumar(5);

        //10negre
        await ruleta.ProceseazaNumar(2);
        await ruleta.ProceseazaNumar(4);
        await ruleta.ProceseazaNumar(6);
        await ruleta.ProceseazaNumar(8);
        await ruleta.ProceseazaNumar(10);
        await ruleta.ProceseazaNumar(11);
        await ruleta.ProceseazaNumar(11);
        await ruleta.ProceseazaNumar(13);
        await ruleta.ProceseazaNumar(13);
        await ruleta.ProceseazaNumar(13);
        
        //rosu
        await ruleta.ProceseazaNumar(7);
        
        ruleta.Bankroll.Should().Be(8100);
        ruleta.StreakNegre.Should().HaveCount(1).And.Contain(p => p.Key == 10);
        ruleta.StreakRosii.Should().HaveCount(0);
    }
    [Fact]
    public async Task Test3Negre12Rosii1NeagraDArCuRestartPariu()
    {
        //arrange
        var ruleta = new Ruleta(new Ruleta.SimData() { Bankroll = 10000,RuleazaRosuNegru = true,RestartPariuDeLaMinimDupaCeAPierdutMizaMaximaInAcelasiStreak = true});
        //3 negre
        
        await ruleta.ProceseazaNumar(2);
        await ruleta.ProceseazaNumar(4);
        await ruleta.ProceseazaNumar(6);

        //12 rosii
        await ruleta.ProceseazaNumar(1);
        await ruleta.ProceseazaNumar(3);
        await ruleta.ProceseazaNumar(5);
        await ruleta.ProceseazaNumar(1);
        await ruleta.ProceseazaNumar(3);
        await ruleta.ProceseazaNumar(5);
        await ruleta.ProceseazaNumar(1);
        await ruleta.ProceseazaNumar(3);
        await ruleta.ProceseazaNumar(5);
        await ruleta.ProceseazaNumar(1);
        await ruleta.ProceseazaNumar(3);
        await ruleta.ProceseazaNumar(5);
        
        //negru
        await ruleta.ProceseazaNumar(2);
        
        ruleta.Bankroll.Should().Be(8000);
        ruleta.StreakRosii.Should().HaveCount(1).And.Contain(p => p.Key == 12);
        ruleta.StreakNegre.Should().HaveCount(0);
    }
    [Fact]
    public async Task Test5RosiiApoiZero()
    {
        //arrange
        var ruleta = new Ruleta(new Ruleta.SimData() { Bankroll = 10000,RuleazaRosuNegru = true});
        //5 rosii
        await ruleta.ProceseazaNumar(1);
        await ruleta.ProceseazaNumar(3);
        await ruleta.ProceseazaNumar(5);
        await ruleta.ProceseazaNumar(7);
        await ruleta.ProceseazaNumar(7);
        //zero
        await ruleta.ProceseazaNumar(0);
        
        
        ruleta.Bankroll.Should().Be(9800);
        ruleta.StreakRosii.Should().HaveCount(1).And.Contain(p => p.Key == 5);
        ruleta.StreakNegre.Should().HaveCount(0);
    }
    [Fact]
    public async Task Test5RosiiApoiZeroApi5RosiiApoiZero()
    {
        //arrange
        var ruleta = new Ruleta(new Ruleta.SimData() { Bankroll = 10000 ,RuleazaRosuNegru = true});
        //5 rosii
        await ruleta.ProceseazaNumar(1);
        await ruleta.ProceseazaNumar(3);
        await ruleta.ProceseazaNumar(5);
        await ruleta.ProceseazaNumar(7);
        await ruleta.ProceseazaNumar(7);
        //zero
        await ruleta.ProceseazaNumar(0);
        
        ruleta.Bankroll.Should().Be(9800);
        //5 rosii
        await ruleta.ProceseazaNumar(1);
        await ruleta.ProceseazaNumar(3);
        await ruleta.ProceseazaNumar(5);
        await ruleta.ProceseazaNumar(7);
        await ruleta.ProceseazaNumar(7);
        //zero
        await ruleta.ProceseazaNumar(0);
        
        ruleta.Bankroll.Should().Be(9600);
        ruleta.StreakRosii.Should().HaveCount(1).And.Contain(p => p.Key == 5);
        ruleta.StreakRosii[5].Should().Be(2);
        ruleta.StreakNegre.Should().HaveCount(0);
    }
}