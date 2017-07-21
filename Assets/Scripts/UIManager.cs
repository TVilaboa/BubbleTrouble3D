using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts
{
    public class UIManager : MonoBehaviour
    {

        void Awake()
        {
            if (instance == null)
            {
                instance = this;
                //LevelText = GameObject.Find("LevelText").GetComponent<Text>();
                //WinText = GameObject.Find("WinText").GetComponent<Text>();
                //StatusText = GameObject.Find("StatusText").GetComponent<Text>();
                SetStatus("Alive");
                //LivesText = GameObject.Find("LivesText").GetComponent<Text>();
                
                //ScoreText = GameObject.Find("ScoreText").GetComponent<Text>();
            }
            
        }

        //singleton implementation
        private static UIManager instance;
        public static UIManager Instance
        {
            get
            {
                if (instance == null)
                    instance = new UIManager();
            
                return instance;
            }
        }

        protected UIManager()
        {
        }

        private float score = 0;


        public void ResetScore()
        {
            score = 0;
            UpdateScoreText();
        }
    
        public void SetScore(float value)
        {
            score = value;
            UpdateScoreText();
        }

        public void IncreaseScore(float value)
        {
            score += value;
            UpdateScoreText();
        }
    
        private void UpdateScoreText()
        {
            ScoreText.text = "Score: " + score;
        }

        public void SetStatus(string text)
        {
            StatusText.text ="Status: " + text;
        }

        public void Win() {
            WinText.text = "Felicitaciones! Demostraste que somos malos diseñando niveles...";
        }

        public void Loose()
        {
            WinText.text = "Segui participando muñeco. Toca enter para volver a probar";
            GameManager.Instance.IsPlayerDead = true;
        }

        public Text ScoreText, StatusText, WinText,LevelText,LivesText;


        public void DisplayLevel(int level)
        {
            LevelText.text = "Nivel " + level;
            StartCoroutine(FadeLevelText(3));
        }

        IEnumerator FadeLevelText (float time)
        {
            yield return new WaitForSeconds(time);

            LevelText.text = "";
        }

        public void UpdateLives(int lives)
        {
            LivesText.text = "Lives: " + lives;
        }
    }
}
