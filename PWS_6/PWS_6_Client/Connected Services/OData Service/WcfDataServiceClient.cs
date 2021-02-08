﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

// Original file name:
// Generation date: 16.11.2020 20:04:59
namespace WSCJAModel
{
    
    /// <summary>
    /// There are no comments for WSCJAEntities2 in the schema.
    /// </summary>
    public partial class WSCJAEntities2 : global::System.Data.Services.Client.DataServiceContext
    {
        /// <summary>
        /// Initialize a new WSCJAEntities2 object.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public WSCJAEntities2(global::System.Uri serviceRoot) : 
                base(serviceRoot, global::System.Data.Services.Common.DataServiceProtocolVersion.V3)
        {
            this.OnContextCreated();
            this.Format.LoadServiceModel = GeneratedEdmModel.GetInstance;
        }
        partial void OnContextCreated();
        /// <summary>
        /// There are no comments for Note in the schema.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public global::System.Data.Services.Client.DataServiceQuery<Note> Note
        {
            get
            {
                if ((this._Note == null))
                {
                    this._Note = base.CreateQuery<Note>("Note");
                }
                return this._Note;
            }
        }
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        private global::System.Data.Services.Client.DataServiceQuery<Note> _Note;
        /// <summary>
        /// There are no comments for Student in the schema.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public global::System.Data.Services.Client.DataServiceQuery<Student> Student
        {
            get
            {
                if ((this._Student == null))
                {
                    this._Student = base.CreateQuery<Student>("Student");
                }
                return this._Student;
            }
        }
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        private global::System.Data.Services.Client.DataServiceQuery<Student> _Student;
        /// <summary>
        /// There are no comments for Note in the schema.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public void AddToNote(Note note)
        {
            base.AddObject("Note", note);
        }
        /// <summary>
        /// There are no comments for Student in the schema.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public void AddToStudent(Student student)
        {
            base.AddObject("Student", student);
        }
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        private abstract class GeneratedEdmModel
        {
            [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
            private static global::Microsoft.Data.Edm.IEdmModel ParsedModel = LoadModelFromString();
            [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
            private const string ModelPart0 = "<edmx:Edmx Version=\"1.0\" xmlns:edmx=\"http://schemas.microsoft.com/ado/2007/06/edm" +
                "x\"><edmx:DataServices m:DataServiceVersion=\"1.0\" m:MaxDataServiceVersion=\"3.0\" x" +
                "mlns:m=\"http://schemas.microsoft.com/ado/2007/08/dataservices/metadata\"><Schema " +
                "Namespace=\"WSCJAModel\" xmlns=\"http://schemas.microsoft.com/ado/2009/11/edm\"><Ent" +
                "ityType Name=\"Note\"><Key><PropertyRef Name=\"Id\" /></Key><Property Name=\"Id\" Type" +
                "=\"Edm.Int32\" Nullable=\"false\" p6:StoreGeneratedPattern=\"Identity\" xmlns:p6=\"http" +
                "://schemas.microsoft.com/ado/2009/02/edm/annotation\" /><Property Name=\"Subj\" Typ" +
                "e=\"Edm.String\" MaxLength=\"Max\" FixedLength=\"false\" Unicode=\"true\" /><Property Na" +
                "me=\"Note1\" Type=\"Edm.Int32\" /><Property Name=\"StudentId\" Type=\"Edm.Int32\" Nullab" +
                "le=\"false\" /><NavigationProperty Name=\"Student\" Relationship=\"WSCJAModel.FK__Not" +
                "e__StudentId__1273C1CD\" ToRole=\"Student\" FromRole=\"Note\" /></EntityType><EntityT" +
                "ype Name=\"Student\"><Key><PropertyRef Name=\"Id\" /></Key><Property Name=\"Id\" Type=" +
                "\"Edm.Int32\" Nullable=\"false\" p6:StoreGeneratedPattern=\"Identity\" xmlns:p6=\"http:" +
                "//schemas.microsoft.com/ado/2009/02/edm/annotation\" /><Property Name=\"Name\" Type" +
                "=\"Edm.String\" MaxLength=\"Max\" FixedLength=\"false\" Unicode=\"true\" /><NavigationPr" +
                "operty Name=\"Note\" Relationship=\"WSCJAModel.FK__Note__StudentId__1273C1CD\" ToRol" +
                "e=\"Note\" FromRole=\"Student\" /></EntityType><Association Name=\"FK__Note__StudentI" +
                "d__1273C1CD\"><End Type=\"WSCJAModel.Student\" Role=\"Student\" Multiplicity=\"1\" /><E" +
                "nd Type=\"WSCJAModel.Note\" Role=\"Note\" Multiplicity=\"*\" /><ReferentialConstraint>" +
                "<Principal Role=\"Student\"><PropertyRef Name=\"Id\" /></Principal><Dependent Role=\"" +
                "Note\"><PropertyRef Name=\"StudentId\" /></Dependent></ReferentialConstraint></Asso" +
                "ciation></Schema><Schema Namespace=\"PWS_6\" xmlns=\"http://schemas.microsoft.com/a" +
                "do/2009/11/edm\"><EntityContainer Name=\"WSCJAEntities2\" m:IsDefaultEntityContaine" +
                "r=\"true\"><EntitySet Name=\"Note\" EntityType=\"WSCJAModel.Note\" /><EntitySet Name=\"" +
                "Student\" EntityType=\"WSCJAModel.Student\" /><AssociationSet Name=\"FK__Note__Stude" +
                "ntId__1273C1CD\" Association=\"WSCJAModel.FK__Note__StudentId__1273C1CD\"><End Role" +
                "=\"Note\" EntitySet=\"Note\" /><End Role=\"Student\" EntitySet=\"Student\" /></Associati" +
                "onSet></EntityContainer></Schema></edmx:DataServices></edmx:Edmx>";
            [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
            private static string GetConcatenatedEdmxString()
            {
                return string.Concat(ModelPart0);
            }
            [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
            public static global::Microsoft.Data.Edm.IEdmModel GetInstance()
            {
                return ParsedModel;
            }
            [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
            private static global::Microsoft.Data.Edm.IEdmModel LoadModelFromString()
            {
                string edmxToParse = GetConcatenatedEdmxString();
                global::System.Xml.XmlReader reader = CreateXmlReader(edmxToParse);
                try
                {
                    return global::Microsoft.Data.Edm.Csdl.EdmxReader.Parse(reader);
                }
                finally
                {
                    ((global::System.IDisposable)(reader)).Dispose();
                }
            }
            [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
            private static global::System.Xml.XmlReader CreateXmlReader(string edmxToParse)
            {
                return global::System.Xml.XmlReader.Create(new global::System.IO.StringReader(edmxToParse));
            }
        }
    }
    /// <summary>
    /// There are no comments for WSCJAModel.Note in the schema.
    /// </summary>
    /// <KeyProperties>
    /// Id
    /// </KeyProperties>
    [global::System.Data.Services.Common.DataServiceKeyAttribute("Id")]
    public partial class Note
    {
        /// <summary>
        /// Create a new Note object.
        /// </summary>
        /// <param name="ID">Initial value of Id.</param>
        /// <param name="studentId">Initial value of StudentId.</param>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public static Note CreateNote(int ID, int studentId)
        {
            Note note = new Note();
            note.Id = ID;
            note.StudentId = studentId;
            return note;
        }
        /// <summary>
        /// There are no comments for Property Id in the schema.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public int Id
        {
            get
            {
                return this._Id;
            }
            set
            {
                this.OnIdChanging(value);
                this._Id = value;
                this.OnIdChanged();
            }
        }
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        private int _Id;
        partial void OnIdChanging(int value);
        partial void OnIdChanged();
        /// <summary>
        /// There are no comments for Property Subj in the schema.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public string Subj
        {
            get
            {
                return this._Subj;
            }
            set
            {
                this.OnSubjChanging(value);
                this._Subj = value;
                this.OnSubjChanged();
            }
        }
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        private string _Subj;
        partial void OnSubjChanging(string value);
        partial void OnSubjChanged();
        /// <summary>
        /// There are no comments for Property Note1 in the schema.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public global::System.Nullable<int> Note1
        {
            get
            {
                return this._Note1;
            }
            set
            {
                this.OnNote1Changing(value);
                this._Note1 = value;
                this.OnNote1Changed();
            }
        }
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        private global::System.Nullable<int> _Note1;
        partial void OnNote1Changing(global::System.Nullable<int> value);
        partial void OnNote1Changed();
        /// <summary>
        /// There are no comments for Property StudentId in the schema.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public int StudentId
        {
            get
            {
                return this._StudentId;
            }
            set
            {
                this.OnStudentIdChanging(value);
                this._StudentId = value;
                this.OnStudentIdChanged();
            }
        }
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        private int _StudentId;
        partial void OnStudentIdChanging(int value);
        partial void OnStudentIdChanged();
        /// <summary>
        /// There are no comments for Student in the schema.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public Student Student
        {
            get
            {
                return this._Student;
            }
            set
            {
                this._Student = value;
            }
        }
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        private Student _Student;
    }
    /// <summary>
    /// There are no comments for WSCJAModel.Student in the schema.
    /// </summary>
    /// <KeyProperties>
    /// Id
    /// </KeyProperties>
    [global::System.Data.Services.Common.DataServiceKeyAttribute("Id")]
    public partial class Student
    {
        /// <summary>
        /// Create a new Student object.
        /// </summary>
        /// <param name="ID">Initial value of Id.</param>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public static Student CreateStudent(int ID)
        {
            Student student = new Student();
            student.Id = ID;
            return student;
        }
        /// <summary>
        /// There are no comments for Property Id in the schema.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public int Id
        {
            get
            {
                return this._Id;
            }
            set
            {
                this.OnIdChanging(value);
                this._Id = value;
                this.OnIdChanged();
            }
        }
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        private int _Id;
        partial void OnIdChanging(int value);
        partial void OnIdChanged();
        /// <summary>
        /// There are no comments for Property Name in the schema.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public string Name
        {
            get
            {
                return this._Name;
            }
            set
            {
                this.OnNameChanging(value);
                this._Name = value;
                this.OnNameChanged();
            }
        }
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        private string _Name;
        partial void OnNameChanging(string value);
        partial void OnNameChanged();
        /// <summary>
        /// There are no comments for Note in the schema.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public global::System.Collections.ObjectModel.Collection<Note> Note
        {
            get
            {
                return this._Note;
            }
            set
            {
                if ((value != null))
                {
                    this._Note = value;
                }
            }
        }
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        private global::System.Collections.ObjectModel.Collection<Note> _Note = new global::System.Collections.ObjectModel.Collection<Note>();
    }
}
