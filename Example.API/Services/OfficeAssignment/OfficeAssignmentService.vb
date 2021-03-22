Imports System.Data.Entity
Imports System.Threading.Tasks

Namespace Services.OfficeAssignment
    Public Class OfficeAssignmentService
        Inherits BaseService(Of OfficeAssignmentModel)
        Implements IOfficeAssignmentService

        Public Async Function GetAllOfficeAssignments() As Task(Of IEnumerable(Of OfficeAssignmentDto)) Implements IOfficeAssignmentService.GetAllOfficeAssignments
            Dim officeAssignments As IEnumerable(Of OfficeAssignmentModel) = Await GetAll().AsNoTracking().ToListAsync()
            If officeAssignments Is Nothing OrElse officeAssignments.Count <= 0 Then
                Return Nothing
            End If

            Return officeAssignments.Map()
        End Function

        Public Async Function GetById(id As Integer) As Task(Of OfficeAssignmentDto) Implements IOfficeAssignmentService.GetById
            Dim officeAssignment As OfficeAssignmentModel = Await GetByCondition(Function(c) c.InstructorID.Equals(id)).
            Include(Function(c) c.Instructor).AsNoTracking().
            FirstOrDefaultAsync()
            If officeAssignment Is Nothing Then
                Return Nothing
            End If

            Return officeAssignment.Map()
        End Function

        Public Async Function InsertAsync(officeAssignment As OfficeAssignmentDto) As Task(Of Boolean) Implements IOfficeAssignmentService.InsertAsync
            Dim newOfficeAssignment As OfficeAssignmentModel = officeAssignment.Map()

            Return Await Insert(newOfficeAssignment)
        End Function

        Public Async Function UpdateAsync(officeAssignment As OfficeAssignmentDto) As Task(Of Boolean) Implements IOfficeAssignmentService.UpdateAsync
            Dim officeAssignmentModel As OfficeAssignmentModel = Await GetByCondition(Function(c) c.InstructorID.Equals(officeAssignment.InstructorID)).
            Include(Function(c) c.Instructor).
            FirstOrDefaultAsync()
            If officeAssignment Is Nothing Then
                Return False
            End If

            officeAssignmentModel.Location = officeAssignment.Location
            officeAssignmentModel.Timestamp = officeAssignment.Timestamp
            Return Await Update(officeAssignmentModel)
        End Function

        Public Async Function DeleteAsync(id As Integer) As Task(Of Boolean) Implements IOfficeAssignmentService.DeleteAsync
            Dim officeAssignment As OfficeAssignmentModel = Await GetByCondition(Function(c) c.InstructorID.Equals(id)).
            FirstOrDefaultAsync()
            If officeAssignment Is Nothing Then
                Return False
            End If

            Return Await Delete(officeAssignment)
        End Function
    End Class
End Namespace