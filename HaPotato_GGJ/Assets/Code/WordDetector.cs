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
   public bool IslandTrigger = false;
   public bool miniGameTrigger1 = false;
   public bool yellowTrigger = false;
   public bool blueTrigger = false;
   //public bool miniGameTrigger2 = false;
   
   private void Start()
   {
      _actions.Add("return", Return);
      _actions.Add("start", Open);
      _actions.Add("cheese", Cheese);
      _actions.Add("stop",Stop);
      _actions.Add("go", Go);
<<<<<<< Updated upstream
      _actions.Add("blue", Blue);
=======
       _actions.Add("blue", Blue);
>>>>>>> Stashed changes
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

   private void GameStart1()
   {
         menuOpening = true;
         Debug.Log("Good Dog Triggered");
      
      
   }

   #endregion
   

   #region CommandWords

   private void Stop()
      {
         if (miniGameTrigger1 == true)
         {
            
         }
      }
      
    private void Blue() 
     {
<<<<<<< Updated upstream
      blueTrigger = true;
      Debug.Log("blueTrigger Triggered");   
=======
        blueTrigger = true;
        Debug.Log("blueTriggered");
>>>>>>> Stashed changes
     }

    private void Yellow()
     {
<<<<<<< Updated upstream
      yellowTrigger = true;
      Debug.Log("yellowTrigger Triggered");  
     }
=======
        yellowTrigger = true;
        Debug.Log("yellowTriggered");
    }
>>>>>>> Stashed changes
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

