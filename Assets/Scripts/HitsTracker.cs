using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HitsTracker : MonoBehaviour
{
    
    [SerializeField] private Ball ball;
    [SerializeField] private TMP_Text hitsText;
    [SerializeField] private TMP_Text maxHitsText;
    [SerializeField] private int maxHits;
    [SerializeField] private Button restartButton;

    public int MaxHits {get{return maxHits;} set{maxHits = value;}}

    private void Start() {
        maxHitsText.text = "Max hits: "+maxHits;
        restartButton.gameObject.SetActive(false);
    }

    private void Update()
    {
        hitsText.text = "Hits: " + ball.Hits;
        CheckForHitsCount();
    }

    private void CheckForHitsCount()
    {
        if(ball.Hits == MaxHits && ball.BallStopped())
        {
            restartButton.gameObject.SetActive(true);
        }
    }

}
