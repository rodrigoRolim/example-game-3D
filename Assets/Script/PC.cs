using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PC : MonoBehaviour
{
    public float velocidade;
    public float velRot;
    private Rigidbody rbd;
    private Quaternion rotOriginal;
    private float rotMX=0;
    public GameObject gateway_L, gateway_R;
    public HealthScript health;
    public ScoreScript score;
    public Vector3 pos_i;
    public int lifes;
    public int scores;
    public GameObject[] ghosts;
    private Color[] initial_colors = new Color[4];

    void Start()
    {
        Application.targetFrameRate = 300;
        initPC();
        initLifes();
        initScore();
        catchColors();
        
    }
    private void catchColors() {

        for (int i = 0; i < 4; i++) {
            initial_colors[i] = ghosts[i].GetComponent<Renderer>().material.color;
        }
    }
    void initPC() {
        velRot = 0.1f;
        velocidade = 1.3f;
        rbd = GetComponent<Rigidbody>();
        pos_i = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        rotOriginal = transform.localRotation;
    }
    void initLifes() {
        Instantiate(health);
        lifes = 3;
        health.setLifes(lifes);
    }
    void initScore() {
        Instantiate(score);
        scores = 0;
        score.setScore(0);
    }
    // Update is called once per frame
    void Update()
    {
        moviments();   
        gateWays();
    }
    void OnTriggerEnter(Collider col) {
        if (col.gameObject.tag == "enemy" && health.getLifes() > 0) {

            health.decreasingLife(lifes);
            lifes = health.getLifes();
            rebackPositionPC();
        } else if (col.gameObject.tag == "littlePill")  {

            updateBoardAndDestroy(col);
        } else if (col.gameObject.tag == "bigPill"){

            updateBoardAndDestroy(col);
            changeGhost();
        } else if (col.gameObject.tag == "destructible"){

            score.increasingScoreGhost(scores);
            scores = score.getScore();
        } else {

            SceneManager.LoadScene(2);
        }
        
    }
    private void updateBoardAndDestroy(Collider col) {
        score.increasingScorePill(scores);
        scores = score.getScore();
        Destroy(col.gameObject);
    }
    private void changeGhost() {
        
        for (int i = 0; i < 4; i++) {
            ghosts[i].GetComponent<Renderer>().material.color = new Color(0,0,1,1);
            ghosts[i].gameObject.tag = "destructible";
        }

        StartCoroutine(rebackPositionGhost());
    
    }
    private IEnumerator rebackPositionGhost() {

        yield return new WaitForSeconds(7);
        for(int i = 0; i < 4; i++) {
            ghosts[i].GetComponent<Renderer>().material.color = initial_colors[i];
            ghosts[i].gameObject.tag = "enemy";
        }
    } 
    void rebackPositionPC() {
        gameObject.transform.position = pos_i;
    }
    void gateWays() {
        if (transform.position.x > gateway_R.transform.position.x) {
            transform.position = new Vector3(gateway_L.transform.position.x, transform.position.y, transform.position.z);
        } else if (transform.position.x < gateway_L.transform.position.x) {
            transform.position = new Vector3(gateway_R.transform.position.x, transform.position.y, transform.position.z);
        }
    }
    void moviments() {
        float moveF = Input.GetAxis("Vertical");
        rotMX += Input.GetAxis("Horizontal");
    
        Quaternion lado = Quaternion.AngleAxis(rotMX*2,Vector3.up);
        transform.localRotation = rotOriginal * lado ;

        rbd.velocity = transform.TransformDirection(new Vector3(0, 0, moveF * velocidade));

        transform.Rotate(new Vector3(0, velRot * Time.deltaTime, 0));
    }
}
