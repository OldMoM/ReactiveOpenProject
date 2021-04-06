using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class TestTimer : MonoBehaviour
{
    ConcurrentTimer timer = new ConcurrentTimer();
    void Start()
    {
        timer.OnTimerStart
            .Subscribe(x =>
            {
                print("开始计时");
            });

        timer.OnTimeCountdownNormalized
            .Subscribe(x =>
            {
                print("当前时间为：" + x);
            });

        timer.OnTimerEnd
            .Subscribe(x =>
            {
                print("结束计时");
            });

        timer.StartTimer(1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
