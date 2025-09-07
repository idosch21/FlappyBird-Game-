using UnityEngine;
using UnityEngine.UI;
namespace FlappyBird
{
    public class GameManager : MonoBehaviour
    {
        public Player player;
        public Text scoreText;
        public GameObject playButton;
        public GameObject gameOver;
        private int score;

        //This method is called when a player hits a obstacle, 
        //we will pause the game, show the game over text and the play button to restart the game
        public void GameOver()
        {
            gameOver.SetActive(true);
            playButton.SetActive(true);
            Pause();
        }
        //This method is called when the player hits a scoring object(in between the pipes)
        //we will increase the score by one and update the score text
        public void IncreaseScore()
        {
            score++;
            scoreText.text = score.ToString();
        }

        //This method is called when we hit start in unity(starting the game)
        //before we did anything else
        private void Awake()
        {
            Pause();
        }

        //This method is called when we hit the play button
        //we will reset the score, hide the game over text and the play button
        //we will also destroy all the pipes in the scene and enable the player script
        //and it will let us play the game by setting the timescale to 1, so everything will start to move.
        public void Play()
        {
            score = 0;
            scoreText.text = score.ToString();

            playButton.SetActive(false);
            gameOver.SetActive(false);
            Time.timeScale = 1f;
            player.enabled = true;

            Pipes[] pipes = FindObjectsByType<Pipes>(FindObjectsSortMode.None);
            foreach (Pipes pipe in pipes)
            {
                Destroy(pipe.gameObject);
            }
        }

        //This method will pause the game by setting the timescale to 0, so everything will stop moving
        //and we will also disable the player script so the player's inputs won't be detected
        public void Pause()
        {
            Time.timeScale = 0f;
            player.enabled = false;
        }
    }
}