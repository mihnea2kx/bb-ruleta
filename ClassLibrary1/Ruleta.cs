using System.Text.RegularExpressions;

namespace ClassLibrary1;

public class Ruleta
{
    public class SimData
    {
        public int TotalSpins { get; set; }
        public int Bankroll { get; set; }
        public bool StopLaZero { get; set; }
        public bool RestartPariuDeLaMinimDupaCeAPierdutMizaMaximaInAcelasiStreak { get; set; }
        public bool RuleazaRosuNegru { get; set; }
        public int PariazaRosuDupaCateNegre { get; set; } = 4;
        public bool RuleazaParImpar { get; set; }
        public int PariazaParDupaCateImpare { get; set; } = 4;
        public bool RuleazaHighLow { get; set; }
        public int PariazaHighDupaCateLow { get; set; } = 4;
        public bool RuleazaDuzine { get; set; }
        public int PariazaDuzinaDupaCateLipsa { get; set; } = 8;
        public string NumereAlese { get; set; } = "";
        public string PariuriStabilite { get; set; } = "100,100,200,300,500,800";
    }

    public int Bankroll => bankroll;
    public int ZeroCounter => counterZero;
    public int TotalRosii => totalRosii;
    public int TotalNegre => totalNegre;
    public int TotalPare => totalPare;
    public int TotalImpare => totalImpare;
    public int TotalLow => total18;
    public int TotalHigh => total36;
    public int TotalD1 => totalD1;
    public int TotalD2 => totalD2;
    public int TotalD3 => totalD3;
    public Dictionary<int, int> StreakRosii => streakRosii;
    public Dictionary<int, int> StreakNegre => streakNegre;
    public Dictionary<int, int> StreakPare => streakPare;
    public Dictionary<int, int> StreakImpare => streakImpare;
    public Dictionary<int, int> StreakLow => streak18;
    public Dictionary<int, int> StreakHigh => streak36;
    public Dictionary<int, int> StreakD1 => streakD1;
    public Dictionary<int, int> StreakD2 => streakD2;
    public Dictionary<int, int> StreakD3 => streakD3;

    public Dictionary<string?, int?> PariuriCastigatoare => pariuriCastigate;
    public Dictionary<string, int?> PariuriPierdute => pariuriPierdute;
    public Dictionary<string, int?> PariuriPierdutePeZero => pariuriPierdutePeZero;


    private readonly List<int> numereRosii = new List<int>()
        { 32, 19, 21, 25, 34, 27, 36, 30, 23, 5, 16, 1, 14, 9, 18, 7, 12, 3 };

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

    private Dictionary<int, int> streakRosii = new Dictionary<int, int>();
    private Dictionary<int, int> streakNegre = new Dictionary<int, int>();
    private Dictionary<int, int> streakPare = new Dictionary<int, int>();
    private Dictionary<int, int> streakImpare = new Dictionary<int, int>();
    private Dictionary<int, int> streak18 = new Dictionary<int, int>();
    private Dictionary<int, int> streak36 = new Dictionary<int, int>();
    private Dictionary<int, int> streakD1 = new Dictionary<int, int>();
    private Dictionary<int, int> streakD2 = new Dictionary<int, int>();
    private Dictionary<int, int> streakD3 = new Dictionary<int, int>();

    private Dictionary<string, int?> pariuriPierdute = new Dictionary<string, int?>();
    private Dictionary<string, int?> pariuriPierdutePeZero = new Dictionary<string, int?>();
    private Dictionary<string, int?> pariuriCastigate = new Dictionary<string, int?>();

    public int counterRosii,
        counterNegre,
        counterPare,
        counterImpare,
        counter18,
        counter36,
        counterDuzina1,
        counterDuzina2,
        counterDuzina3,
        counterLipsaDuzina1,
        counterLipsaDuzina2,
        counterLipsaDuzina3,
        counterZero,
        counterPariuriPrinseDeZero,
        valoarePariuriPrinseDeZero;

    public int pariuRosu, pariuNegru, pariuPar, pariuImpar, pariu18, pariu36, pariuDuzina1, pariuDuzina2, pariuDuzina3;
    public int totalRosii, totalNegre,totalPare,totalImpare,total18,total36,totalD1,totalD2,totalD3;
    int totalSpins = 100000;
    int bankroll = 10000;

