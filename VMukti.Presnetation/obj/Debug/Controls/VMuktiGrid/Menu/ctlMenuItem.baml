   M S B A M L   `   `   `  ����  VMukti.Presentation'    !VMuktiGrid.CustomMenu.ctlMenuItem   5      \ XPresentationFramework, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    8x,http://schemas.microsoft.com/winfx/2006/xaml    5      $
��Auto��5      $��18(�6)   $��Stretch=�5      $��0,0,0,5q�6#   ��5      Z�   � 	Resources  5         OnMouseOver g� 	BeginTime �� 
TargetName �� TargetProperty �� KeyTime �� Value  OnMoudeLeft��%(  &	        &	 
    �� 5	   
   .��5
      �� $ 00:00:00X�6+   $ txtTitle��6@   $6 0(TextElement.Foreground).(SolidColorBrush.Color)�6a   .g�5      �� $ 00:00:00��6&   $ Black��69   �� 5      $ 00:00:00.2600000��6&   $ 	#FFE18926��6A   5      5      �� 5   
   .��5      �� $ 00:00:00X�6+   $6 0(TextElement.Foreground).(SolidColorBrush.Color)�6@   $ txtTitle��6�   .g�5      �� $ 00:00:00��6&   $ 	#FFE18926��69   �� 5      $ 00:00:00.5000000��6&   $ Black��6A   5      5      5       � Triggers 5      :� 5   
    :� RoutedEvent$ Mouse.MouseEnter��6    :� 
SourceName$ txtTitle��66   .[�5      �� -   5        	 ��Name$!	 OnMouseOver_BeginStoryboard��5   H   #��[  6   6H   5      :� 5   
   $ Mouse.MouseLeave��6   $ txtTitle��66   .[�5       �� -   5        $!	 OnMoudeLeft_BeginStoryboard��5       #��[ 6C   5!      .��5%      � -   5        
 �Name$
 
LayoutRoot��5%      $
��Auto��6   $��Stretch=�6,    � ColumnDefinitions 5&   
   �� 5'      $��16 �6   �� 5(      $
��Auto �6   �� 5)      .+�5,   
   �� -   5         ��Name$ imgLeftIcon��5,      $��16��6%   $��16��60   $��Uniform=�6<    �� StretchDirection$
 Both=�6N   $��0��6f   �� 5-   
   -   5        $��txtTitle��5-      $��12(�6$   $��	TextBlock��63   $
��Wrap=�6D    � Cursor$
 Hand��5.      $
��Auto��6"   $��20��6/    �� Padding$ 3,3,3,0q�6;   $��Segoe UI)�5/      $��Normal"�6*   $��Stretch=�6T   $��1��6r   ��6>   Z� 6r   �� 50   
   -   5        $ imgRightIcon��50      $��16��6&   $��Uniform=�61   $
 Both=�6C   $��20��6[   $��2��6g   5<      5=      