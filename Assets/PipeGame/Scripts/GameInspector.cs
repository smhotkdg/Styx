using UnityEngine;
using System.Collections;

namespace MadFireOn
{
    public class GameInspector : MonoBehaviour
    {
        //array where all the pipe objects in the scene are stored
        public PipeScript[] pipeObj;
        //ref to level complete status
        public bool levelComplete = false;
        //ref to which level is on
        private int levelInd;

        void Awake()
        {
            //at start we want levelComplete false
            levelComplete = false;
            //we then set the gameManager variable
            //GameManager.instance.levelComplete = levelComplete;
        }

        // Use this for initialization
        void Start()
        {
            //get all the pipeObj and are stored in array
            //pipeObj = FindObjectsOfType<PipeScript>();
            //assign the current level int to levelInd
            //levelInd = GameManager.instance.currentLevel;
        }

        // Update is called once per frame
        void Update()
        {
            CheckForLevelComplete();

            //if level is complete
            if (levelComplete)
            {
                //we set gamemanager levelcomplete
                //GameManager.instance.levelComplete = levelComplete;                
                Debug.Log("레벨 컴플릿!");
                //check for the total moves taken to solve the puzzle and set the best moves
                //if (GameManager.instance.bestMoves[levelInd] <= 0)
                //{
                //    GameManager.instance.bestMoves[levelInd] = InputHandler.instance.moves;
                //    GameManager.instance.Save();
                //}
                //else if (GameManager.instance.bestMoves[levelInd] > InputHandler.instance.moves)
                //{
                //    GameManager.instance.bestMoves[levelInd] = InputHandler.instance.moves;
                //    GameManager.instance.Save();
                //}
                ////this is to prevent game to change scene after the last level
                //if (GameManager.instance.currentLevel < GameManager.instance.levels.Length - 1)
                //{
                //    //this code unlocks the next level
                //    GameManager.instance.levels[levelInd + 1] = true;
                //    //this code set the levelCompleted bool to true for current level
                //    GameManager.instance.levelCompleted[levelInd] = true;
                //    GameManager.instance.Save();
                //}
            }

        }
        //methode which loop throught all the pipes and check if each one variable
        //"completed" is true
        void CheckForLevelComplete()
        {
            for (int i = 0; i < pipeObj.Length; i++)
            {
                if (pipeObj[i].completed == false)
                {
                    levelComplete = false;
                    return;
                }
                
            }

            levelComplete = true;
        }
    }

}//namespace MadFireOn