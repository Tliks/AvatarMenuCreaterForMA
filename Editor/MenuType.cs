﻿using UnityEngine;

namespace net.narazaka.avatarmenucreator
{
    enum MenuType
    {
        [InspectorName("ON／OFF")]
        Toggle,
        [InspectorName("選択式")]
        Choose,
        [InspectorName("無段階制御")]
        Slider,
    }
}
