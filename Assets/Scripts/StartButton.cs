using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartButton : MonoBehaviour
{
    public void OnClick()
    {
        FindObjectOfType<GameManager>().obstaclesActive = true;
        FindObjectOfType<CharacterController>().Run();
        gameObject.SetActive(false);
    }
}
