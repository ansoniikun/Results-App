Imports System.IO 'This is required to create the file path
Imports System.Text 'This is required to update the text in the file

Public Class Form1

    Dim table As New DataTable()

    Private Sub btnCreate_Click(sender As Object, e As EventArgs) Handles btnCreate.Click

        Dim newFile As String = txtFileName.Text & ".txt" 'ensures that the fil created is a .txt file
        Dim fs As FileStream = File.Create(newFile)
        fs.Close()

    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click

        If txtStudentNo.Text = "" Or txtName.Text = "" Or txtSurname.Text = "" Or txtIndvAss.Text = "" Or txtGrpAss.Text = "" Or txtTest.Text = "" Then
            Dim message As String = "An input field was left open! Do you wish to continue?"
            MsgBox(message, MessageBoxIcon.Warning, "Warning") 'confirms if the users wants to contine with missing inputs;
        Else
            Dim text As New StringBuilder
            text.AppendLine(txtStudentNo.Text & "," & txtName.Text & "," & txtSurname.Text & "," & txtIndvAss.Text & "," & txtGrpAss.Text & "," & txtTest.Text)
            Dim filepath As String = txtFileName.Text & ".txt" 'sets the file path as the same path in the file name text box;
            File.AppendAllText(filepath, text.ToString()) 'updates the text within the file & converts all data type to stings

            txtStudentNo.Text = "" 'sets the initial text within the text box to empty;
            txtName.Text = ""
            txtSurname.Text = ""
            txtIndvAss.Text = ""
            txtGrpAss.Text = ""
            txtTest.Text = ""
        End If

    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        table.Columns.Add("Student No.", Type.GetType("System.String")) 'sets the table contents
        table.Columns.Add("First name", Type.GetType("System.String"))
        table.Columns.Add("Surname", Type.GetType("System.String"))
        table.Columns.Add("Indv Assign", Type.GetType("System.String"))
        table.Columns.Add("Grp Assign", Type.GetType("System.String"))
        table.Columns.Add("Test", Type.GetType("System.String"))

        DataGridView1.DataSource = table

    End Sub

    Private Sub btnDisplay_Click(sender As Object, e As EventArgs) Handles btnDisplay.Click

        Dim lines() As String
        Dim vals() As String
        Dim path As String = txtFileName.Text & ".txt" 'created a variable to hold the file name(path)

        If txtFileName.Text = "" Then
            MsgBox("Please enter the file name you would like to display!", MessageBoxIcon.Warning, "Warning")
        Else
            lines = File.ReadAllLines(path) 'making a template string doesn't work for files

            For i As Integer = 0 To lines.Length - 1 Step +1 'for loop to iterate through each line and word

                vals = lines(i).ToString().Split(",") 'remove each instance of "," after each word
                Dim row(vals.Length - 1) As String

                For j As Integer = 0 To vals.Length - 1 Step +1

                    row(j) = vals(j).Trim()

                Next j

                table.Rows.Add(row)

            Next i
        End If



    End Sub

    'Designed and coded by Hlompho Maleke 202105507
End Class
