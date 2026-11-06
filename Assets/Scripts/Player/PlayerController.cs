using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{

    private TalkChecker _TalkChecker;


    [SerializeField] private float moveSpeed = 5f; //移動速度の数値を変数に代入
    InputAction moveAction;
    InputAction talkAction;
 



    void Awake()
    {

        _TalkChecker = GetComponent<TalkChecker>();
        moveAction = InputSystem.actions["PlayerMove"];

        talkAction = InputSystem.actions["Talk"];

    }



    private void Update()
    {
        Vector2 move = moveAction.ReadValue<Vector2>();
        Vector3 three = new Vector3(move.x, 0f, move.y);
        transform.Translate(three * Time.deltaTime * moveSpeed);

        if (talkAction.WasPressedThisFrame())
        {
            if (_TalkChecker.talkableHeroine != null) //null以外
            {
               
                DialogManager.instance.StartDialogue(_TalkChecker.talkableHeroine); //スタートダイアログメソッドを実行　ヒロインの情報を渡す呼び出し側
                GameManager.instance.PlayableStop();
                //今話しかけられるヒロインの情報を、DialogManagerに渡して会話を開始する

            }


        }

    }







}
