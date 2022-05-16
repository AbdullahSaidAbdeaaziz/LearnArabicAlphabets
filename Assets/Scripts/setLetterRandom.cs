using UnityEngine;
using UnityEngine.UI;
public class setLetterRandom : MonoBehaviour
{
   
   

    internal void SetLetter(string letter)
    {
        GetComponent<Text>().text = letter;
    }
}