    List<int> valoriPariuri = new List<int>()
    {
        0, 100, 100, 200, 300, 500, 800
    };

    private SimData _simData;

    public Ruleta(SimData simData)
    {
        _simData = simData;
        bankroll = simData.Bankroll;
        totalSpins = simData.TotalSpins;
        counterZero = 0;
        counterNegre = 0;
        counterRosii = 0;
        counter18 = 0;
        counter36 = 0;
        counterPare = 0;
        counterImpare = 0;
        counterDuzina1 = 0;
        counterDuzina2 = 0;
        counterDuzina3 = 0;
        counterLipsaDuzina1 = 0;
        counterLipsaDuzina2 = 0;
        counterLipsaDuzina3 = 0;
        totalNegre = 0;
        totalRosii = 0;
        streakNegre = new Dictionary<int, int>();
        streakRosii = new Dictionary<int, int>();
        streak18 = new Dictionary<int, int>();
        streak36 = new Dictionary<int, int>();
        streakPare = new Dictionary<int, int>();
        streakImpare = new Dictionary<int, int>();
        streakD1 = new Dictionary<int, int>();
        streakD2 = new Dictionary<int, int>();
        streakD3 = new Dictionary<int, int>();
        
        SetPariuri();
    }

    private void SetPariuri()
    {
        valoriPariuri = new List<int>() { 0 };
        string[] numbers = Regex.Split(_simData.PariuriStabilite, @"\D+");
        foreach (string value in numbers)
        {
            if (!string.IsNullOrEmpty(value))
            {
                int i = int.Parse(value);
                //numereAlese.Add(i);
                if (i != null)
                {
                    valoriPariuri.Add(i);
                }
            }
        }
    }

    public async Task ProceseazaNumar(int numar)
    {
        if (numar == 0)
        {
            await ProceseazaZero();
            return;
        }

        //rosie neagra
        if(_simData.RuleazaRosuNegru)ProceseazaRosieNeagra(numar);
        //par impar
        if(_simData.RuleazaParImpar) ProceseazaParImpar(numar);
        //0-18 19-36
        if(_simData.RuleazaHighLow) Proceseaza1836(numar);
        //duzine
        if(_simData.RuleazaDuzine) ProceseazaDuzine(numar);
    }

    private void CountPariuPierzator(string indexPariu)
    {
        if (pariuriPierdute.ContainsKey(indexPariu))
        {
            pariuriPierdute[indexPariu]++;
        }
        else
        {
            pariuriPierdute.Add(indexPariu,1);
        }
    }
    private void CountPariuPierzatorPeZero(string indexPariu)
    {
        if (pariuriPierdutePeZero.ContainsKey(indexPariu))
        {
            pariuriPierdutePeZero[indexPariu]++;
        }
        else
        {
            pariuriPierdutePeZero.Add(indexPariu,1);
        }
    }
    private void CountPariuCastigator(string indexPariu)
    {
        if (pariuriCastigate.ContainsKey(indexPariu))
        {
            pariuriCastigate[indexPariu]++;
        }
        else
        {
            pariuriCastigate.Add(indexPariu,1);
        }
    }

    private void ProceseazaDuzine(int numar)
    {
        
        if (numereDuzina1.Contains(numar))
        {
            ProceseazaNumarDuzina1();
        }
        else if (numereDuzina2.Contains(numar))
        {
            ProceseazaNumarDuzina2();
        }else if (numereDuzina3.Contains(numar))
        {
            ProceseazaNumarDuzina3();
        }
        
    }

