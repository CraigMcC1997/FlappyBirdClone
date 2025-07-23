using UnityEngine;

public class PipesGroupController : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            transform.position = new Vector2(transform.position.x + 14.5f, transform.position.y);
        }
    }
}
