using System.Collections.Generic;
using UnityEngine;
using ArabicSupport;
using System.Linq;
using System;

public class GameController : MonoBehaviour
{
    [SerializeField] List<AudioClip> _audioClips;
     public string letter = "أ";
     int count = 0; 
     int correctAnswers = 5;
     string[] letters = new string[] {ArabicFixer.Fix("أ", false, false),
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
     int correctClicks;
     public int remaining = 0;
    public static GameController Instance { get; private set; }

    AudioSource _audioSource;

    void Awake()
    {
        Instance = this;
        _audioSource = GetComponent<AudioSource>(); 
    }

     void OnEnable()
    {
        GenerateBoard();
        UpdateSetLetter();
    }

     void GenerateBoard()
    {
        var clickables = FindObjectsOfType<Clickable_letter>();
        List<string> lettersList = new List<string>();
        for (int i = 0; i < correctAnswers; i++)
        {
            lettersList.Add(letter);
        }
        for(int i = correctAnswers; i < clickables.Length; i++)
        {
            var chooseLetter = chooseInvalidRandomLetter();
            lettersList.Add(chooseLetter);

        }
       lettersList =  lettersList
            .OrderBy(t => UnityEngine.Random.Range(0, 100000))
            .ToList();

        for (int i = 0; i < clickables.Length; i++)
        {
            clickables[i].SetLetter(lettersList[i]);
        }
        remaining = correctAnswers - correctClicks;
        FindObjectOfType<RemainingCounter>().SetRemaining(correctAnswers - correctClicks);
    }

    internal  void HandleCorrectLetterClick()
    {
        var clip = _audioClips.FirstOrDefault(t => t.name == letter);
        _audioSource.PlayOneShot(clip);
        correctClicks++;
        remaining = correctAnswers - correctClicks;
        FindObjectOfType<RemainingCounter>().SetRemaining(remaining);
        if (correctClicks >= correctAnswers && (count >=0 && count <= 27))
        {
            try
            {
                letter = letters[++count];
            }catch(Exception e) { Switch.playGame(0); }
            Debug.Log(count);
            UpdateSetLetter();
            correctClicks = 0;
            GenerateBoard();
        }
        

    }

      void UpdateSetLetter()
    {
        foreach (var setLetter in FindObjectsOfType<setLetterRandom>())
        {
            setLetter.SetLetter(letter);
        }
    }

     string chooseInvalidRandomLetter()
    {
        int R = UnityEngine.Random.Range(0, 27);
        var randomletter = letters[R];
        while (randomletter == letter)
        {
            R = UnityEngine.Random.Range(0, 27);
            randomletter = letters[R];
        }
        return randomletter;

    }
}
