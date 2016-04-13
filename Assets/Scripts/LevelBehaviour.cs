using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LevelBehaviour : MonoBehaviour
{
    public GameObject Highscore;
    public GameObject Trudy;
    public GameObject Platform;
    public GameObject FinalPlatform;

    private float MetersFromGround = 0;
    private Text UIHighscore;

	// Use this for initialization
	void Start ()
    {
        float PositionCurrentX = -3.0f;
        float PositionCurrentY = 4.0f;
        float PositionX = 0.0f;
        float PositionY = 0.0f;

        for (int i = 0; i < 20; ++i)
        {
            Instantiate(Platform, new Vector3(PositionCurrentX, PositionCurrentY, 0), Quaternion.identity);

            PositionX = Random.Range(-5.0f, 5.0f);
            PositionY = Random.Range(1.0f, 3.0f);

            PositionCurrentX  = PositionX;
            PositionCurrentY += PositionY;
        }

        Instantiate(FinalPlatform, new Vector3(PositionCurrentX, PositionCurrentY, 0), Quaternion.identity);

        UIHighscore = Highscore.GetComponent<Text>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        MetersFromGround = Mathf.Max(MetersFromGround, Trudy.transform.position.y);

        UIHighscore.text = ((int)MetersFromGround).ToString();
    }
}
