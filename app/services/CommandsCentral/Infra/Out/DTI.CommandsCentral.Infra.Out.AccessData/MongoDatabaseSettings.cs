namespace DTI.CommandsCentral.Infra.Out.AccessData
{
    public class MongoDatabaseSettings
    {
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
        public string EventStoredCollection { get; set; }
    }
}
