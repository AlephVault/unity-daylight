using UnityEngine;

namespace AlephVault.Unity.DayLight
{
    namespace Core
    {
        public class SampleDayLightSwitcher : MonoBehaviour
        {
            private float elapsedIntervalTime = 0f;
            private DayLightSettings.DaylightType dayLightType = DayLightSettings.DaylightType.Solar;

            // Start is called before the first frame update
            private void Start()
            {
                DayLightSettings.Daylight = dayLightType;
            }

            private void Update()
            {
                elapsedIntervalTime += Time.deltaTime;
                if (elapsedIntervalTime >= 1f)
                {
                    elapsedIntervalTime -= 1f;
                    dayLightType = dayLightType == DayLightSettings.DaylightType.Solar
                        ? DayLightSettings.DaylightType.Lunar
                        : DayLightSettings.DaylightType.Solar;
                    DayLightSettings.Daylight = dayLightType;
                }
            }
        }
    }
}
