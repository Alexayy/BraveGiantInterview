using UnityEngine;

public class LevelController : MonoBehaviour
{
    private int pointsToFinish;
    private int currentPoints;
    public GameObject pieces;
    public GameObject particleControll;

    private void Awake()
    {
        particleControll.GetComponentInChildren<ParticleSystem>().Pause();
    }

    private void Start()
    {
        pointsToFinish = pieces.transform.childCount - 1;
    }

    public void AddPoints()
    {
        if (currentPoints >= pointsToFinish)
        {
            particleControll.GetComponentInChildren<ParticleSystem>().Play();
        }
        
        currentPoints++;
    }
}