using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CountDown : MonoBehaviour
{
    private int time;
    [SerializeField] private TextMeshProUGUI tmp;
    private GameManagerX gx;

    // Start is called before the first frame update
    void Start()
    {
        time = 60;
        gx = gameObject.GetComponent<GameManagerX>();
    }

    public void StartTimer()
    {
        StartCoroutine(CountTime());
    }

    private IEnumerator CountTime()
    {
        while (gx.isGameActive)
        {
            tmp.text = "Time: " + time;
            yield return new WaitForSeconds(1);
            
            if (time <= 0)
            {
                GameManagerX gx = GameObject.Find("Game Manager").GetComponent<GameManagerX>();
                gx.GameOver();
            }

            time--;
        }
    }
}
