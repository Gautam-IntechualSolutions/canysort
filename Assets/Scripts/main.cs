using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class main : MonoBehaviour
{

    public GameObject music, volume;
    bool m=true, v=true;
    // Start is called before the first frame update
    void Start()
    {
        GameObject[] objects = GameObject.FindGameObjectsWithTag("AudioManager");

        if (objects.Length > 1)
            Destroy(objects[0]);

        if (PlayerPrefs.GetInt("Music") == 0)
        {
            music.GetComponent<Image>().sprite = Resources.Load<Sprite>("Sprites/audiotrack");
            AudioManager.Instance.PlayBackgroudmusic();

        }
        else
        {
            AudioManager.Instance.StopBackgroudmusic();
            music.GetComponent<Image>().sprite = Resources.Load<Sprite>("Sprites/audiotrackoff");
        }


        if (PlayerPrefs.GetInt("Volume") == 0)
            volume.GetComponent<Image>().sprite = Resources.Load<Sprite>("Sprites/volume_down");
        else
            volume.GetComponent<Image>().sprite = Resources.Load<Sprite>("Sprites/volume_off");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void onClickMusic()
    {
        if (PlayerPrefs.GetInt("Music") == 0)
        {
            PlayerPrefs.SetInt("Music", 1);
            music.GetComponent<Image>().sprite = Resources.Load<Sprite>("Sprites/audiotrackoff");
            AudioManager.Instance.StopBackgroudmusic();

        }
        else
        {
            PlayerPrefs.SetInt("Music", 0);
            music.GetComponent<Image>().sprite = Resources.Load<Sprite>("Sprites/audiotrack");
            AudioManager.Instance.PlayBackgroudmusic();

        }  

    }
    public void onClickVolume()
    {
        if (PlayerPrefs.GetInt("Volume") == 0)
        {
            PlayerPrefs.SetInt("Volume", 1);
            volume.GetComponent<Image>().sprite = Resources.Load<Sprite>("Sprites/volume_off");
        }
        else
        {
            PlayerPrefs.SetInt("Volume", 0);
            volume.GetComponent<Image>().sprite = Resources.Load<Sprite>("Sprites/volume_down");

        }

    }
    public void OnStartGame()
    {
        SceneManager.LoadScene("GameScene");
    }
}

