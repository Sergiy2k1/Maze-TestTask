using TMPro;
using UnityEngine;

namespace UI.Elements
{
    public class TimeCounter : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI timeText;
        private float _elapsedTime; 
        private bool _isCounting ; 

        private void Update()
        {
            if (_isCounting)
            {
                _elapsedTime += Time.deltaTime;
                UpdateTimeUI();
            }
        }

        private void UpdateTimeUI()
        {
            int minutes = Mathf.FloorToInt(_elapsedTime / 60F);
            int seconds = Mathf.FloorToInt(_elapsedTime % 60F);
            int milliseconds = Mathf.FloorToInt((_elapsedTime * 100F) % 100F);
            
            timeText.text = $"{minutes:00}:{seconds:00}:{milliseconds:00}";
        }

        public void PlayTimer()
        {
            _isCounting = true;
        }
        
        public void StopCounting()
        {
            _isCounting = false;
        }

        public void ResetTime()
        {
            _elapsedTime = 0f;
            _isCounting = true;
            UpdateTimeUI();
        }
    }
}