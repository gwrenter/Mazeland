using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrystalCollision : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision){
        if(collision.gameObject.tag == "Crystal"){
            Destroy(collision.gameObject);
        }
    }
}
