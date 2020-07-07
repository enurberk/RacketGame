using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIRacket : Racket
{
    //Ball classından ball oluşturmak yerine, transform ile topun konumunu alıyoruz. 
    public Transform ball;
    protected override void makeMove()
    {
        //raket top ile olan dikey uzaklığını hesaplayıp ona göre hareket etmesini sağladık.
        //distance olmasaydı titreyen bir raketimiz olurdu;
        //distance>2 vs yaparak raketin zorluk seviyesini ayarlayabilirliz;
        //mesela şuan kaçırdığı toplar oluyor.
        //distance yokken hem titriyordu hemde hiç kaybetmiyordu!
        float distance = Mathf.Abs(ball.position.y - transform.position.y);
        if(distance > 2)
        {
            //topun konum ile raketin konumu karşılaştırıp raketin yukarı veya aşağı gitmesini 
            //sağladık;
            if (ball.position.y > transform.position.y)
            {
                GetComponent<Rigidbody2D>().velocity = new Vector2(0, 1) * moveSpeed;
            }
            //topun aşağı kısımda olması durumu v raketin -y yönünde hareket etmesi;
            else
            {
                GetComponent<Rigidbody2D>().velocity = new Vector2(0, -1) * moveSpeed;
            }
        }
    }
}
