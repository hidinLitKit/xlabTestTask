using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using YG;

public static class YGAdsProvider
{
    public static void TryFullScreenAdWithChance(int chance)
    {
        var random = Random.Range(0, 101);
        if (chance < random) return;
        YandexGame.FullscreenShow();
    }
}
    
