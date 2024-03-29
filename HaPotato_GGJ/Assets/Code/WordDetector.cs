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
   public bool CheeseTrigger = false;
   public bool CakeTrigger = false;
   public bool MurderTrigger = false;
   public bool walkWayTrigger = false;
   public bool IslandTrigger = false;
   public bool LetMeInTrigger = false;
   public bool miniGameTrigger1 = false;
   public bool yellowTrigger = false;
   public bool blueTrigger = false;

   public GameObject credits;
   public GameObject mainMenu;
   //public bool miniGameTrigger2 = false;
   
   private void Start()
   {
      _actions.Add("return", Return);
      _actions.Add("start", Open);
      _actions.Add("cheese", Cheese);
      _actions.Add("stop",Stop);
      _actions.Add("go", Go);
      _actions.Add("blue", Blue);
      _actions.Add("yellow", Yellow);
      _actions.Add("help", Help);


      _actions.Add("bad", BadDog);
      _actions.Add("drop", BadDog);
      _actions.Add("bad dog", BadDog);
      _actions.Add("no", BadDog);

      _actions.Add("good", GoodDog);
      _actions.Add("good boy", GoodDog);
      _actions.Add("good dog", GoodDog);
      _actions.Add("good puppy", GoodDog);
      
      _actions.Add("start game",GameStart1);
      _actions.Add("start game one",GameStart1);
      _actions.Add("one",GameStart1);
      
      _actions.Add("let me in",LetMeIn);
      _actions.Add("credits",Credits);
      _actions.Add("close",Close);
      
      _actions.Add("kill", Kill);
      _actions.Add("Reset", Kill);
      _actions.Add("Restart", Kill);
      
      _actions.Add("cake",CakeFunc);
      _actions.Add("murder",MurderFunc);
      
//      _actions.Add("stop",CrosswalkMinigame);
      
      _keywordRecognizer = new KeywordRecognizer(_actions.Keys.ToArray());
      _keywordRecognizer.OnPhraseRecognized += RecoginzedWords;
      _keywordRecognizer.Start();
      
      credits.SetActive(false);
   }

   private void RecoginzedWords(PhraseRecognizedEventArgs speech)
   {
      Debug.Log(speech.text);
      _actions[speech.text].Invoke();
   }

   #region Minigame Start

   private void GameStart1()
   {
         menuOpening = true;
         Debug.Log("Good Dog Triggered");
      
      
   }

   #endregion
   

   #region CommandWords

   private void Credits()
   {
      if (!miniGameTrigger1 && !credits.activeSelf)
      {
         credits.SetActive(true);
         mainMenu.SetActive(false);
      }
   }
   private void Close()
   {
      if (!miniGameTrigger1 && credits.activeSelf)
      {
         credits.SetActive(false);
         mainMenu.SetActive(true);
      }
   }
   
   private void LetMeIn()
   {
      LetMeInTrigger = true;
      Debug.Log("Let Me In Triggered");
   }
   private void Stop()
      {
         if (miniGameTrigger1 == true)
         {
            
         }
      }
      
    private void Blue() 
     {
      blueTrigger = true;
      Debug.Log("blueTrigger Triggered");   
     }

    private void Yellow()
     {
      yellowTrigger = true;
      Debug.Log("yellowTrigger Triggered");  
     }
    private void Go()
      {
        
      }

      private void Cheese()
      {
         //if (miniGameTrigger1 == true)
         
            CheeseTrigger = true;
            Debug.Log("Cheese Triggered");
         
      }

      private void Help()
      {
         IslandTrigger = true;
         Debug.Log("Island Triggered");
         
         if (miniGameTrigger1 == true)
         {
            IslandTrigger = true;
            Debug.Log("Island Triggered");
         }
      }

      private void Open()
      {
         menuOpening = true;
         miniGameTrigger1 = true;
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
         BDogTrigger = true;
         Debug.Log("Bad Dog Triggered");
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
            Debug.Log("Good Dog Triggered");
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

