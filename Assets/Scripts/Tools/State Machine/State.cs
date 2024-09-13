namespace MrHatProduction.Tools.StateMachine
{
    public abstract class State<T>
    {
        public abstract void Enter(T owner);
        public abstract void Exit();
    }
}