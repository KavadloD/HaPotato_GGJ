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
   [SerializeField] GameObject win,lose;
   private bool gameEnded;
   
   private void Start()
   {
      gameEnded = false;

      _actions.Add("green", Green);
      _actions.Add("yellow", Yellow);

      _keywordRecognizer = new KeywordRecognizer(_actions.Keys.ToArray());
      _keywordRecognizer.OnPhraseRecognized += RecoginzedWords;
      _keywordRecognizer.Start();

   }

   private void RecoginzedWords(PhraseRecognizedEventArgs speech)
   {
      Debug.Log(speech.text);
      _actions[speech.text].Invoke();
   }

   #region CommandWords

      
   private void Green()
   {
      if(!gameEnded){
         lose.SetActive(true);
         gameEnded = true;
      }
   }

    private void Yellow()
    {
      if(!gameEnded){
         win.SetActive(true);
         gameEnded = true;
      }
    }

   #endregion

}
