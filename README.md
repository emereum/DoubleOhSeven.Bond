# DoubleOhSeven.Bond

Bond WPF Views to ViewModel methods without using `ICommands`. Reduce ViewModels to simple POCOs without any boilerplate.

When to use this library
* When you have a ViewModel with zero-argument methods that you want to invoke from a WPF View without creating `ICommand` properties.

When not use this library
* When your ViewModel methods have arguments that are provided from the View.
* When you have strict performance or memory requirements (this library has not been profiled).

## Example

### Before

```xml
<TextBlock Text="{Binding Counter}" />
<Button Command="{Binding IncrementCounterCommand}" />
```

```csharp
public class CounterViewModel : BaseViewModel
{
    public ICommand IncrementCounterCommand =>
        new RelayCommand(x => CanIncrementCounter, x => IncrementCounter());
    
    public int Counter
    {
        get => counter;
        private set { counter = value; NotifyPropertyChanged(); }
    }
    
    private int counter;
    
    public bool CanIncrementCounter => Counter < 10;
    
    public void IncrementCounter()
    {
        if(!CanIncrementCounter)
        {
            throw new InvalidOperationException();
        }
        
        Counter++;
    }
}
```


### After

This example uses `DoubleOhSeven.Bond` in conjunction with `Fody.NotifyPropertyChanged` to reduce the ViewModel down to a simple POCO.

```xml
<TextBlock Text="{Binding Counter}" />
<Button
    Command="{dos:Bond IncrementCounter}"
    IsEnabled="{Binding CanIncrementCounter}"
/>
```

```csharp
[ImplementPropertyChanged]
public class ExampleViewModel
{
    public int Counter { get; private set; }
    
    public bool CanIncrementCounter => Counter < 10;
    
    public void IncrementCounter()
    {
        if(!CanIncrementCounter)
        {
            throw new InvalidOperationException();
        }
        
        Counter++;
    }
}
```