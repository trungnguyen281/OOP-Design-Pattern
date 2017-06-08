using System.Collections.Generic;

namespace SCOFramework
{
    public interface SelectCommand : ICanAddSelect, ICanAddFrom, ICanAddWhere, ICanAddHavingOrRun, ICanAddGroupBy, ICanAddExecuteReader
    {
        ICanAddFrom Select(string selectedColumn);

        ICanAddWhere From(string tableName);

        ICanAddHavingOrRun Where(string condition);

        ICanAddHavingOrRun AllRows();

        ICanAddGroupBy Having(string condition);

        ICanAddExecuteReader GroupBy(string columnName);

        List<T> Execute<T>() where T : new();
    }

    public interface ICanAddSelect
    {
        ICanAddFrom Select(string selectedColumn);
    }

    public interface ICanAddFrom
    {
        ICanAddWhere From(string tableName);
    }

    public interface ICanAddWhere
    {
        ICanAddHavingOrRun Where(string condition);
        ICanAddHavingOrRun AllRows();
    }

    public interface ICanAddHavingOrRun
    {
        ICanAddGroupBy Having(string condition);
        List<T> Execute<T>() where T : new();
    }

    public interface ICanAddGroupBy
    {
        ICanAddExecuteReader GroupBy(string columnName);
    }

    public interface ICanAddExecuteReader
    {
        List<T> Execute<T>() where T : new();
    }
}