namespace dosymep.Bim4Everyone.SimpleServices.InvokeButtons
{
    internal interface IInvokeButtonFactory {
        IInvokeButton Create(ButtonCommand buttonCommand);
    }
}