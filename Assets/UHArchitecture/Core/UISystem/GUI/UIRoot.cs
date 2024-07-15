using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace UralHedgehog
{
    namespace UI
    {
        public class UIRoot : MonoBehaviour
        {
            [SerializeField] private Transform _wrapperPanels;
            [SerializeField] private Transform _wrapperWindows;
            [SerializeField] private WidgetStorage _storage;

            private List<IWidget> _list;

            private void Awake()
            {
                _list = new List<IWidget>();
            }

            public void Create<T>(string widgetName, T model)
            {
                foreach (var w in _storage.Widgets)
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
                widget?.Hide();
            }
            
            private void OnHide(IWidget widget)
            {
                widget.hide -= OnHide;
                _list.Remove(widget);
            }

            private static IWidget GetWidget(IEnumerable<IWidget> list, string name)
            {
                return list.LastOrDefault(widget => widget.Name.Equals(name));
            }
        }
    }
}