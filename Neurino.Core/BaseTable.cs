using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neurino.Core
{
    public abstract class BaseTable<T> : ITable where T : BaseRow
    {
        public abstract string TableName { get; }
        public abstract string GetTableName();
        public abstract string GetModuleName();

        protected List<T> rows = new List<T>();

        public void Add(T row)
        {
            rows.Add(row);
        }

        public IEnumerable<T> GetAll()
        {
            return rows;
        }
    }


    public abstract class BaseRow
    {
        public int ID { get; set; }
    }

    public interface ITable
    {
        string TableName { get; }
        string GetTableName();
        string GetModuleName();

    }
}
