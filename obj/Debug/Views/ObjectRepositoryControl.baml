   M S B A M L   `   `   `  ����M  IPortableAutomation, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullK*clr-namespace:CommandTestAutomation.ModelsCommandTestAutomation.Models  5      S.clr-namespace:CommandTestAutomation.ViewModels CommandTestAutomation.ViewModels  5	      K*clr-namespace:CommandTestAutomation.ModelsCommandTestAutomation.Models  5
      S.clr-namespace:CommandTestAutomation.Interfaces CommandTestAutomation.Interfaces  5      I)clr-namespace:CommandTestAutomation.ViewsCommandTestAutomation.Views  5      M+clr-namespace:CommandTestAutomation.HelpersCommandTestAutomation.Helpers  5      M+clr-namespace:CommandTestAutomation.HelpersCommandTestAutomation.Helpers  5      9    3CommandTestAutomation.Views.ObjectRepositoryControl   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      <model*clr-namespace:CommandTestAutomation.Models     5      @local.clr-namespace:CommandTestAutomation.ViewModels     5	      =models*clr-namespace:CommandTestAutomation.Models     5
      E
interfaces.clr-namespace:CommandTestAutomation.Interfaces     5      ?	uControls)clr-namespace:CommandTestAutomation.Views     5      B
converters+clr-namespace:CommandTestAutomation.Helpers     5      DmyConverters+clr-namespace:CommandTestAutomation.Helpers     5        � 	Resources  5      0   *CommandTestAutomation.Helpers.BindingProxy   DataContextProxy   Data9   3CommandTestAutomation.Helpers.EnumToStringConverter  EnumToStringConverter1   +CommandTestAutomation.Helpers.PathConverter  iconConverter6   0CommandTestAutomation.Helpers.RowNumberConverter  rowToIndexConverter8   2CommandTestAutomation.Helpers.ContextMenuConverter  contextMenuConverter3   -CommandTestAutomation.Helpers.IsNullConverter  isNullConverter>  8CommandTestAutomation.Helpers.INodeToVisibilityConverter  nodeToVisibilityConverter��%�   &	        &	       &	 3     &	 F     &	 Y     &	 l     &	        5   
    5      ��   5   
   6-     5   
   6#     5   
   6(     5   
   6*     5   
   6%     5   
   60   5       J� InputBindings 5      �� 5   
   
 �� Key$ F2��6    �� Command 6   �� *EditNodeClickCommand+�� 5   
   $ Enter��6    6!   �� *CommitEditClickCommand+.��5"      ]� .+�5#   
   ��  �� Orientation$ 
Horizontal=�6   .+�5%      4   .CommandTestAutomation.Helpers.ExtendedTreeView  -   5          Name$ myObjectTree��5&   ;   $	��200��6.   ��5%   .   ��  �� Path$ ObjectMapData� �� Mode$ TwoWay=�	   SelectedItem_	 5'   .   �� * SelectedTestObjectTreeViewItem+$ TwoWay=�  5*        NormalTemplate
 ��Name �� Triggers �� Value �� Binding �� RelativeSource �� AncestorType �� 	Converter �� 
TargetName �� Property �� Value �� FallbackValue  EditTemplate �� UpdateSourceTrigger 	 RootMenu 
 contextMenuStyle m� Command �� Source  ProjectMenu  
FolderMenu  UIObjectMenu   RootMenu   ProjectMenu   
FolderMenu   UIObjectMenu��%�  &	       7  7  &	 �    7  7  &		 �    7 
 7   &	 �    7 
 7   7   7   &	 /	    7 
 7   7   7   7   &	 �    7 
 7   7   &	 �    7 	 7  7  7  �� 5+      .R�5-      �� $ 
Horizontal=�6%   .+�5.      �� $
 iconTreeItem��6L   $��16��6$   $��16��6/   $��0,0,3,0q�6;   6L   �� 5/      ��6(   �� *
NodeName+$ TwoWay=�50       52      �� 54      $ False��55   R    54   *   �� $ 
IsSelected� �� $ TreeViewItemL�8   .a�56   "   �� $ iconTreeItem��6)    � �� 57   &   �� 58   *   8   59   .   ��5:   2   ../Images/Unknown.png��5<   3   5>   +   5@   #   5A      5F      �� 5H      .R�5I      �� $ 
Horizontal=�6%   .+�5J      �� $
 iconTreeItem��6L   $��16��6$   $��16��6/   $��0,0,3,0q�6;   6L   �� 5K      ��6&   �� *
NodeName+$ PropertyChanged=�$ TwoWay=�.��6q    5L   "   �� 5M   &   $ Enter��61    6=   �� *CommitEditClickCommand+ �� $ TreeViewItemL�.��5N   9   5O      5P       5Q      �� 5S      $
 True��5T   R    5S   *   �� $ IsInEditMode� �� $ TreeViewItemL�8   .a�5U   "   �� $ iconTreeItem��6)    � �� 5V   &   �� 5W   *   $
 Name�62   8   5X   .   ��5Y   2   ../Images/Unknown.png��5[   3   5]   +   5_   #   5`      5c      �� 5f      8��  .@�5h      m�  6#   �� $! Data.AddProjectClickCommand�8  ��5i      �� 5j   "   $ 
