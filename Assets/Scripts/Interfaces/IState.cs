public interface IState
{
    public void OnEnter(StateController sc);
    public void UpdateState(StateController sc);
    public void OnHurt(StateController sc);
    public void OnExit(StateController sc);
}