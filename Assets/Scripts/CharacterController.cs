using DG.Tweening;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    private ICharacterState _idleState, _runState, _victoryState, _loseState;

    private CharacterStateContext _characterStateContext;

    public bool isRunning;
    public float speed;

    public float rightLimit;
    public float leftLimit;

    public GameObject upArrow;
    public GameObject downArrow;

    public GameObject upSound;
    public GameObject downSound;

    public GameObject loseText;
    public GameObject winText;


    float smoothFactor = 0.004f;
    float scale = 1f;
    int scaleNumeric = 0;

    private void Start()
    {
        _characterStateContext = new CharacterStateContext(this);

        _idleState = gameObject.AddComponent<IdleState>();
        _runState = gameObject.AddComponent<RunState>();
        _victoryState = gameObject.AddComponent<VictoryState>();
        _loseState = gameObject.AddComponent<LoseState>();

        Idle();
    }

    public void Idle()
    {
        _characterStateContext.Transition(_idleState);
    }
    public void Run()
    {
        _characterStateContext.Transition(_runState);
    }

    public void Victory()
    {
        _characterStateContext.Transition(_victoryState);
    }

    public void Lose()
    {
        _characterStateContext.Transition(_loseState);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collision");
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            Lose();
        }
        else if (collision.gameObject.CompareTag("Finish"))
        {
            Victory();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Coin"))
        {
            GetComponent<Animator>().SetBool("pickUp", true);
            other.GetComponent<Coin>().PickedUp();
        }
    }

    public void moveSide(float force)
    {
        if((force > 0 && transform.position.x < 4.5f) || (force < 0 && transform.position.x > -4.5f))
            transform.Translate(force * smoothFactor, 0, 0);
    }

    public void Upgrade(float size)
    {
        scaleNumeric += Mathf.RoundToInt(size);

        GameObject.FindGameObjectWithTag("Size").GetComponent<TMPro.TextMeshProUGUI>().text = scaleNumeric.ToString();

        float _size = size / 10f;
        
        if(scale >= 0.4f)
            scale += _size;

        if(size > 0)
        {
            upSound.GetComponent<AudioSource>().Play();
            upArrow.SetActive(true);
            upArrow.transform
                .DOLocalJump(new Vector3(0f, 1.5f, 0f), 1f, 1, 1f)
                .OnComplete(() => upArrow.SetActive(false));
        }
        else
        {
            downSound.GetComponent<AudioSource>().Play();
            downArrow.SetActive(true);
            downArrow.transform
                .DOLocalJump(new Vector3(0f, 1f, 0f), 1f, 1, 1f)
                .OnComplete(() => downArrow.SetActive(false));
        }


        GetComponent<Animator>().SetFloat("animSpeed", 1.0f / scale);
        transform.localScale = new Vector3(scale, scale, scale);
    }
}