Horizontal=�6-   .+�5k   &   �� $��16��6,   $��16��67   $��0,0,3,0q�6C   $��../Images/Project.png��6U   �� 5l   &   $��New Project��67   5m   #   5o      5p      �� 5q      8��  .@�5r      m�  6#   �� $  Data.AddFolderClickCommand�8  ��5s      �� 5t   "   $ 
Horizontal=�6-   .+�5u   &   �� $��16��6,   $��16��67   $��0,0,3,0q�6C   $��../Images/AddFolder.png��6U   �� 5v   &   $��
New Folder��67   5w   #   5y      �� 5z      m� 5{       6#   �� $ Data.EditNodeClickCommand�8  ��5|      �� 5}   "   $ 
Horizontal=�6-   .+�5~   &   �� $��16��6,   $��16��67   $��0,0,3,0q�6C   $��../Images/Edit.png��6U   �� 5   &   $��Rename Project��67   5�   #   5�      �� 5�      m� 5�       6#   �� $! Data.DeleteNodeClickCommand�8  ��5�      �� 5�   "   $ 
Horizontal=�6-   .+�5�   &   �� $��16��6,   $��16��67   $��0,0,3,0q�6C   $��../Images/Delete.png��6U   �� 5�   &   $��Remove Project��67   5�   #   5�      5�      �� 5�      8��  .@�5�      m�  6#   �� $  Data.AddFolderClickCommand�8  ��5�      �� 5�   "   $ 
Horizontal=�6-   .+�5�   &   �� $��16��6,   $��16��67   $��0,0,3,0q�6C   $��../Images/AddFolder.png��6U   �� 5�   &   $��
New Folder��67   5�   #   5�      �� 5�      m� 5�       6#   �� $ Data.AddUIObjectCommand�8  ��5�      �� 5�   "   $ 
Horizontal=�6-   .+�5�   &   �� $��16��6,   $��16��67   $��0,0,3,0q�6C   $��../Images/Field.png��6U   �� 5�   &   $��Add UIObject��67   5�   #   5�      �� 5�      m� 5�       6#   �� $ Data.EditNodeClickCommand�8  ��5�      �� 5�   "   $ 
Horizontal=�6-   .+�5�   &   �� $��16��6,   $��16��67   $��0,0,3,0q�6C   $��../Images/Edit.png��6U   �� 5�   &   $��Rename Folder��67   5�   #   5�      �� 5�      m� 5�       6#   �� $! Data.DeleteNodeClickCommand�8  ��5�      �� 5�   "   $ 
Horizontal=�6-   .+�5�   &   �� $��16��6,   $��16��67   $��0,0,3,0q�6C   $��../Images/Delete.png��6U   �� 5�   &   $��Remove Folder��67   5�   #   5�      5�      �� 5�      8��  .@�5�      m�  6#   �� $ Data.EditNodeClickCommand�8  ��5�      �� 5�   "   $ 
Horizontal=�6-   .+�5�   &   �� $��16��6,   $��16��67   $��0,0,3,0q�6C   $��../Images/Edit.png��6U   �� 5�   &   $��Rename UIObject��67   5�   #   5�      �� 5�      m� 5�       6#   �� $! Data.DeleteNodeClickCommand�8  ��5�      �� 5�   "   $ 
Horizontal=�6-   .+�5�   &   �� $��16��6,   $��16��67   $��0,0,3,0q�6C   $��../Images/Delete.png��6U   �� 5�   &   $��Remove UIObject��67   5�   #   5�      5�        5�      8   8  8  8  5�   5   5�      ��5�      �� 5�       �� 
TargetType" Q�6   .�5�      ��  �@�ContextMenu 68   �� # [ �� 5�       �@Q�
IsExpanded 67   �� *
IsExpanded+$ TwoWay=��� 5�       �@Q�
IsSelected 67   �� *
IsSelected+$ TwoWay=��� 5�       � ��$ Normal"�67    �� Triggers 5�      P� 5�       P� Property �@Q�
IsSelected P� Value . . �5�   "   ��  � ��$
 Bold"�6?   5�      5�      ��5�      �� 5�        �� DataType,	   &CommandTestAutomation.Interfaces.INode"  	 6P   ! �� ItemsSource! 6/   �� *
