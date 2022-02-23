using System.Text.RegularExpressions;

namespace ClassLibrary1;

public static class IntExtensions
{
    public static int CrestePariul(this int pariu, int numarPariuri=7)
    {
        if (pariu < numarPariuri - 1)
        {
            pariu++;
            return pariu;
        }

        return 0;
    }

    public static int ValoarePariuDinIndex(this string index)
    {
        string[] numbers = Regex.Split(index, @"\D+");
        if (numbers[1] is not null) return Int32.Parse(numbers[1]);

        return 0;
    }
}

public static class DictExtensions
{
    public static Dictionary<int, int> SetStreak(this Dictionary<int, int> dict, int value)
    {
        if (value > 3)
        {
            if (dict.ContainsKey(value))
            {
                dict[value]++;
            }
            else
            {
                dict.Add(value, 1);
            }
        }

        return dict;
    }
    
    public static int GetVal(this Dictionary<string, int?> dict, string key)
    {
        if (!dict.ContainsKey(key)) return 0;

        return dict[key]??0;
    }
}