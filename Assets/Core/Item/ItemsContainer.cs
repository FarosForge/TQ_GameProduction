using Config;
using Save;
using System.Collections.Generic;

namespace Item
{
    public class ItemsContainer
    {
        private Dictionary<string, I_Item> itemsList = new();
        private Dictionary<string, IResource> resourcesList = new();

        private ItemsContainerConfig config;
        private SaveSystem saveSystem;

        public Dictionary<string, I_Item> ItemsList { get => itemsList; }
        public Dictionary<string, IResource> ResourcesList { get => resourcesList; }

        public ItemsContainer(ItemsContainerConfig config, SaveSystem saveSystem)
        {
            this.config = config;
            this.saveSystem = saveSystem;
        }

        public void Init()
        {
            foreach (var item in config.ItemsList)
            {
                CreateItem(item);
            }

            foreach (var res in config.ResourcesList)
            {
                CreateResource(res);
            }
        }

        private void CreateItem(ItemConfig item)
        {
            if (itemsList.ContainsKey(item.ID)) return;

            int count = saveSystem.data.items.Count > 0 && saveSystem != null ? saveSystem.data.items.Find(v => v.ID == item.ID).Count : 0;

            I_Item it = new Item(count, item, saveSystem);

            itemsList.Add(item.ID, it);
        }

        private void CreateResource(ItemConfig res)
        {
            if (resourcesList.ContainsKey(res.ID)) return;

            int count = saveSystem.data.items.Count > 0 ? saveSystem.data.items.Find(v => v.ID == res.ID).Count : 0;

            IResource it = new Resource(count, res, saveSystem);

            resourcesList.Add(res.ID, it);
        }

        public I_Item GetItem(string id)
        {
            return itemsList[id];
        }
    }
}