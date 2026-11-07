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

    [SerializeField] private TalkChecker _talkchecker;


    private bool isTalking = false;

    [SerializeField] private InputReader inputReader;
    

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
        if (isTalking && inputReader.WasNextPressed())
        {
            ProgressionStory(storyIndex);


        }


    }

    private void SetStoryElement(int _storyIndex, int _textIndex)
    {
        var storyElement = storyDatas[_storyIndex].stories[_textIndex];

        characterImage = storyElement.CharacterImage;
        characterName.text = storyElement.CharacterName;
        storyText.text = storyElement.StoryText;


    }
    public void StartDialogue() 　//ヒロインのデータを受け取る側
      　
    {
        textIndex = 0;
        SetStoryElement(storyIndex,textIndex);

        dialogUi.SetActive(true);
        isTalking = true;


    }
    public void EndDialogue()
    {

        dialogUi.SetActive(false);
        isTalking = false;
        textIndex = 0;


    }
    public void ProgressionStory(int _storyIndex)
    {
        int lastIndex = storyDatas[_storyIndex].stories.Count- 1;

        if (textIndex >= lastIndex)
        {
            _talkchecker.EndTalk();
            return;
        
        }

        textIndex++;

        SetStoryElement(_storyIndex, textIndex);


    }

}
