Imports System.Data.Entity
Imports System.Threading.Tasks
Imports Example.API.Services.OfficeAssignment

Namespace Services.Instructor
    Public Class InstructorService
        Inherits BaseService(Of InstructorModel)
        Implements IInstructorService

        Public Async Function GetAllInstructors() As Task(Of IEnumerable(Of InstructorDto)) Implements IInstructorService.GetAllInstructors
            Dim instructors As IEnumerable(Of InstructorModel) = Await GetAll().AsNoTracking().ToListAsync()
            If instructors Is Nothing OrElse instructors.Count <= 0 Then
                Return Nothing
            End If

            Return instructors.Map()
        End Function

        Public Async Function GetById(id As Integer) As Task(Of InstructorDto) Implements IInstructorService.GetById
            Dim instructor As InstructorModel = Await GetByCondition(Function(c) c.PersonID.Equals(id)).
            Include(Function(c) c.Courses).AsNoTracking().
            FirstOrDefaultAsync()
            If instructor Is Nothing Then
                Return Nothing
            End If

            Return instructor.Map()
        End Function

        Public Async Function InsertAsync(instructor As InstructorDto) As Task(Of Boolean) Implements IInstructorService.InsertAsync
            Dim newInstructor As InstructorModel = instructor.Map()

            Return Await Insert(newInstructor)
        End Function

        Public Async Function UpdateAsync(instructor As InstructorDto) As Task(Of Boolean) Implements IInstructorService.UpdateAsync
            Dim instructorModel As InstructorModel = Await GetByCondition(Function(c) c.PersonID.Equals(instructor.PersonID)).
            Include(Function(c) c.Courses).
            FirstOrDefaultAsync()
            If instructor Is Nothing Then
                Return False
            End If

            instructorModel.Courses = instructor.Courses
            instructorModel.FirstName = instructor.FirstName
            instructorModel.HireDate = instructor.HireDate
            instructorModel.LastName = instructor.LastName
            instructorModel.OfficeAssignment = instructor.OfficeAssignment.Map()
            Return Await Update(instructorModel)
        End Function

        Public Async Function DeleteAsync(id As Integer) As Task(Of Boolean) Implements IInstructorService.DeleteAsync
            Dim instructor As InstructorModel = Await GetByCondition(Function(c) c.PersonID.Equals(id)).
            FirstOrDefaultAsync()
            If instructor Is Nothing Then
                Return False
            End If

            Return Await Delete(instructor)
        End Function
    End Class
End Namespace