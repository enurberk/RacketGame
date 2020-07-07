using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public abstract class Racket : MonoBehaviour
{
    public float moveSpeed = 10;
    //skorun yazılacağı yerdeki obje;
    public Text scoreText;
    //Score değişkeni oluşturduk(özellik) score'u tutabilmemiz için;
    public int Score { get; private set; }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        makeMove();
    }

    protected abstract void makeMove();
    //{
    //    //s ve w tuşlarına basdığımızda bu kod ile aşağı ve yukarı 10 birim gidecek;
    //    float moveAxis = Input.GetAxis(axisName) * moveSpeed;
    //    //rigidbody'sini aldık;
    //    //bunu fixedupdate in içinde yaptığımız için sürekli klavyeyi dinliyecektir! 
    //    GetComponent<Rigidbody2D>().velocity = new Vector2(0, moveAxis);
    //}

    //Ball scriptinden çağırabileceğimiz ve skoru artırabilmemizi sağlayan fonksiyon;
    public void makeScore()
    {
        Score++;
        //scoru yazdırmak için, skoru int, text string bu yüzden toStringe çevirdik;
        scoreText.text = Score.ToString();
    }
}
