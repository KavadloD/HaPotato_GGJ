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
   public bool BDogTrigger = false;
   public bool GDogTrigger = false;
   public bool CakeTrigger = false;
   public bool MurderTrigger = false;
   public bool miniGameTrigger1 = false;
   public bool miniGameTrigger2 = false;
   
   private void Start()
   {
      _actions.Add("return", Return);
      _actions.Add("open", Open);
      _actions.Add("cheese", Cheese);
      _actions.Add("stop",Stop);
      _actions.Add("go", Go);
      _actions.Add("green", Green);
      _actions.Add("yellow", Yellow);
      
      
      _actions.Add("bad", BadDog);
      //_actions.Add("dog", BadDog);
      _actions.Add("bad dog", BadDog);

      _actions.Add("good", GoodDog);
      _actions.Add("good boy", GoodDog);
      _actions.Add("good dog", GoodDog);
      _actions.Add("good puppy", GoodDog);
      
      _actions.Add("start game",GameStart);
      _actions.Add("start game one",GameStart);
      _actions.Add("one",GameStart);
      
      
      
      _actions.Add("kill", Kill);
      _actions.Add("cake",CakeFunc);
      _actions.Add("murder",MurderFunc);
      _keywordRecognizer = new KeywordRecognizer(_actions.Keys.ToArray());
      _keywordRecognizer.OnPhraseRecognized += RecoginzedWords;
      _keywordRecognizer.Start();
   }

   private void RecoginzedWords(PhraseRecognizedEventArgs speech)
   {
      Debug.Log(speech.text);
      _actions[speech.text].Invoke();
   }

   #region Minigame Start

   private void GameStart()
   {
      if (menuOpening == true)
      {
         miniGameTrigger1 = true;
         Debug.Log("Starting the main game");
      }
      
   }

   #endregion
   

   #region CommandWords

   private void Stop()
      {
         if (miniGameTrigger1 == true)
         {
            
         }
      }
      
    private void Green() 
     {
         
     }

    private void Yellow()
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

   #region DogStuff
      private void BadDog()
      {
         if (miniGameTrigger1 == true)
         {

            BDogTrigger = true;
            Debug.Log("Bad Dog Triggered");
         }
      }
      private void GoodDog()
      {
         if (miniGameTrigger1 == true)
         {
            GDogTrigger = true;
            Debug.Log("Good Dog Word heard Triggered");
         }
      }

   #endregion
   
  #region CAKE
   private void CakeFunc()
      {
         CakeTrigger = true;
         Debug.Log("Cake Triggered");
      }
  #endregion
  
  #region MurderGame
  private void MurderFunc()
  {
     {
        MurderTrigger = true;
        Debug.Log("Murder Triggered");
     }
  }

  #endregion
}

