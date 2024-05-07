using System.Collections;
using System.Collections.Generic;
using UnityEngine.Rendering.Universal;
using UnityEngine;
using UnityEngine.UI;

namespace WorldTime
{
    [RequireComponent(typeof(Light2D))]
    public class DayNightCycle : MonoBehaviour
    {
        [SerializeField] Image akrep;
        [SerializeField] Image yelkovan;

        public float duration = 5f;

        [SerializeField] private Gradient gradient;
        private Light2D light2d;
        private float startTime;

        private void Awake()
        {
            float akrepRot = akrep.transform.rotation.z;
            float yelkovanRot = akrep.transform.rotation.z;

            light2d = GetComponent<Light2D>();
            startTime = Time.time;
        }

        // Update is called once per frame
        void Update()
        {
            var timeElapsed = Time.time - startTime;
            var percentage = Mathf.Sin(timeElapsed / duration * Mathf.PI * 2) * 0.5f + 0.5f;
            percentage = Mathf.Clamp01(percentage);
            light2d.color = gradient.Evaluate(percentage);
        }
    }
}