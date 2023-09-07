using AlephVault.Unity.DayLight.Core;
using UnityEngine;
using UnityEngine.UIElements;

namespace AlephVault.Unity.DayLight
{
    namespace Authoring
    {
        namespace Behaviours
        {
            /// <summary>
            ///   This behaviour allows setting the proper class(es)
            ///   in the chosen root element, so the UI refreshes
            ///   properly in real time.
            /// </summary>
            [RequireComponent(typeof(UIDocument))]
            public class DayLightAwareDocument : DayLightAware
            {
                // The related UIDocument component.
                private UIDocument document;

                /// <summary>
                ///   The class for the solar daylight type.
                /// </summary>
                [SerializeField]
                private string solarClass = "solar";

                /// <summary>
                ///   The class for the lunar daylight type.
                /// </summary>
                [SerializeField]
                private string lunarClass = "lunar";

                protected override void Awake()
                {
                    document = GetComponent<UIDocument>();
                    base.Awake();
                }

                protected void Start()
                {
                    OnDaylightChanged(DayLightSettings.Daylight);
                }

                /// <summary>
                ///   The in-Document name of the element that will change classes.
                /// </summary>
                protected virtual string RootElementName()
                {
                    return "Root";
                }
                
                protected override void OnDaylightChanged(DayLightSettings.DaylightType daylightType)
                {
                    VisualElement element = document.rootVisualElement.Q<VisualElement>(RootElementName());
                    element.RemoveFromClassList(solarClass);
                    element.RemoveFromClassList(lunarClass);
                    string ussClass = "";
                    switch (daylightType)
                    {
                        case DayLightSettings.DaylightType.Lunar:
                            ussClass = "lunar";
                            break;
                        default:
                            ussClass = "solar";
                            break;
                    }
                    element.AddToClassList(ussClass);
                }
            }
        }
    }
}