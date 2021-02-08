using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Lab_3.Models
{
    public class StudentContext: DbContext
    {
        public StudentContext() : base("ConnectionString") { }

        public DbSet<Student> Students { get; set; }

        public List<Student> GetList(int limit, int sort, int offset, int minid, int maxid, string like, string column, string globalike)
        {
            var students = this.Students.ToList();
            if (globalike != null)
            {
                if (sort == 1)
                {
                    students = this.Students.Where(s => (s.Id.ToString() + s.Name + s.Number.ToString()).Contains(globalike)).Where(s => s.Id >= minid).Where(s => s.Id <= maxid).OrderBy(s => s.Name).Take(limit + offset).Skip(offset).ToList();
                }
                else if (sort == 2)
                {
                    students = this.Students.Where(s => (s.Id.ToString() + s.Name + s.Number.ToString()).Contains(globalike)).Where(s => s.Id >= minid).Where(s => s.Id <= maxid).OrderByDescending(s => s.Name).Take(limit + offset).Skip(offset).ToList();
                }
                else
                {
                    students = this.Students.Where(s => (s.Id.ToString() + s.Name + s.Number.ToString()).Contains(globalike)).Where(s => s.Id >= minid).Where(s => s.Id <= maxid).OrderBy(s => s.Id).Take(limit + offset).Skip(offset).ToList();
                }
            }
            else if (like == null)
            {
                if (sort == 1)
                {
                    students = this.Students.Where(s => s.Id >= minid).Where(s => s.Id <= maxid).OrderBy(s => s.Name).Take(limit + offset).Skip(offset).ToList();
                }
                else if (sort == 2)
                {
                    students = this.Students.Where(s => s.Id >= minid).Where(s => s.Id <= maxid).OrderByDescending(s => s.Name).Take(limit + offset).Skip(offset).ToList();
                }
                else
                {
                    students = this.Students.Where(s => s.Id >= minid).Where(s => s.Id <= maxid).OrderBy(s => s.Id).Take(limit + offset).Skip(offset).ToList();
                }
            }
            else
            {
                if (sort == 1)
                {
                    students = this.Students.Where(s => s.Name.Contains(like)).Where(s => s.Id >= minid).Where(s => s.Id <= maxid).OrderBy(s => s.Name).Take(limit + offset).Skip(offset).ToList();
                }
                else if (sort == 2)
                {
                    students = this.Students.Where(s => s.Name.Contains(like)).Where(s => s.Id >= minid).Where(s => s.Id <= maxid).OrderByDescending(s => s.Name).Take(limit + offset).Skip(offset).ToList();
                }
                else
                {
                    students = this.Students.Where(s => s.Name.Contains(like)).Where(s => s.Id >= minid).Where(s => s.Id <= maxid).OrderBy(s => s.Id).Take(limit + offset).Skip(offset).ToList();
                }
            }
            return students;
        }

        public Student GetOne(int id)
        {
            var students = this.Students.ToList();
            int index = students.IndexOf(students.Find(x => x.Id == id));
            return students[index];
        }

        public Student Post(string name, int number)
        {
            var students = this.Students;
            int id = 0;
            foreach (Student stud in students)
            {
                if (stud.Id > id)
                {
                    id = stud.Id;
                }
            }
            Student student = new Student { Id = id + 1, Name = name, Number = number };
            this.Students.Add(student);
            this.SaveChanges();
            return student;
        }

        public Student Put(int id, string name, int number)
        {
            var students = this.Students.ToList();
            int index = students.IndexOf(students.Find(x => x.Id == id));
            Student student = students.Find(x => x.Id == id);

            students[index].Name = name == null ? student.Name : name;
            students[index].Number = number == 0 ? student.Number : number;
            this.SaveChanges();
            return students[index];
        }

        public Student Delete(int id)
        {
            var students = this.Students.ToList();
            Student removed = students.Find(x => x.Id == id);
            this.Students.Remove(removed);
            this.SaveChanges();
            return removed;
        }
    }
}