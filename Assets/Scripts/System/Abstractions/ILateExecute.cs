namespace Core.Controller.Abstractions
{
    public interface ILateExecute : IController
    {
        void LateExecute();
    }
}