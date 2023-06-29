namespace hs.util
{
    public static class DateTimeExtensions
    {
        public static int Competencia(this DateTime dt)
        {
            return Int32.Parse(dt.ToString("yyyyMM"));
        }
    }
}