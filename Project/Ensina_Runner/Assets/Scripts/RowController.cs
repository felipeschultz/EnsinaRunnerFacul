using UnityEngine;
using UnityEngine.UI;

public class RowController : MonoBehaviour
{
    public Text nickNameText;
    public Text distanceText;
    public Text correctAnswerText;

    private Vector3 canvasDistance = new Vector3(0, -54, 0);

    public Transform rowTransform;

    public void UpdatePlayer(Player player, int index)
    {
        nickNameText.text = player.Nickname;
        distanceText.text = player.Distance.ToString();
        correctAnswerText.text = player.CorrectAnswers.ToString();

        rowTransform.position += (index * canvasDistance);
    }
}