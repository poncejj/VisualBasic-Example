Imports System.Data.Entity
Imports System.Threading.Tasks

Namespace Services.Department
    Public Class DepartmentService
        Inherits BaseService(Of DepartmentModel)
        Implements IDepartmentService

        Public Async Function GetAllDepartments() As Task(Of IEnumerable(Of DepartmentDto)) Implements IDepartmentService.GetAllDepartments
            Dim departments As IEnumerable(Of DepartmentModel) = Await GetAll().AsNoTracking().ToListAsync()
            If departments Is Nothing OrElse departments.Count <= 0 Then
                Return Nothing
            End If

            Return departments.Map()
        End Function

        Public Async Function GetById(id As Integer) As Task(Of DepartmentDto) Implements IDepartmentService.GetById
            Dim department As DepartmentModel = Await GetByCondition(Function(c) c.DepartmentID.Equals(id)).
            Include(Function(c) c.Courses).AsNoTracking().
            FirstOrDefaultAsync()
            If department Is Nothing Then
                Return Nothing
            End If

            Return department.Map()
        End Function

        Public Async Function InsertAsync(department As DepartmentDto) As Task(Of Boolean) Implements IDepartmentService.InsertAsync
            Dim newDepartment As DepartmentModel = department.Map()

            Return Await Insert(newDepartment)
        End Function

        Public Async Function UpdateAsync(department As DepartmentDto) As Task(Of Boolean) Implements IDepartmentService.UpdateAsync
            Dim departmentModel As DepartmentModel = Await GetByCondition(Function(c) c.DepartmentID.Equals(department.DepartmentID)).
            Include(Function(c) c.Courses).
            FirstOrDefaultAsync()
            If department Is Nothing Then
                Return False
            End If

            departmentModel.Administrator = department.Administrator
            departmentModel.Budget = department.Budget
            departmentModel.Courses = department.Courses
            departmentModel.Name = department.Name
            departmentModel.StartDate = department.StartDate
            Return Await Update(departmentModel)
        End Function

        Public Async Function DeleteAsync(id As Integer) As Task(Of Boolean) Implements IDepartmentService.DeleteAsync
            Dim department As DepartmentModel = Await GetByCondition(Function(c) c.DepartmentID.Equals(id)).
            FirstOrDefaultAsync()
            If department Is Nothing Then
                Return False
            End If

            Return Await Delete(department)
        End Function
    End Class
End Namespace