using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
public class LoseState : MonoBehaviour, ICharacterState
{
    private CharacterController _characterController;

    public void Handle(CharacterController controller)
    {
        if (!_characterController)
        {
            _characterController = controller;
        }

        // Do 
        _characterController.isRunning = false;
        _characterController.GetComponent<Animator>().SetBool("run", false);
        _characterController.GetComponent<Animator>().SetBool("lose", true);
        FindObjectOfType<GameManager>().obstaclesActive = false;


        StartCoroutine(RestartGame());
    }
    IEnumerator RestartGame()
    {
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(0);
    }
    
}
