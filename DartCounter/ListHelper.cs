namespace DartCounter;
public static class ListHelper
{
    private static readonly Random rng = new Random();
    public static void Shuffle<T>(this List<T> list)
    {
        int n = list.Count;
        while (n > 1)
        {
            n--;
            int k = rng.Next(n + 1);
            (list[n], list[k])=(list[k], list[n]);
        }
    }
}
