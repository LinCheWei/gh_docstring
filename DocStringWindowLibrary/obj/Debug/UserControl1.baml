   M S B A M L   `   `   `  ����  DocStringWindowLibrary     DocstringEditor.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$  Docstring Editor��5   	   $	��600��6"   $	��400��6/   
�������.��5      � $��10q�6    � RowDefinitions 5   
   �� 5      $��3* �6   �� 5	      $��2* �6   .+�5   
   �� $��0��6   $
��Auto=�6$   .��5      �� -   5         ��Name$ DocstringCardsPanel��5       �� Orientation$ Vertical=�66   $��0,0,0,10q�6M   .+�5      ��  �� CornerRadius$ 10��6   
�������$��5q�6C    �� Padding$ 10q�6N   
�������$��1q�6n   ._�5      �� .+�5      �� $��Rotate an the columns.��6$   $
��Bold"�6B   �� 5      $��Input:��6$   $��SemiBold"�62   $��0,5,0,0q�6H   �� 5      $��G: The first parameter.��6$   �� 5      $��P: The second parameter.��6$   �� 5      $��A: The second parameter.��6$   �� 5      $��output:��6$   $��SemiBold"�63   $��5,5,0,0q�6I   �� 5      $+��%G: True for success, False otherwise.��6$   �� 5      $��X: The second parameter.��6$   �� 5      $ 
Horizontal=�6%   $��0,10,0,0q�6>   .+�5      �� $��@tag1��6%   $��0,0,5,0q�65   �� 5      $��@tag2��6%   5      �� 5      $ 
Horizontal=�6%   $��Right=�6>   .+�5      �� $��Rotate��6(   $
��Bold"�66   �� 5       $��GUID : 123123123123��6(   $��Italic$�6C   $��10(�6V   $��10,0,0,0q�6d   5!      5"      5#      5%      5&      �� 5)   
   $��1��6   
�������$��0,10,0,0q�65   $ 10q�6G   ._�5*      �� .+�5+      �� -   5         ��Name$ DocstringInput��5+      $	��150��5,       �� TextWrapping$
 Wrap=�5-       �� AcceptsReturn . "	 �� VerticalScrollBarVisibility$
	 Auto=�5/      $��Put in your docstring...��50      
 J� RenderTransformOrigin$
 0.5,0.5&�6:   .��6[   z�51      V� 52      .~�53      �� �� 54       �� AngleX$ 0.605Q�6,   �� 55      T� 56       T� X$ 0.528Q�61   57      .��58   /   59      �� 5:      $ 
Horizontal=�6   $��Right=�66   $��0,10,0,0q�6R   .+�5;      �� $
��Save��6   $	��100��6,   $��40��68   
��� ���
�������$��0,0,10,0q�6k   �� 5<      $��Cancel��6   $��40��6.   $��40��69   
�������
�������6[   5=      5>      5?      5@      5A      