namespace SongTracker.Helpers
{
    public class SongHelper
    {
        public static string ConvertStringToLookup(string name)
        {
            //TODO use regex instead
            return name.Replace("the ", "").Trim().ToLower().Replace(" ","");
        }
        
    }
}
