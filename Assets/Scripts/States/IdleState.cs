using UnityEngine;

public class IdleState : MonoBehaviour, ICharacterState
{
    private CharacterController _characterController;

    public void Handle(CharacterController controller)
    {
        if (!_characterController)
        {
            _characterController = controller;
        }

        _characterController.isRunning = false;
    }
}
