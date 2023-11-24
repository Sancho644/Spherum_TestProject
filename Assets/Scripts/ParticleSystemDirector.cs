using UnityEngine;

[RequireComponent(typeof(ParticleSystem))]
public class ParticleSystemDirector : MonoBehaviour
{
    private const int ForceValue = 10;

    [SerializeField] private Transform _target;
    [SerializeField] private ParticleSystem _particleSystem;

    private ParticleSystem.Particle[] particles;

    private void Start()
    {
        particles = new ParticleSystem.Particle[_particleSystem.particleCount];
    }

    private void Update()
    {
        DirectParticles();
    }

    private void DirectParticles()
    {
        _particleSystem.GetParticles(particles);

        for (int i = 0; i < particles.GetUpperBound(0); i++)
        {
            var force = (particles[i].startLifetime - particles[i].remainingLifetime) *
                        (ForceValue * Vector3.Distance(_target.position - transform.position, particles[i].position));

            particles[i].velocity = (_target.position - transform.position - particles[i].position).normalized * force;
        }

        _particleSystem.SetParticles(particles, particles.Length);
    }
}