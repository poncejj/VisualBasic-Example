Imports System.Threading.Tasks

Namespace Services.Instructor
    Public Interface IInstructorService
        Function GetAllInstructors() As Task(Of IEnumerable(Of InstructorDto))
        Function GetById(id As Integer) As Task(Of InstructorDto)
        Function InsertAsync(instructor As InstructorDto) As Task(Of Boolean)
        Function UpdateAsync(instructor As InstructorDto) As Task(Of Boolean)
        Function DeleteAsync(id As Integer) As Task(Of Boolean)
    End Interface
End Namespace