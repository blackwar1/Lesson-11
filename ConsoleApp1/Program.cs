using System;
using System.Data;

class Program
{
    static void Main()
    {
        DataTable students = new DataTable("Students");

        students.Columns.Add("Id", typeof(int));
        students.Columns.Add("Name", typeof(string));
        students.Columns.Add("Age", typeof(int));
        students.Columns.Add("GroupName", typeof(string));

        students.Rows.Add(1, "Гаврилов Гоша", 20, "ИС-101");
        students.Rows.Add(2, "Прислегин Егор", 22, "ИС-102");
        students.Rows.Add(3, "Булышева Анна", 19, "ИС-101");
        students.Rows.Add(4, "Нагаев Влад", 25, "ИС-103");
        students.Rows.Add(5, "Новикова Кристина", 21, "ИС-102");

        Console.WriteLine("Таблица студентов:");
        Console.WriteLine(new string('-', 50));

        foreach (DataColumn col in students.Columns)
            Console.Write($"{col.ColumnName,-15}");
        Console.WriteLine();
        Console.WriteLine(new string('-', 50));

        foreach (DataRow row in students.Rows)
        {
            foreach (var item in row.ItemArray)
                Console.Write($"{item,-15}");
            Console.WriteLine();
        }
        Console.WriteLine(new string('-', 50));

        DataRow oldestStudent = null;
        int maxAge = 0;

        foreach (DataRow row in students.Rows)
        {
            int age = Convert.ToInt32(row["Age"]);
            if (age > maxAge)
            {
                maxAge = age;
                oldestStudent = row;
            }
        }

        Console.WriteLine($"\nСамый старший студент: {oldestStudent["Name"]}, возраст: {oldestStudent["Age"]}, группа: {oldestStudent["GroupName"]}");
    }
}