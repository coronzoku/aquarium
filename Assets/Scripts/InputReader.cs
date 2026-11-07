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
        if (inputActions == null)
        {
            inputActions = new InputSystem_Actions();

        }
        inputActions.Player.Enable();

    }

    public bool WasNextPressed()
    {
        return inputActions.Dialogue.Next.WasPressedThisFrame();
    
    }

    private void OnDisable()
    {
        inputActions.Disable();

    }

    public void SwitchToDialogue()
    {
        inputActions.Player.Disable();
        inputActions.Dialogue.Enable();
    
    }
    public void SwitchToPlayer()
    {
        inputActions.Dialogue.Disable();
        inputActions.Player.Enable();

    }
}
