using Unity.VisualScripting;
using UnityEngine;

public class HealPowerUp : MonoBehaviour
{
    public AudioClip healPowerupSound;
    public int healthPoints;
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (PlayerHealth.instance.curentHealth != PlayerHealth.instance.maxHealth)
            {
                //rendre de la vie aux joueur 
                AudioManager.instanceAudioManager.PlayClipAt(healPowerupSound, transform.position);
                PlayerHealth.instance.HealtPlayer(healthPoints);
                Destroy(gameObject);
            }
        }

    }
}
