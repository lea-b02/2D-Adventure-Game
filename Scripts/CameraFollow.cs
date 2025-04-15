using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    //pour le player
    public GameObject player;
    public float timeOffset;
    public Vector3 posOffset;
    private Vector3 velocity;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    //void Start()
    //{
        
    //}

    // Update is called once per frame
    void Update()
    {
        //transform qui corespont a l'object camera 
        transform.position = Vector3.SmoothDamp(transform.position,player.transform.position+posOffset,ref velocity,timeOffset);
    }
}
