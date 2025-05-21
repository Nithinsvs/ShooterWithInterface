using System.Reflection;
using System.Threading.Tasks;
using UnityEngine;

public class AsyncCheck : MonoBehaviour
{
    public async void Start()
    {
        Debug.Log("i'm nithin");
        await Task.Delay(5000);
        Debug.Log("i'm not nithin");
    }
}