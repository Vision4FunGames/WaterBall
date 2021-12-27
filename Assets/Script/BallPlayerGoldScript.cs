using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class BallPlayerGoldScript : MonoBehaviour
{
    Canvas canvasMain;

    BallPlayer bl;
    int FinishXPos;
    private void Start()
    {
        canvasMain = GameObject.FindGameObjectWithTag("MainCanvas").GetComponent<Canvas>();
        bl = GetComponent<BallPlayer>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Coin"))
        {
            GameObject current = Instantiate(Resources.Load<GameObject>("GoldImage"), canvasMain.transform);
            Destroy(other.gameObject);
            Vector3 goldpos = Camera.main.WorldToScreenPoint(this.transform.position);
            current.transform.position = goldpos;
            current.transform.DOLocalMove(canvasMain.transform.GetChild(0).transform.localPosition, 1f).OnComplete(() =>
            {
                GameManager.instance.scoreValue += 1;
                GameManager.instance.scoreText.text = ": " + GameManager.instance.scoreValue.ToString();
                Destroy(current);
            });
        }
        if (other.CompareTag("finishstack"))
        {
            other.GetComponent<MeshRenderer>().enabled = false;
            other.transform.GetChild(0).gameObject.SetActive(true);
            other.transform.GetChild(1).gameObject.SetActive(false);

        }
        if (other.CompareTag("Finish"))
        {
            FinishXPos = GameManager.instance.scoreValue * 10;

            if (FinishXPos > 150)
            {
                FinishXPos = 150;
            }
            GetComponent<Rigidbody>().isKinematic = true;
            CameraScriptFinish cs = FindObjectOfType<CameraScriptFinish>();
            cs.FinishActive();
            transform.DOLocalRotateQuaternion(Quaternion.Euler(0, 180, 0), 1f).OnComplete(() =>
            {
              

            });
            transform.DOMove(other.transform.position - new Vector3(0, -2, 0), 1f).OnComplete(() =>
            {
                bl.particleEffectWater.Play();
                transform.DOLocalMoveX(transform.localPosition.x - FinishXPos, 5f).OnComplete(() =>
                {
                    bl.particleEffectWater.Stop();
                    GameManager.instance.WinGame();
                });
            });
            //GameManager.instance.WinGame();
        }
        if (other.CompareTag("camur"))
        {
            GameObject current = Instantiate(Resources.Load<GameObject>("CamurImage"), canvasMain.transform);
            Destroy(other.gameObject);
            Vector3 goldpos = Camera.main.WorldToScreenPoint(this.transform.position);
            current.transform.position = goldpos;
            current.transform.DOLocalMove(canvasMain.transform.GetChild(0).transform.localPosition, 1f).OnComplete(() =>
            {
                GameManager.instance.scoreValue -= 1;
                GameManager.instance.scoreText.text = ": " + GameManager.instance.scoreValue.ToString();
                Destroy(current);
            });
        }
    }
    //private void OnCollisionEnter(Collision collision)
    //{
    //    if (collision.transform.CompareTag("camur"))
    //    {
    //        GameObject current = Instantiate(Resources.Load<GameObject>("CamurImage"), canvasMain.transform);
    //        Destroy(collision.gameObject);
    //        Vector3 goldpos = Camera.main.WorldToScreenPoint(this.transform.position);
    //        current.transform.position = goldpos;
    //        current.transform.DOLocalMove(canvasMain.transform.GetChild(0).transform.localPosition, 1f).OnComplete(() =>
    //        {
    //            GameManager.instance.scoreValue -= 1;
    //            GameManager.instance.scoreText.text = ": " + GameManager.instance.scoreValue.ToString();
    //            Destroy(current);
    //        });
    //    }
    //}
}
