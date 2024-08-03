
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] int maxHealth = 100;
    [SerializeField] float speed = 2f;

    private int currentHealth;

    Animator anim;
    Transform target; // Follow target

    int facingDirection = 1;

    private void Start()
    {
        currentHealth = maxHealth;
        target = GameObject.Find("Player").transform;
        anim = GetComponent<Animator>();
    }
    private void Update()
    {
        if (target  != null)
        {
            Vector3 direction = target.position - transform.position;
            direction.Normalize();

            transform.position += direction * speed * Time.deltaTime;

            var playerToTheRight = target.position.x > transform.position.x;
            transform.localScale = new Vector2(playerToTheRight ? 1 : -1, 1);
        }

    }
    public void Hit(int damage)
    {
        currentHealth -= damage;
        anim.SetTrigger("hit");

        if (currentHealth <= 0)
            Destroy(gameObject);
    }
    private void FlipSprite()
    {
        // Flip thehe sprite horizontally based on the facingDirection
        Vector3 newScale = transform.localScale;
        newScale.x = facingDirection;
        transform.localScale = newScale;
    }
}
