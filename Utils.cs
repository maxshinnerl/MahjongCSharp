namespace Mahjong
{
    public static class Utils
    {
        private static Random rng = new();

        public static void Shuffle<T>(this IList<T> list)
        {
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);  // random index
                (list[k], list[n]) = (list[n], list[k]);  // swap
            }
        }
    }
}