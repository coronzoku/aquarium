using UnityEditor.Timeline.Actions;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{


    [SerializeField]InputReader inputReader;

    

    [SerializeField] private float moveSpeed = 5f; 





    private void Update()
    {
        if (!GameManager.instance.CanMove())
            return;


        Vector2 move = inputReader.inputActions.Player.PlayerMove.ReadValue<Vector2>();
        Vector3 three = new Vector3(move.x, 0f, move.y);
        transform.Translate(three * Time.deltaTime * moveSpeed);

    }



   

}
