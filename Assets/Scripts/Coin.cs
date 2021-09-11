using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Coin : MonoBehaviour
{
    public float animDuration;
    public Ease animEase;

    public GameObject coin;
    public GameObject particle;

    void Start()
    {
        coin.transform.DORotate(new Vector3(0, 360, 0), animDuration * 2, RotateMode.FastBeyond360).SetLoops(-1, LoopType.Incremental);
        coin.transform.DOMoveY(1f, animDuration)
            .SetEase(animEase)
            .SetLoops(-1, LoopType.Yoyo);
    }

    public void PickedUp()
    {
        GetComponent<AudioSource>().Play();
        TMPro.TextMeshProUGUI _score = GameObject.FindGameObjectWithTag("Score").GetComponent<TMPro.TextMeshProUGUI>();
        int numeric = int.Parse(_score.text) + 1;

        _score.text = numeric.ToString();
        coin.SetActive(false);
        particle.SetActive(true);
    }


}
