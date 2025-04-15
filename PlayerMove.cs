using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class PlayerMove : MonoBehaviour
{
    //faire une reference pour les animation
    public Animator animator;

    //visuel du personnage 
    public SpriteRenderer spriteRenderer;

    //V�rifie si le personnage doit sauter.
    private bool isJumping = false;
    //Indique si le personnage est sur le sol.
    private bool isGrounded = false;

    [HideInInspector]//disparaitre la case isClimbing de l'ispector pck il n'est pas sence etre en 2d
    public bool isClimbing = false;

    //Ce sont des points de v�rification pour d�tecter si le personnage touche le sol
    //public Transform groundCheckLeft;
    //public Transform groundCheckRight;
    public Transform groundCheck;

    public float groundCheckRadius;
    public LayerMask collisionLayer;

    //Contr�le la vitesse de d�placement horizontal.
    public float moveSpeed;
    //D�finit la force appliqu�e lors du saut.
    public float jumpForce;

    public float climbSpeed;

    //R�f�rence au Rigidbody2D du personnage (g�re la physique).
    public Rigidbody2D rb;
    //Aide � lisser le mouvement.
    private Vector3 velocity = Vector3.zero;

    private float horizontalMovement;
    private float verticalMovement;

    public CapsuleCollider2D capsuleCollider;

    public static PlayerMove instanceMove;

    public void Awake()
    {
        if (instanceMove != null)
        {
            Debug.LogWarning("Il a plus d'une instance de PlayerMovement dans la scene");
            return;
        }
        instanceMove = this;
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    //void Start()
    //{

    //}

    public void Update()
    {
        
        //Mouvement horizontal
        //        Input.GetAxis("Horizontal") r�cup�re la direction(-1 pour gauche, 1 pour droite).
        //Multipli� par moveSpeed pour ajuster la vitesse.
        //Time.deltaTime assure que le d�placement est fluide quel que soit le frame rate
        horizontalMovement = Input.GetAxis("Horizontal") * moveSpeed * Time.fixedDeltaTime;
        verticalMovement = Input.GetAxis("Vertical") * climbSpeed * Time.fixedDeltaTime;


        if (Input.GetButton("Jump") && isGrounded==true)
        {
            isJumping = true;
        }
        

        Flip(rb.linearVelocity.x);
        //toujour revoit une valer possitif (1)
        float characterVelocity = Mathf.Abs(rb.linearVelocity.x);
        animator.SetFloat("Speed", characterVelocity);
        animator.SetBool("isClimbing", isClimbing);

    }

    //C'est ici que on fait appelle  a move player quil lui fait le mouvement et le saut sont g�r�s.
    void FixedUpdate()
    {
        //detection du sol
        //Si c'est vrai, isGrounded = true ; sinon, false
        //isGrounded = Physics2D.OverlapArea(groundCheckLeft.position, groundCheckRight.position);
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, collisionLayer);
        //la on connait la vites du personnage den la fonction move player
        MovePlayer(horizontalMovement,verticalMovement);

    }

    
    void MovePlayer(float _horizontalMovement,float _verticalMovement) {
        if (!isClimbing)
        {
            //depllace a l'orizontal
            //Cr�e un vecteur de mouvement horizontal tout en gardant la vitesse verticale actuelle (rb.velocity.y).
            Vector3 targetVelocity = new Vector2(_horizontalMovement, rb.linearVelocity.y);
            //Vector3.SmoothDamp applique un effet de ralentissement progressif pour rendre les mouvements plus fluides.
            rb.linearVelocity = Vector3.SmoothDamp(rb.linearVelocity, targetVelocity, ref velocity, .05f);

            if (isJumping == true)
            {
                //Si isJumping est true, applique une force verticale (jumpForce).
                //jumpForce que on recoit de unity
                rb.AddForce(new Vector2(0f, jumpForce));
                isJumping = false;
            }
        }
        else {
            // deplace a la vertical
            //Vector3 targetVelocity = new Vector2(rb.linearVelocity.x, _verticalMovement);

            Vector3 targetVelocity = new Vector2(0, _verticalMovement);
           
            rb.linearVelocity = Vector3.SmoothDamp(rb.linearVelocity, targetVelocity, ref velocity, .05f);

        }
    }

    // a cette fonction on va envoye la vites du personnage et pas Mathf.Abs(rb.velocity.x);
    void Flip(float _velocity) {
        if (_velocity > 0.1f)
        {
            spriteRenderer.flipX = false;
        }
        else if (_velocity < -0.1f) {
            spriteRenderer.flipX = true;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
    }
}
