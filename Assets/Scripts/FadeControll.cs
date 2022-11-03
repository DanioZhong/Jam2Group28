using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FadeControll : MonoBehaviour
{

    [HideInInspector]
    public Animator anim;
    
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKeyDown("1"))
        //{
        //    StartCoroutine(fadeoutEnd());
        //}
    }

    [HideInInspector]
    public IEnumerator fadeoutEnd()
    {
        anim.Play("Fadeout");
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene(1);
    }


}
