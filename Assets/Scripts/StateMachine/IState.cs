namespace StateMachine
{
    public interface IState
    {
        void Enter();
        void Exit();
    }
}