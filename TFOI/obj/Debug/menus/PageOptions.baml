   M S B A M L   `   `   `  ����?  ;TFOI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:TFOI.menus
TFOI.menus  5          TFOI.menus.PageOptions   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      *localclr-namespace:TFOI.menus     5        N� 
Background
  ����� N� Title$ PageOptions��5	      .��5      � -   5        .+�5   
   ��  �� BitmapScalingMode$ NearestNeighbor=�6   $-��'/TFOI;component/Resources/BGOptions.png��6B   �� 5   
   -   5        $��groupBoxBackup��5      $��Database Backup��6)   $
��Left=�6B   $��99��6]   $��
272,97,0,0q�6i   $	��Top=�6}   $	��420��6�   ���	#FF362F2D���	#FF362F2D$1��+/TFOI;component/Resources/#TeamMeatFontBOLD)�6�   �� 5   
   -   5        $��backupEnabled��5      $&�� Enable automatic database backup��6L   $��279,126,0,0q�6w   $1��+/TFOI;component/Resources/#TeamMeatFontBOLD)�6�   $��18.667(�6�   ���	#FF362F2D$	��Top=�6�   $
��Left=�6   d� 	IsChecked 6(   �� *BackupEnabled+6A  �� 5   
   -   5        $��
backupPath��5      $��279,0,350,348q�6$   ���	#FFE7DDDC���	#FF362F2D$1��+/TFOI;component/Resources/#TeamMeatFontBOLD)�6i   ���	#FF362F2D$��2q�6�   $��18.667(�6�   $��Bottom=�6�   $��27��6�   $��
��6  �� 5   
   -   5        $��	btnBrowse��5      $��605,155,0,0q�6!   $��34��66   $��74��6B   $-��'/TFOI;component/Resources/btnBrowse.png��6�   $
��Left=�6�   $	��Top=�6�   �� 5   
   -   5        $��
backupHelp��5       � ToolTip$� �Enable to copy your database file to the specified location if a modification happens(a new run is inserted, a run is deleted etc)��6"   $ NearestNeighbor=�6�   $,��&/TFOI;component/Resources/helpIcon.png��6�   $��663,108,268,388q�6   J� RenderTransformOrigin$ 3.69,-2.214&�6*  �� 5   
   -   5        $
��back��5      $(��"/TFOI;component/Resources/back.png��6   $��25,439,847,60q�6H   $ NearestNeighbor=�6_   6�   �� 5   
   -   5        $��back_��5      $-��'/TFOI;component/Resources/underline.png��6   $ NearestNeighbor=�6N   $y�Hidden=�6�   $��10,470,832,44q�6�   $ 0.5,0.5&�6�   $��87��6�   �� 5   
   -	   5        $��groupBoxPerformance��5      $��Performance��6.   $
��Left=�6C   $��99��6^   $��272,211,0,0q�6j   $	��Top=�6   $	��420��6�   ���	#FF362F2D���	#FF362F2D$1��+/TFOI;component/Resources/#TeamMeatFontBOLD)�6�   �� 5   
   $��Log file read speed��6   $1��+/TFOI;component/Resources/#TeamMeatFontBOLD)�6/   $��18.667(�6h   $��279,235,373,255q�6z   ���	#FF42312D6�   �� 5   
   -
   5        $��slider��5       �� IsSnapToTickEnabled . $
��Left=�6:   $��279,269,0,0q�6U   $	��Top=�6j   $	��358��6�    � Minimum$	 100Q�6�    � SmallChange$	 100Q�6�   	 � Value$		 100Q�6�   
 �� TickPlacement$

 Both=�6�    � LargeChange$	 200Q�6�    � Maximum$
 1000Q�6�    �� TickFrequency$	 100Q�6�   ���	#FF362F2D���	#FF362F2D���	#FFD2CDC563  �� 5   
   -   5        $��performanceHelp��5      $} wThe interval (in milliseconds) at which TFOI will read the log file. Increase this if you see TFOI using much CPU time.��6'   $ NearestNeighbor=�6�   $,��&/TFOI;component/Resources/helpIcon.png��6�   $��663,223,268,273q�6  $ 3.69,-2.214&�6$  �� 5   
   -   5        $��sliderValue��5      $1��+/TFOI;component/Resources/#TeamMeatFontBOLD)�6X   $��32(�6�   $��642,272,0,0q�6�   ���	#FF42312D$	��Top=�6�   $
��Left=�6�   $	��144��6�   $��39��6
  ��6'   ��  �� ElementName$ slider�� �� Path$ Value�6
  �� 5   
   -   5        $��btnSave��5      $��785,408,50,74q�6   $+��%/TFOI;component/Resources/btnSave.png��66   6�   �� 5   
   -   5        $��txtSaved��5      $��Settings saved!��6$   $1��+/TFOI;component/Resources/#TeamMeatFontBOLD)�6;   $��29.333(�6t   $��0,0,-100,20q�6�   ���	#FF362F2D$��Right=�6�   $��50��6�   $��Bottom=�6�   $	��308��6�   5      5       