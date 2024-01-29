namespace CopilotApi.Settings
{
    public interface IDoctorSettings
    {
        string DoctorsCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
        
    }
    public class DoctorSettings : IDoctorSettings
    {
        public string DoctorsCollectionName { get; set; } = string.Empty;
        public string ConnectionString { get; set; } = string.Empty;
        public string DatabaseName { get; set; } = string.Empty;
    }
}
