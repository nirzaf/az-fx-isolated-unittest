using Microsoft.Azure.Functions.Worker;

namespace Microsoft.Azure.Functions.Isolated.TestDoubles;
public class MockFunctionContext : FunctionContext, IDisposable
{
    private readonly FunctionInvocation _invocation;

    public MockFunctionContext()
        : this(new MockFunctionDefinition(), new MockFunctionInvocation())
    {
    }

    private MockFunctionContext(FunctionDefinition functionDefinition, FunctionInvocation invocation)
    {
        FunctionDefinition = functionDefinition;
        _invocation = invocation;
    }

    public bool IsDisposed { get; private set; }

    public override IServiceProvider? InstanceServices { get; set; } 

    public override FunctionDefinition FunctionDefinition { get; }

    public override IDictionary<object, object> Items { get; set; } = new Dictionary<object, object>();

    public override IInvocationFeatures? Features { get; } 

    public override string InvocationId => _invocation.Id;

    public override string FunctionId => _invocation.FunctionId;
    public override TraceContext TraceContext => _invocation.TraceContext;
    
    public override BindingContext? BindingContext { get; }
    
    public override RetryContext? RetryContext { get; }

    public void Dispose()
    {
        IsDisposed = true;
    }
}
