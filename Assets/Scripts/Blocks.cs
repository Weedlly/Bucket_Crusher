using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blocks : MonoBehaviour
{
    public float protect;
    public GameObject effect;
    internal AudioSource hitAudio;

    void Awake(){
        hitAudio = GetComponent<AudioSource>();
    }
    private void OnCollisionEnter2D(Collision2D collision){
        if(collision.gameObject.name == "Crusher"){
            hitAudio.Play();
        }
        if(collision.relativeVelocity.magnitude > protect && collision.gameObject.name == "Crusher"){
            
            Destroy(gameObject, hitAudio.clip.length);
            Instantiate(effect,transform.position, Quaternion.identity);
        }
        
        if(collision.relativeVelocity.magnitude > protect){
            
            Destroy(gameObject, hitAudio.clip.length);
        }
        else if(collision.relativeVelocity.magnitude < protect){
            protect -= collision.relativeVelocity.magnitude;
        }
    }
    
}

