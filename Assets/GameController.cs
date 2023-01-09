using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public Barrier barrierPrefab;
    private int nextBarrierOffset;
    private int updatesSinceLastBarrier;
    // Start is called before the first frame update
    void Start()
    {
        nextBarrierOffset = Random.Range(100, 300);
        updatesSinceLastBarrier = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        updatesSinceLastBarrier++;
        if (updatesSinceLastBarrier >= nextBarrierOffset)
        {
            Instantiate(barrierPrefab);
            updatesSinceLastBarrier = 0;
        }
    }
}
