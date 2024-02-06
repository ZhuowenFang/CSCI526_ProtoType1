using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeatSpawner : MonoBehaviour
{
    private int[] beats = {0,12,0,30};
    private float[] intervals = {0.01f, 2.5f,1.8f,2.9f};
    public GameObject single;
    public GameObject lasting;
    private float timer;
    private int cnt = 0;
    private bool finish = false;
    // Start is called before the first frame update
    void Start()
    {
        timer = intervals[cnt];
        single.SetActive(false);
        lasting.SetActive(false);
    }

    // Update is called once per frame
    void LateUpdate()
    {
        timer -= Time.deltaTime;
        if (timer <= 0 && !finish)
        {
            Spawn(beats[cnt]);
            if (cnt == beats.Length) finish = true;
            timer = intervals[cnt]; // reset
        }
    }

    void Spawn(int cmd)
    {
        cnt += 1;
        if (cmd == 0) {
            GameObject circle = Instantiate(single, transform.position, Quaternion.identity, transform);
            circle.SetActive(true);
        } else {
            GameObject longBeat = Instantiate(lasting, transform.position, Quaternion.identity, transform);
            longBeat.transform.localScale = new Vector3(cmd, 1, 1);
            longBeat.SetActive(true);
        }
    }
}
