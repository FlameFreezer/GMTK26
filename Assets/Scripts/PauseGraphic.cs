using UnityEngine;
using UnityEngine.UI;

public class PauseGraphic : MonoBehaviour
{
    public Sprite pausedSprite;
    public Sprite unpausedSprite;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        Game.Instance().EventBus().onPause += OnPause;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnPause(bool isPaused)
    {
        if(isPaused)
        {
            GetComponent<Image>().sprite = pausedSprite;
        }
        else
        {
            GetComponent<Image>().sprite = unpausedSprite;
        }
    }
}
