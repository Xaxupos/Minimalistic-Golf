using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using MoreMountains.Feedbacks;

public class HitsTracker : MonoBehaviour
{
    

    [SerializeField] MMFeedbacks loseFeedbacks;

    [SerializeField] private Ball ball;
    [SerializeField] private TMP_Text hitsText;
    [SerializeField] private TMP_Text maxHitsText;
    [SerializeField] private TMP_Text restartText;
    [SerializeField] private int maxHits;
    [SerializeField] private Button restartButton;

    private bool lost = false;

    public int MaxHits {get{return maxHits;} set{maxHits = value;}}

    private void Start() {
        maxHitsText.text = "Max hits: "+maxHits;
        restartButton.gameObject.SetActive(false);
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        hitsText.text = "Hits: " + ball.Hits;
        if(!lost)
            CheckForHitsCount();
    }

    private void CheckForHitsCount()
    {
        if(ball.Hits == MaxHits && ball.BallStopped())
        {
            lost = true;
            restartButton.gameObject.SetActive(true);
            restartText.gameObject.SetActive(false);
            loseFeedbacks.PlayFeedbacks();                        
        }
    }

}
