using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class platform : MonoBehaviour
{
    public float speed = 200f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.left * Time.deltaTime * speed);

        if (transform.GetComponent<RectTransform>().localPosition.x < -1080)
        {

            foreach (Transform child in transform)
            {
                if (!child.gameObject.activeSelf)
                {
                    SceneManager.LoadScene("GameOver");
                    Debug.Log("Game is Over");
                    return;
                }
                child.gameObject.SetActive(false);
            }
            transform.GetComponent<RectTransform>().localPosition = new Vector3(1080, transform.GetComponent<RectTransform>().localPosition.y, transform.GetComponent<RectTransform>().localPosition.z);
        }

    }
}
