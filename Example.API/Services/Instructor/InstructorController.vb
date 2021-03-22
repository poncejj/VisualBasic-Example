Imports System.Threading.Tasks

Namespace Services.Instructor
    Public Class InstructorController
        Inherits Controller
        Private _service As IInstructorService

        Public Sub New(ByVal service As IInstructorService)
            _service = service
        End Sub

        Public Function GetAll() As ActionResult
            Dim instructors = _service.GetAllInstructors()
            Return View(instructors)
        End Function

        Public Function GetById(ByVal instructorId As Integer) As ActionResult
            Dim instructor = _service.GetById(instructorId)
            Return View(instructor)
        End Function

        <HttpPost()>
        Public Async Function Insert(instructor As InstructorDto) As Task(Of ActionResult)
            Dim result = Await _service.InsertAsync(instructor)
            Return View(result)
        End Function

        <HttpPut()>
        Public Async Function Update(instructor As InstructorDto) As Task(Of ActionResult)
            Dim result = Await _service.UpdateAsync(instructor)
            Return View(result)
        End Function

        <HttpDelete()>
        Public Async Function Delete(instructorId As Integer) As Task(Of ActionResult)
            Dim result = Await _service.DeleteAsync(instructorId)
            Return View(result)
        End Function
    End Class
End Namespace