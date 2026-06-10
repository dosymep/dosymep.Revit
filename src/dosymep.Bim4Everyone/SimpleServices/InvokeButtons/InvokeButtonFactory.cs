using Ninject;
using Ninject.Parameters;
using Ninject.Syntax;

namespace dosymep.Bim4Everyone.SimpleServices.InvokeButtons;

internal class InvokeButtonFactory : IInvokeButtonFactory {
    private readonly IResolutionRoot _resolutionRoot;

    public InvokeButtonFactory(IResolutionRoot resolutionRoot) {
        _resolutionRoot = resolutionRoot;
    }

    public IInvokeButton Create(ButtonCommand buttonCommand) {
        if(buttonCommand is InvokeButtonCommand invokeButtonCommand) {
            ConstructorArgument constructorArgument = new(nameof(invokeButtonCommand), invokeButtonCommand);
            return _resolutionRoot.Get<InvokeButton>(constructorArgument);
        }

        throw new NotSupportedException();
    }
}