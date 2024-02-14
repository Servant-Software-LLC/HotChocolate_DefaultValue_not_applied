using HotChocolate;
using HotChocolate.Types;

namespace HotChocolateDefaultValues;

public class MyInputObject
{
    [DefaultValue(500)]
    public Optional<int> ValuesToRetrieveInBatch { get; set; }

}
