public abstract class BaseTable<T> where T : BaseRow
{
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