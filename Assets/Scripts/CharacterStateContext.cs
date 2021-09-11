public class CharacterStateContext
{
    public ICharacterState CurrentState
    {
        get; set;
    }

    private readonly CharacterController _characterController;

    public CharacterStateContext(CharacterController characterController)
    {
        _characterController = characterController;
    }

    public void Transition()
    {
        CurrentState.Handle(_characterController);
    }

    public void Transition(ICharacterState state)
    {
        CurrentState = state;
        CurrentState.Handle(_characterController);
    }
}