using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Windows.Speech;

public class WordDetector : MonoBehaviour
{
   private KeywordRecognizer _keywordRecognizer;
   private Dictionary<string, Action> _actions = new Dictionary<string, Action>();
   public bool menuOpening = false;
   
   private void Start()
   {
      _actions.Add("return", Return);
      _actions.Add("open", Open);
      _actions.Add("cheese", Cheese);
      _actions.Add("stop",Stop);
      _actions.Add("go", Go);
      _actions.Add("green", Green);
      _actions.Add("bad", Bad);
      _actions.Add("dog", Dog);
      _actions.Add("kill", Kill);

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

   private void Stop()
      {
         
      }
      
      private void Green()
      {
         
      }
      
      private void Bad()
      {
         
      }
      
      private void Dog()
      {
         
      }
      private void Go()
      {
        
      }

      private void Cheese()
      {
         
      }

      private void Open()
      {
         menuOpening = true;
      }
      private void Return()
      {
         menuOpening = false;
      }

      private void Kill()
      {
         menuOpening = false;
         Debug.Log("Killing the game && resetting");
         SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

      }
   #endregion

}
