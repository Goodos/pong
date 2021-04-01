using UnityEngine;

public class SaveController : MonoBehaviour
{
    public static void SetBestScore(float score)
    {
        PlayerPrefs.SetFloat("BestScore", score);
    }

    public static float GetBestScore() { return PlayerPrefs.GetFloat("BestScore", 0f); }

    public static void SetBallColor(Color color)
    {
        float H, S, V;
        Color.RGBToHSV(color, out H, out S, out V);
        PlayerPrefs.SetFloat("H", H);
    }

    public static float GetBallColor()
    {
        return PlayerPrefs.GetFloat("H", 0);
    }
}