    private void ProceseazaNumarDuzina3()
    {
        //NUMAR Duzina3
        totalD3++;
        //verificam daca avem pariu pe D3
        if (pariuDuzina3 > 0)
        {
            //am castigat pariu primim miza
            bankroll += valoriPariuri[pariuDuzina3] * 2;
            CountPariuCastigator($"{pariuDuzina3}-{valoriPariuri[pariuDuzina3]}");
            CountPariuCastigator($"{pariuDuzina3}-{valoriPariuri[pariuDuzina3]}");
            //resetam pariul
            pariuDuzina3 = 0;
        }
        else
        {
            if (pariuDuzina2 > 0)
            {
                //am pierdut pariu pierdem miza
                bankroll -= valoriPariuri[pariuDuzina2];
                CountPariuPierzator($"{pariuDuzina2}-{valoriPariuri[pariuDuzina2]}");
                //crestem pariul pe duzina2
                pariuDuzina2 = pariuDuzina2.CrestePariul(valoriPariuri.Count);
            }

            if (pariuDuzina1 > 0)
            {
                //am pierdut pariu pierdem miza
                bankroll -= valoriPariuri[pariuDuzina1];
                CountPariuPierzator($"{pariuDuzina1}-{valoriPariuri[pariuDuzina1]}");
                //crestem pariul pe duzina3
                pariuDuzina1 = pariuDuzina1.CrestePariul(valoriPariuri.Count);
            }
        }

        counterDuzina3++;
        counterLipsaDuzina3 = 0;
        counterLipsaDuzina2++;
        counterLipsaDuzina1++;

        //streak logic - a fost numar D1 resetam contorul de D1 si D2
        streakD2.SetStreak(counterDuzina2);
        streakD1.SetStreak(counterDuzina1);
        counterDuzina2 = 0;
        counterDuzina1 = 0;
        //end streak logic

        //punem pariu daca avem 8 D2+D3 
        if (counterLipsaDuzina2 >= _simData.PariazaDuzinaDupaCateLipsa && pariuDuzina2 == 0)
        {
            pariuDuzina2 = pariuDuzina2.CrestePariul(valoriPariuri.Count);
        }

        if (counterLipsaDuzina1 >= _simData.PariazaDuzinaDupaCateLipsa && pariuDuzina1 == 0)
        {
            pariuDuzina1 = pariuDuzina1.CrestePariul(valoriPariuri.Count);
        }
    }

    private void ProceseazaNumarDuzina2()
    {
        //NUMAR Duzina2
        totalD2++;
        //verificam daca avem pariu pe D2
        if (pariuDuzina2 > 0)
        {
            //am castigat pariu primim miza
            bankroll += valoriPariuri[pariuDuzina2] * 2;
            CountPariuCastigator($"{pariuDuzina2}-{valoriPariuri[pariuDuzina2]}");
            CountPariuCastigator($"{pariuDuzina2}-{valoriPariuri[pariuDuzina2]}");
            //resetam pariul
            pariuDuzina2 = 0;
        }
        else
        {
            if (pariuDuzina1 > 0)
            {
                //am pierdut pariu pierdem miza
                bankroll -= valoriPariuri[pariuDuzina1];
                CountPariuPierzator($"{pariuDuzina1}-{valoriPariuri[pariuDuzina1]}");
                //crestem pariul pe duzina1
                pariuDuzina1 = pariuDuzina1.CrestePariul(valoriPariuri.Count);
            }

            if (pariuDuzina3 > 0)
            {
                //am pierdut pariu pierdem miza
                bankroll -= valoriPariuri[pariuDuzina3];
                CountPariuPierzator($"{pariuDuzina3}-{valoriPariuri[pariuDuzina3]}");
                //crestem pariul pe duzina3
                pariuDuzina3 = pariuDuzina3.CrestePariul(valoriPariuri.Count);
            }
        }

        counterDuzina2++;
        counterLipsaDuzina2 = 0;
        counterLipsaDuzina1++;
        counterLipsaDuzina3++;

        //streak logic - a fost numar D1 resetam contorul de D1 si D2
        streakD1.SetStreak(counterDuzina1);
        streakD3.SetStreak(counterDuzina3);
        counterDuzina1 = 0;
        counterDuzina3 = 0;
        //end streak logic

        //punem pariu daca avem 8 D1+D3 
        if (counterLipsaDuzina1 >= _simData.PariazaDuzinaDupaCateLipsa && pariuDuzina1 == 0)
        {
            pariuDuzina1 = pariuDuzina1.CrestePariul(valoriPariuri.Count);
        }

        if (counterLipsaDuzina3 >= _simData.PariazaDuzinaDupaCateLipsa && pariuDuzina3 == 0)
        {
            pariuDuzina3 = pariuDuzina3.CrestePariul(valoriPariuri.Count);
        }
    }

