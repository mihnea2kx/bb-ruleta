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
        public bool RuleazaParImpar { get; set; }
        public bool RuleazaHighLow { get; set; }
        public string NumereAlese { get; set; } = "";
    }

    public int Bankroll => bankroll;
    public int ZeroCounter => counterZero;
    public int TotalRosii => totalRosii;
    public int TotalNegre => totalNegre;
    public int TotalPare => totalPare;
    public int TotalImpare => totalImpare;
    public int TotalLow => total18;
    public int TotalHigh => total36;
    public Dictionary<int, int> StreakRosii => streakRosii;
    public Dictionary<int, int> StreakNegre => streakNegre;
    public Dictionary<int, int> StreakPare => streakPare;
    public Dictionary<int, int> StreakImpare => streakImpare;
    public Dictionary<int, int> StreakLow => streak18;
    public Dictionary<int, int> StreakHigh => streak36;


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

    int counterRosii,
        counterNegre,
        counterPare,
        counterImpare,
        counter18,
        counter36,
        counterDuzina1,
        counterDuzina2,
        counterDuzina3,
        counterZero;

    int pariuRosu, pariuNegru, pariuPar, pariuImpar, pariu18, pariu36, pariuDuzina1, pariuDuzina2, pariuDuzina3;
    int totalRosii, totalNegre,totalPare,totalImpare,total18,total36;
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
        totalNegre = 0;
        totalRosii = 0;
        streakNegre = new Dictionary<int, int>();
        streakRosii = new Dictionary<int, int>();
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
        // ProceseazaDuzine(numar);
    }

    private void ProceseazaDuzine(int numar)
    {
        if (numereDuzina1.Contains(numar))
        {
            counterDuzina1++;
            counterDuzina2 = 0;
            counterDuzina3 = 0;
        }
        else if (numereDuzina2.Contains(numar))
        {
            counterDuzina2++;
            counterDuzina1 = 0;
            counterDuzina3 = 0;
        }
        else if (numereDuzina3.Contains(numar))
        {
            counterDuzina3++;
            counterDuzina1 = 0;
            counterDuzina2 = 0;
        }
    }

    private void Proceseaza1836(int numar)
    {
        if (numar<=18)
        {
            //NUMAR MIC
            total18++;
            //verificam daca avem pariu pe low
            if (pariu18 > 0)
            {
                //am castigat pariu primim miza
                bankroll += valoriPariuri[pariu18];
                //resetam pariul
                pariu18 = 0;
            }
            else if (pariu36 > 0)
            {
                //am pierdut pariu pierdem miza
                bankroll -= valoriPariuri[pariu36];
                //crestem pariul pe high
                pariu36 = pariu36.CrestePariul();
            }

            counter18++;
            
            //streak logic - a fost numar mic resetam contorul de mari
            streak36.SetStreak(counter36);
            counter36 = 0;
            //end streak logic
            
            //punem pariu pe mare daca avem 4 mici 
            if (counter18 >= 4 && pariu36 == 0)
            {
                //streak unde deja s-a pierdut maxim
                if (counter18 > 8)
                {
                    if (_simData.RestartPariuDeLaMinimDupaCeAPierdutMizaMaximaInAcelasiStreak)
                    {
                        pariu36 = pariu36.CrestePariul();
                    }
                }
                else
                {
                    pariu36 = pariu36.CrestePariul();
                }
                
            }
        }
        else
        {
            //NUMAR MARE
            total36++;
            //verificam daca avem pariu pe negru
            if (pariu36 > 0)
            {
                //am castigat pariu primim miza
                bankroll += valoriPariuri[pariu36];
                //resetam pariul pe mare
                pariu36 = 0;
            }
            else if (pariu18 > 0)
            {
                //am pierdut pariu pierdem miza
                bankroll -= valoriPariuri[pariu18];
                //crestem pariul pe low
                pariu18 = pariu18.CrestePariul();
            }

            counter36++;
            
            //streak logic
            streak18.SetStreak(counter18);
            counterRosii = 0;
            //end streak logic

            //punem pariu pe rosu daca avem 4 negre 
            if (counter36 >= 4 && pariu18 == 0)
            {
                //streak unde deja s-a pierdut maxim
                if (counter36 > 8)
                {
                    if (_simData.RestartPariuDeLaMinimDupaCeAPierdutMizaMaximaInAcelasiStreak)
                    {
                        pariu18 = pariu18.CrestePariul();
                    }
                }
                else
                {
                    pariu18 = pariu18.CrestePariul();
                }
                
            }
        }
    }

    private void ProceseazaParImpar(int numar)
    {
        if (numar%2==0)
        {
            //NUMAR PAR
            totalPare++;
            //verificam daca avem pariu pe par
            if (pariuPar > 0)
            {
                //am castigat pariu primim miza
                bankroll += valoriPariuri[pariuPar];
                //resetam pariul
                pariuPar = 0;
            }
            else if (pariuImpar > 0)
            {
                //am pierdut pariu pierdem miza
                bankroll -= valoriPariuri[pariuImpar];
                //crestem pariul pe negru
                pariuImpar = pariuImpar.CrestePariul();
            }

            counterPare++;
            //streak logic - a fost numar rosu resetam contorul de negre
            streakImpare.SetStreak(counterImpare);
            counterImpare = 0;
            //end streak logic
            //punem pariu daca avem 4 pare 
            if (counterPare >= 4 && pariuImpar == 0)
            {
                //streak unde deja s-a pierdut maxim
                if (counterPare > 8)
                {
                    if (_simData.RestartPariuDeLaMinimDupaCeAPierdutMizaMaximaInAcelasiStreak)
                    {
                        pariuImpar = pariuImpar.CrestePariul();
                    }
                }
                else
                {
                    pariuImpar = pariuImpar.CrestePariul();
                }
                
            }
        }
        else
        {
            //NUMAR IMPAR
            totalImpare++;
            //verificam daca avem pariu pe impar
            if (pariuImpar > 0)
            {
                //am castigat pariu primim miza
                bankroll += valoriPariuri[pariuImpar];
                //resetam pariul pe impar
                pariuImpar = 0;
            }
            else if (pariuPar > 0)
            {
                //am pierdut pariu pierdem miza
                bankroll -= valoriPariuri[pariuPar];
                //crestem pariul pe rosu
                pariuPar = pariuPar.CrestePariul();
            }

            counterImpare++;
            
            //streak logic
            streakPare.SetStreak(counterPare);
            counterPare = 0;
            //end streak logic

            //punem pariu pe rosu daca avem 4 negre 
            if (counterImpare >= 4 && pariuPar == 0)
            {
                //streak unde deja s-a pierdut maxim
                if (counterImpare > 8)
                {
                    if (_simData.RestartPariuDeLaMinimDupaCeAPierdutMizaMaximaInAcelasiStreak)
                    {
                        pariuPar = pariuPar.CrestePariul();
                    }
                }
                else
                {
                    pariuPar = pariuPar.CrestePariul();
                }
                
            }
        }
    }

    private void ProceseazaRosieNeagra(int numar)
    {
        if (numereRosii.Contains(numar))
        {
            //NUMAR ROSU
            totalRosii++;
            //verificam daca avem pariu pe rosu
            if (pariuRosu > 0)
            {
                //am castigat pariu primim miza
                bankroll += valoriPariuri[pariuRosu];
                //resetam pariul
                pariuRosu = 0;
            }
            else if (pariuNegru > 0)
            {
                //am pierdut pariu pierdem miza
                bankroll -= valoriPariuri[pariuNegru];
                //crestem pariul pe negru
                pariuNegru = pariuNegru.CrestePariul();
            }

            counterRosii++;
            
            //streak logic - a fost numar rosu resetam contorul de negre
            streakNegre.SetStreak(counterNegre);
            counterNegre = 0;
            //end streak logic
            
            //punem pariu daca avem 4 rosii 
            if (counterRosii >= 4 && pariuNegru == 0)
            {
                //streak unde deja s-a pierdut maxim
                if (counterRosii > 8)
                {
                    if (_simData.RestartPariuDeLaMinimDupaCeAPierdutMizaMaximaInAcelasiStreak)
                    {
                        pariuNegru = pariuNegru.CrestePariul();
                    }
                }
                else
                {
                    pariuNegru = pariuNegru.CrestePariul();
                }
                
            }
        }
        else
        {
            //NUMAR NEGRU
            totalNegre++;
            //verificam daca avem pariu pe negru
            if (pariuNegru > 0)
            {
                //am castigat pariu primim miza
                bankroll += valoriPariuri[pariuNegru];
                //resetam pariul pe negru
                pariuNegru = 0;
            }
            else if (pariuRosu > 0)
            {
                //am pierdut pariu pierdem miza
                bankroll -= valoriPariuri[pariuRosu];
                //crestem pariul pe rosu
                pariuRosu = pariuRosu.CrestePariul();
            }

            counterNegre++;
            
            //streak logic
            streakRosii.SetStreak(counterRosii);
            counterRosii = 0;
            //end streak logic

            //punem pariu pe rosu daca avem 4 negre 
            if (counterNegre >= 4 && pariuRosu == 0)
            {
                //streak unde deja s-a pierdut maxim
                if (counterNegre > 8)
                {
                    if (_simData.RestartPariuDeLaMinimDupaCeAPierdutMizaMaximaInAcelasiStreak)
                    {
                        pariuRosu = pariuRosu.CrestePariul();
                    }
                }
                else
                {
                    pariuRosu = pariuRosu.CrestePariul();
                }
                
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
    }

    async Task ProceseazaZero()
    {
        //Set Streaks
        ResetStreaks();
        
        if (pariuRosu > 0) bankroll -= valoriPariuri[pariuRosu];
        if (pariuNegru > 0) bankroll -= valoriPariuri[pariuNegru];
        if (pariuPar > 0) bankroll -= valoriPariuri[pariuPar];
        if (pariuImpar > 0) bankroll -= valoriPariuri[pariuImpar];
        if (pariu18 > 0) bankroll -= valoriPariuri[pariu18];
        if (pariu36 > 0) bankroll -= valoriPariuri[pariu36];

        ResetBets();
        
        counterZero++;
        counterDuzina1 = 0;
        counterDuzina2 = 0;
        counterDuzina3 = 0;
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
    }
}