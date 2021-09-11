using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class VictoryState : MonoBehaviour, ICharacterState
{
    private CharacterController _characterController;

    public void Handle(CharacterController controller)
    {
        if (!_characterController)
        {
            _characterController = controller;
        }

        _characterController.isRunning = false;
        _characterController.GetComponent<Animator>().SetBool("run", false);
        _characterController.GetComponent<Animator>().SetBool("victory", true);
        FindObjectOfType<GameManager>().obstaclesActive = false;

        Measure();
        StartCoroutine(Compare());
    }

    private void Measure()
    {
        _characterController.transform.DOMove(new Vector3(-4.95f, -0.107f, 136.68f), 3f);
        _characterController.transform.DORotate(new Vector3(0f, 90f, 0f), 3f);
        FindObjectOfType<Cinemachine.CinemachineTransposer>().m_FollowOffset = new Vector3(2.56f, 5.1f, 18.12f);
        FindObjectOfType<Cinemachine.CinemachineComposer>().m_ScreenX = 0.8f;
        FindObjectOfType<Cinemachine.CinemachineComposer>().m_ScreenY = 0.652f;
    }
    IEnumerator Compare()
    {
        yield return new WaitForSeconds(1);
        if(_characterController.transform.localScale.x >= 2.8f)
        {
            Win();
        }
        else
        {
            Lose();
        }
        yield return new WaitForSeconds(4);
        SceneManager.LoadScene(0);
    }

    private void Win()
    {
        _characterController.winText.SetActive(true);
    }
    private void Lose()
    {
        _characterController.loseText.SetActive(true);
    }
}
