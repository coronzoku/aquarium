using UnityEngine;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{
   

    #region　　【シングルトン】
    public static GameManager instance;
    private void Awake()
    {
       

        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);

        }


    }
    #endregion


    public GameState CurerntState { get;  private set; } //プロパティ
         = GameState.Playing;　//プレイング状態



    public void ChangeState(GameState newState)
    {
        CurerntState = newState;

        Debug.Log("現在の状態" +CurerntState);
    
    
    }

    public bool CanMove()
    {
        return CurerntState == GameState.Playing;
    
    }



}

public enum GameState
{

    Playing,
    Talking,
    Paused,

    Event,


}
