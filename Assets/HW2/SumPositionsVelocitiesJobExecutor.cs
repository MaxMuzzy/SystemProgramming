using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using Unity.Jobs;
using UnityEngine;

public class SumPositionsVelocitiesJobExecutor : MonoBehaviour
{
    private NativeArray<Vector3> Positions;
    private NativeArray<Vector3> Velocities;
    private NativeArray<Vector3> FinalPositions;

    private void Start()
    {
        int numElements = 10;
        Positions = new NativeArray<Vector3>(numElements, Allocator.TempJob);
        Velocities = new NativeArray<Vector3>(numElements, Allocator.TempJob);
        FinalPositions = new NativeArray<Vector3>(numElements, Allocator.TempJob);

        for (int i = 0; i < numElements; i++)
        {
            Positions[i] = new Vector3(i, i + 1, i + 2);
            Velocities[i] = new Vector3(i+ 1, i + 2 , i);
        }

        SumPositionsVelocitiesJob job = new SumPositionsVelocitiesJob()
        {
            Positions = Positions,
            Velocities = Velocities,
            FinalPositions = FinalPositions
        };

        JobHandle handle = job.Schedule(numElements, 32); 
        handle.Complete();

        for (int i = 0; i < numElements; i++)
        {
            Debug.Log("Final position " + i + " = " + FinalPositions[i]);
        }

        Positions.Dispose();
        Velocities.Dispose();
        FinalPositions.Dispose();
    }
}
