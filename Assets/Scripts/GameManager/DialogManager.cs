using TMPro;
using UnityEngine.UI;
using UnityEngine;
using System;



public class DialogManager : MonoBehaviour
{
    public GameObject dialogUi;
   
    [SerializeField]private StoryData[] storyDatas; //ストーリーデータ　配列を持つ変数
    [SerializeField] private Sprite characterImage;

    [SerializeField] private TextMeshProUGUI storyText;
    [SerializeField] private TextMeshProUGUI characterName;


   

    

    public int storyIndex { get; private set; }
    public int textIndex { get; private set; } 

    

    #region シングルトン
    public static DialogManager instance;

    private void Awake()
    {

        if (instance == null)
        {
            instance = this;

        }
        else
        {
            Destroy(gameObject);
        }
    
    }

    #endregion


    private void Start()
    {
        dialogUi.SetActive(false);

        SetStoryElement(storyIndex, textIndex);
    }

    private void Update()
    {
        
    }

    private void SetStoryElement(int _storyIndex, int _textIndex)
    {
        var storyElement = storyDatas[_storyIndex].stories[_textIndex];

        characterImage = storyElement.CharacterImage;
        characterName.text = storyElement.CharacterName;
        storyText.text = storyElement.StoryText;


    }
    public void StartDialogue(Heroine targetHeroine) 　//ヒロインのデータを受け取る側
      　
    {
     
        dialogUi.SetActive(true);
　　　　

    }
    public void EndDialogue(Heroine targetHeroine)
    {
    
        dialogUi.GetComponent<Image>().enabled = false;

    }
    public void ProgressionStory(int _storyIndex)
    {
        //if(textIndex < storyDatas)
       

    }

}
