using UnityEngine;

public static class Vibration
{
    public static void Vibrate()
    {
        if (PlayerPrefs.GetFloat("vibration") > 0f)
        {
            Handheld.Vibrate();
            Debug.Log("Vibrate");
        }
    }
}
