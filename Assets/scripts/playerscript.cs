using UnityEngine;
using UnityEngine.SceneManagement;

public class playerscript : MonoBehaviour
{
    Rigidbody2D rb;
    public float movespeed = 5f;
    public float rotateamount = 2f;
    float rot;
    int score;
    public GameObject winText;

    float minX = -2.4f;
    float maxX =  2.4f;
    float minY = -4.55f;
    float maxY =  4.55f;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Vector3 mousepos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            if (mousepos.x < 0)
                rot = rotateamount;
            else
                rot = -rotateamount;
        }
        else
        {
            rot = 0;
        }
    }

    private void FixedUpdate()
    {
        // Apply physics rotation
        rb.MoveRotation(rb.rotation + rot);

        // Move straight forward
        rb.linearVelocity = transform.up * movespeed;
    }

    void LateUpdate()
    {
        Vector3 pos = transform.position;
        pos.x = Mathf.Clamp(pos.x, minX, maxX);
        pos.y = Mathf.Clamp(pos.y, minY, maxY);
        transform.position = pos;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("food"))
        {
            Destroy(collision.gameObject);
            score++;

            if (score >= 5)
            {
                winText.SetActive(true);
            }
        }
        else if (collision.gameObject.CompareTag("danger"))
        {
            SceneManager.LoadScene("Game");
        }
    }
}


