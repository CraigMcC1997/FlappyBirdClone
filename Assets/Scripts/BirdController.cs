using UnityEngine;

public class BirdController : MonoBehaviour
{
    Rigidbody2D rb;
    public ScoreManager scoreManager;
    public GameManager gameManager;
    AudioSource flap, point, hit, die;

    float jumpForce = 10.0f; // Adjust the jump force as needed

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        AudioSource[] audios = GetComponents<AudioSource>();
        flap = audios[0];
        point = audios[1];
        hit = audios[2];
        die = audios[3];
    }

    void Jump()
    {
        if (!gameManager.IsGameOver())
        {
            flap.Play(0);
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
        }
    }

    void ResetBirdPosition()
    {
        transform.position = new Vector2(-4.94f, 1.78f); // Reset position to the left of the screen
        rb.linearVelocity = Vector2.zero; // Reset velocity
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            Jump();

        // TODO: should be maintained in GameManager, needs a refactor
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (gameManager.IsGameOver())
            {
                ResetBirdPosition();
                gameManager.RestartGame();
                scoreManager.ResetCurrentScore();
            }
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Collision"))
        {
            hit.Play(0);
            gameManager.EndGame();
            scoreManager.SaveHighScore();

            if (!collision.gameObject.name.Contains("Ground"))
                die.Play(0);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (!gameManager.IsGameOver())
        {
            point.Play(0);
            if (other.gameObject.name.Contains("Trigger"))
                scoreManager.UpdateCurrentScore();
        }
    }
}
