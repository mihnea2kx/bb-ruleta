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
}