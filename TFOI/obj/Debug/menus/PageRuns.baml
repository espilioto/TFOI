   M S B A M L   `   `   `  ����?  ;TFOI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:TFOI.menus
TFOI.menus  5          TFOI.menus.PageRuns   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      *localclr-namespace:TFOI.menus     5        N� 
Background
  ����� N� Title$ PageRuns��5	      .��5      � -   5        .+�5   
   ��  �� BitmapScalingMode$ NearestNeighbor=�6   $*��$/TFOI;component/Resources/BGRuns.png��6B   �� 5   
   -   5        $��btnDeleteRun��5      $-��'/TFOI;component/Resources/btnDelete.png��6$   $��10,366,817,99q�6U   6�   �� 5   
   -   5        $
��back��5      $(��"/TFOI;component/Resources/back.png��6   $��25,439,847,60q�6H   $ NearestNeighbor=�6_   6�   �� 5   
   -   5        $��back_��5      $-��'/TFOI;component/Resources/underline.png��6   $ NearestNeighbor=�6N   $y�Hidden=�6�   $��10,470,832,44q�6�    J� RenderTransformOrigin$ 0.5,0.5&�6�   $��87��6�   &   System.Windows.Controls.DataGrid  5   
   -   5        $��dataGrid��5         AutoGenerateColumns .  $
��Left=�6?   $	��232��6Z   $��150,264,0,0q�6g   $	��Top=�6|   $	��759��6�   ���	#FFE7DDDC���	#FFE7DDDC$1��+/TFOI;component/Resources/#TeamMeatFontBOLD)�6�   $��18.667(�6   J� OpacityMask �	#FFE7DDDC���	#FF362F2D   AlternatingRowBackground �	#FFCAC5BD   RowBackground �	#FFE7DDDC$��0q�6�     GridLinesVisibility$
 None=�6�  	   
IsReadOnly	 . 
   CanUserResizeRows
 .     Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$
 Date��6C      Width5  /System.Windows.Controls.DataGridLengthConverter$	 137 6Q   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6%   �� *	Timestamp+6Q     5      $
 Seed��6>    6%   �� *Seed+6>     5      $ 	Character��6B    6%   �� *
CharName+6B     5      $
 Time��6>    6%   �� *Time+6>     5      $ Result��6@    6%   �� *Result+6@   5      �� 5   
   -   5        $��selectedRun��5      $
��Left=�6$   $	��236��6?   $��0,10,0,0q�6L   $	��Top=�6^   $	��960��6v   .+�5      �� -   5        $��selectedRunCharIcon��5      $��44��6/   $��45��6;    �� Left$	 865��6F   
 �� Top$ 19��6X   � 5      -   5        $��selectedRunFloors��5      $��74��61   $	��705��6=   $	 155��6I   $ 3��6[   �� 5       -	   5        $��selectedRunSeed��5       $
��Wrap=�6/   $	��130��6C   $��89��6O   $1��+/TFOI;component/Resources/#TeamMeatFontBOLD)�6[   $��48(�6�   ���	#FF362F2D$ 10��6�   $��Center=�6�   $��Center=�6�   $ 20��6  �� 5!      -
   5        $��selectedRunTime��5!      $	��150��6/   $��45��6;   $	 118��6G   $1��+/TFOI;component/Resources/#TeamMeatFontBOLD)�6X   $��48(�6�   ���	#FF362F2D$ 2��6�   �� 5"      -   5        $��selectedRunResult��5"      $ 10��61   $	 184��6B   $��42��6S   $	��140��6_   $1��+/TFOI;component/Resources/#TeamMeatFontBOLD)�6k   $��40(�6�   ���	#FF362F2D6�   � 5#      -   5        $��selectedRunItems��5#      $��64��60   $	��710��6<   $ 77��6H   $	 155��6X   � 5$      -   5        $��selectedRunBosses��5$      $��95��61   $	��760��6=   $	 141��6I   $	 155��6Z   5%      �� 5&   
   -   5         ��Name$ 	totalRuns��5&      $
��Wrap=�6'    �� TextAlignment$ Center=�6;   $��63��6R   $	 118��6^   $1��+/TFOI;component/Resources/#TeamMeatFontBOLD)�6o   $��24(�6�   ���	#FF362F2D$��4,251,818,226q�6�   5(      5)      