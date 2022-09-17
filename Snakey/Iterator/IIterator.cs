namespace Snakey.Iterator;

public interface IIterator
{
    object GetNext();
    bool HasMore();
}