    private void ProceseazaNumarDuzina1()
    {
        //NUMAR Duzina1
        totalD1++;
        //verificam daca avem pariu pe D1
        if (pariuDuzina1 > 0)
        {
            //am castigat pariu primim miza
            bankroll += valoriPariuri[pariuDuzina1] * 2;
            CountPariuCastigator($"{pariuDuzina1}-{valoriPariuri[pariuDuzina1]}");
            CountPariuCastigator($"{pariuDuzina1}-{valoriPariuri[pariuDuzina1]}");
            //resetam pariul
            pariuDuzina1 = 0;
        }
        else
        {
            if (pariuDuzina2 > 0)
            {
                //am pierdut pariu pierdem miza
                bankroll -= valoriPariuri[pariuDuzina2];
                CountPariuPierzator($"{pariuDuzina2}-{valoriPariuri[pariuDuzina2]}");
                //crestem pariul pe duzina2
                pariuDuzina2 = pariuDuzina2.CrestePariul(valoriPariuri.Count);
            }

            if (pariuDuzina3 > 0)
            {
                //am pierdut pariu pierdem miza
                bankroll -= valoriPariuri[pariuDuzina3];
                CountPariuPierzator($"{pariuDuzina3}-{valoriPariuri[pariuDuzina3]}");
                //crestem pariul pe duzina3
                pariuDuzina3 = pariuDuzina3.CrestePariul(valoriPariuri.Count);
            }
        }

        counterDuzina1++;
        counterLipsaDuzina1 = 0;
        counterLipsaDuzina2++;
        counterLipsaDuzina3++;

        //streak logic - a fost numar D1 resetam contorul de D1 si D2
        streakD2.SetStreak(counterDuzina2);
        streakD3.SetStreak(counterDuzina3);
        counterDuzina2 = 0;
        counterDuzina3 = 0;
        //end streak logic

        //punem pariu daca avem 8 D2+D3 
        if (counterLipsaDuzina2 >= _simData.PariazaDuzinaDupaCateLipsa && pariuDuzina2 == 0)
        {
            pariuDuzina2 = pariuDuzina2.CrestePariul(valoriPariuri.Count);
        }

        if (counterLipsaDuzina3 >= _simData.PariazaDuzinaDupaCateLipsa && pariuDuzina3 == 0)
        {
            pariuDuzina3 = pariuDuzina3.CrestePariul(valoriPariuri.Count);
        }
    }

    private void Proceseaza1836(int numar)
    {
        if (numar<=18)
        {
            ProceseazaNumarMic();
        }
        else
        {
            ProceseazaNumarMare();
        }
    }

    private void ProceseazaNumarMare()
    {
        //NUMAR MARE
        total36++;
        //verificam daca avem pariu pe negru
        if (pariu36 > 0)
        {
            //am castigat pariu primim miza
            bankroll += valoriPariuri[pariu36];
            CountPariuCastigator($"{pariu36}-{valoriPariuri[pariu36]}");
            //resetam pariul pe mare
            pariu36 = 0;
        }
        else if (pariu18 > 0)
        {
            //am pierdut pariu pierdem miza
            bankroll -= valoriPariuri[pariu18];
            CountPariuPierzator($"{pariu18}-{valoriPariuri[pariu18]}");
            //crestem pariul pe low
            pariu18 = pariu18.CrestePariul(valoriPariuri.Count);
        }

        counter36++;

        //streak logic
        streak18.SetStreak(counter18);
        counter18 = 0;
        //end streak logic

        //punem pariu pe rosu daca avem 4 negre 
        if (counter36 >= _simData.PariazaHighDupaCateLow && pariu18 == 0)
        {
            //streak unde deja s-a pierdut maxim
            if (counter36 > _simData.PariazaHighDupaCateLow + valoriPariuri.Count - 2)
            {
                if (_simData.RestartPariuDeLaMinimDupaCeAPierdutMizaMaximaInAcelasiStreak)
                {
                    pariu18 = pariu18.CrestePariul(valoriPariuri.Count);
                }
            }
            else
            {
                pariu18 = pariu18.CrestePariul(valoriPariuri.Count);
            }
        }
    }

