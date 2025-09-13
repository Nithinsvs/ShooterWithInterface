using System.Reflection;
using System.Threading.Tasks;
using UnityEngine;

public class AsyncCheck : MonoBehaviour
{
    public void Start()
    {
        Met1();
        Met2();
    }

    async void Met1()
    {
        Debug.Log("i'm nithin");
        await Task.Delay(5000);
        Debug.Log("i'm not nithin");
    }

    void Met2()
    {
        Debug.Log("printing");
    }
}