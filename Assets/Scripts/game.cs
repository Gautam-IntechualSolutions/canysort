using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class game : MonoBehaviour
{

    float startPosx, endPosx;
    public Text Score;
    public List<GameObject> candies;
    public List<GameObject> Bottom;

    public List<GameObject> BottomCandies;
    List<string> candieslist = new List<string>();
    public int totalCandy = 3;
    List<string> candyname = new List<string>();

    bool IsDrag;
    int i = 0;
    int BottomCandyindex;

    // Start is called before the first frame update
    void Start()
    {
        
        BottomCandyindex = 0;
        IsDrag = false;
        candieslist.Add("Sprites/Candy_1");
        candieslist.Add("Sprites/Candy_2");
        candieslist.Add("Sprites/Candy_3");
        for (int i = 0; i < candies.Count; i++)
        {
            candyname.Add(candieslist[Random.Range(0, 3)]);
            candies[i].GetComponent<Image>().sprite = Resources.Load<Sprite>(candyname[i]);

        }
        for (int i = 0; i < totalCandy; i++)
        {
            candies[i].SetActive(false);
        }
    }

    void colorChanage()
    {
        for (i = totalCandy; i <= 8; i++)
        {
            if (i != 8)
            {
                candies[i].GetComponent<Image>().sprite = Resources.Load<Sprite>(candyname[i + 1]);
            }
            else
            {
                for (int j = totalCandy; j < 8; j++)
                {
                    candyname[j] = candyname[j + 1];
                }
                candyname[8] = candieslist[Random.Range(0, 3)];
                candies[i].GetComponent<Image>().sprite = Resources.Load<Sprite>(candyname[i]);
            }
        }
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            IsDrag = true;
            startPosx = Input.mousePosition.x;
        }
        //Add candy for boxplatform

        if (Input.GetMouseButtonUp(0) && IsDrag)
        {
            endPosx = Input.mousePosition.x;
            //if mouse drag in x direction
            if ((endPosx - startPosx) > 0.50)
            {
                if (totalCandy >= 3)
                {
                    //not drag mouse when any candy on outside of pipe
                    IsDrag = false;
                    return;
                }

                Debug.Log("CandYPlatform " + totalCandy);

                int checkIndex;

                if (BottomCandyindex <= 2)
                    checkIndex = 0;
                else if (BottomCandyindex <= 4)
                    checkIndex = 1;
                else
                    checkIndex = 2;

                if ((Bottom[checkIndex].GetComponent<RectTransform>().localPosition.x > -1080 && Bottom[checkIndex].GetComponent<RectTransform>().localPosition.x < 1000) && !BottomCandies[BottomCandyindex].activeSelf)
                {
                    AudioManager.Instance.CandySwipe();

                    if (BottomCandyindex == 0)
                    {
                        if (totalCandy != 1)
                        {
                            SceneManager.LoadScene("GameOver");
                            return;
                        }
                    }
                    else if (BottomCandyindex == 2)
                    {

                        if (totalCandy != 2)
                        {
                            SceneManager.LoadScene("GameOver");
                            return;
                        }
                    }
                    else if (BottomCandyindex == 3)
                    {

                        if (totalCandy != 0)
                        {
                            SceneManager.LoadScene("GameOver");
                            return;
                        }
                            
                    }

                    for (int i = totalCandy; i <= 2; i++)
                    {
                        BottomCandies[BottomCandyindex].SetActive(true);
                        BottomCandies[BottomCandyindex].GetComponent<Image>().sprite = Resources.Load<Sprite>(candyname[totalCandy]);
                        candies[totalCandy].SetActive(false);
                        BottomCandyindex++;

                        if (BottomCandyindex == 2 || BottomCandyindex == 3 || BottomCandyindex == 6)
                        {
                            GameManager.Instance.ScoreCounter++;
                            AudioManager.Instance.ScoreScound();

                            if (GameManager.Instance.ScoreCounter % 3 == 0)
                                GameManager.Instance.speed = GameManager.Instance.speed + 10.0f;

                            Score.text = "Score : " + GameManager.Instance.ScoreCounter++;

                        }

                        if (BottomCandyindex == 6)
                            BottomCandyindex = 0;

                        totalCandy++;
                    }
                    // Fill



                }
                return;

            }
        }
        if (Input.GetMouseButtonUp(0) && totalCandy != 0)
        {
            AudioManager.Instance.TapCandy();
            totalCandy--;
            candies[totalCandy].SetActive(true);
            colorChanage();
        }
    }
}