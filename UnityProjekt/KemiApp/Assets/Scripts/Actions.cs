using UnityEngine;
using System.Collections;

// A class for easier use of the enumeration Actions down below
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

// An enumeration containing all possible actions in the game
public enum Actions
{
    nothing,
    openWorkstation,
    wentUpstairs,
    wentDownstairs,
    getItemsInbox,
    deliverItems,
    openCabinet,
    closeCabinet
}