    private void ProceseazaNumarMic()
    {
        //NUMAR MIC
        total18++;
        //verificam daca avem pariu pe low
        if (pariu18 > 0)
        {
            //am castigat pariu primim miza
            bankroll += valoriPariuri[pariu18];
            CountPariuCastigator($"{pariu18}-{valoriPariuri[pariu18]}");
            //resetam pariul
            pariu18 = 0;
        }
        else if (pariu36 > 0)
        {
            //am pierdut pariu pierdem miza
            bankroll -= valoriPariuri[pariu36];
            CountPariuPierzator($"{pariu36}-{valoriPariuri[pariu36]}");
            //crestem pariul pe high
            pariu36 = pariu36.CrestePariul(valoriPariuri.Count);
        }

        counter18++;

        //streak logic - a fost numar mic resetam contorul de mari
        streak36.SetStreak(counter36);
        counter36 = 0;
        //end streak logic

        //punem pariu pe mare daca avem 4 mici 
        if (counter18 >= _simData.PariazaHighDupaCateLow  && pariu36 == 0)
        {
            //streak unde deja s-a pierdut maxim
            if (counter18 > _simData.PariazaHighDupaCateLow + valoriPariuri.Count-2)
            {
                if (_simData.RestartPariuDeLaMinimDupaCeAPierdutMizaMaximaInAcelasiStreak)
                {
                    pariu36 = pariu36.CrestePariul(valoriPariuri.Count);
                }
            }
            else
            {
                pariu36 = pariu36.CrestePariul(valoriPariuri.Count);
            }
        }
    }

    private void ProceseazaParImpar(int numar)
    {
        if (numar%2==0)
        {
            ProceseazaNumarPar();
        }
        else
        {
            ProceseazaNumarImpar();
        }
    }

    private void ProceseazaNumarImpar()
    {
        //NUMAR IMPAR
        totalImpare++;
        //verificam daca avem pariu pe impar
        if (pariuImpar > 0)
        {
            //am castigat pariu primim miza
            bankroll += valoriPariuri[pariuImpar];
            CountPariuCastigator($"{pariuImpar}-{valoriPariuri[pariuImpar]}");
            //resetam pariul pe impar
            pariuImpar = 0;
        }
        else if (pariuPar > 0)
        {
            //am pierdut pariu pierdem miza
            bankroll -= valoriPariuri[pariuPar];
            CountPariuPierzator($"{pariuPar}-{valoriPariuri[pariuPar]}");
            //crestem pariul pe rosu
            pariuPar = pariuPar.CrestePariul(valoriPariuri.Count);
        }

        counterImpare++;

        //streak logic
        streakPare.SetStreak(counterPare);
        counterPare = 0;
        //end streak logic

        //punem pariu pe par daca avem 4 impare 
        if (counterImpare >= _simData.PariazaParDupaCateImpare && pariuPar == 0)
        {
            //streak unde deja s-a pierdut maxim
            if (counterImpare > _simData.PariazaParDupaCateImpare && pariuImpar == 0)
            {
                if (_simData.RestartPariuDeLaMinimDupaCeAPierdutMizaMaximaInAcelasiStreak)
                {
                    pariuPar = pariuPar.CrestePariul(valoriPariuri.Count);
                }
            }
            else
            {
                pariuPar = pariuPar.CrestePariul(valoriPariuri.Count);
            }
        }
    }

    private void ProceseazaNumarPar()
    {
        //NUMAR PAR
        totalPare++;
        //verificam daca avem pariu pe par
        if (pariuPar > 0)
        {
            //am castigat pariu primim miza
            bankroll += valoriPariuri[pariuPar];
            CountPariuCastigator($"{pariuPar}-{valoriPariuri[pariuPar]}");
            //resetam pariul
            pariuPar = 0;
        }
        else if (pariuImpar > 0)
        {
            //am pierdut pariu pierdem miza
            bankroll -= valoriPariuri[pariuImpar];
            CountPariuPierzator($"{pariuImpar}-{valoriPariuri[pariuImpar]}");
            //crestem pariul pe negru
            pariuImpar = pariuImpar.CrestePariul(valoriPariuri.Count);
        }

        counterPare++;
        //streak logic - a fost numar rosu resetam contorul de negre
        streakImpare.SetStreak(counterImpare);
        counterImpare = 0;
        //end streak logic
        //punem pariu daca avem 4 pare 
        if (counterPare >= _simData.PariazaParDupaCateImpare && pariuImpar == 0)
        {
            //streak unde deja s-a pierdut maxim
            if (counterPare > _simData.PariazaParDupaCateImpare+valoriPariuri.Count-2)
            {
                if (_simData.RestartPariuDeLaMinimDupaCeAPierdutMizaMaximaInAcelasiStreak)
                {
                    pariuImpar = pariuImpar.CrestePariul(valoriPariuri.Count);
                }
            }
            else
            {
                pariuImpar = pariuImpar.CrestePariul(valoriPariuri.Count);
            }
        }
    }

