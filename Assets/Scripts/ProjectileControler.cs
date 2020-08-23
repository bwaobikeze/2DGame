using UnityEngine;

public class ProjectileControler : MonoBehaviour
{
    Rigidbody2D myRB;
    public float rocketSpeed;
    void Awake()
    {
         myRB = GetComponent<Rigidbody2D>();
        if(transform.localRotation.z>0){
            myRB.AddForce(new Vector2(-1,0)*rocketSpeed,ForceMode2D.Impulse);
        }else
             myRB.AddForce(new Vector2(1,0)*rocketSpeed,ForceMode2D.Impulse);

   
       
    }

    void Update()
    {

    }

}