using UnityEngine;

public class CheckPoint : MonoBehaviour
{


  

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") )
        {
            CurrentSceneManager.instanceCurrentSceneManager.respawnPoint = collision.transform.position;
            //il va supprime l'instence du premier check point 
            //on a plus le moin d'utiliset l'ancient check point
            //Destroy(gameObject);
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
        }
    }
}
