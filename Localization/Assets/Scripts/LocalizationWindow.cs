using UnityEngine;
using UnityEngine.Localization.Settings;
using UnityEngine.UI;

public class LocalizationWindow : MonoBehaviour
{
    [SerializeField]
    private Button _enButton;

    [SerializeField]
    private Button _ruButton;

    private void Start()
    {
        _enButton.onClick.AddListener(() => ChangeLanguage(0));
        _ruButton.onClick.AddListener(() => ChangeLanguage(1));
    }

    private void ChangeLanguage(int index)
    {
        LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[index];
    }

    private void OnDestroy()
    {
        _enButton.onClick.RemoveAllListeners();
        _ruButton.onClick.RemoveAllListeners();

    }
}

