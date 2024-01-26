using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Windows.Speech;
using TMPro;
using TMPro.Examples;

public class DetectYellow : MonoBehaviour
{
   private KeywordRecognizer _keywordRecognizer;
   private Dictionary<string, Action> _actions = new Dictionary<string, Action>();
   public bool yellowSaid = false;
   public bool greenSaid = false;
   [SerializeField] GameObject win,lose;
   public WinCon wincon = WinCon.MIDGAME;

   public float timer;
   public float startTime;
   [SerializeField] TMP_Text countdown;
   
   private void Start()
   {
      _actions.Add("green", Green);
      _actions.Add("yellow", Yellow);

      _keywordRecognizer = new KeywordRecognizer(_actions.Keys.ToArray());
      _keywordRecognizer.OnPhraseRecognized += RecoginzedWords;
      _keywordRecognizer.Start();

      timer = Time.time;
      startTime = timer; 
   }

   private void Update(){
      if(wincon == WinCon.MIDGAME){
         if(timer > startTime + 5){
            countdown.text = "XP";
            lose.SetActive(true);
            Debug.Log("TIME OUT, LOSE!!!");
            wincon = WinCon.LOSE;
         }
         else{
            timer = Time.time;
            countdown.text = string.Format("{0:N3}", timer);
         }
      }
      else if(wincon == WinCon.WIN && timer > startTime + 5){
         countdown.text = ":)";
      }
   }

   private void RecoginzedWords(PhraseRecognizedEventArgs speech)
   {
      Debug.Log(speech.text);
      _actions[speech.text].Invoke();
   }

   #region CommandWords

      
   private void Green()
   {
      Debug.Log("GREEN SAID");
      if(wincon == WinCon.MIDGAME){
         greenSaid = true;
         lose.SetActive(true);
         wincon = WinCon.LOSE;
      }
   }

    private void Yellow()
    {
      Debug.Log("YELLOW SAID");
      if(wincon == WinCon.MIDGAME){
         yellowSaid = true;
         win.SetActive(true);
         wincon = WinCon.WIN;
      }
    }

   #endregion

}

public enum WinCon{MIDGAME, WIN, LOSE}