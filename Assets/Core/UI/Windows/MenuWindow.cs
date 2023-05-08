using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class MenuWindow : UIWindow
{
    [SerializeField] private Transform buttonsGroup;
    [SerializeField] private Button startButton;
    [SerializeField] private GameModeSlot slotPrefab;

    private GameModesListConfig gameModes;
    private SessionManager session;

    [Inject]
    public void Construct(GameModesListConfig gameModes, SessionManager session)
    {
        this.session = session;
        this.gameModes = gameModes;
    }

    private void Start()
    {
        foreach (var mode in gameModes.List)
        {
            CreateSlot(mode);
        }
        session.SetGameMode(1);
        startButton.onClick.AddListener(() => session.Init(Deactivate));
    }

    private void CreateSlot(GameModeRef mode)
    {
        var slot = Instantiate(slotPrefab);
        slot.transform.SetParent(buttonsGroup);
        slot.transform.localScale = Vector3.one;

        slot.SetData
        (
            mode.ResourceBuildsCount,
            () => session.SetGameMode(mode.ResourceBuildsCount)
        );
    }
}
