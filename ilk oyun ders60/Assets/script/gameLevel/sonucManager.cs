using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class sonucManager : MonoBehaviour
{
    public void oyunayenidenbasla()
    {
        SceneManager.LoadScene("gamelevel");
    }
    public void anamenu()
    {
        SceneManager.LoadScene("men� level");
    }


}
