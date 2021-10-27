Imports System.Windows.Forms

Public Class SelectLang
    Public selectedLang As New List(Of String)
    Public Sub New()
        InitializeComponent()
    End Sub
    Public Sub New(langDic As Dictionary(Of String, String))
        MyClass.New
        For Each i As String In langDic.Keys
            ListView1.Items.Add(i).SubItems.Add(langDic(i))
        Next
    End Sub
    Public Sub allowMutil(f As Boolean)
        ListView1.MultiSelect = f
        ListView1.CheckBoxes = f
    End Sub

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        If ListView1.SelectedItems.Count = 0 Then Return
        If ListView1.MultiSelect Then
            For Each i As ListViewItem In ListView1.CheckedItems
                selectedLang.Add(i.Text)
            Next
        Else
            For Each i As ListViewItem In ListView1.SelectedItems
                selectedLang.Add(i.Text)
            Next
        End If
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

End Class
