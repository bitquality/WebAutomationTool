   M S B A M L   `   `   `  ����M  IPortableAutomation, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullS.clr-namespace:CommandTestAutomation.ViewModels CommandTestAutomation.ViewModels  5      M+clr-namespace:CommandTestAutomation.HelpersCommandTestAutomation.Helpers  5	      K*clr-namespace:CommandTestAutomation.ModelsCommandTestAutomation.Models  5
      S.clr-namespace:CommandTestAutomation.Interfaces CommandTestAutomation.Interfaces  5      I)clr-namespace:CommandTestAutomation.ViewsCommandTestAutomation.Views  5      c _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35qPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.InteractivitySystem.Windows.Interactivity 5      5    /CommandTestAutomation.Views.TestPlanUserControl   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      =vm.clr-namespace:CommandTestAutomation.ViewModels     5      B
converters+clr-namespace:CommandTestAutomation.Helpers     5	      =models*clr-namespace:CommandTestAutomation.Models     5
      E
interfaces.clr-namespace:CommandTestAutomation.Interfaces     5      ?	uControls)clr-namespace:CommandTestAutomation.Views     5      jinteractivityPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.Interactivity     5        � 	Resources  5      0   *CommandTestAutomation.Helpers.BindingProxy   DataContextProxy   Data1   +CommandTestAutomation.Helpers.PathConverter  iconConverter6   0CommandTestAutomation.Helpers.RowNumberConverter  rowToIndexConverter8   2CommandTestAutomation.Helpers.ContextMenuConverter  contextMenuConverter3   -CommandTestAutomation.Helpers.IsNullConverter  isNullConverter>  8CommandTestAutomation.Helpers.INodeToVisibilityConverter  nodeToVisibilityConverter  tbMargin��%�   &	        &	      &	 /     &	 B     &	 U     &	 h     &	 {       5   
    6<   ��   5   
   6#     5   
   6(     5   
   6*     5   
   6%     5   
   60   u�5   
   0,10,0,0q�6/   5       J� InputBindings 5      �� 5   
   
 �� Key$ F2��6    �� Command 6   �� *EditNodeClickCommand+�� 5   
   $ Enter��6    6!   �� *CommitEditClickCommand+.��5      ]� .+�5   
   ��  �� Orientation$ 
Horizontal=�6   .+�5!      4   .CommandTestAutomation.Helpers.ExtendedTreeView  -   5          Name$ myTestPlanTree��5"   <   $	��200��6/   ��5!   /   ��  �� Path$ ProjectData� �� Mode$ TwoWay=�	   SelectedItem_	 5$   /   �� *SelectedTestPlanTreeViewItem+$ TwoWay=�  5&        NormalTemplate
 ��Name �� Triggers �� Value �� Binding �� RelativeSource �� AncestorType �� 	Converter �� 
TargetName �� Property �� Value �� FallbackValue  EditTemplate �� UpdateSourceTrigger 	 RootMenu 
 contextMenuStyle m� Command �� Source  ProjectMenu  
FolderMenu  TestCaseMenu   RootMenu   ProjectMenu   
FolderMenu   FileMenu��%�  &	       7  7  &	 �    7  7  &		 �    7 
 7   &	 �    7 
 7   7   7   &	 /	    7 
 7   7   7   7   &	 �    7 
 7   7   &	 �    7 	 7  7  7  �� 5)      .R�5+      �� $ 
Horizontal=�6%   .+�5,      �� $
 iconTreeItem��6L   $��16��6$   $��16��6/   $��0,0,3,0q�6;   6L   �� 5-      ��6(   �� *
NodeName+$ TwoWay=�5.       50      �� 52      $ False��53   R    52   *   �� $ 
IsSelected� �� $ TreeViewItemL�8   .a�54   "   �� $ iconTreeItem��6)    � �� 55   &   �� 56   *   8   57   .   ��58   2   ../Images/Unknown.png��5:   3   5<   +   5>   #   5?      5D      �� 5F      .R�5G      �� $ 
Horizontal=�6%   .+�5H      �� $
 iconTreeItem��6L   $��16��6$   $��16��6/   $��0,0,3,0q�6;   6L   �� 5I      ��6&   �� *
NodeName+$ PropertyChanged=�$ TwoWay=�.��6q    5J   "   �� 5K   &   $ Enter��61    6=   �� *CommitEditClickCommand+ �� $ TreeViewItemL�.��5L   9   5M      5N       5O      �� 5Q      $
 True��5R   R    5Q   *   �� $ IsInEditMode� �� $ TreeViewItemL�8   .a�5S   "   �� $ iconTreeItem��6)    � �� 5T   &   �� 5U   *   $
 Name�62   8   5V   .   ��5W   2   ../Images/Unknown.png��5Y   3   5[   +   5]   #   5^      5a      �� 5d      8��  .@�5e      m�  6'   �� $! Data.AddProjectClickCommand�8  ��5f   "   �� 5g   &   $ 
Horizontal=�61   .+�5h   *   �� $��16��60   $��16��6;   $��0,0,3,0q�6G   $��../Images/Project.png��6Y   �� 5i   *   $��New Project��6;   5j   '   5l      5m      �� 5n      8��  .@�5p      m�  6'   �� $  Data.AddFolderClickCommand�8  ��5q   "   �� 5r   &   $ 
Horizontal=�61   .+�5s   *   �� $��16��60   $��16��6;   $��0,0,3,0q�6G   $��../Images/AddFolder.png��6Y   �� 5t   *   $��
New Folder��6;   5u   '   5w      �� 5x      m� 5y       6'   �� $ Data.EditNodeClickCommand�8  ��5z   "   �� 5{   &   $ 
Horizontal=�61   .+�5|   *   �� $��16��60   $��16��6;   $��0,0,3,0q�6G   $��../Images/Edit.png��6Y   �� 5}   *   $��Rename Project��6;   5~   '   5�      �� 5�      m� 5�       6'   �� $! Data.DeleteNodeClickCommand�8  ��5�      �� 5�   "   $ 
Horizontal=�6-   .+�5�   &   �� $��16��6,   $��16��67   $��0,0,3,0q�6C   $��../Images/Delete.png��6U   �� 5�   &   $��Remove Project��67   5�   #   5�      5�      �� 5�      8��  .@�5�      m�  6'   �� $  Data.AddFolderClickCommand�8  ��5�   "   �� 5�   &   $ 
Horizontal=�61   .+�5�   *   �� $��16��60   $��16��6;   $��0,0,3,0q�6G   $��../Images/AddFolder.png��6Y   �� 5�   *   $��
New Folder��6;   5�   '   5�      �� 5�      m� 5�       6'   �� $" Data.AddTestCaseClickCommand�8  ��5�   "   �� 5�   &   $ 
Horizontal=�61   .+�5�   *   �� $��16��60   $��16��6;   $��0,0,3,0q�6G   $��../Images/TestCase.png��6Y   �� 5�   *   $��Add TestCase��6;   5�   '   5�      �� 5�      m� 5�       6'   �� $ Data.EditNodeClickCommand�8  ��5�   "   �� 5�   &   $ 
Horizontal=�61   .+�5�   *   �� $��16��60   $��16��6;   $��0,0,3,0q�6G   $��../Images/Edit.png��6Y   �� 5�   *   $��Rename Folder��6;   5�   '   5�      �� 5�      m� 5�       6'   �� $! Data.DeleteNodeClickCommand�8  ��5�   #   �� 5�   '   $ 
Horizontal=�62   .+�5�   ,   �� $��16��62   $��16��6=   $��0,0,3,0q�6I   $��../Images/Delete.png��6[   �� 5�   +   $��Remove Folder��6<   5�   (   5�       5�      �� 5�      8��  .@�5�      m�  6'   �� $ Data.EditNodeClickCommand�8  ��5�   "   �� 5�   &   $ 
Horizontal=�61   .+�5�   *   �� $��16��60   $��16��6;   $��0,0,3,0q�6G   $��../Images/Edit.png��6Y   �� 5�   *   $��Rename TestCase��6;   5�   '   5�      �� 5�      m� 5�       6(   �� $! Data.DeleteNodeClickCommand�8  ��5�      �� 5�   "   $ 
Horizontal=�6-   .+�5�   &   �� $��16��6,   $��16��67   $��0,0,3,0q�6C   $��../Images/Delete.png��6U   �� 5�   &   $��Remove Test Case��67   5�   #   5�      5�        5�      8   8  8  8  5�   1   5�      ��5�      �� 5�       �� 
TargetType" Q�6   .�5�      ��  �@�ContextMenu 68   �� # [ �� 5�       �@Q�
IsExpanded 67   �� *
IsExpanded+$ TwoWay=��� 5�       �@Q�
IsSelected 67   �� *
IsSelected+$ TwoWay=��� 5�       � ��$ Normal"�67    �� Triggers 5�      P� 5�       P� Property �@Q�
IsSelected P� Value . . �5�   "   ��  � ��$
 Bold"�6?   5�      5�      ��5�      �� 5�        �� DataType,   &CommandTestAutomation.Interfaces.INode"   6T   ! �� ItemsSource! 63   �� *
Children+.R�5�       �� ��61   �� ��5�   $   �� 5�   '   " ��6-   .�5�   *   ��  � ��# [ 6M    5�   (   ^� 5�   *   " ^� 
Conditions" 5�   .   �� 5�   2   # �� Binding# 6<   �� *IsInEditMode+$ TwoWay=�$ �� Value$ True6i   .0�5�   .   ��  � ��# [ 6P   5�   +   5�   #   5�      5�      5�      �� 5�      y�6   �� # [ $" SelectedTestPlanTreeViewItem�.+�5�      �� $
��Left=�6   $ 
Horizontal=�68   $��0,0,75,0q�6Q   .+�5�      �� -   5        % ��Name$% 
btnAddStep��5�      $��20��62   $��40��6>     stlFlatButton#��[ 6L   ��5�   !   ��  �� *FindAncestor+" >�$) #DataContext.AddTestStepClickCommand�.��5      �� $��../Images/Add.png��6    5     �� 5     -   5        $% btnRemoveTestStep��5     $��20��69   $��40��6E   #��[ 6S   ��5  "   ��  �� *FindAncestor+" >�$, &DataContext.RemoveTestStepClickCommand�.��5     �� $��../Images/Remove.png��6    5     �� 5     -   5        $% btnSaveTestCaseStep��5     $��20��6;   $��40��6G   #��[ 6U   ��5	  "   ��  �� *FindAncestor+" >�$* $DataContext.SaveTestStepClickCommand�.��5     �� $��../Images/Save.png��6    5     5     &	   System.Windows.Controls.DataGrid	  5     -   5        & 	 Name$& myDataGridTestSteps��5     ' 	  CanUserDeleteRows' . $	��900��6Q   ( 	  CanUserAddRows( .  ) 	  CanUserResizeColumns) . * 	  CanUserResizeRows* .  + 	  AutoGenerateColumns+ .  , 	  EnableRowVirtualization, .  $��0,2,0.333,-2.333q�5  =   ��5     �� - �� ElementName$- myTestPlanTree��$  SelectedItem.TestStepsData�$ TwoWay=�. �� SelectedItem. 5     �� *SelectedTestStep+$ TwoWay=�/ 	  RowHeaderStyle/ 5     �� 5     :
  4System.Windows.Controls.Primitives.DataGridRowHeader" 
 6    .�5     ��  � ��$ 20��5  @   5     �� 5      � �� 5  "   `� 5  &   0 `� 	Converter#0 [ 63   .1�5   *   �� �� 5!  *    62   �� *FindAncestor+" 	 5"  '   5$     5%     1 	  Columns1 5'     4  .System.Windows.Controls.DataGridTemplateColumn  5*     ,  &System.Windows.Controls.DataGridColumn2   Header$2 Action��61   3   Width5  /System.Windows.Controls.DataGridLengthConverter$3 * 6A   4   CellTemplate4 5+     �� 5,  "   .R�5-  &   �� ��63   �� *TestStepFieldActionName+5.  #   5   CellEditingTemplate5 50     �� 51  "   .R�52  &   �� ��60   �� $ UIFieldActions�$ TwoWay=�. 53  0   �� *TestStepFieldActionName+��54  *   �� 55  .   .R�56  2   �� ��6=   �� 57  /   59  '   5:  #   5<       5B     $2 	UI Object��61   $3 * 6D   5 5C     �� 5D  "   .R�5E  &     $ myUIObjectTree��5H  >   $	��200��61   ��5F  1   ��  �� *FindAncestor+" >�$ DataContext.ObjectMapData�$ TwoWay=�	 5I  1   ��  �� *FindAncestor+" >�$2 ,DataContext.SelectedTestStep.UiFieldNodeItem�$ PropertyChanged=�$ TwoWay=�  5L  *   ��%
  &	       7  7  �� 5M  .   .R�5N  2   �� $ 
Horizontal=�6=   .+�5O  6   �� $
 iconTreeItem��6d   $��16��6<   $��16��6G   $��0,0,3,0q�6S   6d   �� 5P  6   ��6@   �� *
NodeName+$ TwoWay=�5Q  3    5S  2   �� 5T  6   $ False��5U  f    5T  B   �� $ 
IsSelected� �� $ TreeViewItemL�8   .a�5V  :   �� $ iconTreeItem��6A    � �� 5W  >   �� 5X  B   8   5Y  F   ��5Z  J   ../Images/Unknown.png��5\  K   5^  C   5`  ;   5a  7   5d  /   5f  +   ��5g  *   �� 5h  .   " Q�64   .�5i  2   ��  �@Q�
IsExpanded 6O   �� *
IsExpanded+$ TwoWay=��� 5j  2    �@Q�
IsSelected 6O   �� *
IsSelected+$ TwoWay=��� 5k  2    � ��$ Normal"�6O    5l  2   P� 5m  6    �@Q�
IsSelected . . �5n  :   ��  � ��$
 Bold"�6W   5o  7   5q  /   ��5s  *   �� 5t  .   "   6h   ! 6G   �� *
Children+.R�5u  0   �� ��6A   �� ��5v  6   �� 5w  :   " ��6@   .�5x  >   ��  � ��# [ 6`   5y  ;   5{  3   5|  /   5~  '   5  #   4 5�     �� 5�  "   .R�5�  &   �� 6 ��Name$6 
txtUiField��60   ��6D   �� *UiFieldNodeItem.NodeName+$ TwoWay=�5�  '   5�  #   5�     0  *System.Windows.Controls.DataGridTextColumn  5�     $2 Value��6-   $3 * 6<   1  +System.Windows.Controls.DataGridBoundColumn7   Binding7 6F   �� *TestStepFieldActionValue+  5�     $2 Description��6-   $3 * 6B   7 6L   �� *TestStepDescription+5�     5�     5�     5�     5�     