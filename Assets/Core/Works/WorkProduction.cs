using Config;
using Cysharp.Threading.Tasks;
using Game;
using Item;
using System;
using UnityEngine;

namespace Work
{
    public class WorkProduction : IWork
    {
        private RecipeConfig recipe;
        private SessionManager session;

        public WorkProduction(float productionTime)
        {
            ProductionTime = productionTime;
            ResourceCount = 2;
            Resources = new IResource[ResourceCount];
        }

        public bool InWorking { get; private set; }

        public float ProductionTime { get; private set; }

        public IResource[] Resources { get; private set; }

        public int ResourceCount { get; private set; }
        public Action OnStopWorking { get; set; }

        public void ResultWork(I_Item item)
        {
            if (!InWorking) return;

            Debug.Log("Product " + item.ID);

            foreach (var res in recipe.Resources)
            {
                session.ItemsContainer.ResourcesList[res.ID].Remove(1);
            }

            item.Add(1);
        }

        public void StartWork(IWorkData data)
        {
            switch (data)
            {
                case WorkProductionData work:
                    for (int i = 0; i < work.resources.Length; i++)
                    {
                        Resources[i] = work.resources[i];
                        if (Resources[i].Count <= 0) return;
                    }

                    session = work.session;
                    recipe = session.RecipesList.Recipes[work.RecipeID];

                    Production(session.ItemsContainer.GetItem(recipe.GetResult(GetResources()).ID));
                    break;
            }
        }

        public void StopWork()
        {
            InWorking = false;
            OnStopWorking?.Invoke();
        }

        private void Production(I_Item item)
        {
            Debug.Log("Start crafting");
            InWorking = true;
            waitMinig(item).Forget();
        }

        private async UniTaskVoid waitMinig(I_Item item)
        {
            while (InWorking)
            {
                foreach (var res in recipe.Resources)
                {
                    if (session.ItemsContainer.ResourcesList[res.ID].Count <= 0)
                    {
                        StopWork();
                    }
                }

                await UniTask.Delay((int)ProductionTime * 1000);
                ResultWork(item);
            }
        }

        private string[] GetResources()
        {
            string[] val = new string[Resources.Length];

            for (int i = 0; i < Resources.Length; i++)
            {
                val[i] = Resources[i].ID;
            }

            return val;
        }
    }
}