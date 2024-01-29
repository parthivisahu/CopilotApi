namespace CopilotApi.Settings
{
    public interface IPatientSettings
    {
        string PatientsCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }

    public class PatientSettings : IPatientSettings
    {
        public string PatientsCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
}
