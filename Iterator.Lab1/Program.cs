using static System.Linq.Enumerable;

var spots = Range(0, 10).Select(i => new TouristSpot()).ToArray();
var collection = new TouristSpotCollectionAggregate<TouristSpot>(spots);

var touristsDiscretionIterator = (TouristsDiscretionIterator<TouristSpot>)collection.GetTouristsDiscretionIterator();
var navigatorRecommendationIterator = (NavigatorRecommendationIterator<TouristSpot>)collection.GetNavigatorRecommendationIterator();
var localGuideIterator = (LocalGuideIterator<TouristSpot>)collection.GetLocalGuideIterator();

// just example
touristsDiscretionIterator.First();
while (!touristsDiscretionIterator.IsDone())
{
    touristsDiscretionIterator.Next();
}

public class TouristSpot
{
    // Tourist spot implementation
}

public interface IAggregate<T>
{
    IIterator<T> GetTouristsDiscretionIterator();

    long Count();

    T GetItem(long index);
}

public interface IIterator<T>
{
    void First();

    void Next();

    T CurrentItem();

    bool IsDone();
}

public class TouristSpotCollectionAggregate<T> : IAggregate<T>
{
    private T[] array;

    public TouristSpotCollectionAggregate(T[] _array)
    {
        array = _array;
    }

    public void Append(T item)
    {
        T[] array2 = array;
        array = new T[array2.Length + 1];
        array2.CopyTo(array, 0);
        array[array.Length - 1] = item;
    }

    public void Remove(long index)
    {
        T[] array2 = array;
        array = new T[array2.Length - 1];

        for (long i = 0; i < index; i++)
            array[i] = array2[i];

        for (long i = index + 1; i < array2.Length; i++)
            array[i - 1] = array2[i];
    }

    public IIterator<T> GetTouristsDiscretionIterator()
    {
        return new TouristsDiscretionIterator<T>(this);
    }

    public IIterator<T> GetNavigatorRecommendationIterator()
    {
        return new NavigatorRecommendationIterator<T>(this);
    }

    public IIterator<T> GetLocalGuideIterator()
    {
        return new LocalGuideIterator<T>(this);
    }

    public long Count()
    {
        return array.Length;
    }

    public T GetItem(long index)
    {
        if ((index >= 0) && (index < array.Length))
            return array[index];
        else
            throw new NotImplementedException("Error. Bad index");
    }
}

public class IteratorBase<T> : IIterator<T>
{
    private IAggregate<T> aggregate;
    private long current;

    public IteratorBase(IAggregate<T> collection)
    {
        aggregate = collection;
        current = 0;
    }

    virtual public void First()
    {
        current = 0;
    }

    virtual public void Next()
    {
        current++;
    }

    virtual public bool IsDone()
    {
        return current >= aggregate.Count();
    }

    virtual public T CurrentItem()
    {
        if (!IsDone())
            return aggregate.GetItem(current);
        else
        {
            throw new NotImplementedException("Error");
        }
    }
}
public class TouristsDiscretionIterator<T> : IteratorBase<T>
{
    public TouristsDiscretionIterator(IAggregate<T> collection) : base(collection) { }

    virtual public void Next()
    {
        base.Next();
        // Implementation for tourist's discretion
    }
}

public class NavigatorRecommendationIterator<T> : IteratorBase<T>
{
    public NavigatorRecommendationIterator(IAggregate<T> collection) : base(collection) { }

    virtual public void Next()
    {
        base.Next();
        // Implementation for navigator recommendations
    }
}

public class LocalGuideIterator<T> : IteratorBase<T>
{
    public LocalGuideIterator(IAggregate<T> collection) : base(collection) { }

    virtual public void Next()
    {
        base.Next();
        // Implementation for local guide
    }
}