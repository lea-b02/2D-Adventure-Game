using System.Collections;
using UnityEngine;

public class PlayerEffect : MonoBehaviour
{

    public void AddSpeed(int speedGiven , float speedDuration)
    {
        PlayerMove.instanceMove.moveSpeed += speedGiven;
        StartCoroutine(RemoveSpeed(speedGiven,speedDuration));

    }

    public IEnumerator RemoveSpeed(int speedGiven, float speedDuration)
    {
        yield return new WaitForSeconds(speedDuration);
        PlayerMove.instanceMove.moveSpeed -= speedGiven;

    }
}
