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
        nextBarrierOffset = Random.Range(64, 256);
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
            Barrier newBarrier = Instantiate(barrierPrefab);
            newBarrier.transform.SetPositionAndRotation(
                new Vector3(12f, 0f, 0f),
                Quaternion.identity
            );
            updatesSinceLastBarrier = 0;
        }
    }
}
