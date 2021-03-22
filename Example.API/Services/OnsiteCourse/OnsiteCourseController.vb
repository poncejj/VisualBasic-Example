Imports System.Threading.Tasks

Namespace Services.OnsiteCourse
    Public Class OnsiteCourseController
        Inherits Controller
        Private _service As IOnsiteCourseService

        Public Sub New(ByVal service As IOnsiteCourseService)
            _service = service
        End Sub

        Public Function GetAll() As ActionResult
            Dim onsiteCourses = _service.GetAllOnsiteCourses()
            Return View(onsiteCourses)
        End Function

        Public Function GetById(ByVal onsiteCourseId As Integer) As ActionResult
            Dim onsiteCourse = _service.GetById(onsiteCourseId)
            Return View(onsiteCourse)
        End Function

        <HttpPost()>
        Public Async Function Insert(onsiteCourse As OnsiteCourseDto) As Task(Of ActionResult)
            Dim result = Await _service.InsertAsync(onsiteCourse)
            Return View(result)
        End Function

        <HttpPut()>
        Public Async Function Update(onsiteCourse As OnsiteCourseDto) As Task(Of ActionResult)
            Dim result = Await _service.UpdateAsync(onsiteCourse)
            Return View(result)
        End Function

        <HttpDelete()>
        Public Async Function Delete(onsiteCourseId As Integer) As Task(Of ActionResult)
            Dim result = Await _service.DeleteAsync(onsiteCourseId)
            Return View(result)
        End Function
    End Class
End Namespace