    private void ProceseazaRosieNeagra(int numar)
    {
        if (numereRosii.Contains(numar))
        {
            ProceseazaNumarRosu();
        }
        else
        {
            ProceseazaNumarNegru();
        }
    }

    private void ProceseazaNumarNegru()
    {
        //NUMAR NEGRU
        totalNegre++;
        //verificam daca avem pariu pe negru
        if (pariuNegru > 0)
        {
            //am castigat pariu primim miza
            bankroll += valoriPariuri[pariuNegru];
            CountPariuCastigator($"{pariuNegru}-{valoriPariuri[pariuNegru]}");
            //resetam pariul pe negru
            pariuNegru = 0;
        }
        else if (pariuRosu > 0)
        {
            //am pierdut pariu pierdem miza
            bankroll -= valoriPariuri[pariuRosu];
            CountPariuPierzator($"{pariuRosu}-{valoriPariuri[pariuRosu]}");
            //crestem pariul pe rosu
            pariuRosu = pariuRosu.CrestePariul(valoriPariuri.Count);
        }

        counterNegre++;

        //streak logic
        streakRosii.SetStreak(counterRosii);
        counterRosii = 0;
        //end streak logic

        //punem pariu pe rosu daca avem 4 negre 
        if (counterNegre >= _simData.PariazaRosuDupaCateNegre && pariuRosu == 0)
        {
            //streak unde deja s-a pierdut maxim
            if (counterNegre > _simData.PariazaRosuDupaCateNegre+valoriPariuri.Count-2)
            {
                if (_simData.RestartPariuDeLaMinimDupaCeAPierdutMizaMaximaInAcelasiStreak)
                {
                    pariuRosu = pariuRosu.CrestePariul(valoriPariuri.Count);
                }
            }
            else
            {
                pariuRosu = pariuRosu.CrestePariul(valoriPariuri.Count);
            }
        }
    }

    private void ProceseazaNumarRosu()
    {
        //NUMAR ROSU
        totalRosii++;
        //verificam daca avem pariu pe rosu
        if (pariuRosu > 0)
        {
            //am castigat pariu primim miza
            bankroll += valoriPariuri[pariuRosu];
            CountPariuCastigator($"{pariuRosu}-{valoriPariuri[pariuRosu]}");
            //resetam pariul
            pariuRosu = 0;
        }
        else if (pariuNegru > 0)
        {
            //am pierdut pariu pierdem miza
            bankroll -= valoriPariuri[pariuNegru];
            CountPariuPierzator($"{pariuNegru}-{valoriPariuri[pariuNegru]}");
            //crestem pariul pe negru
            pariuNegru = pariuNegru.CrestePariul(valoriPariuri.Count);
        }

        counterRosii++;

        //streak logic - a fost numar rosu resetam contorul de negre
        streakNegre.SetStreak(counterNegre);
        counterNegre = 0;
        //end streak logic

        //punem pariu daca avem 4 rosii 
        if (counterRosii >= _simData.PariazaRosuDupaCateNegre && pariuNegru == 0)
        {
            //streak unde deja s-a pierdut maxim
            if (counterRosii > _simData.PariazaRosuDupaCateNegre+valoriPariuri.Count-2)
            {
                if (_simData.RestartPariuDeLaMinimDupaCeAPierdutMizaMaximaInAcelasiStreak)
                {
                    pariuNegru = pariuNegru.CrestePariul(valoriPariuri.Count);
                }
            }
            else
            {
                pariuNegru = pariuNegru.CrestePariul(valoriPariuri.Count);
            }
        }
    }