Children+.R�5�      �� ��6+   �� ��5�      �� 5�   "   " ��6(   .�5�   &   ��  � ��# [ 6I    5�   &   ^� 5�   *   " ^� 
Conditions" 5�   .   �� 5�   2   # �� Binding# 6<   �� *IsInEditMode+$ TwoWay=�$ �� Value$ True6i   .0�5�   .   ��  � ��# [ 6P   5�   +   5�   #   5�      5�      5�      � 5�      % � DataContext% 6   �� * SelectedTestObjectTreeViewItem+y�6J   �� # [ & � RowDefinitions& 5�      �� 5�      $
��0.5* �6$   �� 5�      $��2* �6$   .+�5�      �� $��0��6   $��5,0,0,0q�6*   .+�5�      �� $ 
Horizontal=�6!   $��0,10,0,0q�6:   .+�5�      �� $��23��6$   $��Environment��62   $	��Top=�6E   $	��110��6]   �� 5�      $	��110��5  !   ��5�   #   ��  �� *FindAncestor+" >�$' !DataContext.EnvironmentCollection�' �� SelectedItem' 5  #   ��  �� *FindAncestor+" �$( "DataContext.UIFieldEnvironmentType�( �� SelectedValue( 5  "   �� $ UIFieldEnvironmentType�# [ ��5     �� 5  "   .R�5	  &   �� $ 
Horizontal=�61   .+�5
  *   �� $	��110��6E   $��23��6Q   ��64   �� 6Q   5  '   5  #   5     5     �� 5     $ 
