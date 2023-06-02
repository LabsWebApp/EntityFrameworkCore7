using Microsoft.Data.SqlClient;
using System.Data;
using static ConnectionStrings.ConnectionStrings;

namespace BulkCrudModel;

public static class AdoMethods
{
    public static void Truncate(string tableName = "dbo.People")
    {
        using var connection = new SqlConnection(GetConnectionStrings(SqlExpress));
        connection.Open();
        var sql = $"TRUNCATE TABLE {tableName}";
        using var command = new SqlCommand(sql, connection);
        command.ExecuteNonQuery();
    }

    //BULK INSERT dbo.People
    public static void BulkInsertPeople(IEnumerable<Person> people, int batchSize = int.MaxValue)
    {
        using var connection = new SqlConnection(GetConnectionStrings(SqlExpress));
        connection.Open();

        using var bulkCopy = new SqlBulkCopy(connection, SqlBulkCopyOptions.TableLock, null)
        {
            DestinationTableName = "People"
        };

        // Сопоставление столбцов между источником и местом назначения
        bulkCopy.ColumnMappings.Add(nameof(Person.Id), nameof(Person.Id));
        bulkCopy.ColumnMappings.Add(nameof(Person.Name), nameof(Person.Name));
        bulkCopy.ColumnMappings.Add(nameof(Person.DeleteMe), nameof(Person.DeleteMe));
        bulkCopy.ColumnMappings.Add(nameof(Person.UpdateTime), nameof(Person.UpdateTime));

        // IEnumerable<Person> to a DataTable
        var dataTable = new DataTable();
        dataTable.Columns.Add(nameof(Person.Id), typeof(Guid));
        dataTable.Columns.Add(nameof(Person.Name), typeof(string));
        dataTable.Columns.Add(nameof(Person.DeleteMe), typeof(bool));
        dataTable.Columns.Add(nameof(Person.UpdateTime), typeof(DateTime));

        // Разбиваем коллекцию на части по batchSize элементов и записываем их в БД
        foreach (var batch in people.Batch(batchSize))
        {
            dataTable.Clear();
            foreach (var person in batch)
                dataTable.Rows.Add(person.Id, person.Name, person.DeleteMe, person.UpdateTime);
            bulkCopy.WriteToServer(dataTable);
        }
    }

    private static IEnumerable<IEnumerable<T>> Batch<T>(this IEnumerable<T> source, int size)
    {
        T[]? bucket = null;
        var count = 0;

        foreach (var item in source)
        {
            bucket ??= new T[size];

            bucket[count++] = item;

            if (count != size) continue;

            yield return bucket;

            bucket = null;
            count = 0;
        }

        // Возвращение остатка
        if (bucket == null || count <= 0) yield break;
        Array.Resize(ref bucket, count);
        yield return bucket;
    }
}