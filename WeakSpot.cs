using UnityEngine;

public class WeakSpot : MonoBehaviour
{
    public GameObject objectToDestroy;
    public AudioClip weakSpotSound ;
        
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) {

            AudioManager.instanceAudioManager.PlayClipAt(weakSpotSound, transform.position);

            //Destroy(transform.parent.gameObject);
            Destroy(objectToDestroy);
        }
    }
}
