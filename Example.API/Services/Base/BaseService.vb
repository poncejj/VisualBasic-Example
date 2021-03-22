Imports System.Data.Entity
Imports System.Data.Entity.Infrastructure
Imports System.Linq.Expressions
Imports System.Threading.Tasks

Public Class BaseService(Of T As Class)
    Private _context As New SchoolContext

    Public Function GetAll() As DbSet(Of T)
        Return _context.Set(Of T)
    End Function

    Public Function GetByCondition(condition As Expression(Of Func(Of T, Boolean))) As IQueryable(Of T)
        Return _context.Set(Of T).Where(condition)
    End Function

    Public Async Function Insert(entity As T) As Task(Of Boolean)
        Try
            Dim entry As DbEntityEntry(Of T) = _context.Entry(entity)
            entry.State = EntityState.Added
            Dim result As Integer = Await _context.SaveChangesAsync()
            Return result > 0
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Async Function Update(entity As T) As Task(Of Boolean)
        Try
            Dim entry As DbEntityEntry(Of T) = _context.Entry(entity)
            entry.State = EntityState.Modified
            Dim result As Integer = Await _context.SaveChangesAsync()
            Return result > 0
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Async Function Delete(entity As T) As Task(Of Boolean)
        Try
            Dim entry As DbEntityEntry(Of T) = _context.Entry(entity)
            entry.State = EntityState.Deleted
            Dim result As Integer = Await _context.SaveChangesAsync()
            Return result > 0
        Catch ex As Exception
            Return False
        End Try
    End Function
End Class
