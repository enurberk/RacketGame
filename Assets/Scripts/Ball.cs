using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Ball : MonoBehaviour
{
    //raketleri tanımladık;
    public Racket leftRacket, rightRacket;
    
    //topun rigidbody'sini aldık;
    Rigidbody2D rb2;
    
    //hız değeri tanımladık;
    public float moveSpeed = 10;

    // Start is called before the first frame update
    void Start()
    {
        //topun rigidbody'sini kod ile çektik;
        rb2 = GetComponent<Rigidbody2D>();
        //topa velocity(yönlü hız vektörü) atadık;
        //ve hızını ayarlamak için oluşturduğumuz moveSpeed ile çarptık;
        rb2.velocity = new Vector2(1, 0) * moveSpeed;
    }

    // Update is called once per frame

    //collision adlı nesne diğer nesne, topun çarptığı duvarlar yani;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //TagManager adlı scriptten nesne oluşturduk ve içinde tagları çekicez;
        TagManager tagManager = collision.gameObject.GetComponent<TagManager>();

        //ses için;
        GetComponent<AudioSource>().Play();

        //tag yoksa null döndürür;
        if (tagManager == null) return;
        
        //TagManager den oluşturduğumuz enum=Tag ondan nesne oluşturduk tag isimli,
        //ve tagManager adlı nesnemiz için myTagleri çektik; 
        Tag tag = tagManager.myTag;
        
        //sol duvara çarparsa top sağ raket kazanacak;
        if (tag.Equals(Tag.Left_Wall))
        {
            //right side will win
            rightRacket.makeScore();
        }
        
        //sağ duvara çarparsa top sol raket kazanacak;
        if (tag.Equals(Tag.Right_Wall))
        {
            //left side will win
            leftRacket.makeScore();
        }

        //topun raketlere çarptığı yere göre farklı açılarda gitmesi için;
        if (tag.Equals(Tag.Left_Racket))
        {
            SpinPositionCalculate(collision, 1);
        }
        //topun raketlere çarptığı yere göre farklı açılarda gitmesi için;
        else if (tag.Equals(Tag.Right_Racket))
        {
            SpinPositionCalculate(collision, -1);
        }
    }

    private void SpinPositionCalculate(Collision2D collision, int x)
    {
        //rakete topun çarptığı yerden itibaren üst kısmının boyutu;
        float a = transform.position.y - collision.gameObject.transform.position.y;
        //raketin boyutu;
        float b = collision.collider.bounds.size.y;
        //yeni oluşacak vektörün 0 ile 1 arasında olması için bunu yaptık;
        float y = a / b;
        //sağ raket olduğu için top sol tarafa yani x=-1 yönüne gidecek;
        //float x = -1;

        //rigidboyd ile topun farklı açıda gitmesini sağladık;
        rb2.velocity = new Vector2(x, y) * moveSpeed;
    }
}
