using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gate : MonoBehaviour
{
    List<int> numbers = new List<int>();

    [SerializeField]
    private GameObject LeftText;

    [SerializeField]
    private GameObject RightText;

    [SerializeField]
    private GameObject LeftCube;

    [SerializeField]
    private GameObject RightCube;

    int firstNumber;
    int secondNumber;

    void Start()
    {
        numbers.Add(-1);
        numbers.Add(-2);
        numbers.Add(-3);
        numbers.Add(-4);

        numbers.Add(1);
        numbers.Add(2);
        numbers.Add(3);
        numbers.Add(4);

        firstNumber = numbers[Mathf.RoundToInt(Random.Range(0, 8))];
        secondNumber = numbers[Mathf.RoundToInt(Random.Range(0, 8))];

        if (firstNumber > 0)
        {            
            while (secondNumber > 0)
            {
                secondNumber = numbers[Mathf.RoundToInt(Random.Range(0, 8))];
            }
        }
        else if (firstNumber < 0)
        {
            while (secondNumber < 0)
            {
                secondNumber = numbers[Mathf.RoundToInt(Random.Range(0, 8))];
            }
        }

        string firstNumText = "";

        if(firstNumber > 0) {
            firstNumText = "+" + firstNumber.ToString();
        }
        else
        {
            firstNumText = firstNumber.ToString();
        }

        string secondNumText = "";

        if (secondNumber > 0)
        {
            secondNumText = "+" + secondNumber.ToString();
        }
        else
        {
            secondNumText = secondNumber.ToString();
        }

        LeftText.GetComponent<TMPro.TextMeshProUGUI>().text = firstNumText;
        RightText.GetComponent<TMPro.TextMeshProUGUI>().text = secondNumText;

    }

    public void Upgrade(side _side)
    {
        if (_side.Equals(side.left))
        {
            FindObjectOfType<CharacterController>().Upgrade(firstNumber);
        }
        else
        {
            FindObjectOfType<CharacterController>().Upgrade(secondNumber);
        }

        LeftCube.GetComponent<BoxCollider>().enabled = false;
        RightCube.GetComponent<BoxCollider>().enabled = false;
    }
}
