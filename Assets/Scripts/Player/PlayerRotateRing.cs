using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//function responsible for rotating the player's neutraliser ring
public class PlayerRotateRing : MonoBehaviour
{
    int currRing = 0;
    //right now just changing the UI text, swap to render to texture of the real ring instead
    [SerializeField] Text ringUITextLeft, ringUITextMiddle, ringUITextRight;

    public int CurrRing { get => currRing; }

    private void Start()
    {
        AssignTextToScreens(currRing);
    }
    //up the rotation of the ring - if it's bigger than 9, go back to 0
    public void RotateRingUp()
    {
        currRing++;
        if (currRing > 9)
            currRing = 0;
        AssignTextToScreens(currRing);
    }
    //down the rotation of the ring - if it's less than 0, go back to 9
    public void RotateRingDown()
    {
        currRing--;
        if (currRing < 0)
            currRing = 9;
        AssignTextToScreens(currRing);
    }


    void AssignTextToScreens(int number)
    {
        AssignTextToOneScreen(ringUITextLeft, number - 1);
        AssignTextToOneScreen(ringUITextMiddle, number);
        AssignTextToOneScreen(ringUITextRight, number + 1);
    }

    void AssignTextToOneScreen(Text text, int number)
    {
        if (number > 9)
            number -= 10;
        else if (number < 0)
            number += 10;

        text.text = number.ToString();
    }
}
