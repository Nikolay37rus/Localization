using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Notifications.Android;
using Unity.Notifications.iOS;
using UnityEngine.UI;
using System;

public class NotificationWindow : MonoBehaviour
{
    private const string AndroidNotificationChannelId = "android_notification_id";
    [SerializeField]
    private Button _showNotificationButton;

    private void Start()
    {
        _showNotificationButton.onClick.AddListener(CreateNotification);
    }  

    private void OnDestoy()
    {
        _showNotificationButton.onClick.RemoveAllListeners();
    }
    private void CreateNotification()
    {
#if UNITY_ANDROID
       CreateNotificationAndroid();
#elif UNITY_IOS
       CreateNotificationIOS();
#endif
    }

    private void CreateNotificationAndroid()
    {
        var androidChanal = new AndroidNotificationChannel
        {
            Id = AndroidNotificationChannelId,
            Name = "Energy",
            EnableVibration = true,
            Importance = Importance.High,
            CanShowBadge = true
        };

        AndroidNotificationCenter.RegisterNotificationChannel(androidChanal);

        var androidNotification = new AndroidNotification
        {
            Color = Color.red,
            RepeatInterval = TimeSpan.FromSeconds(3600)
        };

        AndroidNotificationCenter.SendNotification(androidNotification, AndroidNotificationChannelId);
                   
    }
    
   
    private void CreateNotificationIOS()
    {
        var iosNotification = new iOSNotification
        {
            Identifier = "ios_notification",
            Title = "Title",
            Body = "Body",
            Data = "02/05/2021",
            ForegroundPresentationOption = PresentationOption.Alert | PresentationOption.Badge |  PresentationOption.Sound 
        };

        iOSNotificationCenter.ScheduleNotification(iosNotification);
    }

}
