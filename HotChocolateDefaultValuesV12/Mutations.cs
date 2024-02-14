using HotChocolateDefaultValues;

namespace HotChocolateDefaultValues;

public class Mutations
{
    public MyInputObjectOut DoSomething(MyInputObject input) => 
        new MyInputObjectOut() { Result = input.ValuesToRetrieveInBatch.Value };
}
