using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public GameObject player;
    private Vector3 offset;
    // Start is called before the first frame update
    float LowY;
    public float smoothing;
    void Start()
    {
       offset= transform.position - player.transform.position;
       // when fall camraea wont follow
       LowY=transform.position.y;

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //transform.position= player.transform.position;
        Vector3 targetComPos= player.transform.position+offset;
        transform.position= Vector3.Lerp(transform.position,targetComPos,smoothing*Time.deltaTime);
        
        if(transform.position.y<LowY){
            transform.position=new Vector3(transform.position.x, LowY, transform.position.z);
        
        }

    }
}
