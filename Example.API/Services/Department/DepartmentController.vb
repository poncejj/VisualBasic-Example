Imports System.Threading.Tasks

Namespace Services.Department
    Public Class DepartmentController
        Inherits Controller
        Private _service As IDepartmentService

        Public Sub New(ByVal service As IDepartmentService)
            _service = service
        End Sub

        Public Function GetAll() As ActionResult
            Dim departments = _service.GetAllDepartments()
            Return View(departments)
        End Function

        Public Function GetById(ByVal departmentId As Integer) As ActionResult
            Dim department = _service.GetById(departmentId)
            Return View(department)
        End Function

        <HttpPost()>
        Public Async Function Insert(department As DepartmentDto) As Task(Of ActionResult)
            Dim result = Await _service.InsertAsync(department)
            Return View(result)
        End Function

        <HttpPut()>
        Public Async Function Update(department As DepartmentDto) As Task(Of ActionResult)
            Dim result = Await _service.UpdateAsync(department)
            Return View(result)
        End Function

        <HttpDelete()>
        Public Async Function Delete(departmentId As Integer) As Task(Of ActionResult)
            Dim result = Await _service.DeleteAsync(departmentId)
            Return View(result)
        End Function
    End Class
End Namespace