    private void ResetStreaks()
    {
        //streak rosii
        if (counterRosii > 3)
        {
            if (streakRosii.ContainsKey(counterRosii))
            {
                streakRosii[counterRosii]++;
            }
            else
            {
                streakRosii.Add(counterRosii, 1);
            }
        }
        counterRosii = 0;
        
        //strak negre
        if (counterNegre > 3)
        {
            if (streakNegre.ContainsKey(counterNegre))
            {
                streakNegre[counterNegre]++;
            }
            else
            {
                streakNegre.Add(counterNegre, 1);
            }
        }
        counterNegre = 0;
        
        //strak pare
        if (counterPare > 3)
        {
            if (streakPare.ContainsKey(counterPare))
            {
                streakPare[counterPare]++;
            }
            else
            {
                streakPare.Add(counterPare, 1);
            }
        }
        counterPare = 0;
        
        //strak impare
        if (counterImpare > 3)
        {
            if (streakImpare.ContainsKey(counterImpare))
            {
                streakImpare[counterImpare]++;
            }
            else
            {
                streakImpare.Add(counterImpare, 1);
            }
        }
        counterImpare = 0;
        
        //strak low
        if (counter18 > 3)
        {
            if (streak18.ContainsKey(counter18))
            {
                streak18[counter18]++;
            }
            else
            {
                streak18.Add(counter18, 1);
            }
        }
        counter18 = 0;
        
        //strak high
        if (counter36 > 3)
        {
            if (streak36.ContainsKey(counter36))
            {
                streak36[counter36]++;
            }
            else
            {
                streak36.Add(counter36, 1);
            }
        }
        counter36 = 0;
        
        //strak D1
        if (counterDuzina1 > 3)
        {
            if (streakD1.ContainsKey(counterDuzina1))
            {
                streakD1[counterDuzina1]++;
            }
            else
            {
                streakD1.Add(counterDuzina1, 1);
            }
        }
        counterDuzina1 = 0;
        
        //strak D2
        if (counterDuzina2 > 3)
        {
            if (streakD2.ContainsKey(counterDuzina2))
            {
                streakD2[counterDuzina2]++;
            }
            else
            {
                streakD2.Add(counterDuzina2, 1);
            }
        }
        counterDuzina2 = 0;
        
        //strak D3
        if (counterDuzina1 > 3)
        {
            if (streakD3.ContainsKey(counterDuzina3))
            {
                streakD3[counterDuzina3]++;
            }
            else
            {
                streakD3.Add(counterDuzina3, 1);
            }
        }
        counterDuzina3 = 0;
    }

    private void ProceseazaPariuPrinsPeZero(int pariu)
    {
        if (pariu > 0)
        {
            counterPariuriPrinseDeZero++;
            valoarePariuriPrinseDeZero += valoriPariuri[pariu];
            bankroll -= valoriPariuri[pariu];
            CountPariuPierzatorPeZero($"{pariu}-{valoriPariuri[pariu]}");
        }
    }
    async Task ProceseazaZero()
    {
        //Set Streaks
        ResetStreaks();
        
        ProceseazaPariuPrinsPeZero(pariuRosu);
        ProceseazaPariuPrinsPeZero(pariuNegru);
        ProceseazaPariuPrinsPeZero(pariuPar);
        ProceseazaPariuPrinsPeZero(pariuImpar);
        ProceseazaPariuPrinsPeZero(pariu18);
        ProceseazaPariuPrinsPeZero(pariu36);
        ProceseazaPariuPrinsPeZero(pariuDuzina1);
        ProceseazaPariuPrinsPeZero(pariuDuzina2);
        ProceseazaPariuPrinsPeZero(pariuDuzina3);

        ResetBets();
        
        counterZero++;
        counterDuzina1 = 0;
        counterDuzina2 = 0;
        counterDuzina3 = 0;
        counterLipsaDuzina1 = 0;
        counterLipsaDuzina2 = 0;
        counterLipsaDuzina3 = 0;
        counterImpare = 0;
        counterPare = 0;
        counterRosii = 0;
        counterNegre = 0;
        counter18 = 0;
        counter36 = 0;

    }

    private void ResetBets()
    {
        pariuRosu = 0;
        pariuNegru = 0;
        pariuPar = 0;
        pariuImpar = 0;
        pariu18 = 0;
        pariu36 = 0;
        pariuDuzina1 = 0;
        pariuDuzina2 = 0;
        pariuDuzina3 = 0;
    }
}