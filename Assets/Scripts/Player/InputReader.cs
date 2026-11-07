using UnityEngine;
using UnityEngine.InputSystem;

public class InputReader : MonoBehaviour
{
    public InputSystem_Actions inputActions;


    void Awake()
    {

        inputActions = new InputSystem_Actions();

    }

    private void OnEnable()
    {
        inputActions.Enable();

    }

    private void OnDisable()
    {
        inputActions.Disable();

    }

    public void SwitchToDialogue()
    {
        inputActions.Player.Disable();
        inputActions.UI.Enable();
    
    }
    public void SwitchToPlayer()
    {
        inputActions.Player.Disable();
        inputActions.UI.Enable();

    }
}
