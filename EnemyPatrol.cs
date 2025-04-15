using UnityEngine;
//patrol + ataque

public class EnemyPatrol : MonoBehaviour
{
    public int damageOnCollision=20;
    public float speed;
    public Transform[] waypoints;

    public SpriteRenderer graphics; 
    private Transform target;
    private int desPoint = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
     target = waypoints[0];   
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 dir = target.position - transform.position ;
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);

        //si l'ennemi et quasiment arrive a sa destination
        if (Vector3.Distance(transform.position , target.position)<0.3f) { 
            desPoint = (desPoint + 1) % waypoints.Length;
            target = waypoints[desPoint];
            graphics.flipX = !graphics.flipX;
        }
    }

    //si on m'est pas 2d cela sera en 3d
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Player")) { 
            PlayerHealth playerHealth = collision.transform.GetComponent<PlayerHealth>();
            playerHealth.TakeDomage(damageOnCollision);
        }
    }
}
