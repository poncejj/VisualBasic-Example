Imports System.Threading.Tasks

Namespace Services.OfficeAssignment
    Public Interface IOfficeAssignmentService
        Function GetAllOfficeAssignments() As Task(Of IEnumerable(Of OfficeAssignmentDto))
        Function GetById(id As Integer) As Task(Of OfficeAssignmentDto)
        Function InsertAsync(officeAssignment As OfficeAssignmentDto) As Task(Of Boolean)
        Function UpdateAsync(officeAssignment As OfficeAssignmentDto) As Task(Of Boolean)
        Function DeleteAsync(id As Integer) As Task(Of Boolean)
    End Interface
End Namespace