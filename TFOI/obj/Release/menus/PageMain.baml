   M S B A M L   `   `   `  ���� C  ?TFOIBeta, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:TFOIBeta.menusTFOIBeta.menus      TFOIBeta.menus.PageMain   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     .localclr-namespace:TFOIBeta.menus     -     N� Title$  PageMain�� � 	Resources    logoSway g� AutoReverse g� RepeatBehavior �� TargetProperty �� 
TargetName9  3System.Windows.Media.Animation.EasingDoubleKeyFrame O� KeyTime O� Value��%�   &	        ��  . $ Forever��.��U� $V P(UIElement.RenderTransform).(TransformGroup.Children)[2].(RotateTransform.Angle)�$
 logo��.\�  $ 0:0:0.1��$ 0Q�  $ 0:0:0.7��$ 1Q� � Triggers :� 	 :� RoutedEvent$	 FrameworkElement.Loaded��.[��� #��[  .��� .+��� 
 �� BitmapScalingMode$
 NearestNeighbor=�$��/Resources/BGMainMenu.png���� -   $
��logo��$
 NearestNeighbor=�$4��./TFOIBeta;component/Resources/logoNoShadow.png�� J� RenderTransformOrigin$ 0.5,0.5&�$��
82,16,82,0q�$	��Top=�$	��150��z�V� .~��� �� �� T�  J� Effect 3  -System.Windows.Media.Effects.DropShadowEffect     	Direction$	 300Q�   Opacity$	 0.4Q�   
BlurRadius$ 7Q�   ShadowDepth$ 10Q��� -   $��newrun_��$
 NearestNeighbor=�$��/Resources/arrow.png��$��320,232,549,271q�$y�Hidden=��� -   $��newrun��$��/Resources/NEWRUN.png��$��377,209,394,268q�$ 0.5,0.5&�z�V� .~��� �� ��  �� Angle$ -4Q�T� �� -   $��runs_��$
 NearestNeighbor=�$��/Resources/arrow.png��$��328,279,541,224q�$y�Hidden=��� -   $
��runs��$��/Resources/RUNS.png��$��335,269,396,222q�z�V� .~��� �� �� $ -4Q�T� �� -   $��chars_��$
 NearestNeighbor=�$��/Resources/arrow.png��$��338,328,531,175q�$y�Hidden=��� -   $��chars��$��/Resources/CHARS.png��$ 0.5,0.5&�$��391,304,406,172q�z�V� .~���  �� ScaleY$ 1Q���  �� AngleY$ 0Q��� $ -5.647Q�T� �� -	   $��items_��$
 NearestNeighbor=�$��/Resources/arrow.png��$��346,375,523,128q�$y�Hidden=��� -
   $��items��$��/Resources/ITEMS.png��$��399,361,413,130q�$ 0.5,0.5&�z�V� .~��� �� �� $ -6.352Q�T� �� -   $��bosses_��$
 NearestNeighbor=�$��/Resources/arrow.png��$��355,423,514,80q�$y�Hidden=��� -   $��bosses��$��/Resources/BOSSES.png��$��407,386,375,57q�$ 0.5,0.5&�z�V� .~��� �� �� $ -6.554Q�T� �� -   $��options_��$
 NearestNeighbor=�$��/Resources/arrow.png��$��360,471,509,33q�$y�Hidden=��� -   $��options��$��/Resources/OPTIONS.png��$��412,418,334,3q�$ 0.5,0.5&�z�V� .~��� �� �� $ -5.924Q�T� �� -   $
��exit��$,��&/TFOIBeta;component/Resources/exit.png��$
 NearestNeighbor=�$��843,430,20,51q�$��70��$��29��$��UniformToFill=��� -   $��exit_��$��/Resources/underline.png��$
 NearestNeighbor=�$y�Hidden=�$��834,472,19,45q