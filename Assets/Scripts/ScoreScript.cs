using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreScript : MonoBehaviour
{
    [SerializeField] GameObject ball;
    [SerializeField] TMP_Text sctx;
    private BallBehavior bbehavior;
    private void Start()
    {
        bbehavior = ball.GetComponent<BallBehavior>();
    }
    // Update is called once per frame
    void Update()
    {
        sctx.text = (bbehavior.score).ToString();
    }
}
