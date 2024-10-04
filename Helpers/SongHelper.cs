namespace SongTracker.Helpers
{
    public class SongHelper
    {
        public static string ConvertStringToLookup(string name)
        {
            return name.Replace("the ", "").Trim().ToLower().Replace(" ","");
        }
        
    }
}
