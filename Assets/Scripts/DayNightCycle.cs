using System.Collections;
using System.Collections.Generic;
using UnityEngine.Rendering.Universal;
using UnityEngine;

namespace WorldTime
{
    [RequireComponent(typeof(Light2D))]
    public class DayNightCycle : MonoBehaviour
    {
        public float duration = 5f;

        [SerializeField] private Gradient gradient;
        private Light2D light2d;
        private float startTime;

        private void Awake()
        {
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