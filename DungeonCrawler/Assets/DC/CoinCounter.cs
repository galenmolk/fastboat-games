using TMPro;
using UnityEngine;

namespace DC
{
     public class CoinCounter : MonoBehaviour
     {
          public TextMeshProUGUI coinCounterText;
          private int count;
     
          private void OnEnable()
          {
               coinCounterText.text = count.ToString();
               Coin.OnCoinPickedUp += UpdateCount;
          }

          private void OnDisable()
          {
               Coin.OnCoinPickedUp -= UpdateCount;
          }

          private void UpdateCount()
          {
               count++;
               coinCounterText.text = count.ToString();
          }
     }
}
