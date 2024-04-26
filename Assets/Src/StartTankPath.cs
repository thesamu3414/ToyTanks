using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartTankPath : MonoBehaviour
{
    [SerializeField] Transform[] pathPoints;

    [SerializeField] private float speed;

    public Animator transition;
    public float transitionTime = 1f;

    private int pointsIndex;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("pathPoints length: " + pathPoints.Length);
        pointsIndex = 0;
        transform.position = pathPoints[pointsIndex].transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (pointsIndex < pathPoints.Length -1)
        {
            Debug.Log("position: " + transform.position + " next point: " + pathPoints[pointsIndex].transform.position + " index: " + pointsIndex);
            transform.position = Vector2.MoveTowards(transform.position, pathPoints[pointsIndex].transform.position, speed * Time.deltaTime);


            if (transform.position == pathPoints[pointsIndex].transform.position)
                pointsIndex++;
        }
        else if(pointsIndex == pathPoints.Length -1)
        {
            LoadNextScene();
        }
    }

    public void LoadNextScene()
    {
        StartCoroutine(LoadMyScene(SceneManager.GetActiveScene().buildIndex + 1));
    }

    IEnumerator LoadMyScene(int sceneIndex)
    {
        transition.SetTrigger("Start");
        Debug.Log("Start triggered");

        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene(sceneIndex);
    }
}
