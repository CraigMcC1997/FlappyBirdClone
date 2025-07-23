using UnityEngine;

public class PipesController : MonoBehaviour
{
    public GameManager gameManager;
    float speed = -5.0f;

    void movePipes()
    {
        float translation = speed * Time.deltaTime;
        transform.Translate(translation, 0, 0);

        if (transform.position.x <= -10.0f)
        {
            float randomY = Random.Range(2.5f, 6.8f);
            transform.position = new Vector2(10.0f, randomY);
        }
    }


    // Update is called once per frame
    void Update()
    {
        if (!gameManager.IsGameOver())
            movePipes();
    }
}
