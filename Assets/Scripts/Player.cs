
using UnityEngine;
public class Player : MonoBehaviour
{

    public int score = 0;
    public void RecountScore() {
        score++;
        NextTurn.isLastWorded = true;
    }

}
