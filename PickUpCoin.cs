using UnityEngine;

public class PickUpCoin: MonoBehaviour
{
    //public AudioSource audioSource;
    public AudioClip sound;
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) {

            //elle ce fait a la fin l'audio - PlayOneShot
            //AudioSource.PlayClipAtPoint(sound,transform.position); (pas top cette option pck on ne peu pas accede au different paramettre de l'audio source)
            //pck on utiliser audio mixer sinon on aurait pkus ce contente de PlayClipAtPoint

            AudioManager.instanceAudioManager.PlayClipAt(sound, transform.position);

            Inventory.instance.AddCoins(1);
            CurrentSceneManager.instanceCurrentSceneManager.cointsPickInThisScene++;
            Destroy(gameObject);

        }





    }
}
