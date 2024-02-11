using UnityEngine;
using UnityEngine.UI;
[CreateAssetMenu]
public class Dialogue : ScriptableObject
{
    [SerializeField]
    [TextArea(5, 15)]
    public string DialogueText;
    public string CharacterName;
    public Image CharacterImage;
    public Dialogue nextDialogue, previousDialogue;
    public float waitTime = 0.02f;
}
