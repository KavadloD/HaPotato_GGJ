using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Windows.Speech;

public class DetectYellow : MonoBehaviour
{
   private KeywordRecognizer _keywordRecognizer;
   private Dictionary<string, Action> _actions = new Dictionary<string, Action>();
   public bool menuOpening = false;
   [SerializeField] SpriteRenderer bg;
   [SerializeField] GameObject win,lose;
   [SerializeField] Sprite winSprite, lossSprite;
   private GameObject audioLayer;
    private AudioSource _audioSource;
    private WordDetector _wordDetector;
    private bool notYellowTriggered;
    private bool yellowTriggered;
    [SerializeField] WinLoss winloss;
   
   void Awake()
    {
        audioLayer = GameObject.FindGameObjectWithTag("GameController");
        _wordDetector = audioLayer.GetComponent<WordDetector>();
        _audioSource = GetComponent<AudioSource>();
        yellowTriggered = false;
        notYellowTriggered = false;
        
    }

   private void Start()
   {
         AudioLoudnessDetecton[] audioLoudness = FindObjectsOfType<AudioLoudnessDetecton>();     
        _audioSource = GetComponent<AudioSource>();
        _wordDetector = audioLayer.GetComponent<WordDetector>();
        winloss = WinLoss.ingame;

   }

   private void FixedUpdate(){
      if (_wordDetector.yellowTrigger == true)
        {
            _wordDetector.yellowTrigger = false;
            yellowTriggered = true;
            Debug.Log("Yellow detected in DetectYellow");
        }
      if (_wordDetector.blueTrigger == true)
        {
            _wordDetector.blueTrigger = false;
            notYellowTriggered = true;
            Debug.Log("Blue detected in DetectYellow");
        }

      if (yellowTriggered == true && winloss == WinLoss.ingame)
        {
            bg.sprite = winSprite;
            winloss = WinLoss.win;
            Debug.Log("Yellow spoken, you win!");
        }

        if (notYellowTriggered == true && winloss == WinLoss.ingame)
        {
            bg.sprite = lossSprite;
            winloss = WinLoss.loss;
            Debug.Log("Not yellow spoken, you lose!");
        }
   }

   private enum WinLoss{
      ingame, win, loss
   }
   
}
