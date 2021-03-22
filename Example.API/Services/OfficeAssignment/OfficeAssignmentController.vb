Imports System.Threading.Tasks

Namespace Services.OfficeAssignment
    Public Class OfficeAssignmentController
        Inherits Controller
        Private _service As IOfficeAssignmentService

        Public Sub New(ByVal service As IOfficeAssignmentService)
            _service = service
        End Sub

        Public Function GetAll() As ActionResult
            Dim officeAssignments = _service.GetAllOfficeAssignments()
            Return View(officeAssignments)
        End Function

        Public Function GetById(ByVal officeAssignmentId As Integer) As ActionResult
            Dim officeAssignment = _service.GetById(officeAssignmentId)
            Return View(officeAssignment)
        End Function

        <HttpPost()>
        Public Async Function Insert(officeAssignment As OfficeAssignmentDto) As Task(Of ActionResult)
            Dim result = Await _service.InsertAsync(officeAssignment)
            Return View(result)
        End Function

        <HttpPut()>
        Public Async Function Update(officeAssignment As OfficeAssignmentDto) As Task(Of ActionResult)
            Dim result = Await _service.UpdateAsync(officeAssignment)
            Return View(result)
        End Function

        <HttpDelete()>
        Public Async Function Delete(officeAssignmentId As Integer) As Task(Of ActionResult)
            Dim result = Await _service.DeleteAsync(officeAssignmentId)
            Return View(result)
        End Function
    End Class
End Namespace