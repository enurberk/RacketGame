using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class HumanRacket : Racket
{
    //eksen ismi veridik ve rakete hız değeri atadık;
    public string axisName = "Vertical1";

    protected override void makeMove()
    {
        //s ve w tuşlarına basdığımızda bu kod ile aşağı ve yukarı 10 birim gidecek;
        float moveAxis = Input.GetAxis(axisName) * moveSpeed;
        //rigidbody'sini aldık;
        //bunu fixedupdate in içinde yaptığımız için sürekli klavyeyi dinliyecektir! 
        GetComponent<Rigidbody2D>().velocity = new Vector2(0, moveAxis);
    }
}
