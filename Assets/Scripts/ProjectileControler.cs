using UnityEngine;

public class ProjectileControler : MonoBehaviour
{
    Rigidbody2D myRB;
    public float rocketSpeed;
    void Awake()
    {
        myRB = GetComponent<Rigidbody2D>();
        myRB.AddForce(new Vector2(1, 0), ForceMode2D.Impulse);
    }

    void Update()
    {

    }

}