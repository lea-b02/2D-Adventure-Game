using UnityEngine;
using System.Collections;
using Unity.VisualScripting;
public class PlayerHealth : MonoBehaviour
{
    public float invincibilityTimeAfterHit=3f;
    public int maxHealth = 100;
    public int curentHealth;
    public bool isInvincible = false;
    public SpriteRenderer graphics;
    public float invincibilityFlashDelay = 0.2f;

    public HealtBar healtBar;

    public static PlayerHealth instance;

    public AudioClip healthSound;

    public void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Il a plus d'une instance de PlayerHealth dans la scene");
            return;
        }
        instance = this;
    }


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        curentHealth = maxHealth;
        healtBar.SetMaxHealth(maxHealth);
    }

    // Update is called once per frame
    // lu a chaque frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.H)) {
            TakeDomage(60);
        }

    }

    public void TakeDomage(int damage) {
        if (!isInvincible) {
            AudioManager.instanceAudioManager.PlayClipAt(healthSound, transform.position);
            curentHealth -= damage;
            healtBar.SetHealth(curentHealth);

            //verifie si le jouer et toujour vivent
            if (curentHealth <= 0) {
                DieMethod();
                return;
            }

            isInvincible = true;
            StartCoroutine(InvincibilityFlash());
            StartCoroutine(InvincibilityDelay());

        }

    }

    public void DieMethod() {
        Debug.Log("Le jouer est elimine");
        // on veux bloque les mouvement du personnage
        PlayerMove.instanceMove.enabled = false;
        // jouer l'animation de mort du personnage
        PlayerMove.instanceMove.animator.SetTrigger("Die");
        //empeche les interaction physique avec les autre element de la scene 
        PlayerMove.instanceMove.rb.bodyType= RigidbodyType2D.Kinematic;
        PlayerMove.instanceMove.rb.linearVelocity = Vector3.zero;
        PlayerMove.instanceMove.capsuleCollider.enabled=false;
        GameOverManager.instanceGameOverManager.OnPlayerHealth();
    }

    public void RespawnMethod()
    {
        Debug.Log("Le jouer est revenue");
        PlayerMove.instanceMove.enabled = true;
        PlayerMove.instanceMove.animator.SetTrigger("Respawn"); 
        PlayerMove.instanceMove.rb.bodyType = RigidbodyType2D.Dynamic;
        PlayerMove.instanceMove.capsuleCollider.enabled = true;
        curentHealth = maxHealth;
        healtBar.SetHealth(curentHealth);
    }

    public void HealtPlayer(int amount) {
        if ((curentHealth + amount) > maxHealth)
        {
            curentHealth = maxHealth;
        }
        else {

            curentHealth += amount;
        }
        
        healtBar.SetHealth(curentHealth);

    }

    public IEnumerator InvincibilityFlash()
    {

        while (isInvincible)
        {
            graphics.color = new Color(1f,1f,1f,0f);
            yield return new WaitForSeconds(invincibilityFlashDelay);
            graphics.color = new Color(1f, 1f, 1f, 1f);
            yield return new WaitForSeconds(invincibilityFlashDelay);
        }

    }

    public IEnumerator InvincibilityDelay() {
        yield return new WaitForSeconds(invincibilityTimeAfterHit);
        isInvincible= false;

    }
}
