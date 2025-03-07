
namespace Prosoft.Core
{
    public abstract class BaseTable<T> where T : BaseRow
    {
        
        public abstract string TableName {get; }
        public abstract string ModuleName { get; }

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
}