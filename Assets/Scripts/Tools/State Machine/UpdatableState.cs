namespace MrHatProduction.Tools.StateMachine
{
    public abstract class UpdatableState<T> : State<T>, IUpdatable
    {
        public abstract void Update();
    }
}