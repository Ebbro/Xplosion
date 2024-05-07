using UnityEngine; 
using System.Collections; 
using System.Collections.Generic;
public class Bomb : MonoBehaviour { 
   public float radius = 5.0F; 
   public float power = 100.0F; 
   public float lift = 10; 
   public float speed = 500; 
   public bool explode = false;
   public int life = 3; 
   void FixedUpdate() { 
      if(explode){ 
         Vector3 explosionPos = transform.position; 
         Collider[] colliders = Physics.OverlapSphere(explosionPos, radius); 
         foreach (Collider hit in colliders) { 
            if (hit.GetComponent<Rigidbody>()) { 
               hit.GetComponent<Rigidbody>().AddExplosionForce(power, explosionPos, radius, lift); 
            } 
         }
         Destroy(this.gameObject,0.3f); 
       } 
   } 
   void OnCollisionEnter(Collision collision) {    
      if(collision.gameObject.tag == "Cube"){ 
         life = life-1;
         if (life==0){
         explode = true;
         }
      }
   }

}
