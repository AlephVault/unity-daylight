using AlephVault.Unity.DayLight.Core;
using UnityEngine;

namespace AlephVault.Unity.DayLight
{
    namespace Authoring
    {
        namespace Behaviours
        {
            /// <summary>
            ///   Daylight-aware behaviours are here. This typically
            ///   applies to UI elements, but can apply to other ones
            ///   as well (e.g. a background).
            /// </summary>
            public abstract class DayLightAware : MonoBehaviour
            {
                protected virtual void Awake()
                {
                    DayLightSettings.DaylightChanged += OnDaylightChanged;
                }

                protected virtual  void OnDestroy()
                {
                    DayLightSettings.DaylightChanged -= OnDaylightChanged;
                }

                protected abstract void OnDaylightChanged(DayLightSettings.DaylightType daylightType);
            }
        }
    }
}