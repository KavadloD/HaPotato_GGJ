using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Windows.Speech;

public class WordDetector : MonoBehaviour
{
   private KeywordRecognizer _keywordRecognizer;
   private Dictionary<string, Action> _actions = new Dictionary<string, Action>();

   private void Start()
   {
      _actions.Add("cheese", Cheese);
      _actions.Add("stop",Stop);
      _actions.Add("green", Green);
      _actions.Add("bad", Bad);
      _actions.Add("dog", Dog);

      _keywordRecognizer = new KeywordRecognizer(_actions.Keys.ToArray());
      _keywordRecognizer.OnPhraseRecognized += RecoginzedWords;
      _keywordRecognizer.Start();
   }

   private void RecoginzedWords(PhraseRecognizedEventArgs speech)
   {
      Debug.Log(speech.text);
      _actions[speech.text].Invoke();
   }

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
   private void Cheese()
   {
      
   }
}
