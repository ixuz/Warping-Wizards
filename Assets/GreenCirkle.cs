using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GreenCirkle : MonoBehaviour {

    public GameObject BloodExplosion;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            AudioManager.instance.PlaySfx("StartMobSpawners");
            Instantiate(BloodExplosion, transform.position, transform.rotation);

      //SceneManager.LoadScene("VictoryScene");
      StartCoroutine(delayedLoad());
        }
    }

  IEnumerator delayedLoad() {
    yield return new WaitForSeconds(0.5f);
    FadeScreen.instance.LoadScene("VictoryScene");
  }

}
