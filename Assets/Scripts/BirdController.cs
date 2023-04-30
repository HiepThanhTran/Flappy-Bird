using UnityEngine;
using UnityEngine.UI;

public class BirdController : MonoBehaviour
{
    public float flyPower;
    public AudioClip dieClip;
    public AudioClip hitClip;
    public AudioClip gameOverClip;
    public Text txtPoint;

    GameObject obj;
    GameObject gameController;
    AudioSource audioSource;
    AudioSource audioSourceTxtPoint;
    Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        obj = gameObject;
        audioSource = obj.GetComponent<AudioSource>();
        audioSourceTxtPoint = txtPoint.GetComponent<AudioSource>();
        anim = obj.GetComponent<Animator>();
        anim.SetFloat("flyPower", 0);
        anim.SetBool("isDeath", false);


        if (gameController == null)
        {
            gameController = GameObject.FindGameObjectWithTag("GameController");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space))
        {
            if (!gameController.GetComponent<GameController>().isEndGame)
            {
                audioSource.Play();
            }
            obj.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, flyPower));
        }
        anim.SetFloat("flyPower", obj.GetComponent<Rigidbody2D>().velocity.y);
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (!other.gameObject.CompareTag("Sky"))
        {
            audioSource.PlayOneShot(hitClip);
            audioSource.PlayOneShot(dieClip);
            audioSource.clip = gameOverClip;
            audioSource.Play();
            anim.SetBool("isDeath", true);
            gameController.GetComponent<GameController>().EndGame();
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        audioSourceTxtPoint.Play();
        gameController.GetComponent<GameController>().GetPoint();
    }
}
