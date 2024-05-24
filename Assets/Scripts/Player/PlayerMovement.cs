using UnityEngine;


[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    private Rigidbody2D rb;
    private Vector2 movement;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }


    void Update()
    {
        movement.x = Input.GetAxis("Horizontal");
        movement.y = Input.GetAxis("Vertical");
    }


    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("GardenToShop"))
        {
            LevelManager.Instance.EnterShopFromGarden();
        }
        else if (other.gameObject.CompareTag("FarmToShop"))
        {
            LevelManager.Instance.EnterShopFromFarm();
        }
        else if (other.gameObject.CompareTag(nameof(LevelManager.Spaces.Garden)))
        {
            LevelManager.Instance.EnterGarden();
        }
        else if (other.gameObject.CompareTag(nameof(LevelManager.Spaces.Farm)))
        {
            LevelManager.Instance.EnterFarm();
        }

    }
}
