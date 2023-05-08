using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorkProductionData : IWorkData
{
    public IResource[] resources;
    public int RecipeID;
    public SessionManager session;

    public WorkProductionData(IResource[] resources, int recipeID, SessionManager session)
    {
        this.resources = resources;
        RecipeID = recipeID;
        this.session = session;
    }
}
