using System.Collections.Generic;
using UnityEngine;

namespace Building
{
    public class BuildingsViewContainer : MonoBehaviour
    {
        [SerializeField] private List<ResorceBuilding> resorceBuildings;
        [SerializeField] private List<ProductionBuilding> productionBuildings;

        public List<ResorceBuilding> ResorceBuildings { get => resorceBuildings; }
        public List<ProductionBuilding> ProductionBuildings { get => productionBuildings; }

        public void SetActiveResourceBuildings(int val)
        {
            DeactivateResourceBuildings();

            for (int i = 0; i < val; i++)
            {
                resorceBuildings[i].gameObject.SetActive(true);
            }
        }

        private void DeactivateResourceBuildings()
        {
            foreach (var build in resorceBuildings)
            {
                build.gameObject.SetActive(false);
            }
        }
    }
}