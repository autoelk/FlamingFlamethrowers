using UnityEngine;

public class Starfield : MonoBehaviour 
{

    public int maxStars = 1000;
    public int universeSize = 5;

    private ParticleSystem.Particle[] points;

    private ParticleSystem starParticleSystem;

    private void Create()
    {

        points = new ParticleSystem.Particle[maxStars];

        for (int i = 0; i < maxStars; i++)
        {
            points[i].position = Random.insideUnitSphere * universeSize;
            points[i].startSize = Random.Range(0.05f, 0.05f);
            points[i].startColor = new Color(1, 1, 1, 1);
        }

        starParticleSystem = gameObject.GetComponent<ParticleSystem>();

        starParticleSystem.SetParticles(points, points.Length);
    }

    void Start()
    {
        Create();
    }

    void Update()
    {
        //You can access the particleSystem here if you wish
    }
}