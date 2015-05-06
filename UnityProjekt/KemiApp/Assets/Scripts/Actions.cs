using UnityEngine;
using System.Collections;

public enum Actions
{
    nothing,
    openWorkstation,
    wentUpstairs,
    wentDownstairs,
    getItemsInbox,
    deliverItems
}

public static class CheckActions
{
    public static string ActionToString(Actions action)
    {
        switch (action)
        {
            case Actions.openWorkstation: return "open workstation";
            case Actions.wentUpstairs: return "go upstairs";
            case Actions.getItemsInbox: return "get items in inbox";
            case Actions.deliverItems: return "deliver items";
            default:
                return action.ToString();
        }
    }
}