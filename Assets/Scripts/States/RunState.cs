using UnityEngine;

public class RunState : MonoBehaviour, ICharacterState
{
    private CharacterController _characterController;
    private bool initialized = false;

    public void Handle(CharacterController controller)
    {
        if (!_characterController)
        {
            _characterController = controller;
        }

        initialized = true;
        _characterController.isRunning = true;
        _characterController.GetComponent<Animator>().SetBool("run", true);
        _characterController.GetComponent<Animator>().SetBool("pickUp", false);
    }

    private void FixedUpdate()
    {
        if (initialized && _characterController.isRunning)
        {
            _characterController.transform.Translate(new Vector3(0, 0, _characterController.speed));
        }
    }
}