Horizontal=�6!   $��0,10,0,0q�6:   .+�5     �� $��23��6$   $��Control Type��62   $	��Top=�6F   $	��110��6^   �� 5     $	��110��5  $   ��5  $   ��  �� *FindAncestor+" >�$' !DataContext.UIFieldTypeCollection�' 5     ��  �� *FindAncestor+" �$ DataContext.UIFieldType�( 5  $   �� $ UIFieldType�# [ ��5     �� 5  "   .R�5  &   �� $ 
Horizontal=�61   .+�5  *   �� $	��110��6E   $��23��6Q   ��64   �� 6Q   5  '   5   #   5"     5#     �� 5%     $ 
Horizontal=�6!   $��0,10,0,0q�6:   .+�5&     �� $��23��6$   $��Control Name��62   $	��Top=�6F   $	��110��6^   �� 5'     $��23��6<   $	��Top=�6J   $	��222��6b   ��6"   �� *
NodeName+6b   5(     5)     �� 5,     $��1��6   $��5,5,0,0q�6,   .+�5-     �� $ Vertical=�6!   .+�5.     �� $��UI Object Properties:��6$   $��0,20,0.333,5q�6A   �� 5/     .+�50     �� $
��Left=�6)   $ 
Horizontal=�6D   $��0,0,75,0q�6]   .+�52  "   �� -   5        ) ��Name$) btnAddProperty��52  *   $��20��6B   $��40��6N     stlFlatButton#��[ 6\   ��53  "   ��  �� *FindAncestor+" >�$) #DataContext.AddPropertyClickCommand�.��55  &   �� $��../Images/Add.png��6,   56  #   �� 59  "   -   5        $) btnRemoveProperty��59  *   $��20��6E   $��40��6Q   #��[ 6_   ��5:  "   ��  �� *FindAncestor+" >�$, &DataContext.RemovePropertyClickCommand�.��5=  &   �� $��../Images/Remove.png��6,   5>  #   �� 5?  "   -   5        $) btnSaveProperty��5?  *   $��20��6C   $��40��6O   #��[ 6]   ��5@  "   ��  �� *FindAncestor+" >�$* $DataContext.SavePropertyClickCommand�.��5C  &   �� $��../Images/Save.png��6,   5D  #   5F     &
   System.Windows.Controls.DataGrid
  5I     -   5        * 
 Name$* myPropCollection��5I  '   + 
  CanUserDeleteRows+ . $	��900��6Z   , 
  CanUserAddRows, .  - 
  CanUserResizeColumns- . . 
  CanUserResizeRows. .  / 
  AutoGenerateColumns/ .  0 
  EnableRowVirtualization0 .  $��0,2,0.333,-2.333q�5P  E   ��5K  $   �� 1 �� ElementName$1 myObjectTree��$( "SelectedItem.UIFieldPropCollection�$ TwoWay=�' 5M  #   ��  �� *FindAncestor+" >�$+ %DataContext.SelectedPropertyNameValue�2 
  RowHeaderStyle2 5Q  "   �� 5R  &   :  4System.Windows.Controls.Primitives.DataGridRowHeader"  6,   .�5S  *   ��  � ��$ 20��5T  L   5U  +   �� 5V  *    � �� 5W  .   `� 5X  2   3 `� 	Converter#3 [ 6?   .1�5Y  6   �� �� 5Z  6    6>   �� *FindAncestor+" 
 5[  3   5]  +   5^  '   4 
  Columns4 5`  "   4  .System.Windows.Controls.DataGridTemplateColumn  5c  &   ,  &System.Windows.Controls.DataGridColumn5   Header$5 Property��6=   6   Width5  /System.Windows.Controls.DataGridLengthConverter$6 * 6O   7   CellEditingTemplate7 5e  *   �� 5f  .   .R�5g  2   �� 8 ��Name$8 xProperties��5j  C   $	��200��66   ��5h  6   ��  �� *FindAncestor+" >�$( "DataContext.PropertyNameCollection�' 5k  6   ��  �� *FindAncestor+" �$ DataContext.PropertyName�( 5m  6   �� *PropertyName+��5n  6   �� 5o  :   .R�5p  >   �� ��6I   �� 5q  ;   5s  3   5t  /   9   CellTemplate9 5v  *   �� 5w  .   .R�5x  2   �� ��6<   �� *PropertyName+$ TwoWay=�5y  3   5z  /   5|  '   0  *System.Windows.Controls.DataGridTextColumn  5  &   $5 Value��69   $6 * 6H   1  +System.Windows.Controls.DataGridBoundColumn:   Binding: 6R   �� *PropertyValue+$ TwoWay=�5�     5�     5�     5�     5�     5�     5�     5�     