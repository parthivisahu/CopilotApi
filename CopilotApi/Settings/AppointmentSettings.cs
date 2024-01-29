namespace CopilotApi.Settings
{
    public interface IAppointmentSettings
    {
        string AppointmentsCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
    public class AppointmentSettings : IAppointmentSettings
    {
        public string AppointmentsCollectionName { get; set; } = string.Empty;
        public string ConnectionString { get; set; } = string.Empty;
        public string DatabaseName { get; set; } = string.Empty;
    }
}
