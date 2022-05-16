using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Switch : MonoBehaviour
{
    public static void playGame(int index)
    {
        SceneManager.LoadScene(index);
    }
}
