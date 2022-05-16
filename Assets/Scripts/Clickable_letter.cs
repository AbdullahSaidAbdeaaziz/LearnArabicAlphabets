using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using ArabicSupport;
public class Clickable_letter : MonoBehaviour, IPointerClickHandler
{
    private string[] letters = new string[] {ArabicFixer.Fix("أ", false, false),
                                             ArabicFixer.Fix("ب", false, false),
                                             ArabicFixer.Fix("ت", false, false),
                                             ArabicFixer.Fix("ث", false, false),
                                             ArabicFixer.Fix("ج", false, false),
                                             ArabicFixer.Fix("ح", false, false),
                                             ArabicFixer.Fix("خ", false, false),
                                             ArabicFixer.Fix("د", false, false),
                                             ArabicFixer.Fix("ذ", false, false),
                                             ArabicFixer.Fix("ر", false, false),
                                             ArabicFixer.Fix("ز", false, false),
                                             ArabicFixer.Fix("س", false, false),
                                             ArabicFixer.Fix("ش", false, false),
                                             ArabicFixer.Fix("ص", false, false),
                                             ArabicFixer.Fix("ض", false, false),
                                             ArabicFixer.Fix("ط", false, false),
                                             ArabicFixer.Fix("ظ", false, false),
                                             ArabicFixer.Fix("ع", false, false),
                                             ArabicFixer.Fix("غ", false, false),
                                             ArabicFixer.Fix("ف", false, false),
                                             ArabicFixer.Fix("ق", false, false),
                                             ArabicFixer.Fix("ك", false, false),
                                             ArabicFixer.Fix("ل", false, false),
                                             ArabicFixer.Fix("م", false, false),
                                             ArabicFixer.Fix("ن", false, false),
                                             ArabicFixer.Fix("ه", false, false),
                                             ArabicFixer.Fix("و", false, false),
                                             ArabicFixer.Fix("ي", false, false)
                                         };
    string curClickLetter;

    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log($"click on letter {curClickLetter}");
        if (curClickLetter == GameController.Instance.letter)
        {
            GetComponent<Text>().color = Color.green;
            enabled = false;
            GameController.Instance.HandleCorrectLetterClick();
        }else
        {
            GetComponent<Text>().color = Color.red;
            
        }
        
    }

    internal void SetLetter(string letter)
    {
        enabled = true;
        GetComponent<Text>().color = Color.white;
        curClickLetter = letter;
        GetComponent<Text>().text = letter;
    }
}
