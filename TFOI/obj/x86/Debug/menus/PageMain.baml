   M S B A M L   `   `   `  ����C  ?TFOIBeta, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:TFOIBeta.menusTFOIBeta.menus  5          TFOIBeta.menus.PageMain   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      .localclr-namespace:TFOIBeta.menus     5      -   5          N� Title$  PageMain��5	       � 	Resources 5         logoSway g� AutoReverse g� RepeatBehavior �� TargetProperty �� 
TargetName9  3System.Windows.Media.Animation.EasingDoubleKeyFrame O� KeyTime O� Value��%   &	        �� 5   
    . $ Forever��69   .��5      U� $V P(UIElement.RenderTransform).(TransformGroup.Children)[2].(RotateTransform.Angle)�6,   $
 logo��6�   .\�5        $ 0:0:0.1��6'   $ 0Q�69     5      $ 0:0:0.7��6'   $ 1Q�69   5      5      5       � Triggers 5      :� 5   
   	 :� RoutedEvent$	 FrameworkElement.Loaded��6   .[�5      �� #��[  6   5      .��5      � .+�5   
   �� 
 �� BitmapScalingMode$
 NearestNeighbor=�6   $��/Resources/BGMainMenu.png��6B   �� 5   
   -   5        $
��logo��5      $
 NearestNeighbor=�6   $4��./TFOIBeta;component/Resources/logoNoShadow.png��6N    J� RenderTransformOrigin$ 0.5,0.5&�6�   $��
82,16,82,0q�6�   $	��Top=�6�   $	��150��6�   z�5      V� 5      .~�5      �� �� 5       �� 5!      T� 5"      5#       J� Effect 5%      3  -System.Windows.Media.Effects.DropShadowEffect  5&         	Direction$	 300Q�6#      Opacity$	 0.4Q�63      
BlurRadius$ 7Q�6A      ShadowDepth$ 10Q�6P   5(      �� 5*   
   -   5        $��newrun_��5*      $
 NearestNeighbor=�6   $��/Resources/arrow.png��6Q   $��320,232,549,271q�6o   $y�Hidden=�6�   �� 5+   
   -   5        $��newrun��5+      $��/Resources/NEWRUN.png��6   $��377,209,394,268q�6=   $ 0.5,0.5&�6V   z�5,      V� 5-      .~�5.      �� �� 5/      �� 50       �� Angle$ -4Q�6&   T� 51      52      54      �� 55   
   -   5        $��runs_��55      $
 NearestNeighbor=�6   $��/Resources/arrow.png��6O   $��328,279,541,224q�6m   $y�Hidden=�6�   �� 56   
   -   5        $
��runs��56      $��/Resources/RUNS.png��6   $��345,269,386,222q�6:   z�57      V� 58      .~�59      �� �� 5:      �� 5;      $ -4Q�6&   T� 5<      5=      5?      �� 5@   
   -   5        $��chars_��5@      $
 NearestNeighbor=�6   $��/Resources/arrow.png��6P   $��338,328,531,175q�6n   $y�Hidden=�6�   �� 5A   
   -   5        $��chars��5A      $��/Resources/CHARS.png��6   $ 0.5,0.5&�6;   $��391,304,406,172q�6[   z�5B      V� 5C      .~�5D      ��  �� ScaleY$ 1Q�6%   �� 5E       �� AngleY$ 0Q�6$   �� 5F      $ -5.647Q�6&   T� 5G      5H      5J      �� 5K   
   -	   5        $��items_��5K      $
 NearestNeighbor=�6   $��/Resources/arrow.png��6P   $��346,375,523,128q�6n   $y�Hidden=�6�   �� 5L   
   -
   5        $��items��5L      $��/Resources/ITEMS.png��6   $��399,361,413,130q�6;   $ 0.5,0.5&�6T   z�5M      V� 5N      .~�5O      �� �� 5P      �� 5Q      $ -6.352Q�6&   T� 5R      5S      5U      �� 5V   
   -   5        $��bosses_��5V      $
 NearestNeighbor=�6   $��/Resources/arrow.png��6Q   $��355,423,514,80q�6o   $y�Hidden=�6�   �� 5W   
   -   5        $��bosses��5W      $��/Resources/BOSSES.png��6   $��407,386,375,57q�6=   $ 0.5,0.5&�6U   z�5X      V� 5Y      .~�5Z      �� �� 5[      �� 5\      $ -6.554Q�6&   T� 5]      5^      5`      �� 5a   
   -   5        $��options_��5a      $
 NearestNeighbor=�6    $��/Resources/arrow.png��6R   $��360,471,509,33q�6p   $y�Hidden=�6�   �� 5b   
   -   5        $��options��5b      $��/Resources/OPTIONS.png��6   $��412,418,334,3q�6?   $ 0.5,0.5&�6V   z�5c      V� 5d      .~�5e      �� �� 5f      �� 5g      $ -5.924Q�6&   T� 5h      5i      5k      �� 5l   
   -   5        $
��exit��5l      $,��&/TFOIBeta;component/Resources/exit.png��6   $
 NearestNeighbor=�6L   $��843,430,20,51q�6~   $��70��6�   $��29��6�   $��UniformToFill=�6  �� 5m   
   -   5        $��exit_��5m      $��/Resources/underline.png��6   $
 NearestNeighbor=�6?   $y�Hidden=�6q   $��834,472,19,45q�6�   5n      5o      