   M S B A M L   `   `   `  ����?  ;TFOI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:TFOI.menus
TFOI.menus  5          TFOI.menus.PageChars   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      *localclr-namespace:TFOI.menus     5      -   5          N� 
Background
  ����� N� Title$ 	PageChars��5	      .��5      � .+�5   
   ��  �� BitmapScalingMode$ NearestNeighbor=�6   $-��'/TFOI;component/Resources/itemPanel.png��6B   $��19,92,860,102q�6s   �� 5   
   $ NearestNeighbor=�6   $��/Resources/BGChars.png��6B   �� 5   
   -   5        $
��back��5      $(��"/TFOI;component/Resources/back.png��6   $��25,439,847,60q�6H   $ NearestNeighbor=�6_   $
��Fill=�6�   �� 5   
   -   5        $��back_��5      $-��'/TFOI;component/Resources/underline.png��6   $ NearestNeighbor=�6N   $y�Hidden=�6�   $��10,470,832,44q�6�    J� RenderTransformOrigin$ 0.5,0.5&�6�   � 5   
   -   5        $��	charPanel��5      $��156,0,150,403q�6%   $ 0.5,0.5&�6<   $��54��6\   $��Bottom=�6h   �� 5   
   $��TOP 20 ITEMS FOUND��6    �� TextAlignment$ Center=�6.   $
��Wrap=�6E   $1��+/TFOI;component/Resources/#TeamMeatFontBOLD)�6Y   $��32(�6�   $��4,0,842,435q�6�   ���	#FF362F2D6�   �� 5   
   $-��'/TFOI;component/Resources/itemPanel.png��6   $��4,90,842,104q�6B   $��Center=�6X   $��Center=�6s   $	��114��6�   $
��Fill=�6�   � 5   
   -   5        $��
top20Items��5      $��16,98,854,101q�6&   �� 5   
   $-��'/TFOI;component/Resources/bossPanel.png��6   $ NearestNeighbor=�6A   $��826,109,6,149q�6s   $
��Fill=�6�   �� 5   
   $��TOP 5 BOSSES FOUGHT��6   $ Center=�6/   $
��Wrap=�6F   $1��+/TFOI;component/Resources/#TeamMeatFontBOLD)�6Z   $��32(�6�   $��810,11,-1,424q�6�   ���	#FF362F2D6�   �� 5   
   -   5        $��
top5Bosses��5      $��815,121,0,158q�6'   �� 5   
   -   5        $��	charStats��5      $ Center=�6%   $��133,150,150,340q�6<   $1��+/TFOI;component/Resources/#TeamMeatFontBOLD)�6U   $��26.667(�6�   ���	#FF362F2D6�   &   System.Windows.Controls.DataGrid  5   
   -   5        $��dataGrid��5         AutoGenerateColumns .  $
��Left=�6?   $	��270��6Z   $��145,221,0,0q�6g   $	��Top=�6|   $	��648��6�   ���	#FFE7DDDC���	#FFE7DDDC$1��+/TFOI;component/Resources/#TeamMeatFontBOLD)�6�   $��18.667(�6   J� OpacityMask �	#FFE7DDDC���	#FF362F2D   AlternatingRowBackground �	#FFCAC5BD   RowBackground �	#FFE7DDDC$��0q�6�  	   GridLinesVisibility$
	 None=�6�  
   Columns
 5      0  *System.Windows.Controls.DataGridTextColumn  5       ,  &System.Windows.Controls.DataGridColumn   Header$
 DATE��6C      Width5  /System.Windows.Controls.DataGridLengthConverter$	 137 6Q   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6%   �� *	Timestamp+6Q     5!      $
 SEED��6>    6%   �� *Seed+6>     5"      $ 	CHARACTER��6B    6%   �� *
CharName+6B     5#      $
 TIME��6>    6%   �� *Time+6>     5$      $ RESULT��6@    6%   �� *Result+6@   5&      5'      5(      