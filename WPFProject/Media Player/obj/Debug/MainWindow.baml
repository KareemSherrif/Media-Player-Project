   M S B A M L   `   `   `  ����G  CMedia Player, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:Media_PlayerMedia_Player  5   	   O Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem 5   	       Media_Player.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,localclr-namespace:Media_Player     5   	   9System&clr-namespace:System;assembly=mscorlib     5   	     � Title$  K-Player��5	   	   $	��600��6   $	��800��6'    � TaskbarItemInfo 5
      *  $System.Windows.Shell.TaskbarItemInfo  5   
    � 	Resources 5         OverlayMusic H� Drawing �� Rect �� ImageSource  OverlayVideo2  ,System.Windows.Controls.AlternationConverter  AlternationConverter��%�   &	        &	 d     &	 �     H� 5   
    5      �� 5      $ 	0,0,16,16�6   $ /Assets/Music.png��60   5      H� 5   
    5      �� 5      $ 	0,0,16,16�6   $ /Assets/Video.png��60   5        5   
   6   5      .��5      � ��5   
   �� 5       �� EndPoint$ 0.5,1&�6"    �� 
StartPoint$ 0.5,0&�63   .��5      �  � Color$ 	#FF9C9C9C��6   	 � Offset$	 0.523Q�61   � 5       $ 	#FF444242��6   $	 1Q�61   5!      .+�5%   
   r� -   5        
 r�Name$
 	MediaArea��5%   0    r� LoadedBehavior$ Manual=�6   $��10,38,186,169q�6�    r� Volume 6g   �� *Value+ �� ElementName$ SliderProgress��6�   �� 5'   
   -   5         ��Name$ LViewItemList��5'      $
��Left=�6+   $	��328��6F   $��
611,72,0,0q�6S   $	��Top=�6g   $	��178��6    J� 	AllowDrop .  � ContextMenu 5(      �� 5)      .@�5*      m� -   5        $��Delete��5*      6N   5+      5/      �� 50   
   -   5         ��Name$ TBlockEmptyListWarning��50      $
��Wrap=�64   $-��'Drag Items Below, To Create a Playlist.��6H   $	��134��6w   $
��Bold"�6�   $��611,72,47,453q�6�   � 52   
   -   5         �Name$ GridControlButtons��52      $��Center=�6+   $��26,478,16,17q�6H   $	��750��6^    J� RenderTransformOrigin$ 0.532,0.551&�6j   $��Center=�6�   $��74��6�   ��53      �� 54      .+�57      d� -   5         d�Name$ TbtnPlayPause��57      $��Center=�63   $��35��6P   $��317,24,398,15q�6[   $��Center=�6r   $ 0.5,0.5&�6�   $��35��6�   ��58      �� 59       �� ImageSource$ ./Assets/play-1.png��6!   5<      �� 5?      -   5         ��Name$ LblProgress��5?      $
��Left=�6*   $��	10,20,0,0q�6E   $	��Top=�6X   $��54��6p   ��6{   �� *
Position+$ 	MediaArea�� �� Mode$ TwoWay=��� 5@      -   5         ��Name$ SliderProgress��5@      $
��Left=�6-   $��10,0,0,0q�6H   $	��Top=�6Z   $	��706��6r    �� TickPlacement$ TopLeft=�6�    � LargeChange$
 0.25Q�6�   d� 5A      -	   5        $ TBtnMute��5A      $
��Mute��6-   $
��Left=�6<   $��
676,52,0,0q�6W   $	��Top=�6k   $��40��6�   $ 1.864,-0.266&�6�   6�   �� 5B      -
   5        $ SliderVolume��5B      $
��Left=�6+   $��705,27,-14,0q�6F   $	��Top=�6\   $��59��6t   $	 0.2Q�6   $ 0.5,0.5&�6�    �� IsDirectionReversed .  � Maximum$ 1Q�6   � Value 6�   �� *Volume+$ 	MediaArea��$ OneWayToSource=�z�5C      V� 5D      .~�5E      �� �� 5F      �� 5G       �� Angle$ 90Q�6*   T� 5H      5I      5K      �� 5L      -   5         ��Name$ 	BtnRewind��5L      $
��Left=�6(   $��
247,24,0,0q�6C   $	��Top=�6W   $��35��6o   $��35��6z   ��5M      �� 5N      $ ./Assets/rewind-1.png��6!   5Q      �� 5S      -   5        $ 
BtnForward��5S      $
��Left=�6)   $��
421,24,0,0q�6D   $	��Top=�6X   $��35��6p   $��35��6|   ��5T      �� 5U      $ ./Assets/Forward-1.png��6!   5X      �� 5[      -   5        $ LblTotalDuration��5[      $��00:00:00��6.   $
��Left=�6A   $��
659,20,0,0q�6\   $	��Top=�6p   $��32��6�   $��57��6�   �� 5\      -   5        $ BtnNext��5\      $�� ��6&   $
��Left=�61   $��
386,24,0,0q�6L   $	��Top=�6`   $��35��6x   $��35��6�   $ 0.067,0.553&�6�   ��5]      �� 5^      $ ./Assets/Next-1.png��6!   5a      �� 5b      -   5        $ BtnPrevious��5b      $
��Left=�6*   $��
282,24,0,0q�6E   $	��Top=�6Y   $��35��6q   $��35��6|   $ 0.067,0.553&�6�   ��5c      �� 5d      $ ./Assets/previous-1.png��6!   5g      �� 5h      -   5        $ BtnStop��5h      $�� ��6&   $
��Left=�61   $��
352,24,0,0q�6L   $	��Top=�6`   $��35��6x   $��35��6�   ��5i      �� 5j      $ ./Assets/stop-1.png��6!   5m      5n      o� 5o   
   $
��Left=�6   $��20��6*   $	��Top=�66   $	��792��6N   .@�5p      m� -   5          m�Name$  MenuItemFile��5p      $
��File��6-   $��23��6;   $��30��6G   .@�5q      m� -   5        $  SubMenuItemOpen��5q      $
��Open��64   6B   m� 5r      -   5        $  SubMenuItemExit��5r      $
��Exit��64   5s      5t      �� 5u   
   -   5        $ LblPlayList��5u      $��Playlist��6%   $��Center=�68   $��15(�6\   $��611,38,0,497q�6j   $
��Bold"�6�   ��5v      �� 5w      $ 0.5,1&�6&   $ 0.5,0&�67   .��5x      � $ Black��6#   $	 0Q�61   � 5y      $ White��6#   $	 1Q�61   5z      5|      5}      5~      