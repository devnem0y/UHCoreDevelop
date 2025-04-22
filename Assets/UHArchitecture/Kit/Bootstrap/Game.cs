using System;
using UnityEngine;
using UralHedgehog.UI;

namespace UralHedgehog
{
    public class Game : EntryPoint
    {
        public static Game Instance { get; private set; }

        private void Awake()
        {
            /*if (Instance == null) Instance = this;
            else
            {
                Destroy(gameObject);
                return;
            }
    
            DontDestroyOnLoad(gameObject);*/
            
            Instance = this;
        }

        protected override void Initialization()
        {
            base.Initialization();
            UIManager = new UIManager(FindObjectOfType<UIRoot>());
        }

        public override void ChangeState(GameState state)
        {
            base.ChangeState(state);
            
            switch (GameState)
            {
                case GameState.LOADING:
                    Debug.Log("<color=yellow>Loading</color>");
                    ScreenTransition.Perform(null, TransitionMode.STATIC);
                    break;
                case GameState.MAIN:
                    Debug.Log("<color=yellow>Main</color>");
                    var example = new Example();
                    UIManager.OpenViewExample(example);
                    UIManager.OpenViewSettings(_settings);
                    ScreenTransition.Show();
                    break;
                case GameState.PLAY:
                    Debug.Log("<color=yellow>Play</color>");
                    break;
                case GameState.VICTORY:
                    Debug.Log("<color=yellow>Victory</color>");
                    break;
                case GameState.DEFEAT:
                    Debug.Log("<color=yellow>Defeat</color>");
                    break;
                
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                UIManager.CloseViewExample();
            }
        }
    }
}