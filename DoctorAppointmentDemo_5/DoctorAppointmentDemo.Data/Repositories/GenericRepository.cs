using DoctorAppointmentDemo.Data.Interfaces;
using DoctorAppointmentDemo.Domain.Entities;

public abstract class GenericRepository<TSource> : IGenericRepository<TSource> where TSource : Auditable
{

    public abstract string Path { get; }

    protected readonly ISerializationService _serializer;

    protected GenericRepository(ISerializationService serializer)
    {
        _serializer = serializer;
    }

    public TSource Create(TSource source)
    {
        source.Id = GetNextId();
        source.CreatedAt = DateTime.Now;

        var items = GetAll().ToList();
        items.Add(source);
        SaveToFile(items);

        return source;
    }


    public TSource? GetById(int id)
    {
        return GetAll().FirstOrDefault(x => x.Id == id);
    }

    public TSource Update(int id, TSource source)
    {
        var items = GetAll().ToList();
        var index = items.FindIndex(x => x.Id == id);

        if (index >= 0)
        {
            source.Id = id;
            source.UpdatedAt = DateTime.Now;
            items[index] = source;
            SaveToFile(items);
        }

        return source;
    }

    public IEnumerable<TSource> GetAll()
    {
        if (!File.Exists(Path))
        {
            _serializer.Serialize(Path, new List<TSource>());
            return new List<TSource>();
        }

        var items = _serializer.Deserialize<List<TSource>>(Path);

        return items ?? new List<TSource>();
    }

    public bool Delete(int id)
    {
        var items = GetAll().ToList();
        var itemToRemove = items.FirstOrDefault(x => x.Id == id);

        if (itemToRemove != null)
        {
            items.Remove(itemToRemove);
            SaveToFile(items);
            return true;
        }

        return false;
    }


    protected void SaveToFile(List<TSource> items)
    {
        _serializer.Serialize(Path, items);
    }

    protected int GetNextId()
    {
        var items = GetAll() ?? new List<TSource>();
        return items.Any() ? items.Max(item => item.Id) + 1 : 1;
    }
}
