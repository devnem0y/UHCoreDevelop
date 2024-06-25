using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace UralHedgehog
{
    namespace UI
    {
        public class UIHandler : MonoBehaviour
        {
            [SerializeField] private Transform _wrapperPanels;
            [SerializeField] private Transform _wrapperWindows;
            [SerializeField, Tooltip("Для того чтобы все работало правильно, в префабе виджета, скрипт виджета должен идти вторым после RectTransform-а")]
            private MonoBehaviour[] _widgets;

            private List<IWidget> _list;

            private void Awake()
            {
                _list = new List<IWidget>();
            }

            public void Create<T>(string widgetName, T model)
            {
                foreach (var w in _widgets)
                {
                    if (!w.name.Equals(widgetName)) continue;
                    var widgetT = (Widget<T>)w;
                    var widget = Instantiate(widgetT, widgetT.Type == Type.WINDOW ? _wrapperWindows : _wrapperPanels);
                    widget.transform.name = widgetName;
                    var WidgetComponent = (Widget<T>)widget.GetComponent(widgetName);
                    _list.Add(WidgetComponent);
                    widget.Init(model);
                    widget.hide += OnHide;
                    widget.Show();
                }
            }

            public void Kill(string widgetName)
            {
                var widget = GetWidget(_list, widgetName);
                widget.hide -= OnHide;
                _list.Remove(widget);
            }

            private void OnHide(IWidget widget)
            {
                Kill(widget.Name);
            }

            private static IWidget GetWidget(IEnumerable<IWidget> list, string name)
            {
                return list.LastOrDefault(window => window.Name.Equals(name));
            }
        }
    }
}