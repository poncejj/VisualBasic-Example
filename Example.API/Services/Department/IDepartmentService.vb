Imports System.Threading.Tasks

Namespace Services.Department
    Public Interface IDepartmentService
        Function GetAllDepartments() As Task(Of IEnumerable(Of DepartmentDto))
        Function GetById(id As Integer) As Task(Of DepartmentDto)
        Function InsertAsync(department As DepartmentDto) As Task(Of Boolean)
        Function UpdateAsync(department As DepartmentDto) As Task(Of Boolean)
        Function DeleteAsync(id As Integer) As Task(Of Boolean)
    End Interface
End Namespace