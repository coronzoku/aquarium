using UnityEngine;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{
    public bool isPlayable  = true;

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



  
 

    public void PlayableStop()
    {
        isPlayable = false;
    

     }
    public void ResumePlayable()
    {

        isPlayable = true;
    }


}
