Imports System.Threading.Tasks

Namespace Services.OnlineCourse
    Public Interface IOnlineCourseService
        Function GetAllOnlineCourses() As Task(Of IEnumerable(Of OnlineCourseDto))
        Function GetById(id As Integer) As Task(Of OnlineCourseDto)
        Function InsertAsync(onlineCourse As OnlineCourseDto) As Task(Of Boolean)
        Function UpdateAsync(onlineCourse As OnlineCourseDto) As Task(Of Boolean)
        Function DeleteAsync(id As Integer) As Task(Of Boolean)
    End Interface
End Namespace