using UnityEngine;

public class PickUpState : MonoBehaviour, ICharacterState
{
    private CharacterController _characterController;

    public void Handle(CharacterController controller)
    {
        if (!_characterController)
        {
            _characterController = controller;
        }

        _characterController.isRunning = false;
        _characterController.GetComponent<Animator>().SetBool("pickup", true);
    }
}
