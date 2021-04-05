using System.ComponentModel;
using System.Runtime.CompilerServices;

public class IntPropertyChanged: PropertyChangedEventArgs
{
    public int OldValue { get; }
    public int NewValue { get; }

    public IntPropertyChanged(string propertyName, int oldValue, int newValue): base(propertyName)
    {
        OldValue = oldValue;
        NewValue = newValue;
    }
}

public class FloatPropertyChanged: PropertyChangedEventArgs
{
    public float OldValue { get; }
    public float NewValue { get; }

    public FloatPropertyChanged(string propertyName, float oldValue, float newValue): base(propertyName)
    {
        OldValue = oldValue;
        NewValue = newValue;
    }
}

public abstract class NotifyObject: INotifyPropertyChanged
{
    public event PropertyChangedEventHandler PropertyChanged;

    protected void NotifyPropertyChanged(int oldVal, int newVal, [CallerMemberName] string propertyName = "")
    {
        var e = PropertyChanged;
        if (e != null)
        {
            e(this, new IntPropertyChanged(propertyName, oldVal, (int) newVal));
        }
    }

    protected void NotifyPropertyChanged(float oldVal, float newVal, [CallerMemberName] string propertyName = "")
    {
        var e = PropertyChanged;
        if (e != null)
        {
            e(this, new FloatPropertyChanged(propertyName, oldVal, (int) newVal));
        }
    }
}