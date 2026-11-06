using UnityEngine;

public class TalkChecker : MonoBehaviour
{
    [Header("会話可能なヒロイン")]
    public Heroine talkableHeroine;



    void Start()
    {
      
    }


    public void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Heroine")) //タグがヒロインなら
        {
            Heroine target = other.gameObject.GetComponent<Heroine>();
            talkableHeroine = target;

            target.TalkMark.GetComponent<SpriteRenderer>().enabled = true;

        }


    }
    private void OnTriggerEnter(Collider other)
    {
    
    }

    public void OnTriggerExit(Collider other)
    {
        Heroine target = other.gameObject.GetComponent<Heroine>();
        target.TalkMark.GetComponent<SpriteRenderer>().enabled = false;

        if (talkableHeroine == target)
        {
            talkableHeroine = null;
        }

    }

}
