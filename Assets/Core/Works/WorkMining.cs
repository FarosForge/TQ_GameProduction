using Cysharp.Threading.Tasks;
using Item;
using System;
using UnityEngine;

namespace Work
{
    public class WorkMining : IWork
    {
        public WorkMining(float productionTime)
        {
            ProductionTime = productionTime;
            ResourceCount = 1;
            Resources = new IResource[ResourceCount];
        }

        public IResource[] Resources { get; private set; }
        public bool InWorking { get; private set; }
        public float ProductionTime { get; private set; }
        public int ResourceCount { get; private set; }
        public Action OnStopWorking { get; set; }

        public void ResultWork(I_Item item)
        {
            if (!InWorking) return;

            Debug.Log("Mine " + item.ID);
            item.Add(1);
        }

        public void StartWork(IWorkData data)
        {
            switch (data)
            {
                case WorkMinigData work:
                    Resources[0] = work.resource;
                    Mining(work.resource);
                    break;
            }
        }

        public void StopWork()
        {
            InWorking = false;
        }

        private void Mining(IResource resource)
        {
            Debug.Log("Start mining ");
            InWorking = true;
            waitMinig(resource).Forget();
        }

        private async UniTaskVoid waitMinig(IResource resource)
        {
            while (InWorking)
            {
                await UniTask.Delay((int)ProductionTime * 1000);
                ResultWork(resource);
            }
        }
    }
}