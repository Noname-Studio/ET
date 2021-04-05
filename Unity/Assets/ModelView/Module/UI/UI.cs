using System.Collections.Generic;
using UnityEngine;

namespace ET
{
    public class UIAwakeSystem: AwakeSystem<UI, string, GameObject>
    {
        public override void Awake(UI self, string name, GameObject gameObject)
        {
            self.Awake(name, gameObject);
        }
    }

    public sealed class UI: Entity
    {
        public GameObject GameObject;

        public string Name { get; private set; }

        public Dictionary<string, UI> nameChildren = new Dictionary<string, UI>();

        public void Awake(string name, GameObject gameObject)
        {
            nameChildren.Clear();
            gameObject.AddComponent<ComponentView>().Component = this;
            gameObject.layer = LayerMask.NameToLayer(LayerNames.UI);
            Name = name;
            GameObject = gameObject;
        }

        public override void Dispose()
        {
            if (IsDisposed)
            {
                return;
            }

            base.Dispose();

            foreach (UI ui in nameChildren.Values)
            {
                ui.Dispose();
            }

            UnityEngine.Object.Destroy(GameObject);
            nameChildren.Clear();
        }

        public void SetAsFirstSibling()
        {
            GameObject.transform.SetAsFirstSibling();
        }

        public void Add(UI ui)
        {
            nameChildren.Add(ui.Name, ui);
            ui.Parent = this;
        }

        public void Remove(string name)
        {
            UI ui;
            if (!nameChildren.TryGetValue(name, out ui))
            {
                return;
            }

            nameChildren.Remove(name);
            ui.Dispose();
        }

        public UI Get(string name)
        {
            UI child;
            if (nameChildren.TryGetValue(name, out child))
            {
                return child;
            }

            GameObject childGameObject = GameObject.transform.Find(name)?.gameObject;
            if (childGameObject == null)
            {
                return null;
            }

            child = EntityFactory.Create<UI, string, GameObject>(Domain, name, childGameObject);
            Add(child);
            return child;
        }
    }
}