using Mono.Cecil;
using UnityEngine;

public class Enemy3D : MonoBehaviour
{
    public float speed = 2.5f; 
    // Update is called once per frame
    void Update()
    {
        var direction  = new Vector3(112, 55, 0) - transform.position;
        if (direction.magnitude > 100){
            transform.position += direction.normalized*Time.deltaTime*speed;
        }
    }

    public void Kill(){
        Destroy(gameObject);
    }
}
