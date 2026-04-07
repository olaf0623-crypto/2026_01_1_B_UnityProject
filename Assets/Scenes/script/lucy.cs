using UnityEngine;

public class lucy : MonoBehaviour
{
    public int health = 100;
    public float Timer = 1.0f;

    public object Keycode { get; private set; }

    void Start()
    {
        health = health + 100;
    }

    // Update is called once per frame
    void Update()
    {
        Timer = Timer - Timer.deltaTime;

        if (Timer <= 0)
        {
            Timer = 1.0f;
            health = health - 20;
        }

        if (Input.GetKeyDown(Keycode.space))
        {
            health = health + 2;
        }
    }
}
