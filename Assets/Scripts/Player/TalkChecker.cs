using UnityEditor.Timeline.Actions;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.GraphicsBuffer;

public class TalkChecker : MonoBehaviour
{
    [Header("会話可能なヒロイン")]
    public Heroine talkableHeroine;


   [SerializeField] InputReader inputReader;




    private void Awake()
    {
       
        
    }

    private void Update()
    {
        if (talkableHeroine == null)
        {
            return;
        
        }
        if (GameManager.instance.CurerntState != GameState.Playing)
        {
            return;

        }
        if (inputReader.inputActions.Player.Talk.WasPressedThisFrame())
        {
            Debug.Log("会話ボタンが押された");
            StartTalk(talkableHeroine);

        }

    }
  

    private void OnTriggerStay(Collider other)
    {
        if (!other.CompareTag("Heroine"))
        {
            return;
        }

        if (other.CompareTag("Heroine")) //タグがヒロインなら
        {
            Heroine target = other.gameObject.GetComponent<Heroine>();
            talkableHeroine = target;

            target.TalkMark.GetComponent<SpriteRenderer>().enabled = true;

        

        }
    }





    public void OnTriggerExit(Collider other)
    {
        if (!other.CompareTag("Heroine"))
        {
            return;
        }

        Heroine target = other.gameObject.GetComponent<Heroine>();
        target.TalkMark.GetComponent<SpriteRenderer>().enabled = false;

        if (talkableHeroine == target)
        {
            talkableHeroine = null;
        }

    }

    private void StartTalk(Heroine target)
    {
       
        GameManager.instance.ChangeState(GameState.Talking);
        inputReader.SwitchToDialogue();
        DialogManager.instance.StartDialogue();
 
    }
    public void EndTalk()
    {
        
        DialogManager.instance.EndDialogue();
        inputReader.SwitchToPlayer();
        GameManager.instance.ChangeState(GameState.Playing);

    }





    }





