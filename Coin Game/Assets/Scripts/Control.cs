using UnityEngine;
using UnityEngine.SceneManagement;

public class Control : MonoBehaviour
{

    public float speed = 10f;

    Rigidbody rb;

    float xInput;
    float yInput;

    int score = 0;

    public int winScore = 5;

    public GameObject winText;



    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }



    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < -10f) // if the player falls off the platform
        {
            SceneManager.LoadScene("Game");
        }

    }

    void FixedUpdate()
    {
        xInput = Input.GetAxis("Horizontal");

        yInput = Input.GetAxis("Vertical");

        rb.AddForce(xInput * speed, 0, yInput * speed);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Coin")
        {
            other.gameObject.SetActive(false);

            score++;

            if (score >= winScore)
            {
                winText.SetActive(true);
            }
        }
    }
}
