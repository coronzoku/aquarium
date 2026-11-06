using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "StoryData", menuName = "Scriptable Objects/StoryData")]
public class StoryData : ScriptableObject
{
    public List<Story> stories = new List<Story>();
    
}
[System.Serializable]

public class Story
{
    public Sprite CharacterImage;
    public Animator Charactoranime;

    [TextArea]
    public string StoryText;
    public string CharacterName;
    


}