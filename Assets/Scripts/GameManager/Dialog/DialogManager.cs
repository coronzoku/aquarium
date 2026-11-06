using TMPro;
using UnityEngine.UI;
using UnityEngine;



public class DialogManager : MonoBehaviour
{
    public GameObject dialogPanel;
    [SerializeField]private StoryData[] storyDatas;
    [SerializeField] private Image characterImage;

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
         dialogPanel.SetActive(false);
         SetStoryElement(storyIndex, textIndex);
    }

    private void SetStoryElement(int _storyIndex, int _textIndex)
    {

        //characterImage.sprite = storyElement.CharacterImage;
        //characterName.text = storyElement.CharacterName;

    }
    public void StartDialogue(Heroine　targetHeroine) 　//ヒロインのデータを受け取る側
        //パネル表示とキャラ停止　
    {
        GameManager.instance.isPlayable = false;
        dialogPanel.GetComponent<SpriteRenderer>().enabled = true;
　　　　

    }
    public void EndDialogue(Heroine targetHeroine)
    {
        GameManager.instance.isPlayable = true;
        dialogPanel.GetComponent<SpriteRenderer>().enabled = false;

    }
    public void DisplaySentence()
    {
       

    }

}
