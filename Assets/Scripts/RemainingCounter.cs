using UnityEngine;
using UnityEngine.UI;
public class RemainingCounter : MonoBehaviour
{
  internal void   SetRemaining(int remaining)
    {
        GetComponent<Text>().text = "x" + remaining;
        
    }

}
