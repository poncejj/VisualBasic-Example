Imports System.Threading.Tasks

Namespace Services.OnsiteCourse
    Public Interface IOnsiteCourseService
        Function GetAllOnsiteCourses() As Task(Of IEnumerable(Of OnsiteCourseDto))
        Function GetById(id As Integer) As Task(Of OnsiteCourseDto)
        Function InsertAsync(onsiteCourse As OnsiteCourseDto) As Task(Of Boolean)
        Function UpdateAsync(onsiteCourse As OnsiteCourseDto) As Task(Of Boolean)
        Function DeleteAsync(id As Integer) As Task(Of Boolean)
    End Interface
End Namespace