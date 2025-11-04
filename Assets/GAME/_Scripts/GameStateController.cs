using UnityEngine;

public class GameStateController : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<BallController>(out BallController ballController) == false)
            return;

        ballController.gameObject.SetActive(false);
        Debug.Log("Вы победили!");
    }
}