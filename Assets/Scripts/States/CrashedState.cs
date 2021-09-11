using UnityEngine;

public class CrashedState : MonoBehaviour, ICharacterState
{
    private CharacterController _characterController;

    public void Handle(CharacterController controller)
    {
        if (!_characterController)
        {
            _characterController = controller;
        }

        // Do stuff
        _characterController.GetComponent<Animator>().SetBool("lose", true);
    }
}
