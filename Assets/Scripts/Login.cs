using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Login : CameraMove
{
    public Animator animator;
    AsyncOperation op;
    HologramBall hologramBall;
    public GameObject substationPos;
    public GameObject Sphere;
    public float moveDuration = 4f;
    public float rimDuration = 1f;
    // Start is called before the first frame update
    void Start()
    {
        op = SceneManager.LoadSceneAsync("SampleScene");
        op.allowSceneActivation = false;
        hologramBall = HologramBall.instance;
    }
    public void LoginSuccess() {
        op.allowSceneActivation = true;
    }
    void RimAnim() {
        animator.SetTrigger("Login");
    }
    void GotoSecondPlace() {
        moveTo(substationPos.transform.position, moveDuration / 3).SetEase(Ease.OutExpo).OnComplete(RimAnim);
    }
    void GotoFirstPlace() {
        Vector3 firstPlace = substationPos.transform.position + (substationPos.transform.position - Sphere.transform.position).normalized * 2;
        moveTo(firstPlace, moveDuration * 2 / 3).OnComplete(GotoSecondPlace);
    }
    void LoginAnim() {
        hologramBall.rotate = false;
        Quaternion quaternion = transform.rotation;
        Vector3 dir = (Sphere.transform.position - substationPos.transform.position).normalized;
        quaternion.SetLookRotation(dir);
        transform.DORotate(quaternion.eulerAngles, moveDuration);
        GotoFirstPlace();
    }
    public void LoginFunc() {
        //animator.SetTrigger("Login");
        LoginAnim();
        Invoke(nameof(LoginSuccess), moveDuration + rimDuration);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
