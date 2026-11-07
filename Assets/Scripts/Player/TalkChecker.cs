using UnityEditor.Timeline.Actions;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.GraphicsBuffer;

public class TalkChecker : MonoBehaviour
{
    [Header("会話可能なヒロイン")]
    public Heroine talkableHeroine;


    InputReader inputReader;




    private void Awake()
    {
        inputReader = GetComponent<InputReader>();
        
    }

    private void Update()
    {
        if (inputReader.inputActions.Player.Talk.WasPressedThisFrame())
        {
            Debug.Log("会話ボタンが押された");
            StartTalk(talkableHeroine);


        }
    }

    private void OnTriggerEnter(Collider other)
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
        DialogManager.instance.StartDialogue(target);
 
    }
    public void EndTalk(Heroine target)
    {
        DialogManager.instance.EndDialogue(target);
        inputReader.SwitchToPlayer();
        GameManager.instance.ChangeState(GameState.Playing);



    }





    }





