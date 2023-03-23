using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;

public class Tasks : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        CancellationTokenSource cancelTokenSource = new CancellationTokenSource();
        CancellationToken cancelToken = cancelTokenSource.Token;

        Task task2 = Task2(cancelToken);
        Task task1 = Task1(cancelToken);
    }

    async Task Task1(CancellationToken cancelToken)
    {
        await Task.Delay(1000);
        Debug.Log("Done1");
    }

    async Task Task2(CancellationToken cancelToken)
    {
        var i = 0;
        while(i <= 60)
        {
            i++;
            await Task.Yield();
        }
        Debug.Log("Done2");
    }
}
