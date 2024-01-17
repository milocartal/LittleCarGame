using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayMenuManager : MonoBehaviour
{

    public GameObject PlayMenuMainContainer;
    public GameObject CourseSimpleContainer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GoToCourseSimpleMenu()
    {
        CourseSimpleContainer.SetActive(true);
        PlayMenuMainContainer.SetActive(false);
    }

    public void Return_to_PlayMenu ()
    {
        CourseSimpleContainer.SetActive(false);
        PlayMenuMainContainer.SetActive(true);
    }
}
