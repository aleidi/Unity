using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterShake : MonoBehaviour
{
    /// <summary>
    /// Maximum distance in each direction the transform
    /// with translate during shaking.
    /// </summary>
    [SerializeField]
    private Vector3 m_vMaxTranslationShake = Vector3.one;

    /// <summary>
    /// Maximum angle, in degrees, the transform will rotate
    /// during shaking.
    /// </summary>
    [SerializeField]
    private Vector3 m_vMaximumAngularShake = Vector3.one * 15;

    /// <summary>
    /// Frequency of the Perlin noise function. Higher values
    /// will result in faster shaking.
    /// </summary>
    [SerializeField]
    private float m_fFrequency = 15;

    /// <summary>
    /// <see cref="m_fTrauma"/> is taken to this power before
    /// shaking is applied. Higher values will result in a smoother
    /// falloff as m_fTrauma reduces.
    /// </summary>
    [SerializeField]
    private float m_fTraumaExponent = 1;

    /// <summary>
    /// Amount of m_fTrauma per second that is recovered.
    /// </summary>
    [SerializeField]
    private float m_fRecoverySpeed = 1;

    /// <summary>
    /// Value between 0 and 1 defining the current amount
    /// of stress this transform is enduring.
    /// </summary>
    private float m_fTrauma;

    private float m_fSeed;

    private void Awake()
    {
        m_fSeed = Random.value;
    }

    // Update is called once per frame
    void Update()
    {
        // Taking m_fTrauma to an exponent allows the ability to smoothen
        // out the transition from shaking to being static.
        float shake = Mathf.Pow(m_fTrauma, m_fTraumaExponent);

        // This x value of each Perlin noise sample is fixed,
        // allowing a vertical strip of noise to be sampled by each dimension
        // of the translational and rotational shake.
        // PerlinNoise returns a value in the 0...1 range; this is transformed to
        // be in the -1...1 range to ensure the shake travels in all directions.
        transform.localPosition = new Vector3(
            m_vMaxTranslationShake.x * (Mathf.PerlinNoise(m_fSeed, Time.time * m_fFrequency) * 2 - 1),
            m_vMaxTranslationShake.y * (Mathf.PerlinNoise(m_fSeed + 1, Time.time * m_fFrequency) * 2 - 1),
            m_vMaxTranslationShake.z * (Mathf.PerlinNoise(m_fSeed + 2, Time.time * m_fFrequency) * 2 - 1)
        ) * shake;

        m_fTrauma = Mathf.Clamp01(m_fTrauma - m_fRecoverySpeed * Time.deltaTime);
    }

    public void DoShake(float value)
    {
        m_fTrauma = value;
    }
}
