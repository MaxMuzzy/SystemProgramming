using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using Unity.Jobs;
using UnityEngine;

public class TenOutJobExecutor : MonoBehaviour
{
    void Start()
    {
        NativeArray<int> data = new NativeArray<int>(new int[] { 1, 2, 10, 11, 15 }, Allocator.TempJob);

        TenOutJob job = new TenOutJob { data = data };
        JobHandle handle = job.Schedule();

        handle.Complete();

        for (int i = 0; i < data.Length; i++)
        {
            Debug.Log("data[" + i + "] = " + data[i]);
        }

        data.Dispose();
    }
}
