using Unity.Collections;
using Unity.Jobs;
using UnityEngine;

public struct TenOutJob : IJob
{
    public NativeArray<int> data;

    public void Execute()
    {
        for (int i = 0; i < data.Length; i++)
        {
            if (data[i] > 10)
            {
                data[i] = 0;
            }
        }
    }
}
