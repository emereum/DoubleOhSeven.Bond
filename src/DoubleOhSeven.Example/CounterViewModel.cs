using System;
using PropertyChanged;

namespace DoubleOhSeven.Example
{
    [ImplementPropertyChanged]
    class CounterViewModel
    {
        public int Counter { get; private set; }

        public bool CanIncrementCounter => Counter < 10;

        public void IncrementCounter()
        {
            if (!CanIncrementCounter)
            {
                throw new InvalidOperationException();
            }

            Counter++;
        }
    }
}
