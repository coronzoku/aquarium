using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UIElements;


[CreateAssetMenu(fileName = "StoryData", menuName = "Scriptable Objects/StoryData")]
public class StoryData : ScriptableObject
{
    public List<Story> stories = new List<Story>();
    
}
[System.Serializable]

public class Story
{
    public Sprite CharacterImage;

    [TextArea]
    public string StoryText;
    public string CharacterName;
    


}