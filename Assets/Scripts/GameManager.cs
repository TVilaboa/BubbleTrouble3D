using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts
{
    public class GameManager : MonoBehaviour {

        public GameObject sphere;
        private int Level;
        public bool IsPlayerDead;

        // Use this for initialization
        void Start () {
            if (instance == null)
            {
                instance = this;
            }
            Level = 0;
            //UIManager.Instance.DisplayLevel(Level);
            //var direction = Random.Range(1, 2);
            //GameObject bubble = GameObject.FindGameObjectWithTag("Bubble");
            //if (direction == 1)
            //    bubble.gameObject.GetComponent<BubbleScript>().Init(Vector3.left, 2);
            //else
            //    bubble.gameObject.GetComponent<BubbleScript>().Init(Vector3.right, 2);
        }

        void Update()
        {
            GameObject [] bubbles = GameObject.FindGameObjectsWithTag("Bubble");
        
            //Level has ended
            if (bubbles == null || bubbles.Length == 0)
            {
                Level ++;
                UIManager.Instance.DisplayLevel(Level);
                if (Level <= 5)
                {
                    firstStrategy();
                }
                else if (Level <= 10)
                {
                    secondStrategy();
                }
                else if (Level <= 10)
                {
                    thirdStrategy();
                }
                else if (Level <= 15)
                {
                    fourthStrategy();
                }
                else if (Level < 20)
                {
                }
                else if (Level == 20)
                {
                    fifthStrategy();
                }
                else
                {
                    UIManager.Instance.Win();
                }
            }

            if (IsPlayerDead && Input.GetKeyDown(KeyCode.Return))
            {
                SceneManager.LoadScene("BubbleTrouble");
            }
        }

        private void genBubbles(int quantity, int minSize, int maxSize) {
            for (int i = 0; i < Level; i++)
            {
                var position = sphere.gameObject.transform.position;
                position.x = Random.Range(-29, 29);
                var size = Random.Range(minSize, maxSize);
                var direction = Random.Range(1, 2);
                GameObject bubble = Instantiate(sphere, position, Quaternion.identity);
                if (direction == 1)
                {
                    bubble.GetComponent<BubbleScript>().Init(Vector3.right, size);
                }
                else
                {
                    bubble.GetComponent<BubbleScript>().Init(Vector3.right, size);
                }
            }
        }

        private void firstStrategy() {
            genBubbles(Level, 1, 4);
        }

        private void secondStrategy() {
            int split = Level / 2;
            int split2 = Level / 4;
            genBubbles(split, 1, 2);
            genBubbles(split2, 2, 4);
        }

        private void thirdStrategy() {
            genBubbles(1, 4, 4);
            int split = Level / 3;
            genBubbles(split, 1, 4);
        }

        private void fourthStrategy() {
            int split = Level / 4;
            genBubbles(split, 4, 4);
            genBubbles(2, 1, 2);
        }

        private void fifthStrategy() {
            genBubbles(3, 4, 4);
            genBubbles(2, 3, 3);
            genBubbles(4, 2, 2);
            genBubbles(4, 1, 1);
        }

        //singleton implementation
        private static GameManager instance;
        public static GameManager Instance
        {
            get
            {
                if (instance == null)
                    instance = new GameManager();

                return instance;
            }
        }

        protected GameManager()
        {
        }
    }
}
