namespace SCOFramework
{
    public abstract class SCOConnection
    {
        public string ConnectionString { get; set; }

        public abstract void Close();

        public abstract void Open();

        public abstract SCOCommand CreateTextCommand(string query);

        public abstract ICanAddSelect CreateSelectCommand();

        public abstract ICanAddUpdate CreateUpdateCommand();
    }
}