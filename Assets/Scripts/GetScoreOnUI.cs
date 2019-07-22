using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//works in stage 3 - gets the data from KeepScore and gets them on the UI texts
public class GetScoreOnUI : MonoBehaviour
{
    KeepScore keep;
    [SerializeField] Text time1, time2, perfectRooms, scoreTime1, scoreTime2, perfectRoomsScore;
    [SerializeField] Text missed, missedScore, overshot, overshotScore, rotation, rotationScore, livesLost, livesLostScore;
    [SerializeField] Text finalScoreText;
    private void Start()
    {
        //find object of type is not a perfect solution, but since it's the only object of this type in scene and it goes through different scenes, it's the simplest one
        keep = FindObjectOfType<KeepScore>();
        PutUIScore();
    }
    void PutUIScore()
    {
        //put the bonuses and erros on the UI
        time1.text = keep.Stage1time.ToString("F1");
        time2.text = keep.Stage2time.ToString("F1");
        perfectRooms.text = keep.PerfectRoomsDone.ToString();
        missed.text = keep.WallsMissed.ToString();
        overshot.text = keep.WallsShotMultiple.ToString();
        rotation.text = keep.WallsShotWithWrong.ToString();
        livesLost.text = keep.LivesLost.ToString();

        int finalScore = 0;

        //points for stage1 time
        int partialScore = (int)((1 / keep.Stage1time) * 1000);
        scoreTime1.text = partialScore.ToString();
        finalScore += partialScore;

        //points for stage2 time
        partialScore = (int)((1 / keep.Stage2time) * 1000);
        scoreTime2.text = partialScore.ToString();
        finalScore += partialScore;

        //points for perfect rooms
        partialScore = keep.PerfectRoomsDone * 100;
        perfectRoomsScore.text = partialScore.ToString();
        finalScore += partialScore;

        //points for missed walls
        partialScore = keep.WallsMissed * 20;
        missedScore.text = partialScore.ToString();
        finalScore -= partialScore;

        //points for overshot walls
        partialScore = keep.WallsShotMultiple * 10;
        overshotScore.text = partialScore.ToString();
        finalScore -= partialScore;

        //points for lost lives
        partialScore = keep.LivesLost * 50;
        livesLostScore.text = partialScore.ToString();
        finalScore -= partialScore;

        //points for wrong rotation
        partialScore = keep.WallsShotWithWrong * 15;
        rotationScore.text = partialScore.ToString();
        finalScore -= partialScore;

        //final score text
        finalScoreText.text = finalScore.ToString();
    }
}
