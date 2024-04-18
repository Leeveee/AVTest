using System.Collections;
using Components;
using DamageHandler;
using HealthHandler;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace HealthBar
{
  public class HealthBar : MonoBehaviour
  {
   private const float START_SCALE = 1f;
   private const float MAX_SCALE = 1.6f;
   private readonly Vector3 _startPos = new Vector3(0.5f, 3f, 0f);
   private readonly Vector3 _maxPos = new Vector3(0.5f, 7f, 0f);
    
    [SerializeField]
    private Image healthBar;
    [SerializeField]
    private TextMeshProUGUI _damageText;

    private CanvasGroup _canvasGroup;
    private IDamageable _damageable;
    private Camera _camera;

    private void LateUpdate()
    {
      if (_damageable == null)
      {
        return;
      }

      transform.position = _damageable.HpBarPosition;
      transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, 0);
    }

    public void InitCharacterTakeDamage (IDamageable damageable)
    {
      _damageable = damageable;
      _damageable.OnGetDamage += GetDamage;
    }

    private void GetDamage (HealthInfo healthInfo, int damage)
    {
      _canvasGroup = GetComponent<CanvasGroup>();
      _canvasGroup.alpha = 1;
      healthBar.fillAmount = (float)healthInfo.CurrentHealth / healthInfo.MaxHealth;
      StartCoroutine(ShowDamage(damage));

      if (healthBar.fillAmount <= 0)
      {
        Destroy(gameObject);
      }
    }
    
    private IEnumerator ShowDamage (int damage)
    {
      _damageText.gameObject.SetActive(true);

      _damageText.text = damage.ToString();

      for (float i = 0; i < 1; i += Time.deltaTime)
      {
        yield return null;
        float currentScale = Mathf.Lerp(START_SCALE, MAX_SCALE, i);
        _damageText.transform.localScale = Vector3.one * currentScale;

        float currentAlpha = 1 - i;
        _damageText.alpha = currentAlpha;

        Vector3 currentPos = Vector3.Lerp(_startPos, _maxPos, i);
        _damageText.transform.localPosition = currentPos;
      }

      _damageText.gameObject.SetActive(false);
    }

    private void OnDestroy()
    {
      _damageable.OnGetDamage -= GetDamage;
    }
  }
}