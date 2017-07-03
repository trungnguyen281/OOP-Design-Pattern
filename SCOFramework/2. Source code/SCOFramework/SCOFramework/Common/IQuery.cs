using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCOFramework
{
    public interface IQuery
    {
        List<T> ExecuteQuery<T>() where T : new();
        List<T> ExecuteQueryWithOutRelationship<T>() where T : new();
        int ExecuteNonQuery();
    }

    public interface ICanAddWhere<T> where T : new()
    {
        ICanAddHavingOrRun<T> Where(string condition);
        ICanAddHavingOrRun<T> AllRow();
    }

    public interface ICanAddHavingOrRun<T> where T : new()
    {
        ICanAddGroupBy<T> Having(string condition);
        List<T> Run();
    }

    public interface ICanAddGroupBy<T> where T : new()
    {
        ICanRun<T> GroupBy(string columnNames);
    }

    public interface ICanRun<T> where T : new()
    {
        List<T> Run();
    }
}
