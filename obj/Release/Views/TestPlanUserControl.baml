   M S B A M L   `   `   `  ���� M  IPortableAutomation, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullS.clr-namespace:CommandTestAutomation.ViewModels CommandTestAutomation.ViewModels  M+clr-namespace:CommandTestAutomation.HelpersCommandTestAutomation.Helpers  K*clr-namespace:CommandTestAutomation.ModelsCommandTestAutomation.Models  S.clr-namespace:CommandTestAutomation.Interfaces CommandTestAutomation.Interfaces  I)clr-namespace:CommandTestAutomation.ViewsCommandTestAutomation.Views  c _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35qPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.InteractivitySystem.Windows.Interactivity 5    /CommandTestAutomation.Views.TestPlanUserControl   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     =vm.clr-namespace:CommandTestAutomation.ViewModels     B
converters+clr-namespace:CommandTestAutomation.Helpers     =models*clr-namespace:CommandTestAutomation.Models     E
interfaces.clr-namespace:CommandTestAutomation.Interfaces     ?	uControls)clr-namespace:CommandTestAutomation.Views     jinteractivityPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.Interactivity       � 	Resources  0   *CommandTestAutomation.Helpers.BindingProxy   DataContextProxy   Data1   +CommandTestAutomation.Helpers.PathConverter  iconConverter6   0CommandTestAutomation.Helpers.RowNumberConverter  rowToIndexConverter8   2CommandTestAutomation.Helpers.ContextMenuConverter  contextMenuConverter3   -CommandTestAutomation.Helpers.IsNullConverter  isNullConverter>  8CommandTestAutomation.Helpers.INodeToVisibilityConverter  nodeToVisibilityConverter  tbMargin��%   &	        &	      &	      &	      &	      &	 "     &	 '        ��           u�0,10,0,0q� J� InputBindings �� 
 �� Key$ F2�� �� Command �� *EditNodeClickCommand+�� $ Enter�� �� *CommitEditClickCommand+.��]� .+���  �� Orientation$ 
Horizontal=�.+�4   .CommandTestAutomation.Helpers.ExtendedTreeView  -     Name$ myTestPlanTree��$	��200������  �� Path$ ProjectData� �� Mode$ TwoWay=�	   SelectedItem_	 �� *SelectedTestPlanTreeViewItem+$ TwoWay=�    NormalTemplate
 ��Name �� Triggers �� Value �� Binding �� RelativeSource �� AncestorType �� 	Converter �� 
TargetName �� Property �� Value �� FallbackValue  EditTemplate �� UpdateSourceTrigger 	 RootMenu 
 contextMenuStyle m� Command �� Source  ProjectMenu  
FolderMenu  TestCaseMenu   RootMenu   ProjectMenu   
FolderMenu   FileMenu��%x
  &	       7  7  &	 %    7  7  &		 �    7 
 7   &	 ~    7 
 7   7   7   &	 �    7 
 7   7   7   7   &	 X    7 
 7   7   &	 �	    7 	 7  7  7  �� .R��� $ 
Horizontal=�.+��� $
 iconTreeItem��$��16��$��16��$��0,0,3,0q��� ���� *
NodeName+$ TwoWay=� �� $ False�� �� $ 
IsSelected� �� $ TreeViewItemL�8   .a��� $ iconTreeItem�� � �� �� 8   ��../Images/Unknown.png���� .R��� $ 
Horizontal=�.+��� $
 iconTreeItem��$��16��$��16��$��0,0,3,0q��� ���� *
NodeName+$ PropertyChanged=�$ TwoWay=�.�� �� $ Enter�� �� *CommitEditClickCommand+ �� $ TreeViewItemL�.�� �� $
 True�� �� $ IsInEditMode� �� $ TreeViewItemL�8   .a��� $ iconTreeItem�� � �� �� $
 Name�8   ��../Images/Unknown.png���� 8��  .@�m�  �� $! Data.AddProjectClickCommand�8  ���� $ 
Horizontal=�.+��� $��16��$��16��$��0,0,3,0q�$��../Images/Project.png���� $��New Project���� 8��  .@�m�  �� $  Data.AddFolderClickCommand�8  ���� $ 
Horizontal=�.+��� $��16��$��16��$��0,0,3,0q�$��../Images/AddFolder.png���� $��
New Folder���� m�  �� $ Data.EditNodeClickCommand�8  ���� $ 
Horizontal=�.+��� $��16��$��16��$��0,0,3,0q�$��../Images/Edit.png���� $��Rename Project���� m�  �� $! Data.DeleteNodeClickCommand�8  ���� $ 
Horizontal=�.+��� $��16��$��16��$��0,0,3,0q�$��../Images/Delete.png���� $��Remove Project���� 8��  .@�m�  �� $  Data.AddFolderClickCommand�8  ���� $ 
Horizontal=�.+��� $��16��$��16��$��0,0,3,0q�$��../Images/AddFolder.png���� $��
New Folder���� m�  �� $" Data.AddTestCaseClickCommand�8  ���� $ 
Horizontal=�.+��� $��16��$��16��$��0,0,3,0q�$��../Images/TestCase.png���� $��Add TestCase���� m�  �� $ Data.EditNodeClickCommand�8  ���� $ 
Horizontal=�.+��� $��16��$��16��$��0,0,3,0q�$��../Images/Edit.png���� $��Rename Folder���� m�  �� $! Data.DeleteNodeClickCommand�8  ���� $ 
Horizontal=�.+��� $��16��$��16��$��0,0,3,0q�$��../Images/Delete.png���� $��Remove Folder���� 8��  .@�m�  �� $ Data.EditNodeClickCommand�8  ���� $ 
Horizontal=�.+��� $��16��$��16��$��0,0,3,0q�$��../Images/Edit.png���� $��Rename TestCase���� m�  �� $! Data.DeleteNodeClickCommand�8  ���� $ 
Horizontal=�.+��� $��16��$��16��$��0,0,3,0q�$��../Images/Delete.png���� $��Remove Test Case��  8   8  8  8  ����  �� 
TargetType" Q�.���  �@�ContextMenu �� # [ ��  �@Q�
IsExpanded �� *
IsExpanded+$ TwoWay=���  �@Q�
IsSelected �� *
IsSelected+$ TwoWay=���  � ��$ Normal"� �� Triggers P�  P� Property �@Q�
IsSelected P� Value . . ���  � ��$
 Bold"�����   �� DataType,   &CommandTestAutomation.Interfaces.INode"   ! �� ItemsSource! �� *
Children+.R��� ���� ���� " ��.���  � ��# [  ^� " ^� 
Conditions" �� # �� Binding# �� *IsInEditMode+$ TwoWay=�$ �� Value$ True.0���  � ��# [ �� y��� # [ $" SelectedTestPlanTreeViewItem�.+��� $
��Left=�$ 
Horizontal=�$��0,0,75,0q�.+��� -   % ��Name$% 
btnAddStep��$��20��$��40��  stlFlatButton#��[ ����  �� *FindAncestor+" >�$) #DataContext.AddTestStepClickCommand�.���� $��../Images/Add.png���� -   $% btnRemoveTestStep��$��20��$��40��#��[ ����  �� *FindAncestor+" >�$, &DataContext.RemoveTestStepClickCommand�.���� $��../Images/Remove.png���� -   $% btnSaveTestCaseStep��$��20��$��40��#��[ ����  �� *FindAncestor+" >�$* $DataContext.SaveTestStepClickCommand�.���� $��../Images/Save.png��&	   System.Windows.Controls.DataGrid	  -   & 	 Name$& myDataGridTestSteps��' 	  CanUserDeleteRows' . $	��900��( 	  CanUserAddRows( .  ) 	  CanUserResizeColumns) . * 	  CanUserResizeRows* .  + 	  AutoGenerateColumns+ .  , 	  EnableRowVirtualization, .  $��0,2,0.333,-2.333q����� - �� ElementName$- myTestPlanTree��$  SelectedItem.TestStepsData�$ TwoWay=�. �� SelectedItem. �� *SelectedTestStep+$ TwoWay=�/ 	  RowHeaderStyle/ �� :
  4System.Windows.Controls.Primitives.DataGridRowHeader" 
 .���  � ��$ 20����  � �� `� 0 `� 	Converter#0 [ .1��� ��  �� *FindAncestor+" 	 1 	  Columns1 4  .System.Windows.Controls.DataGridTemplateColumn  ,  &System.Windows.Controls.DataGridColumn2   Header$2 	UI Object��3   Width5  /System.Windows.Controls.DataGridLengthConverter$3 * 4   CellEditingTemplate4 �� .R�  $ myUIObjectTree��$	��200������  �� *FindAncestor+" >�$ DataContext.ObjectMapData�$ TwoWay=�	 ��  �� *FindAncestor+" >�$2 ,DataContext.SelectedTestStep.UiFieldNodeItem�$ PropertyChanged=�$ TwoWay=�  ��%7  &	       7  7  �� .R��� $ 
Horizontal=�.+��� $
 iconTreeItem��$��16��$��16��$��0,0,3,0q��� ���� *
NodeName+$ TwoWay=� �� $ False�� �� $ 
IsSelected� �� $ TreeViewItemL�8   .a��� $ iconTreeItem�� � �� �� 8   ��../Images/Unknown.png������ " Q�.���  �@Q�
IsExpanded �� *
IsExpanded+$ TwoWay=���  �@Q�
IsSelected �� *
IsSelected+$ TwoWay=���  � ��$ Normal"� P�  �@Q�
IsSelected . . ���  � ��$
 Bold"����� "   ! �� *
Children+.R��� ���� ���� " ��.���  � ��# [ 5   CellTemplate5 �� .R��� 6 ��Name$6 
txtUiField������ *UiFieldNodeItem.NodeName+$ TwoWay=�  $2 Action��$3 * 5 �� .R��� ���� *TestStepFieldActionName+4 �� .R��� ���� $ UIFieldActions�$ TwoWay=�. �� *TestStepFieldActionName+���� .R��� ���� 0  *System.Windows.Controls.DataGridTextColumn  $2 Value��$3 * 1  +System.Windows.Controls.DataGridBoundColumn7   Binding7 �� *TestStepFieldActionValue+