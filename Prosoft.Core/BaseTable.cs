
namespace Prosoft.Core
{
    public abstract class BaseTable<T> where T : BaseRow
    {
        protected List<T> rows = new List<T>();

        public abstract string ModuleName { get; }

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