   M S B A M L   `   `   `  ����?  ;TFOI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:TFOI.menus
TFOI.menus  5          TFOI.menus.PageItems   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      *localclr-namespace:TFOI.menus     5      c _Microsoft.Expression.Effects, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35=ee4http://schemas.microsoft.com/expression/2010/effects  5      -   5          N� Title$  Items��5
      .��5      � $	��540��6   .+�5   
   ��  �� BitmapScalingMode$ NearestNeighbor=�6   $+��%/TFOI;component/Resources/BGItems.png��6B   �� 5   
   -   5        $
��back��5      $(��"/TFOI;component/Resources/back.png��6   $��25,439,847,60q�6H   $ NearestNeighbor=�6_   6�   �� 5   
   -   5        $��back_��5      $-��'/TFOI;component/Resources/underline.png��6   $ NearestNeighbor=�6N   $y�Hidden=�6�   $��10,470,832,44q�6�    J� RenderTransformOrigin$ 0.5,0.5&�6�   $��87��6�   �� 5   
   $��Hidden=�6   $��212,73,217,371q�6<   .��5      � -   5         �Name$ 	itemPanel��5      $
��1024��6,   $	��531��6:    � Orientation$ 
Horizontal=�6F   $��Center=�6_   5      �� 5   
   -   5        $��textItemName��5      $
��Wrap=�6(   $
��Left=�6<   $��43��6W   $��	13,56,0,0q�6c   $	��Top=�6v   $	��182��6�   $1��+/TFOI;component/Resources/#TeamMeatFontBOLD)�6�   $��21.333(�6�   �� 5   
   -   5        $��textItemDescription��5      $
��Wrap=�6/   $
��Left=�6C   $��72��6^   $��	11,98,0,0q�6j   $	��Top=�6}   $	��178��6�   $1��+/TFOI;component/Resources/#TeamMeatFontBOLD)�6�   $��21.333(�6�   ���	#FF362F2D6�   �� 5   
   -   5        $��textItemDetails��5      $
��Wrap=�6+   $
��Left=�6?   $	��161��6Z   $��
759,33,0,0q�6g   $	��Top=�6{   $	��174��6�   $1��+/TFOI;component/Resources/#TeamMeatFontBOLD)�6�   $��21.333(�6�   ���	#FF362F2D6�   �� 5   
   -   5        $��	itemStats��5       �� TextAlignment$ Center=�6%   $��143,198,207,292q�6<   $1��+/TFOI;component/Resources/#TeamMeatFontBOLD)�6U   $��26.667(�6�   ���	#FF362F2D6�   �� 5   
   $��GLOBAL TOP 30 ITEMS��6   $ Center=�6/   $
��Wrap=�6F   $1��+/TFOI;component/Resources/#TeamMeatFontBOLD)�6Z   $��32(�6�   $��776,214,10,221q�6�   ���	#FF362F2D6�   �� 5   
   $-��'/TFOI;component/Resources/bossPanel.png��6   $ NearestNeighbor=�6B   $��759,277,-11,38q�6t   $��Center=�6�   $��Center=�6�   $	��212��6�   $	��225��6�   $
��Fill=�6�   � 5   
   -	   5        $��top30ItemsPanel��5      $��768,286,14,6q�6+   &   System.Windows.Controls.DataGrid  5   
   -
   5        $��dataGrid��5         AutoGenerateColumns .  $
��Left=�6?   $	��231��6Z   $��151,260,0,0q�6g   $	��Top=�6|   $	��588��6�   ���	#FFE7DDDC���	#FFE7DDDC$1��+/TFOI;component/Resources/#TeamMeatFontBOLD)�6�   $��18.667(�6   J� OpacityMask �	#FFE7DDDC���	#FF362F2D   AlternatingRowBackground �	#FFCAC5BD	   RowBackground	 �	#FFE7DDDC$��0q�6�  
   GridLinesVisibility$

 None=�6�     Columns 5       0  *System.Windows.Controls.DataGridTextColumn  5!      ,  &System.Windows.Controls.DataGridColumn   Header$
 DATE��6C      Width5  /System.Windows.Controls.DataGridLengthConverter$	 137 6Q   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6%   �� *	Timestamp+6Q     5"      $
 SEED��6>    6%   �� *Seed+6>     5#      $ 	CHARACTER��6B    6%   �� *
CharName+6B     5$      $
 TIME��6>    6%   �� *Time+6>     5%      $ RESULT��6@    6%   �� *Result+6@   5'      5(      5)      