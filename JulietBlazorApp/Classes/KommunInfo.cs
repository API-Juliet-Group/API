using BaseLibrary.DTO;

namespace JulietBlazorApp.Classes
{
    public class KommunInfo
    {
        public string KommunNamn { get; set; }

        public int BostadCount { get; set; }

        public string VisningsNamn => $"{KommunNamn} ({BostadCount})";
    }
}
