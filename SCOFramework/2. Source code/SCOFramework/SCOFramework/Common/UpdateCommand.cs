namespace SCOFramework
{
    public interface UpdateCommand : ICanAddUpdate, ICanAddSet, ICanAddSetOrWhere, ICanAddExecuteNonQuery
    {
        ICanAddSet Update(string tableName);
        ICanAddSetOrWhere Set(string statement);
        ICanAddExecuteNonQuery Where(string condition);
        void Execute();
    }

    public interface ICanAddUpdate
    {
        ICanAddSet Update(string tableName);
    }

    public interface ICanAddSet
    {
        ICanAddSetOrWhere Set(string statement);
    }

    public interface ICanAddSetOrWhere
    {
        ICanAddSetOrWhere Set(string statement);
        ICanAddExecuteNonQuery Where(string condition);
    }

    public interface ICanAddExecuteNonQuery
    {
        void Execute();
    }
}
