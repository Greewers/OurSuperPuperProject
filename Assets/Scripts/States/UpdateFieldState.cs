public class UpdateFieldState : BaseState
{
    public GridManager GridManager { get; }
    public GlobalOptions GlobalOptions { get; }

    private Player _player;

    public UpdateFieldState(string name, StateMachine stateMachine, GridManager gridManager, GlobalOptions globalOptions, Player player) : base(name, stateMachine)
    {
        GridManager = gridManager;
        GlobalOptions = globalOptions;
        _player = player;
    }

    public override void Enter()
    {
        var items = GridManager.GetAllItem();
        foreach (var item in items)
        {
            item.UpdateTimer();
        }

        GlobalOptions.ScoreIncriment();

        if (!_player.IsDead)
            _stateMachine.ChangeState(typeof(SpawnState));
        else
            _stateMachine.ChangeState(typeof(EndState));
    }

    public override void Exit()
    {
    }
}
