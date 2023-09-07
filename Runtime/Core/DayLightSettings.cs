using System;
using UnityEngine;

namespace AlephVault.Unity.DayLight
{
    namespace Core
    {
        /// <summary>
        ///   Tracks the application-wide daylight
        ///   settings for all the behaviours and
        ///   the UI elements.
        /// </summary>
        public static class DayLightSettings
        {
            private const string DaylightTypeKey = "AlephVault.Unity.Daylight.DaylightType";

            /// <summary>
            ///   The daylight type.
            /// </summary>
            public enum DaylightType
            {
                Solar = 0,
                Lunar = 2
            }

            /// <summary>
            ///   The current daylight setting.
            /// </summary>
            public static DaylightType Daylight
            {
                set
                {
                    PlayerPrefs.SetInt(DaylightTypeKey, (int) value);
                    DaylightChanged?.Invoke(value);
                }
                get
                {
                    DaylightType value = (DaylightType) PlayerPrefs.GetInt(DaylightTypeKey, 0);
                    if (!Enum.IsDefined(typeof(DaylightType), value)) value = DaylightType.Solar;
                    return value;
                }
            }

            /// <summary>
            ///   A callback that tells whether the
            ///   daylight setting changed or not.
            /// </summary>
            public static Action<DaylightType> DaylightChanged = null;
        }
    }
}
