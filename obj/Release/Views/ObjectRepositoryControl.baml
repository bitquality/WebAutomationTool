   M S B A M L   `   `   `  ���� M  IPortableAutomation, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullK*clr-namespace:CommandTestAutomation.ModelsCommandTestAutomation.Models  S.clr-namespace:CommandTestAutomation.ViewModels CommandTestAutomation.ViewModels  K*clr-namespace:CommandTestAutomation.ModelsCommandTestAutomation.Models  S.clr-namespace:CommandTestAutomation.Interfaces CommandTestAutomation.Interfaces  I)clr-namespace:CommandTestAutomation.ViewsCommandTestAutomation.Views  M+clr-namespace:CommandTestAutomation.HelpersCommandTestAutomation.Helpers  M+clr-namespace:CommandTestAutomation.HelpersCommandTestAutomation.Helpers  9    3CommandTestAutomation.Views.ObjectRepositoryControl   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     <model*clr-namespace:CommandTestAutomation.Models     @local.clr-namespace:CommandTestAutomation.ViewModels     =models*clr-namespace:CommandTestAutomation.Models     E
interfaces.clr-namespace:CommandTestAutomation.Interfaces     ?	uControls)clr-namespace:CommandTestAutomation.Views     B
converters+clr-namespace:CommandTestAutomation.Helpers     DmyConverters+clr-namespace:CommandTestAutomation.Helpers       � 	Resources  0   *CommandTestAutomation.Helpers.BindingProxy   DataContextProxy   Data9   3CommandTestAutomation.Helpers.EnumToStringConverter  EnumToStringConverter1   +CommandTestAutomation.Helpers.PathConverter  iconConverter6   0CommandTestAutomation.Helpers.RowNumberConverter  rowToIndexConverter8   2CommandTestAutomation.Helpers.ContextMenuConverter  contextMenuConverter3   -CommandTestAutomation.Helpers.IsNullConverter  isNullConverter>  8CommandTestAutomation.Helpers.INodeToVisibilityConverter  nodeToVisibilityConverter��%r   &	        &	      &	      &	      &	      &	 "     &	 '        ��              J� InputBindings �� 
 �� Key$ F2�� �� Command �� *EditNodeClickCommand+�� $ Enter�� �� *CommitEditClickCommand+.��]� .+���  �� Orientation$ 
Horizontal=�.+�4   .CommandTestAutomation.Helpers.ExtendedTreeView  -     Name$ myObjectTree��$	��200������  �� Path$ ObjectMapData� �� Mode$ TwoWay=�	   SelectedItem_	 �� * SelectedTestObjectTreeViewItem+$ TwoWay=�    NormalTemplate
 ��Name �� Triggers �� Value �� Binding �� RelativeSource �� AncestorType �� 	Converter �� 
TargetName �� Property �� Value �� FallbackValue  EditTemplate �� UpdateSourceTrigger 	 RootMenu 
 contextMenuStyle m� Command �� Source  ProjectMenu  
FolderMenu  UIObjectMenu   RootMenu   ProjectMenu   
FolderMenu   UIObjectMenu��%o
  &	       7  7  &	 %    7  7  &		 �    7 
 7   &	 ~    7 
 7   7   7   &	 �    7 
 7   7   7   7   &	 P    7 
 7   7   &	 �	    7 	 7  7  7  �� .R��� $ 
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
New Folder���� m�  �� $ Data.AddUIObjectCommand�8  ���� $ 
Horizontal=�.+��� $��16��$��16��$��0,0,3,0q�$��../Images/Field.png���� $��Add UIObject���� m�  �� $ Data.EditNodeClickCommand�8  ���� $ 
Horizontal=�.+��� $��16��$��16��$��0,0,3,0q�$��../Images/Edit.png���� $��Rename Folder���� m�  �� $! Data.DeleteNodeClickCommand�8  ���� $ 
Horizontal=�.+��� $��16��$��16��$��0,0,3,0q�$��../Images/Delete.png���� $��Remove Folder���� 8��  .@�m�  �� $ Data.EditNodeClickCommand�8  ���� $ 
Horizontal=�.+��� $��16��$��16��$��0,0,3,0q�$��../Images/Edit.png���� $��Rename UIObject���� m�  �� $! Data.DeleteNodeClickCommand�8  ���� $ 
Horizontal=�.+��� $��16��$��16��$��0,0,3,0q�$��../Images/Delete.png���� $��Remove UIObject��  8   8  8  8  ����  �� 
TargetType" Q�.���  �@�ContextMenu �� # [ ��  �@Q�
IsExpanded �� *
IsExpanded+$ TwoWay=���  �@Q�
IsSelected �� *
IsSelected+$ TwoWay=���  � ��$ Normal"� �� Triggers P�  P� Property �@Q�
IsSelected P� Value . . ���  � ��$
 Bold"�����   �� DataType,	   &CommandTestAutomation.Interfaces.INode"  	 ! �� ItemsSource! �� *
Children+.R��� ���� ���� " ��.���  � ��# [  ^� " ^� 
Conditions" �� # �� Binding# �� *IsInEditMode+$ TwoWay=�$ �� Value$ True.0���  � ��# [ � % � DataContext% �� * SelectedTestObjectTreeViewItem+y��� # [ & � RowDefinitions& �� $
��0.5* ��� $��2* �.+��� $��0��$��5,0,0,0q�.+��� $ 
Horizontal=�$��0,10,0,0q�.+��� $��23��$��Application Type��$	��Top=�$	��110���� $	��110������  �� *FindAncestor+" >�$' !DataContext.EnvironmentCollection�' �� SelectedItem' ��  �� *FindAncestor+" �$( "DataContext.UIFieldEnvironmentType�( �� SelectedValue( �� $ UIFieldEnvironmentType�# [ ���� .R��� $ 
Horizontal=�.+��� $	��110��$��23������ �� $ 
Horizontal=�$��0,10,0,0q�.+��� $��23��$��Control Type��$	��Top=�$	��110���� $	��110������  �� *FindAncestor+" >�$' !DataContext.UIFieldTypeCollection�' ��  �� *FindAncestor+" �$ DataContext.UIFieldType�( �� $ UIFieldType�# [ ���� .R��� $ 
Horizontal=�.+��� $	��110��$��23������ �� $ 
Horizontal=�$��0,10,0,0q�.+��� $��23��$��Control Name��$	��Top=�$	��110���� $��23��$	��Top=�$	��222������ *
NodeName+�� $��1��$��5,5,0,0q�.+��� $ Vertical=�.+��� $��UI Object Properties:��$��0,20,0.333,5q��� .+��� $
��Left=�$ 
Horizontal=�$��0,0,75,0q�.+��� -   ) ��Name$) btnAddProperty��$��20��$��40��  stlFlatButton#��[ ����  �� *FindAncestor+" >�$) #DataContext.AddPropertyClickCommand�.���� $��../Images/Add.png���� -   $) btnRemoveProperty��$��20��$��40��#��[ ����  �� *FindAncestor+" >�$, &DataContext.RemovePropertyClickCommand�.���� $��../Images/Remove.png���� -   $) btnSaveProperty��$��20��$��40��#��[ ����  �� *FindAncestor+" >�$* $DataContext.SavePropertyClickCommand�.���� $��../Images/Save.png��&
   System.Windows.Controls.DataGrid
  -   * 
 Name$* myPropCollection��+ 
  CanUserDeleteRows+ . $	��900��, 
  CanUserAddRows, .  - 
  CanUserResizeColumns- . . 
  CanUserResizeRows. .  / 
  AutoGenerateColumns/ .  0 
  EnableRowVirtualization0 .  $��0,2,0.333,-2.333q����� 1 �� ElementName$1 myObjectTree��$( "SelectedItem.UIFieldPropCollection�$ TwoWay=�' ��  �� *FindAncestor+" >�$+ %DataContext.SelectedPropertyNameValue�2 
  RowHeaderStyle2 �� :  4System.Windows.Controls.Primitives.DataGridRowHeader"  .���  � ��$ 20����  � �� `� 3 `� 	Converter#3 [ .1��� ��  �� *FindAncestor+" 
 4 
  Columns4 4  .System.Windows.Controls.DataGridTemplateColumn  ,  &System.Windows.Controls.DataGridColumn5   Header$5 Property��6   Width5  /System.Windows.Controls.DataGridLengthConverter$6 * 7   CellEditingTemplate7 �� .R��� 8 ��Name$8 xProperties��$	��200������  �� *FindAncestor+" >�$( "DataContext.PropertyNameCollection�' ��  �� *FindAncestor+" �$ DataContext.PropertyName�( �� *PropertyName+���� .R��� ���� 9   CellTemplate9 �� .R��� ���� *PropertyName+$ TwoWay=�0  *System.Windows.Controls.DataGridTextColumn  $5 Value��$6 * 1  +System.Windows.Controls.DataGridBoundColumn:   Binding: �� *PropertyValue+$ TwoWay=