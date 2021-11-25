using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        PlayerCharacter Me = new PlayerCharacter();
        Debug.Log(Me.HP(5));
        Debug.Log(Me.HP(5));
        Me.HP(5);
        Debug.Log(Me.HP());

        BlobberEngine.CharacterCondition cond = new BlobberEngine.CharacterCondition(1, 10, 5);
        int[] outp = cond.SaveCondition();
        Debug.Log(outp[0] + " + " + outp[1] + " + " + outp[2]);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
